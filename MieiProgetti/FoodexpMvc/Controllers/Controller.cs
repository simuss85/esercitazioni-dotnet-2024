using FoodexpMvc.Models;
using FoodexpMvc.Views;

namespace FoodexpMvc.Controllers
{
    public class Controller
    {
        private static bool accesso;
        private static bool eseguito;
        private static int idAutenticato;
        private static Utente utenteAttuale = new();

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
                        //accesso login
                        //verifico l'accesso
                        idAutenticato = UtentiController.VerificaAccesso();
                        if (idAutenticato != 0)
                        {
                            //memorizzo l'utente attuale
                            utenteAttuale = UtentiController.GetUtenteById(idAutenticato);
                            accesso = true;
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
                        //creo l'oggetto utente controller per la gestione utente
                        UtentiController utentiController = new(utenteAttuale);
                        utentiController.SelezioneMenu();
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