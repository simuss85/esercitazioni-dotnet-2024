using FoodexpMvc.Models;
using FoodexpMvc.Views;

namespace FoodexpMvc.Controllers
{
    public class AlimentiController : Controller
    {
        private static bool eseguito;

        #region Switch Selezione
        /// <summary>
        /// Gestisce la selezione del sotto-menu "Gestione utenti"
        /// </summary>
        public static void SelezioneMenu()
        {
            //frigorifero - filtra alimenti
            eseguito = false;
            while (!eseguito)
            {
                AlimentiView.MenuFiltraAlimenti();
                string input = Console.ReadLine()!.ToLower();

                Console.Clear();

                switch (input)
                {
                    case "1":
                        //visualizza tutti
                        AlimentiView.VisualizzaAlimenti(GetAlimenti(), "Tutti\n");
                        break;

                    case "2":
                        //visualizza scaduti
                        AlimentiView.VisualizzaAlimenti(GetAlimentiScaduti(), "Scaduti\n");
                        break;

                    case "3":
                        //visualizza in scadenza
                        break;

                    case "4":
                        //visualizza in esaurimento
                        break;

                    case "5":
                        //ordina per nome
                        break;

                    case "6":
                        //ordina per data di scadenza
                        break;

                    case "7":
                        //ordina per data di inserimento
                        break;

                    case "8":
                        //ordina per quantità
                        break;

                    case "9":
                        //ordina per categoria
                        break;

                    case "r":
                        //torna al menu principale
                        View.MessaggioTornaMenuPrincipale();
                        eseguito = true;
                        return;

                    default:
                        //torna al menu principale
                        View.MessaggioSelezioneErrata();
                        break;
                }
                Console.WriteLine("\n...premi un tasto");
                Console.ReadKey();
                Console.Clear();

            }
        }
        #endregion

        #region C - Aggiungi alimento
        /// <summary>
        /// Aggiunge al db.Alimenti gli oggetti di tipo Alimento presenti nella lista.
        /// </summary>
        /// <param name="alimentiDaInserire">La lista di oggetti di tipo Alimento da aggiungere</param>
        public static void AggiungiAlimenti(List<Alimento> alimentiDaInserire)
        {
            bool trovato;
            //memorizzo il db.Alimenti

            foreach (var a in alimentiDaInserire)   //per ogni elemento della lista da inserire
            {
                trovato = false;
                foreach (var adb in _db.Alimenti)  //ricerco nel db la corrispondenza
                {
                    if (a.Nome == adb.Nome)     //trovato il nome verifico la data
                    {
                        if (a.DataScadenza == adb.DataScadenza)
                        {
                            adb.Quantita += a.Quantita; //stessa data incremento quantità
                            _db.SaveChanges();

                        }
                        else
                        {   //stsso nome, data diversa
                            _db.Alimenti.Add(a);
                            _db.SaveChanges();
                        }
                        trovato = true;
                        break;

                    }
                }
                if (!trovato)
                {   //nome non presente, inseriso l'oggetto in db.Alimenti
                    _db.Alimenti.Add(a);
                    _db.SaveChanges();
                }
            }
        }
        #endregion

        #region R - Leggi tabella alimenti
        /// <summary>
        /// Seleziona tutti gli alimenti presenti in db.Alimenti
        /// <b>**da modificare**</b>
        /// </summary>
        /// <returns>La lista degli alimenti da stampare</returns>
        public static List<string> GetAlimenti()
        {
            int conta = 1;

            List<string> lista = new();
            foreach (var a in _db.Alimenti)
            {
                lista.Add($"{conta} - {a.Nome} {a.Quantita} {a.DataScadenza}");
                conta++;
            }
            return lista;
        }

        public static List<string> GetAlimentiScaduti()
        {
            int conta = 1;

            List<string> lista = new();
            foreach (var a in _db.Alimenti)
            {
                if (a.DataScadenza <= DateTime.Now)
                {
                    lista.Add($"{conta} - {a.Nome} {a.Quantita} {a.DataScadenza}");
                    conta++;
                }
            }
            return lista;
        }
        #endregion

        #region U - Modifica alimento
        public static void ModificaAlimento()
        {

        }
        #endregion

        #region D - Elimina alimento
        private static void EliminaAlimento()
        {

        }
        #endregion

        #region Metodi accessori
        #endregion
    }
}