using FoodexpMvc.Models;
using FoodexpMvc.Views;

namespace FoodexpMvc.Controllers
{
    public class UtentiController : Controller
    {
        //cotruttore
        public UtentiController(Utente utenteAttuale)
        {
            UtenteAttuale = utenteAttuale;
        }

        #region Switch Selezione
        /// <summary>
        /// Gestisce la selezione del sotto-menu "Gestione utenti"
        /// </summary>
        public static int SelezioneMenu()
        {
            int idUscita = 0; //in caso di eliminazione utente viene settato a -1
            //gestione utenti
            bool eseguito = false;
            while (!eseguito)
            {
                Console.Clear();

                UtentiView.MenuGestioneUtenti();
                string input = Console.ReadLine()!.ToLower();

                Console.Clear();

                switch (input)
                {
                    case "1":
                        //visualizza utenti
                        UtentiView.VisualizzaUtenti(GetUtenti());
                        Console.WriteLine("\n...premi un tasto");
                        Console.ReadKey();
                        break;

                    case "2":
                        //modifica nome e/o password
                        ModificaUtente();
                        break;

                    case "3":
                        //elimina account
                        EliminaUtente();
                        eseguito = true;
                        idUscita = -1;
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
            return idUscita;
        }
        #endregion

        #region C - Registra Utente
        /// <summary>
        /// Gestisce l'inserimento di un nuovo utente nel database. <br/>
        /// <b> Versione di base <b>
        /// </summary>
        public static void RegistraUtente()
        {
            Console.WriteLine("Inserisci il tuo nome: ");
            string nome = Console.ReadLine()!;
            Console.WriteLine("***Provvisorio password***");  //TO DO da migliorare?
            Console.WriteLine("Inserisci una password di 8 caratteri:");
            string password = Console.ReadLine()!;
            //verifica inserimento di almeno 8 caratteri
            while (password.Length < 8)
            {
                Console.WriteLine("Devi inserire almeno 8 caratteri");
                password = Console.ReadLine()!;
            }

            //ricerca dell'utente; true trovato, false non trovato
            if (GetIdUtente(nome, password) != 0)
            {
                Console.WriteLine("Utente gia presente.\nEsegui l'accesso nella schermata principale");
                Console.WriteLine("\n...premi un tasto");
                Console.ReadKey();
            }
            else
            {
                //creo utente e lo salvo nel db.Utenti
                UtenteAttuale = new Utente { Nome = nome, Password = password };
                _db.Utenti.Add(UtenteAttuale);
                _db.SaveChanges();
            }
        }
        #endregion

        #region R - Leggi tabella utenti
        /// <summary>
        /// Legge la tabella Utenti e memorizza i recordi in una lista di string.
        /// </summary>
        /// <returns>Lista di utenti in formato "id - Nome "</returns>
        private static List<string> GetUtenti()
        {
            List<string> listaUtenti = new();
            int id = 1; //per la stampa a schermo
            //scansiono db.Utenti
            var utenti = _db.Utenti.ToList();

            foreach (var u in utenti)
            {
                listaUtenti.Add($"{id} - {u.Nome}");
                id++;
            }
            return listaUtenti;
        }
        #endregion

        #region U - Modifica utente
        /// <summary>
        /// Permette di modificare il nome e/o la password dell'utente attuale. <br/>
        /// Richiede la password per poter accedere alle modifiche con max 3 tentativi.
        /// </summary>
        public static void ModificaUtente()
        {
            string input;
            bool eseguito = false;
            bool accesso = false;
            int tentativi = 3;

            while (!accesso && tentativi > 0)
            {
                Console.WriteLine($"Inserisci la password (hai {tentativi} tentativi)");
                string password = Console.ReadLine()!;
                if (password == UtenteAttuale!.Password)    //verifico la password
                {
                    //modifica del campo nome
                    accesso = true;
                    while (!eseguito)
                    {
                        Console.WriteLine("Vuoi modificare il tuo nome? (s/n)");
                        input = Console.ReadLine()!;

                        if (input == "s")
                        {
                            Console.WriteLine("Inserisci il nuovo nome");
                            string nome = Console.ReadLine()!;  //TO DO controllo input
                            Console.WriteLine("Aggiorno il nome");
                            Thread.Sleep(600);
                            UtenteAttuale.Nome = nome;  //aggiorno con il nuovo nome
                            eseguito = true;
                        }
                        else if (input == "n")
                        {
                            eseguito = true;
                        }
                        else
                        {
                            View.MessaggioSelezioneErrata();
                        }
                    }
                    //modifica del campo password
                    eseguito = false;
                    while (!eseguito)
                    {
                        Console.WriteLine("Vuoi cambiare la tua password? (s/n)");
                        input = Console.ReadLine()!;
                        if (input == "s")
                        {
                            Console.WriteLine("***Provvisorio password***");  //TO DO da migliorare?
                            Console.WriteLine("Inserisci una password di 8 caratteri:");
                            string nuovaPassword = Console.ReadLine()!;
                            //verifica inserimento di almeno 8 caratteri
                            while (password.Length < 8)
                            {
                                Console.WriteLine("Devi inserire almeno 8 caratteri");
                                password = Console.ReadLine()!;
                            }
                            Console.WriteLine("Aggiorno la password");
                            Thread.Sleep(600);
                            UtenteAttuale.Password = nuovaPassword;  //aggiorno la password
                            eseguito = true;
                        }
                        else if (input == "n")
                        {
                            eseguito = true;
                        }
                        else
                        {
                            View.MessaggioSelezioneErrata();
                        }
                    }

                    //aggiorno il db.Utenti
                    var user = _db.Utenti.FirstOrDefault(u => u.Id == UtenteAttuale.Id);

                    if (user != null)
                    {
                        user.Nome = UtenteAttuale.Nome;
                        user.Password = UtenteAttuale.Password;
                        _db.SaveChanges();
                    }

                }
                else    //password inserita errata
                {
                    tentativi--;
                    if (tentativi == 1)
                    {
                        Console.WriteLine("Attenzione, ultimo tentativo!!!");
                    }
                    else
                    {
                        Console.WriteLine("Password errata, riprova");

                    }
                }
            }
        }
        #endregion

        #region D - Elimina utente
        /// <summary>
        /// Permette di eliminare l'utente attuale
        /// </summary>
        private static void EliminaUtente()
        {
            string input;
            bool eseguito = false;
            bool accesso = false;
            int tentativi = 3;

            while (!accesso && tentativi > 0)
            {
                Console.WriteLine($"Inserisci la password (hai {tentativi} tentativi)");
                string password = Console.ReadLine()!;
                if (password == UtenteAttuale!.Password)    //verifico la password
                {
                    accesso = true;
                    while (!eseguito)
                    {
                        Console.WriteLine("Vuoi eliminare il tuo account? (s/n)");
                        input = Console.ReadLine()!;

                        if (input == "s")
                        {
                            var user = _db.Utenti.FirstOrDefault(u => u.Id == UtenteAttuale.Id);

                            if (user != null)
                            {
                                _db.Utenti.Remove(user);
                                _db.SaveChanges();
                                Console.WriteLine("Utente cancellato! Arrivederci");
                                Console.WriteLine("\n...premi un tasto");
                                Console.ReadKey();
                                eseguito = true;
                            }
                        }
                        else if (input == "n")
                        {
                            eseguito = true;
                        }
                        else
                        {
                            View.MessaggioSelezioneErrata();
                        }
                    }
                }
                else
                {
                    tentativi--;
                    if (tentativi == 1)
                    {
                        Console.WriteLine("Attenzione, ultimo tentativo!!!");
                    }
                    else
                    {
                        Console.WriteLine("Password errata, riprova");

                    }
                }
            }
        }
        #endregion

        #region Verifica accesso Utente
        /// <summary>
        /// Controlla l'accesso da parte dell'utente, inserendo nome e password. Accede al db.Utenti <br/>
        /// e verifica la corrispondeza dei dati inseriti. Permette l'inserimento per massimo 3 volte <br/>
        /// poi esce dal controllo.
        /// </summary>
        /// <returns>True se l'utente attualmente  è autenticato; false se non esiste o errato</returns>
        public static bool VerificaAccesso()
        {
            bool accesso = false;
            int idUtente;
            int tentativi = 3;    //esegue al max per 3 volte
            string nome;
            string password;

            while (!accesso && tentativi > 0)
            {
                Console.Clear();

                //TO DO da gestire gli errori di input
                if (tentativi == 1)
                {
                    Console.WriteLine("Attenzione ultima possibilità");
                }
                else
                {
                    Console.WriteLine("Inserisci i dati di accesso");
                }

                Console.Write("\nNome utente: ");
                nome = Console.ReadLine()!;
                Console.Write("Password: ");
                password = Console.ReadLine()!;
                //ricerca dell'utente; true trovato, false non trovato
                idUtente = GetIdUtente(nome, password);

                Console.Clear();

                if (idUtente != 0)  //se ho trovato l'utente allora id diverso da zero
                {
                    accesso = true;
                    CaricaUtente(idUtente, nome, password);
                }
                else
                {
                    tentativi--;
                    Console.WriteLine($"Utente non trovato.");  //TO DO spectre rosso
                    Console.WriteLine("\n...premi un tasto");
                    Console.ReadKey();
                }
            }

            if (tentativi == 0)
            {
                View.MessaggioTornaMenuPrincipale();
            }

            return accesso;
        }
        #endregion

        #region Metodi accessori
        /// <summary>
        /// Metodo accessorio che scansiona il db.Utenti e verifica se esiste una corrispondenza con <br/>
        /// il nome e la password inserita.
        /// </summary>
        /// <param name="nome">Il nome da ricercare</param>
        /// <param name="password">La password associata al nome da cercare</param>
        /// <returns>Il numero id dell'utente; 0 se non esiste l'utente</returns>
        private static int GetIdUtente(string nome, string password)
        {
            int idUtente = 0;

            var utenti = _db.Utenti.ToList();
            foreach (var u in utenti)
            {
                if (u.Nome == nome && u.Password == password)
                {
                    idUtente = u.Id;
                    break;  //TO DO da controllare se la connessione rimane aperta o no
                }
            }
            return idUtente;
        }

        /// <summary>
        /// Inizializza l'oggetto UtenteAttuale con i campi nome e password dell'utente <br/>
        /// nella sessione attuale.
        /// </summary>
        /// <param name="id">Id dell'utente da caricare</param>
        /// <param name="nome">Il nome dell'utente da caricare</param>
        /// <param name="password">La password associata all'utente da caricare</param>
        private static void CaricaUtente(int id, string nome, string password)
        {
            UtenteAttuale = new Utente
            {
                Id = id,
                Nome = nome,
                Password = password
            };
        }
        #endregion
    }
}