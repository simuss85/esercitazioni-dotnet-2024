using FoodexpMvc.Views;

namespace FoodexpMvc.Controllers
{
    public class ListaSpesaController
    {
        private static bool eseguito;
        public static void SelezioneMenu()
        {
            //gestione lista della spesa
            eseguito = false;
            while (!eseguito)
            {
                View.MenuLitaSpesa();
                string input = Console.ReadLine()!.ToLower();

                Console.Clear();

                switch (input)
                {
                    case "1":
                        //viualizza lista
                        break;

                    case "2":
                        //inserisci alimento
                        break;

                    case "3":
                        //modifica alimento
                        break;

                    case "4":
                        //elimina alimento
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