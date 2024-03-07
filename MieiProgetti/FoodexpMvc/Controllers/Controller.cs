using FoodexpMvc.Views;

namespace FoodexpMvc.Controllers
{
    public class Controller
    {
        private static bool accesso;
        private static bool eseguito;

        /// <summary>
        /// Getisce l'avvio dell'applicazione, gestisce i menu di login e il menu <br/>
        /// di selezione principale. Richiama le Views per i menu e i Controllers <br/>
        /// per la logica di business.
        /// </summary>
        public static void AvvioApp()
        {
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
                        // richiama metodo accesso account UtentiController.cs
                        accesso = UtentiController.VerificaAccesso();
                        break;

                    case "2":
                        //richiama metodo di registrazione utente UtentiController.cs
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
                        //filtra alimenti 
                        View.MenuLitaSpesa();
                        //ListaSpesaController.cs
                        break;

                    case "3":
                        //gestione alimenti
                        View.MenuGestioneAlimenti();
                        //AlimentiController.cs
                        break;

                    case "4":
                        //gestione categorie 
                        View.MenuGestioneCategorie();
                        //CategorieController.cs
                        break;

                    case "5":
                        //gestione utenti
                        View.MenuGestioneUtenti();
                        //UtentiController.cs
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
    }
}