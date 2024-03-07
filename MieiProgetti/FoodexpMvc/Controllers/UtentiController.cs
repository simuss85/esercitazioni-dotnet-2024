using FoodexpMvc.Views;

namespace FoodexpMvc.Controllers
{
    public class UtentiController
    {
        private static bool eseguito;
        public static void SelezioneMenu()
        {
            //gestione utenti
            eseguito = false;
            while (!eseguito)
            {
                View.MenuGestioneUtenti();
                string input = Console.ReadLine()!.ToLower();

                Console.Clear();

                switch (input)
                {
                    case "1":
                        //visualizza utenti
                        break;

                    case "2":
                        //modifica password
                        break;

                    case "3":
                        //elimina account
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
    }
}