using FoodexpMvc.Models;
using FoodexpMvc.Views;

namespace FoodexpMvc.Controllers
{
    public class Controller
    {
        private static bool accesso;
        private static bool eseguito;
        public static Utente? UtenteAttuale { get; set; }
        protected static readonly Database _db = new();

        /// <summary>
        /// Getisce l'avvio dell'applicazione, gestisce i menu di login e il menu <br/>
        /// di selezione principale. Richiama le Views per i menu e i Controllers <br/>
        /// per la logica di business.
        /// </summary>
        public static void AvvioApp()
        {
            CreaUtenteAdmin();  //per l'inizializzazione DEBUG TEST

            int idSelezione;

        Login:
            //schermata login
            accesso = false;
            while (!accesso)
            {
                Console.Clear();

                View.MenuLogin();
                var cursore = Console.GetCursorPosition();
                idSelezione = ValidaInput.GetIntElenco(2, cursore.Left, cursore.Top, true);

                switch (idSelezione)
                {
                    case 1:
                        //accesso login
                        //verifico l'accesso
                        accesso = UtentiController.VerificaAccesso();
                        if (accesso)
                        {
                            Console.WriteLine("Accesso eseguito");   //TO DO spectre verde
                            Thread.Sleep(1000);
                        }
                        else
                        {
                            Console.WriteLine("Esegui la registrazione");   //TO DO spectre verde
                            Console.Write("\n...premi un tasto");
                            Console.ReadKey();
                        }
                        break;

                    case 2:
                        //registra nuovo utente
                        Console.Clear();

                        UtentiController.RegistraUtente();
                        break;

                    case -1:
                        Console.WriteLine("\nUscita..."); //TO DO spectre
                        Thread.Sleep(500);
                        return;

                    default:
                        //non fa nulla
                        break;
                }
            }

            //menu principale
            eseguito = false;
            while (!eseguito)
            {
                Console.Clear();
                if (UtenteAttuale!.Nome == "admin123")
                {
                    Console.WriteLine("Inizializzo il frigo");
                    InizializzaFrigo();
                }
                View.MenuPrincipale();
                var cursore = Console.GetCursorPosition();
                idSelezione = ValidaInput.GetIntElenco(5, cursore.Left, cursore.Top, true);

                Console.Clear();

                switch (idSelezione)
                {
                    case 1:
                        //frigorifero 
                        AlimentiController.SelezioneMenu();
                        break;

                    case 2:
                        //lista della spesa
                        ListaSpesaController.SelezioneMenu();
                        break;

                    case 3:
                        //gestione alimenti
                        AlimentiController.SelezioneSottoMenu();
                        break;

                    case 4:
                        //gestione categorie 
                        CategorieController.SelezioneMenu();
                        break;

                    case 5:
                        //gestione utenti
                        UtentiView.MenuGestioneUtenti();
                        if (UtentiController.SelezioneMenu() == -1)
                        {
                            //utente eliminato torna al login
                            goto Login;
                        }
                        break;

                    case -1:
                        Console.WriteLine("Uscita..."); //TO DO spectre
                        Thread.Sleep(500);
                        return;

                    default:
                        View.MessaggioSelezioneErrata();
                        break;
                }
            }
        }
        #region Utente admin e test
        private static void CreaUtenteAdmin()
        {
            var user = _db.Utenti.FirstOrDefault(u => u.Nome == "admin123");

            if (user == null)
            {
                Utente admin = new Utente { Nome = "admin123", Password = "qwertyuiop" };
                _db.Utenti.Add(admin);
                _db.SaveChanges();
            }
        }

        private static void InizializzaFrigo()
        {
            //creo categorie 
            List<Categoria> cateogrieDaAggiungere = new List<Categoria>
            {
                new Categoria { Nome = "latticini"},//1
                new Categoria { Nome = "salumi"},   //2
                new Categoria { Nome = "frutta"},   //3
                new Categoria { Nome = "verdura"},  //4
                new Categoria { Nome = "formaggi"}, //5
                new Categoria { Nome = "carne"},    //6
                new Categoria { Nome = "pesce"},    //7
                new Categoria { Nome = "bevande"}   //8
            };
            CategorieController.AggiungiCategorie(cateogrieDaAggiungere);
            //creo lista alimenti
            List<Alimento> alimentiDaAggiungere = new List<Alimento>
            {
                new Alimento {Nome = "yogurt fragola", Quantita = 3, DataScadenza = new DateTime(2024, 3, 12), DataInserimento = DateTime.Today , CategoriaId = 1},
                new Alimento {Nome = "prosciutto cotto", Quantita = 1, DataScadenza = new DateTime(2024, 3, 3), DataInserimento = DateTime.Today , CategoriaId = 2},
                new Alimento {Nome = "gorgonzola", Quantita = 1, DataScadenza = new DateTime(2024, 3, 31), DataInserimento = DateTime.Today , CategoriaId = 5},
                new Alimento {Nome = "branzino", Quantita = 3, DataScadenza = new DateTime(2024, 3, 20), DataInserimento = DateTime.Today , CategoriaId = 7},
                new Alimento {Nome = "salsiccia", Quantita = 4, DataScadenza = new DateTime(2024, 3, 28), DataInserimento = DateTime.Today , CategoriaId = 6},
                new Alimento {Nome = "actimel", Quantita = 6, DataScadenza = new DateTime(2024, 3, 22), DataInserimento = DateTime.Today , CategoriaId = 1},
                new Alimento {Nome = "succo ACE", Quantita = 2, DataScadenza = new DateTime(2024, 4, 24), DataInserimento = DateTime.Today , CategoriaId = 8},
                new Alimento {Nome = "melanzane", Quantita = 3, DataScadenza = new DateTime(2024, 3, 16), DataInserimento = DateTime.Today , CategoriaId = 4},
                new Alimento {Nome = "braciole", Quantita = 3, DataScadenza = new DateTime(2024, 3, 19), DataInserimento = DateTime.Today , CategoriaId = 6},
                new Alimento {Nome = "rucola", Quantita = 1, DataScadenza = new DateTime(2024, 3, 17), DataInserimento = DateTime.Today , CategoriaId = 4}

            };

            //creo utenti di prova
            List<Utente> utentiDaInserire = new List<Utente>
            {
                new Utente {Nome = "Emy", Password = "pongo89" },   //2
                new Utente {Nome = "Alex", Password = "maria99" }   //3
            };

            //creo lista listaAlimenti
            List<ListaSpesa> listaSpesaDaAggiungere = new List<ListaSpesa>
            {
                new ListaSpesa {Alimento = "insalata", Quantita = 1, CategoriaId = 4, UtenteId = 2},
                new ListaSpesa {Alimento = "salamino", Quantita = 3, CategoriaId = 2, UtenteId = 3},
                new ListaSpesa {Alimento = "parmigiano", Quantita = 1, CategoriaId = 5, UtenteId = 2},
                new ListaSpesa {Alimento = "orata", Quantita = 1, CategoriaId = 7, UtenteId = 2},
                new ListaSpesa {Alimento = "vino rosso", Quantita = 2, CategoriaId = 8, UtenteId = 3}
            };

            //aggiungo alimenti iniziali
            AlimentiController.AggiungiAlimenti(alimentiDaAggiungere);
            UtentiController.AggiungiUtenti(utentiDaInserire);
            ListaSpesaController.AggiungiListaSpesa(listaSpesaDaAggiungere);
        }
        #endregion
    }
}