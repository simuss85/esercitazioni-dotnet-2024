using FoodexpMvc.Models;
using FoodexpMvc.Views;

namespace FoodexpMvc.Controllers
{
    public class CategorieController : Controller
    {
        private static bool eseguito;

        #region Switch Selezione
        /// <summary>
        /// Gestisce la selezione del sotto-menu "Gestione categorie"
        /// </summary>
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
        #endregion

        #region C - Aggiungi categoria
        /// <summary>
        /// Aggiunge al db.Categorie gli oggetti di tipo Categoria presenti nella lista.
        /// </summary>
        /// <param name="categorieDaInserire">La lista dei oggetti di tipo Categoria da aggiungere</param>
        public static void AggiungiCategorie(List<Categoria> categorieDaInserire)
        {
            bool trovato = false;
            //memorizzo il db.Categorie
            var categorieNelDb = _db.Categorie.ToList();

            foreach (var c in categorieDaInserire)       //per ogni elemento della lista da inserire
            {
                trovato = false;
                foreach (var cdb in categorieNelDb)     //ricerco nel db la corrispondenza
                {
                    if (c.Nome == cdb.Nome)     //categoria gia presente
                    {
                        trovato = true;
                        break;
                    }
                }
                if (!trovato)   //aggiunge categoria non presente
                {
                    _db.Categorie.Add(c);
                    _db.SaveChanges();
                }
            }
        }
        #endregion

        #region R - Leggi tabella categorie
        #endregion

        #region U - Modifica categoria
        #endregion

        #region D - Elimina categoria
        #endregion

        #region Metodi accessori
        #endregion
    }
}