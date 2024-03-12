using FoodexpMvc.Models;
using FoodexpMvc.Views;
using Microsoft.EntityFrameworkCore;

namespace FoodexpMvc.Controllers
{
    public class ListaSpesaController : Controller
    {
        private static bool eseguito;

        #region Switch Selezione
        public static void SelezioneMenu()
        {
            //gestione lista della spesa
            eseguito = false;
            while (!eseguito)
            {
                ListaSpesaView.MenuListaSpesa();
                string input = Console.ReadLine()!.ToLower();

                Console.Clear();

                switch (input)
                {
                    case "1":
                        //viualizza lista
                        ListaSpesaView.VisualizzaLista(GetLista());
                        Console.Write("\n...premi un tasto ");
                        Console.ReadKey();
                        break;

                    case "2":
                        //inserisci alimento
                        AggiungiInListaSpesa();
                        break;

                    case "3":
                        //modifica alimento
                        ModificaListaSpesa();
                        break;

                    case "4":
                        //elimina alimento
                        EliminaDaListaSpesa();
                        break;

                    case "r":
                        //torna al menu principale
                        View.MessaggioTornaMenuPrincipale();
                        eseguito = true;
                        break;

                    default:
                        //torna al menu principale
                        View.MessaggioSelezioneErrata();
                        break;
                }
            }
        }
        #endregion

        #region C - Aggiungi alimento lista
        public static void AggiungiInListaSpesa()
        {

        }

        /// <summary>
        /// Aggiunge al db.ListaSpesa gli oggetti di tipo ListaSpesa presenti nella lista.
        /// </summary>
        /// <param name="listaSpesaDaAggiungere">La lista di oggetti di tipo ListaSpesa da aggiungere</param>
        public static void AggiungiListaSpesa(List<ListaSpesa> listaSpesaDaAggiungere)
        {
            foreach (var elemento in listaSpesaDaAggiungere)   //per ogni elemento della lista da inserire
            {
                //verifico che non sia gia nella lista
                var ldb = _db.ListaSpesa.FirstOrDefault(l => l.Alimento == elemento.Alimento);

                if (ldb != null)
                {
                    //elemento gia presente non fa niente
                }
                else
                {
                    _db.ListaSpesa.Add(elemento);
                    _db.SaveChanges();
                }
            }
        }
        #endregion

        #region R - Leggi tabella ListaSpesa
        public static List<string> GetLista()
        {
            List<string> lista = new();

            //scansiono db.ListaSpesa
            var ldb = _db.ListaSpesa.Include(c => c.Categoria).Include(u => u.Utente);

            foreach (var l in ldb)
            {
                lista.Add($"{l.Alimento} - {l.Quantita} - {l.Categoria!.Nome} - {l.Utente!.Nome}");
            }
            return lista;
        }
        #endregion

        #region U - Modifica alimento lista
        public static void ModificaListaSpesa()
        {

        }
        #endregion

        #region D- Elimina alimento lista
        private static void EliminaDaListaSpesa()
        {

        }
        #endregion

        #region Metodi accessori
        //eventuali metodi accessori
        #endregion
    }
}