using FoodexpMvc.Views;

namespace FoodexpMvc.Controllers
{
    public class AlimentiController
    {
        private static bool eseguito;

        public static void SelezioneMenu()
        {
            //frigorifero - filtra alimenti
            eseguito = false;
            while (!eseguito)
            {
                AlimentiView.MenuFiltraAlimenti();
                string input = Console.ReadLine()!.ToLower();

                switch (input)
                {
                    case "1":
                        //visualizza tutti
                        break;

                    case "2":
                        //visualizza scaduti
                        break;

                    case "3":
                        //visualizza in scadenza
                        break;

                    case "4":
                        //visualizza in esaurimento
                        break;

                    case "5":
                        //ordina per nome
                        break;

                    case "6":
                        //ordina per data di scadenza
                        break;

                    case "7":
                        //ordina per data di inserimento
                        break;

                    case "8":
                        //ordina per quantità
                        break;

                    case "9":
                        //ordina per categoria
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