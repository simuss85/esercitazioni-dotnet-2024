using FoodexpMvc.Views;

namespace FoodexpMvc.Controllers
{
    public class CategorieController
    {
        private static bool eseguito;

        public static void SelezioneMenu()
        {
            //gestione categorie
            eseguito = false;
            while (!eseguito)
            {
                CategorieView.MenuGestioneCategorie();
                string input = Console.ReadLine()!.ToLower();

                Console.Clear();

                switch (input)
                {
                    case "1":
                        //visualizza categorie
                        break;

                    case "2":
                        //modifica categorie
                        break;

                    case "3":
                        //elimina categorie
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