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

        Login:
            //schermata login
            accesso = false;
            while (!accesso)
            {
                Console.Clear();

                View.MenuLogin();
                string input = Console.ReadLine()!.ToLower();

                switch (input)
                {
                    case "1":
                        //accesso login
                        //verifico l'accesso
                        accesso = UtentiController.VerificaAccesso();
                        if (accesso)
                        {
                            Console.WriteLine("Accesso eseguito");   //TO DO spectre verde
                            Console.WriteLine("\n...premi un tasto");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Accesso bloccato!!!\nEsegui la registrazione");   //TO DO spectre verde
                            Console.WriteLine("\n...premi un tasto");
                            Console.ReadKey();
                        }
                        break;

                    case "2":
                        //registra nuovo utente
                        Console.Clear();

                        UtentiController.RegistraUtente();
                        break;

                    case "e":
                        Console.WriteLine("Uscita..."); //TO DO spectre
                        Thread.Sleep(500);
                        return;

                    default:
                        Console.WriteLine("Selezione errata");  //TO DO spectre
                        Thread.Sleep(500);
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
                string input = Console.ReadLine()!.ToLower();

                Console.Clear();

                switch (input)
                {
                    case "1":
                        //frigorifero 
                        AlimentiController.SelezioneMenu();
                        break;

                    case "2":
                        //lista della spesa
                        ListaSpesaView.MenuListaSpesa();
                        //ListaSpesaController.cs
                        break;

                    case "3":
                        //gestione alimenti
                        AlimentiView.MenuGestioneAlimenti();
                        //AlimentiController.cs
                        break;

                    case "4":
                        //gestione categorie 
                        CategorieView.MenuGestioneCategorie();
                        //CategorieController.cs
                        break;

                    case "5":
                        //gestione utenti
                        UtentiView.MenuGestioneUtenti();
                        if (UtentiController.SelezioneMenu() == -1)
                        {
                            //utente eliminato torna al login
                            goto Login;
                        }
                        break;

                    case "e":
                        Console.WriteLine("Uscita..."); //TO DO spectre
                        Thread.Sleep(500);
                        return;

                    default:
                        Console.WriteLine("Selezione errata");  //TO DO spectre
                        Thread.Sleep(500);
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
                new Categoria { Nome = "Latticini"},
                new Categoria { Nome = "Salumi"},
                new Categoria { Nome = "Frutta"},
                new Categoria { Nome = "Verdura"},
                new Categoria { Nome = "Formaggi"},
                new Categoria { Nome = "Carne"},
                new Categoria { Nome = "Pesce"},
                new Categoria { Nome = "Bevande"}
            };
            CategorieController.AggiungiCategorie(cateogrieDaAggiungere);
            //creo lista alimenti
            DateTime now = DateTime.Now;
            string dataOggi = now.ToString("dd/MM/yyyy");

            List<Alimento> alimentiDaAggiungere = new List<Alimento>
            {
                new Alimento {Nome = "yogurt fragola", Quantita = 3, DataScadenza = new DateTime(2024, 3, 12), DataInserimento = DateTime.Parse(dataOggi) , CategoriaId = 1},
                new Alimento {Nome = "prosciutto cotto", Quantita = 1, DataScadenza = new DateTime(2024, 3, 3), DataInserimento = DateTime.Parse(dataOggi) , CategoriaId = 2},
                new Alimento {Nome = "gorgonzola", Quantita = 1, DataScadenza = new DateTime(2024, 3, 31), DataInserimento = DateTime.Parse(dataOggi) , CategoriaId = 5},
                new Alimento {Nome = "branzino", Quantita = 3, DataScadenza = new DateTime(2024, 3, 20), DataInserimento = DateTime.Parse(dataOggi) , CategoriaId = 7},
                new Alimento {Nome = "salsiccia", Quantita = 4, DataScadenza = new DateTime(2024, 3, 28), DataInserimento = DateTime.Parse(dataOggi) , CategoriaId = 6},
                new Alimento {Nome = "actimel", Quantita = 6, DataScadenza = new DateTime(2024, 3, 22), DataInserimento = DateTime.Parse(dataOggi) , CategoriaId = 1},
                new Alimento {Nome = "succo ACE", Quantita = 2, DataScadenza = new DateTime(2024, 4, 24), DataInserimento = DateTime.Parse(dataOggi) , CategoriaId = 8},
                new Alimento {Nome = "melanzane", Quantita = 3, DataScadenza = new DateTime(2024, 3, 16), DataInserimento = DateTime.Parse(dataOggi) , CategoriaId = 4},
                new Alimento {Nome = "braciole", Quantita = 3, DataScadenza = new DateTime(2024, 3, 19), DataInserimento = DateTime.Parse(dataOggi) , CategoriaId = 6},
                new Alimento {Nome = "rucola", Quantita = 1, DataScadenza = new DateTime(2024, 3, 17), DataInserimento = DateTime.Parse(dataOggi) , CategoriaId = 4}

            };
            //aggiungo alimenti iniziali
            AlimentiController.AggiungiAlimenti(alimentiDaAggiungere);
        }
        #endregion
    }
}