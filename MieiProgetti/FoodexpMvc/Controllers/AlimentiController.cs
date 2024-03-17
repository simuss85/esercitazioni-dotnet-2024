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
        /// Gestisce la selezione del sotto-menu "Frigorifero - filtra alimenti"
        /// </summary>
        public static void SelezioneMenu()
        {
            string input;

            //frigorifero - filtra alimenti
            bool inverti;
            eseguito = false;
            while (!eseguito)
            {
                Console.Clear();

                AlimentiView.MenuFiltraAlimenti();
                var cursore = Console.GetCursorPosition();
                int idSelezione = ValidaInput.GetIntElenco(9, cursore.Left, cursore.Top, true);

                switch (idSelezione)
                {
                    case 1:
                        //visualizza tutti
                        Console.Clear();

                        AlimentiView.VisualizzaAlimenti(GetAlimenti(), "Tutti\n");
                        //gestione output uscita
                        Console.Write("\n...premi un tasto per tornare indietro ");
                        Console.ReadKey();
                        break;

                    case 2:
                        //visualizza scaduti
                        Console.Clear();

                        AlimentiView.VisualizzaAlimenti(GetAlimentiScaduti(), "Scaduti\n");
                        //gestione output uscita
                        Console.Write("\n...premi un tasto per tornare indietro ");
                        Console.ReadKey();
                        break;

                    case 3:
                        //visualizza in scadenza
                        Console.Clear();

                        int giorni = 1;
                        AlimentiView.VisualizzaAlimenti(GetAlimentiScaduti(giorni), $"Scaduti o in scadenza ({giorni} giorno/i)\n");
                        //gestione output uscita
                        Console.Write("\n...premi un tasto per tornare indietro ");
                        Console.ReadKey();
                        break;

                    case 4:
                        //visualizza in esaurimento
                        Console.Clear();

                        int quantita = 1;
                        AlimentiView.VisualizzaAlimenti(GetAlimentiEsaurimento(quantita), $"In esaurimento (quantità {quantita})\n");
                        //gestione output uscita
                        Console.Write("\n...premi un tasto per tornare indietro ");
                        Console.ReadKey();
                        break;

                    case 5:
                        //ordina per nome
                        do
                        {
                            Console.Clear();

                            AlimentiView.VisualizzaAlimenti(GetAlimentiPerNome(), $"Ordine per nome\n");
                            Console.Write("\n...vuoi invertire l'ordine della lista? (s/n) ");
                            cursore = Console.GetCursorPosition();
                            input = ValidaInput.GetSiNo(cursore.Left, cursore.Top);

                            if (input == "s")
                            {
                                inverti = true;
                                Console.Clear();

                                AlimentiView.VisualizzaAlimenti(GetAlimentiPerNome(inverti), $"Ordine per nome decrescente\n");
                                Console.Write("\n...premi per riordinare ");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else
                            {
                                inverti = false;
                            }
                        }
                        while (inverti);
                        break;

                    case 6:
                        //ordina per data di scadenza
                        do
                        {
                            Console.Clear();

                            AlimentiView.VisualizzaAlimenti(GetAlimentiPerScadenza(), $"Ordine per data di scadenza\n");
                            Console.Write("\n...vuoi invertire l'ordine della lista? (s/n) ");
                            cursore = Console.GetCursorPosition();
                            input = ValidaInput.GetSiNo(cursore.Left, cursore.Top);

                            if (input == "s")
                            {
                                inverti = true;
                                Console.Clear();

                                AlimentiView.VisualizzaAlimenti(GetAlimentiPerScadenza(inverti), $"Ordine per data di scadenza decrescente\n");
                                Console.Write("\n...premi per riordinare ");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else
                            {
                                inverti = false;
                            }
                        }
                        while (inverti);
                        break;

                    case 7:
                        //ordina per data di inserimento
                        do
                        {
                            Console.Clear();

                            AlimentiView.VisualizzaAlimenti(GetAlimentiPerInserimento(), $"Ordine per data di inserimento\n");
                            Console.Write("\n...vuoi invertire l'ordine della lista? (s/n) ");
                            cursore = Console.GetCursorPosition();
                            input = ValidaInput.GetSiNo(cursore.Left, cursore.Top);

                            if (input == "s")
                            {
                                inverti = true;
                                Console.Clear();

                                AlimentiView.VisualizzaAlimenti(GetAlimentiPerInserimento(inverti), $"Ordine per data di inserimento decrescente\n");
                                Console.Write("\n...premi per riordinare ");
                                Console.ReadKey();
                            }
                            else
                            {
                                inverti = false;
                            }
                        }
                        while (inverti);
                        break;

                    case 8:
                        //ordina per quantità
                        do
                        {
                            Console.Clear();

                            AlimentiView.VisualizzaAlimenti(GetAlimentiPerQuantita(), $"Ordine per quantità\n");
                            Console.Write("\n...vuoi invertire l'ordine della lista? (s/n) ");
                            cursore = Console.GetCursorPosition();
                            input = ValidaInput.GetSiNo(cursore.Left, cursore.Top);

                            if (input == "s")
                            {
                                inverti = true;
                                Console.Clear();

                                AlimentiView.VisualizzaAlimenti(GetAlimentiPerQuantita(inverti), $"Ordine per quantità decrescente\n");
                                Console.Write("\n...premi per riordinare ");
                                Console.ReadKey();
                            }
                            else
                            {
                                inverti = false;
                            }
                        }
                        while (inverti);
                        break;

                    case 9:
                        //ordina per categoria
                        do
                        {
                            Console.Clear();

                            AlimentiView.VisualizzaAlimenti(GetAlimentiPerCategoria(), $"Ordine per categoria alimenti\n");
                            Console.Write("\n...vuoi invertire l'ordine della lista? (s/n) ");
                            cursore = Console.GetCursorPosition();
                            input = ValidaInput.GetSiNo(cursore.Left, cursore.Top);

                            if (input == "s")
                            {
                                inverti = true;
                                Console.Clear();

                                AlimentiView.VisualizzaAlimenti(GetAlimentiPerCategoria(inverti), $"Ordine per categoria decrescente\n");
                                Console.Write("\n...premi per riordinare ");
                                Console.ReadKey();
                            }
                            else
                            {
                                inverti = false;
                            }
                        }
                        while (inverti);
                        break;

                    case -1:
                        //torna al menu principale
                        View.MessaggioTornaMenuPrincipale();
                        eseguito = true;
                        return;

                    default:
                        //torna al menu principale
                        View.MessaggioSelezioneErrata();
                        break;
                }
                //torna al menu principale
                View.MessaggioTornaMenuPrincipale(0);
            }
        }

        /// <summary>
        /// Gestisce la selezione del sotto-menu "Gestione alimenti"
        /// </summary>
        public static void SelezioneSottoMenu()
        {
            //gestione alimenti
            eseguito = false;
            while (!eseguito)
            {
                Console.Clear();

                AlimentiView.MenuGestioneAlimenti();
                var cursore = Console.GetCursorPosition();
                int idSelezione = ValidaInput.GetIntElenco(3, cursore.Left, cursore.Top, true);

                switch (idSelezione)
                {
                    case 1:
                        //inserisci alimento
                        Console.Clear();

                        AggiungiAlimento();
                        break;

                    case 2:
                        //modifica alimento
                        Console.Clear();

                        ModificaAlimento();
                        break;

                    case 3:
                        //elimina alimento
                        Console.Clear();

                        EliminaAlimento();
                        eseguito = false;
                        break;

                    case -1:
                        //torna al menu principale
                        View.MessaggioTornaMenuPrincipale();
                        eseguito = true;
                        return;

                    default:
                        //torna al menu principale
                        View.MessaggioSelezioneErrata();
                        break;
                }
            }
        }
        #endregion

        #region C - Aggiungi alimento
        /// <summary>
        /// Aggiunge un oggetto di tipo Alimento al db.Alimenti.
        /// </summary>
        public static void AggiungiAlimento()
        {
            eseguito = false;
            while (!eseguito)
            {
                Console.Clear();

                //nome
                Console.Write("Inserisci nome: ");
                var cursore = Console.GetCursorPosition();
                string nome = ValidaInput.GetString(cursore.Left, cursore.Top);

                //quantita
                Console.Write("Inserisci quantita: ");
                cursore = Console.GetCursorPosition();
                int quantita = ValidaInput.GetQuantita(cursore.Left, cursore.Top);

                //data
                Console.Write("Inserisci Data\n(gg/mm/aaaa): ");
                cursore = Console.GetCursorPosition();
                DateTime dataScadenza = ValidaInput.GetData(cursore.Left, cursore.Top);

                //categoria
                Console.Clear();
                //stampo elenco per l'utente
                CategorieView.VisualizzaCategorie(CategorieController.GetCategorie());
                int totaleCategorie = _db.Categorie.Count();
                Console.Write("\nSeleziona categoria: ");
                cursore = Console.GetCursorPosition();
                int idCategoria = ValidaInput.GetIntElenco(totaleCategorie, cursore.Left, cursore.Top);

                //info
                Console.Write("\nVuoi inserire un'info? (s/n)");
                cursore = Console.GetCursorPosition();
                string input = ValidaInput.GetSiNo(cursore.Left, cursore.Top);
                string info = "";
                if (input == "s")
                {
                    Console.Clear();

                    Console.Write("Info: ");
                    cursore = Console.GetCursorPosition();
                    info = ValidaInput.GetString(cursore.Left, cursore.Top);
                }

                Console.Clear();

                Console.WriteLine("Riepilogo inserimento\n");
                Console.WriteLine($"Nome: {nome}\nQuantità: {quantita}\nData di scadenza: {dataScadenza.ToString("d")}\nCategoria: {_db.Categorie.FirstOrDefault(c => c.Id == idCategoria)!.Nome}\nInfo: {info}");

                //creo nuovo oggetto Alimento
                Alimento a = new Alimento();

                //assegno i valori per ogni attributo
                a.Nome = nome;
                a.Quantita = quantita;
                a.DataScadenza = dataScadenza;
                a.DataInserimento = DateTime.Today;
                a.CategoriaId = idCategoria;
                a.Info = info;

                //conferma
                Console.WriteLine("\nConfermi inserimento? (s/n)");
                cursore = Console.GetCursorPosition();
                input = ValidaInput.GetSiNo(cursore.Left, cursore.Top);

                if (input == "s")   //confermo inserimento
                {
                    //inserisco nel db e salvo
                    _db.Alimenti.Add(a);
                    _db.SaveChanges();
                    Console.WriteLine("Alimento aggiunto");
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
                else            //non voglio inserire oppure voglio modificare
                {
                    Console.WriteLine("Vuoi modificare qualcosa? (s/n)");
                    cursore = Console.GetCursorPosition();
                    input = ValidaInput.GetSiNo(cursore.Left, cursore.Top);

                    if (input == "s")   //voglio modificare qualcosa
                    {
                        Console.Clear();

                        Console.WriteLine("Riepilogo inserimento\n");
                        Console.WriteLine($"1 - Nome: {nome}\n2 - Quantità: {quantita}\n3 - Data di scadenza: {dataScadenza.ToString("d")}\n4 - Categoria: {_db.Categorie.FirstOrDefault(c => c.Id == idCategoria)!.Nome}\n5 - Info: {info}\nr - Tutto corretto");
                        Console.Write("\nSeleziona l'elemento da modificare: ");
                        cursore = Console.GetCursorPosition();
                        int idSelezione = ValidaInput.GetIntElenco(5, cursore.Left, cursore.Top, true);

                        switch (idSelezione)
                        {
                            case 1:
                                //nome
                                Console.Write("Inserisci nome: ");
                                cursore = Console.GetCursorPosition();
                                nome = ValidaInput.GetString(cursore.Left, cursore.Top);
                                break;

                            case 2:
                                //quantita
                                Console.Write("Inserisci quantita: ");
                                cursore = Console.GetCursorPosition();
                                quantita = ValidaInput.GetQuantita(cursore.Left, cursore.Top);
                                break;

                            case 3:
                                //data
                                Console.Write("Inserisci Data\n(gg/mm/aaaa): ");
                                cursore = Console.GetCursorPosition();
                                dataScadenza = ValidaInput.GetData(cursore.Left, cursore.Top);
                                break;

                            case 4:
                                //categoria
                                Console.Clear();
                                //stampo elenco per l'utente
                                CategorieView.VisualizzaCategorie(CategorieController.GetCategorie());
                                totaleCategorie = _db.Categorie.Count();
                                Console.Write("\nSeleziona categoria: ");
                                cursore = Console.GetCursorPosition();
                                idCategoria = ValidaInput.GetIntElenco(totaleCategorie, cursore.Left, cursore.Top);
                                break;

                            case 5:
                                //info
                                Console.Write("\nVuoi inserire un'info? (s/n)");
                                cursore = Console.GetCursorPosition();
                                input = ValidaInput.GetSiNo(cursore.Left, cursore.Top);
                                info = "";
                                if (input == "s")
                                {
                                    Console.Clear();

                                    Console.Write("Info: ");
                                    cursore = Console.GetCursorPosition();
                                    info = ValidaInput.GetString(cursore.Left, cursore.Top);
                                    Console.Clear();
                                }
                                break;

                            case -1:
                                //tutto corretto non fa niente
                                break;

                            default:
                                Console.WriteLine("Selezione errata");
                                break;
                        }

                        Console.Clear();
                        Console.WriteLine("Riepilogo inserimento\n");
                        Console.WriteLine($"Nome: {nome}\nQuantità: {quantita}\nData di scadenza: {dataScadenza.ToString("d")}\nCategoria: {_db.Categorie.FirstOrDefault(c => c.Id == idCategoria)!.Nome}\nInfo: {info}");
                    }
                    else
                    {
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
        /// <summary>
        /// Permette di modificare un record da db.Alimenti selezionando da un elenco numerato.
        /// </summary>
        public static void ModificaAlimento()
        {
            eseguito = false;
            while (!eseguito)   //inizio la procedura di modifica
            {
                Console.Clear();

                AlimentiView.VisualizzaAlimenti(GetAlimenti(), "Modifica alimento");
                var alimenti = _db.Alimenti.ToList();   //per la corretta corrispondenza tra elenco e id
                int totaleAlimenti = alimenti.Count;
                Console.WriteLine($"r - Torna al menu precedente");  //inserisco opzione di uscita dinamica
                Console.WriteLine("\nCosa vuoi modificare? ");
                var cursore = Console.GetCursorPosition();
                int id = ValidaInput.GetIntElenco(totaleAlimenti, cursore.Left, cursore.Top, true);

                if (id == -1)   //premuto r - torna al menu precedente
                {
                    eseguito = true;
                    View.MessaggioTornaMenuPrecedente(800);
                }
                else    //ho selezionato un alimento dalla lista 
                {
                    eseguito = false;
                    id--;       //index parte da 0

                    //carico alimento da modificare
                    var a = alimenti[id];

                    //preparo le variabili di appoggio per l'inserimento dati dell'utente
                    string? nome = a!.Nome;
                    int quantita = a.Quantita;
                    DateTime dataScadenza = a.DataScadenza!.Value;
                    int idCategoria = a.CategoriaId;
                    string? info = a.Info;
                    string input;

                    Console.Clear();

                    Console.WriteLine("Riepilogo alimento\n");
                    Console.WriteLine($"1 - Nome: {nome}\n2 - Quantità: {quantita}\n3 - Data di scadenza: {dataScadenza.ToString("d")}\n4 - Categoria: {_db.Categorie.FirstOrDefault(c => c.Id == idCategoria)!.Nome}\n5 - Info: {info}\nr - Tutto corretto");
                    //richiesta di modifica
                    Console.Write("\nSeleziona l'elemento da modificare: ");
                    cursore = Console.GetCursorPosition();
                    int idSelezione = ValidaInput.GetIntElenco(5, cursore.Left, cursore.Top, true);

                    switch (idSelezione)
                    {
                        case 1:
                            //nome
                            Console.Write("Inserisci nome: ");
                            cursore = Console.GetCursorPosition();
                            nome = ValidaInput.GetString(cursore.Left, cursore.Top);
                            break;

                        case 2:
                            //quantita
                            Console.Write("Inserisci quantita: ");
                            cursore = Console.GetCursorPosition();
                            quantita = ValidaInput.GetQuantita(cursore.Left, cursore.Top);
                            break;

                        case 3:
                            //data
                            Console.Write("Inserisci Data\n(gg/mm/aaaa): ");
                            cursore = Console.GetCursorPosition();
                            dataScadenza = ValidaInput.GetData(cursore.Left, cursore.Top);
                            break;

                        case 4:
                            //categoria
                            Console.Clear();
                            //stampo elenco per l'utente
                            CategorieView.VisualizzaCategorie(CategorieController.GetCategorie());
                            int totaleCategorie = _db.Categorie.Count();
                            Console.Write("\nSeleziona categoria: ");
                            cursore = Console.GetCursorPosition();
                            idCategoria = ValidaInput.GetIntElenco(totaleCategorie, cursore.Left, cursore.Top);
                            break;

                        case 5:
                            //info
                            Console.Write("\nVuoi inserire un'info? (s/n)");
                            cursore = Console.GetCursorPosition();
                            input = ValidaInput.GetSiNo(cursore.Left, cursore.Top);
                            if (input == "s")
                            {
                                Console.Clear();

                                Console.Write("Info: ");
                                cursore = Console.GetCursorPosition();
                                info = ValidaInput.GetString(cursore.Left, cursore.Top);
                                Console.Clear();
                            }
                            break;

                        case -1:
                            //tutto corretto non fa niente
                            eseguito = true;
                            View.MessaggioTornaMenuPrecedente();
                            Console.ReadKey();
                            return;

                        default:
                            Console.WriteLine("Selezione errata");
                            break;
                    }

                    Console.Clear();
                    Console.WriteLine("Riepilogo inserimento\n");
                    Console.WriteLine($"Nome: {nome}\nQuantità: {quantita}\nData di scadenza: {dataScadenza.ToString("d")}\nCategoria: {_db.Categorie.FirstOrDefault(c => c.Id == idCategoria)!.Nome}\nInfo: {info}");

                    //conferma iserimento
                    Console.WriteLine("\nConfermi inserimento? (s/n)");
                    cursore = Console.GetCursorPosition();
                    input = ValidaInput.GetSiNo(cursore.Left, cursore.Top);

                    if (input == "s")
                    {
                        //assegno i valori per ogni attributo
                        a.Nome = nome;
                        a.Quantita = quantita;
                        a.DataScadenza = dataScadenza;
                        a.DataInserimento = DateTime.Today;
                        a.CategoriaId = idCategoria;
                        a.Info = info;
                        _db.SaveChanges();
                    }
                }
            }

        }
        #endregion

        #region D - Elimina alimento

        /// <summary>
        /// Permette di eliminare un record di db.Alimento scegliendo da un elenco numerato fino a quando l'utente seleziona <br/>
        /// il carattere 0.
        /// </summary>
        private static void EliminaAlimento()
        {
            eseguito = false;
            while (!eseguito)
            {
                Console.Clear();

                AlimentiView.VisualizzaAlimenti(GetAlimenti(), "Seleziona alimento da eliminare\n");
                var alimenti = GetListTipoAlimento();   //estrae la lista Alimenti dal db.Alimenti
                int totaleAlimenti = alimenti.Count;
                Console.WriteLine($"r - Torna al menu precedente");  //inserisco opzione di uscita dinamica
                Console.WriteLine("\nCosa vuoi eliminare? ");
                var cursore = Console.GetCursorPosition();
                int id = ValidaInput.GetIntElenco(totaleAlimenti, cursore.Left, cursore.Top, true);

                if (id == -1)   //premuto r - torna al menu precedente
                {
                    eseguito = true;
                    View.MessaggioTornaMenuPrecedente(800);
                }
                else    //ho selezionato un alimento dalla lista 
                {
                    eseguito = false;
                    id--;       //index parte da 0

                    Console.WriteLine($"Vuoi eliminare {alimenti[id].Nome}? (s/n)");
                    cursore = Console.GetCursorPosition();
                    string input = ValidaInput.GetSiNo(cursore.Left, cursore.Top);

                    if (input == "s")
                    {
                        //seleziono l'alimento in posizione [id] dalla lista di tipo Alimento
                        //seleziono poi il suo id che passo al metodo che elimina l'oggetto dal db.Alimento
                        EliminaAlimentoPerId(alimenti[id].Id);
                        Console.WriteLine("Alimento cancellato");
                    }
                }
            }
        }

        #endregion

        #region Metodi accessori
        /// <summary>
        /// Estrate dalla tabella db.Alimenti gli oggetti di tipo Alimento e li mette in una lista.
        /// </summary>
        /// <returns>La lista di oggetti di tipo Alimento</returns>
        private static List<Alimento> GetListTipoAlimento()
        {
            var alimenti = _db.Alimenti.ToList();
            return alimenti;
        }

        /// <summary>
        /// Metodo accessorio che elimina un record da db.Alimenti tramite il suo Id
        /// </summary>
        /// <param name="id">L'id del record da eliminare</param>
        private static void EliminaAlimentoPerId(int id)
        {
            foreach (var a in _db.Alimenti)
            {
                if (a.Id == id)
                {
                    _db.Alimenti.Remove(a);
                    _db.SaveChanges();
                }
            }
        }
        #endregion
    }
}