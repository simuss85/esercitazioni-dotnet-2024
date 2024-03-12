using FoodexpMvc.Models;
using FoodexpMvc.Views;
using Microsoft.EntityFrameworkCore;

namespace FoodexpMvc.Controllers
{
    public class ListaSpesaController : Controller
    {
        private static bool eseguito;

        #region Switch Selezione
        /// <summary>
        /// Gestisce la selezione del sotto-menu "Gestione lista della spesa"
        /// </summary>
        public static void SelezioneMenu()
        {
            //gestione lista della spesa
            eseguito = false;
            while (!eseguito)
            {
                Console.Clear();

                ListaSpesaView.MenuListaSpesa();
                string input = Console.ReadLine()!.ToLower();

                switch (input)
                {
                    case "1":
                        //viualizza lista
                        Console.Clear();

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
        /// <summary>
        /// Aggiunge un oggetto di tipo ListaSpesa al db.ListaSpesa
        /// </summary>
        public static void AggiungiInListaSpesa()
        {
            string input;

            eseguito = false;
            while (!eseguito)
            {
                Console.Clear();

                //nome
                Console.Write("Inserisci alimento: ");
                var cursore = Console.GetCursorPosition();
                string alimento = ValidaInput.GetString(cursore.Left, cursore.Top);

                //quantita
                Console.Write("Inserisci quantita: ");
                cursore = Console.GetCursorPosition();
                int quantita = ValidaInput.GetQuantita(cursore.Left, cursore.Top);

                //verifica se gia presente
                var r = _db.ListaSpesa.FirstOrDefault(l => l.Alimento == alimento);

                if (r != null)  //gia presente chiedo cosa fare
                {
                    Console.WriteLine("Alimento gia presente nella lista\n");
                    Console.WriteLine($"{r.Alimento} - {r.Quantita} - {_db.Categorie.First(c => c.Id == r.CategoriaId).Nome} - {_db.Utenti.First(u => u.Id == r.UtenteId).Nome}");

                    Console.Write("\nVuoi modificare la quantità? (s/n) ");
                    cursore = Console.GetCursorPosition();
                    input = ValidaInput.GetSiNo(cursore.Left, cursore.Top);

                    if (input == "s")   //modifico la quantita
                    {
                        //quantita
                        Console.Write("Inserisci quantita: ");
                        cursore = Console.GetCursorPosition();
                        quantita = ValidaInput.GetQuantita(cursore.Left, cursore.Top);

                        r.Quantita = quantita;
                        _db.SaveChanges();

                        //richiesta altro inserimento
                        Console.Write("\nVuoi aggiungere altro? (s/n)");
                        cursore = Console.GetCursorPosition();
                        input = ValidaInput.GetSiNo(cursore.Left, cursore.Top);
                        if (input == "n")
                        {
                            eseguito = true;
                        }
                    }

                }
                else    //alimento non presente quindi ne creo uno nuovo
                {
                    //categoria
                    Console.Clear();
                    //stampo elenco per l'utente
                    CategorieView.VisualizzaCategorie(CategorieController.GetCategorie());
                    int totaleCategorie = _db.Categorie.Count();
                    Console.Write("\nSeleziona categoria: ");
                    cursore = Console.GetCursorPosition();
                    int idCategoria = ValidaInput.GetIntElenco(totaleCategorie, cursore.Left, cursore.Top);

                    Console.Clear();

                    Console.WriteLine("Riepilogo inserimento\n");
                    Console.WriteLine($"Alimento: {alimento}\nQuantità: {quantita}\nCategoria: {_db.Categorie.FirstOrDefault(c => c.Id == idCategoria)!.Nome}\n");

                    //creo nuovo oggetto Alimento
                    ListaSpesa l = new ListaSpesa();

                    //assegno i valori per ogni attributo
                    l.Alimento = alimento;
                    l.Quantita = quantita;
                    l.CategoriaId = idCategoria;
                    l.UtenteId = UtenteAttuale!.Id;

                    //conferma
                    Console.WriteLine("\nConfermi inserimento? (s/n)");
                    cursore = Console.GetCursorPosition();
                    input = ValidaInput.GetSiNo(cursore.Left, cursore.Top);

                    if (input == "s")   //confermo inserimento
                    {
                        //inserisco nel db e salvo
                        _db.ListaSpesa.Add(l);
                        _db.SaveChanges();
                        Console.WriteLine("Alimento aggiunto alla lista");
                        Thread.Sleep(800);

                        //richiesta altro inserimento
                        Console.Write("\nVuoi aggiungere altro? (s/n)");
                        cursore = Console.GetCursorPosition();
                        input = ValidaInput.GetSiNo(cursore.Left, cursore.Top);
                        if (input == "n")
                        {
                            eseguito = true;
                        }
                    }
                }
            }
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