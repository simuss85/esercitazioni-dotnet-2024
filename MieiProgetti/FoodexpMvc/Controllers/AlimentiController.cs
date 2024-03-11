using FoodexpMvc.Models;
using FoodexpMvc.Views;
using Microsoft.EntityFrameworkCore;

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
            bool inverti;
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
                        int giorni = 1;
                        AlimentiView.VisualizzaAlimenti(GetAlimentiScaduti(giorni), $"Scaduti o in scadenza ({giorni} giorno/i)\n");
                        break;

                    case "4":
                        //visualizza in esaurimento
                        int quantita = 1;
                        AlimentiView.VisualizzaAlimenti(GetAlimentiEsaurimento(quantita), $"In esaurimento (quantità {quantita})\n");
                        break;

                    case "5":
                        //ordina per nome
                        inverti = false;
                        do
                        {
                            AlimentiView.VisualizzaAlimenti(GetAlimentiPerNome(), $"Ordine per nome\n");
                            Console.WriteLine("\n...vuoi invertire l'ordine della lista? (s/n)");
                            input = Console.ReadLine()!.ToLower();
                            if (input == "s")
                            {
                                inverti = true;
                                Console.Clear();

                                AlimentiView.VisualizzaAlimenti(GetAlimentiPerNome(inverti), $"Ordine per nome decrescente\n");
                            }
                            else if (input == "n")
                            {
                                inverti = true; //condizione di uscita dal while senza forzarlo
                            }
                            else
                            {
                                View.MessaggioSelezioneErrata();
                                Console.Clear();
                            }
                        }
                        while (!inverti);
                        break;

                    case "6":
                        //ordina per data di scadenza
                        inverti = false;
                        do
                        {
                            AlimentiView.VisualizzaAlimenti(GetAlimentiPerScadenza(), $"Ordine per data di scadenza\n");
                            Console.WriteLine("\n...vuoi invertire l'ordine della lista? (s/n)");
                            input = Console.ReadLine()!.ToLower();
                            if (input == "s")
                            {
                                inverti = true;
                                Console.Clear();

                                AlimentiView.VisualizzaAlimenti(GetAlimentiPerScadenza(inverti), $"Ordine per data di scadenza decrescente\n");
                            }
                            else if (input == "n")
                            {
                                break;
                            }
                            else
                            {
                                View.MessaggioSelezioneErrata(1000);
                                Console.Clear();
                            }
                        }
                        while (!inverti);
                        break;

                    case "7":
                        //ordina per data di inserimento
                        inverti = false;
                        do
                        {
                            AlimentiView.VisualizzaAlimenti(GetAlimentiPerInserimento(), $"Ordine per data di inserimento\n");
                            Console.WriteLine("\n...vuoi invertire l'ordine della lista? (s/n)");
                            input = Console.ReadLine()!.ToLower();
                            if (input == "s")
                            {
                                inverti = true;
                                Console.Clear();

                                AlimentiView.VisualizzaAlimenti(GetAlimentiPerInserimento(inverti), $"Ordine per data di inserimento decrescente\n");
                            }
                            else if (input == "n")
                            {
                                break;
                            }
                            else
                            {
                                View.MessaggioSelezioneErrata(1000);
                                Console.Clear();
                            }
                        }
                        while (!inverti);
                        break;

                    case "8":
                        //ordina per quantità
                        inverti = false;
                        do
                        {
                            AlimentiView.VisualizzaAlimenti(GetAlimentiPerQuantita(), $"Ordine per quantità\n");
                            Console.WriteLine("\n...vuoi invertire l'ordine della lista? (s/n)");
                            input = Console.ReadLine()!.ToLower();
                            if (input == "s")
                            {
                                inverti = true;
                                Console.Clear();

                                AlimentiView.VisualizzaAlimenti(GetAlimentiPerQuantita(inverti), $"Ordine per quantità decrescente\n");
                            }
                            else if (input == "n")
                            {
                                break;
                            }
                            else
                            {
                                View.MessaggioSelezioneErrata(1000);
                                Console.Clear();
                            }
                        }
                        while (!inverti);
                        break;

                    case "9":
                        //ordina per categoria
                        inverti = false;
                        do
                        {
                            AlimentiView.VisualizzaAlimenti(GetAlimentiPerCategoria(), $"Ordine per categoria alimenti\n");
                            Console.WriteLine("\n...vuoi invertire l'ordine della lista? (s/n)");
                            input = Console.ReadLine()!.ToLower();
                            if (input == "s")
                            {
                                inverti = true;
                                Console.Clear();

                                AlimentiView.VisualizzaAlimenti(GetAlimentiPerCategoria(inverti), $"Ordine per categoria decrescente\n");
                            }
                            else if (input == "n")
                            {
                                break;
                            }
                            else
                            {
                                View.MessaggioSelezioneErrata(1000);
                                Console.Clear();
                            }
                        }
                        while (!inverti);
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
                Console.Write("\n...premi un tasto");
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
                        trovato = true;
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
        /// </summary>
        /// <returns>La lista degli alimenti da stampare</returns>
        public static List<string> GetAlimenti()
        {
            List<string> lista = new();
            foreach (var a in _db.Alimenti)
            {
                lista.Add($"{a.Nome} {a.Quantita} {a.DataScadenza!.Value:d}"); //per la data ottengo il valore e formatto output con solo la data
            }
            return lista;
        }

        /// <summary>
        /// Filtra gli alimenti per data di scadenza (minore o uguale alla data odierna), oppure <br/>
        /// per alimenti che stanno per scadere (range = 0 default).
        /// </summary>
        /// <param name="range">Valore da sommare alla data attuale</param>
        /// <returns>La lista degli alimenti da stampare</returns>
        public static List<string> GetAlimentiScaduti(int range = 0)
        {
            List<string> lista = new();
            foreach (var a in _db.Alimenti)
            {
                if (range == 0)      //verifica scadenza esatta
                {
                    if (a.DataScadenza <= DateTime.Today)
                    {
                        lista.Add($"{a.Nome} {a.Quantita} {a.DataScadenza.Value:d}");
                    }
                }
                else                //verifica scadenza prossima di giorni
                {
                    if (a.DataScadenza <= DateTime.Today.AddDays(range))
                    {
                        lista.Add($"{a.Nome} {a.Quantita} {a.DataScadenza.Value:d}");
                    }
                }

            }
            return lista;
        }

        /// <summary>
        /// Filtra gli alimenti per quantità in esaurimento (range = 1 default).
        /// </summary>
        /// <param name="range">Valore di controllo per la quantità da considerare</param>
        /// <returns>La lista degli alimenti da stampare</returns>
        public static List<string> GetAlimentiEsaurimento(int range = 1)
        {
            List<string> lista = new();
            foreach (var a in _db.Alimenti)
            {
                if (a.Quantita <= range)
                {
                    lista.Add($"{a.Nome} {a.Quantita} {a.DataScadenza!.Value:d}");
                }
            }
            return lista;
        }

        /// <summary>
        /// Filtra gli alimenti per nome e li ordina in ordine crescente (default) <br/>
        /// oppre in ordine decrescente (valore true).
        /// </summary>
        /// <param name="inverti">Se impostato a <b>true</b> ordina la lista decrescente</param>
        /// <returns>La lista degli alimenti da stampare</returns>
        public static List<string> GetAlimentiPerNome(bool inverti = false)
        {
            List<string> lista = new();
            foreach (var a in _db.Alimenti)
            {
                lista.Add($"{a.Nome} {a.Quantita} {a.DataScadenza!.Value:d}");
            }
            //riordino la lista
            lista.Sort();

            if (inverti) //nel caso la volessi in ordine decrescente
            {
                lista.Reverse();    //inverto l'ordine degli elementi
            }
            return lista;
        }

        /// <summary>
        /// Filtra gli alimenti per data di scadenza in ordine decrecente (default) <br/>
        /// oppure in  ordine decrecente (valore true).
        /// </summary>
        /// <param name="inverti">Se impostato a <b>true</b> ordina la lista decrescente</param>
        /// <returns>La lista degli alimenti da stampare</returns>
        public static List<string> GetAlimentiPerScadenza(bool inverti = false)
        {
            List<string> lista = new();
            List<Alimento> alimenti = new();
            //utilizzo il metodo OrderBy per avere elementi gia ordinati
            if (inverti)
            {
                alimenti = _db.Alimenti.OrderByDescending(a => a.DataScadenza).ToList();
            }
            else
            {
                alimenti = _db.Alimenti.OrderBy(a => a.DataScadenza).ToList();
            }

            foreach (var a in alimenti)
            {
                lista.Add($"{a.Nome} {a.Quantita} {a.DataScadenza!.Value:d}");
            }

            return lista;
        }

        /// <summary>
        /// Filtra gli alimenti per data di inserimento in ordine decrecente (default) <br/>
        /// oppure in  ordine decrecente (valore true).
        /// </summary>
        /// <param name="inverti">Se impostato a <b>true</b> ordina la lista decrescente</param>
        /// <returns>La lista degli alimenti da stampare</returns>
        public static List<string> GetAlimentiPerInserimento(bool inverti = false)
        {
            List<string> lista = new();
            List<Alimento> alimenti = new();
            //utilizzo il metodo OrderBy per avere elementi gia ordinati
            if (inverti)
            {
                alimenti = _db.Alimenti.OrderByDescending(a => a.DataInserimento).ToList();
            }
            else
            {
                alimenti = _db.Alimenti.OrderBy(a => a.DataInserimento).ToList();
            }

            foreach (var a in alimenti)
            {
                lista.Add($"{a.Nome} {a.Quantita} {a.DataScadenza!.Value:d} {a.DataInserimento!.Value:d}");
            }

            return lista;
        }

        /// <summary>
        /// Filtra gli alimenti per quantita in ordine decrecente (default) <br/>
        /// oppure in  ordine decrecente (valore true).
        /// </summary>
        /// <param name="inverti">Se impostato a <b>true</b> ordina la lista decrescente</param>
        /// <returns>La lista degli alimenti da stampare</returns>
        public static List<string> GetAlimentiPerQuantita(bool inverti = false)
        {
            List<string> lista = new();
            List<Alimento> alimenti = new();
            //utilizzo il metodo OrderBy per avere elementi gia ordinati
            if (inverti)
            {
                alimenti = _db.Alimenti.OrderByDescending(a => a.Quantita).ToList();
            }
            else
            {
                alimenti = _db.Alimenti.OrderBy(a => a.Quantita).ToList();
            }

            foreach (var a in alimenti)
            {
                lista.Add($"{a.Nome} {a.Quantita} {a.DataScadenza!.Value:d}");
            }

            return lista;
        }

        /// <summary>
        /// Filtra gli alimenti per quantita in ordine decrecente (default) <br/>
        /// oppure in  ordine decrecente (valore true).
        /// </summary>
        /// <param name="inverti">Se impostato a <b>true</b> ordina la lista decrescente</param>
        /// <returns>La lista degli alimenti da stampare</returns>
        public static List<string> GetAlimentiPerCategoria(bool inverti = false)
        {
            List<string> lista = new();
            List<Alimento> alimenti = new();
            //utilizzo il metodo OrderBy per avere elementi gia ordinati
            if (inverti)
            {
                alimenti = _db.Alimenti.Include(c => c.Categoria).OrderByDescending(c => c.Categoria!.Nome).ToList();
            }
            else
            {
                alimenti = _db.Alimenti.Include(c => c.Categoria).OrderBy(c => c.Categoria!.Nome).ToList();
            }

            foreach (var a in alimenti)
            {
                lista.Add($"{a.Nome} {a.Quantita} {a.DataScadenza!.Value:d} {a.Categoria!.Nome}");
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