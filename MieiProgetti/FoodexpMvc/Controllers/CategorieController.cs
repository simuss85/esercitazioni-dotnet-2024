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
                        CategorieView.VisualizzaCategorie(GetCategorie());
                        Console.WriteLine("\n...premi un tasto");
                        Console.ReadKey();
                        break;

                    case "2":
                        //inserisci categorie
                        AggiungiCategoria();
                        break;

                    case "3":
                        //modifica categorie
                        ModificaCategoria();
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
                Console.Clear();
            }
        }
        #endregion

        #region C - Aggiungi categoria
        /// <summary>
        /// Aggiunge un oggetto di tipo Categoria al db.Categorie.
        /// </summary>
        public static void AggiungiCategoria()
        {
            eseguito = false;
            while (!eseguito)
            {
                Console.Clear();

                CategorieView.VisualizzaCategorie(GetCategorie());
                Console.WriteLine("\nVuoi inserire una nuova categoria? (s/n)");
                var cursore = Console.GetCursorPosition();
                string input = ValidaInput.GetSiNo(cursore.Left, cursore.Top);


                if (input == "n")   //torna al menu precedente
                {
                    eseguito = true;
                    View.MessaggioTornaMenuPrecedente(1000);
                }
                else    //inserimento categoria
                {
                    eseguito = false;
                    Categoria nuovaCategoria = new Categoria();      //creo nuovo oggetto Categoria

                    Console.Write("Inserisci nome: ");
                    cursore = Console.GetCursorPosition();
                    string nome = ValidaInput.GetString(cursore.Left, cursore.Top).ToLower();   //i nomi categoria uppercase

                    //verifico che non sia gia presente
                    var giaPresente = _db.Categorie.FirstOrDefault(c => c.Nome == nome);

                    if (giaPresente == null)    //continuo con la modifica
                    {
                        //eseguo l'inserimento
                        nuovaCategoria.Nome = nome;
                        _db.Categorie.Add(nuovaCategoria);
                        _db.SaveChanges();

                        Console.WriteLine($"\nCategoria '{nome}' aggiunta");
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        Console.WriteLine($"Categoria '{nome}' gia presente");
                        Console.WriteLine("Riprova");
                        Thread.Sleep(800);
                    }

                }
            }


        }

        /// <summary>
        /// Aggiunge al db.Categorie gli oggetti di tipo Categoria presenti nella lista.
        /// </summary>
        /// <param name="categorieDaInserire">La lista dei oggetti di tipo Categoria da aggiungere</param>
        public static void AggiungiCategorie(List<Categoria> categorieDaInserire)
        {
            bool trovato;

            foreach (var c in categorieDaInserire)       //per ogni elemento della lista da inserire
            {
                trovato = false;
                foreach (var cdb in _db.Categorie)     //ricerco nel db la corrispondenza
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
        /// <summary>
        /// Legge la tabella Categorie e memorizza i recordi in una lista di string.
        /// </summary>
        /// <returns>Lista di utenti in formato "id - Nome "</returns>
        public static List<string> GetCategorie()
        {
            List<string> listaCategorie = new();

            //scansiono db.Categorie
            var utenti = _db.Categorie.ToList();

            foreach (var u in utenti)
            {
                listaCategorie.Add($"{u.Id} - {View.PascalCase(u.Nome!)}");
            }
            return listaCategorie;
        }
        #endregion

        #region U - Modifica categoria
        /// <summary>
        /// Permette di modificare una categoria dal db.Categorie
        /// </summary>
        public static void ModificaCategoria()
        {
            eseguito = false;
            while (!eseguito)
            {
                Console.Clear();

                CategorieView.VisualizzaCategorie(GetCategorie());
                int totaleCategorie = _db.Categorie.Count();
                Console.WriteLine($"r - Torna al menu precedente");  //inserisco opzione di uscita dinamica
                Console.WriteLine("\nCosa vuoi modificare? ");
                var cursore = Console.GetCursorPosition();
                int id = ValidaInput.GetIntElenco(totaleCategorie, cursore.Left, cursore.Top, true);

                if (id == -1)   //torna al menu precedente
                {
                    eseguito = true;
                    View.MessaggioTornaMenuPrecedente(1000);
                }
                else    //modifico categoria
                {
                    eseguito = false;

                    //carico categoria da modificare
                    var c = _db.Categorie.FirstOrDefault(c => c.Id == id);

                    //preparo la variabile di appoggio per l'inserimento dell'utente
                    string? nome = c!.Nome;

                    Console.Clear();

                    cursore = Console.GetCursorPosition();
                    Console.WriteLine($"Vuoi modificare la categoria '{View.PascalCase(c.Nome!)}'? (s/n)");
                    cursore = Console.GetCursorPosition();
                    string input = ValidaInput.GetSiNo(cursore.Left, cursore.Top);
                    if (input == "s")
                    {
                        Console.Write("Inserisci nuovo nome: ");
                        cursore = Console.GetCursorPosition();
                        nome = ValidaInput.GetString(cursore.Left, cursore.Top).ToLower();   //i nomi categoria uppercase

                        //conferma iserimento
                        Console.WriteLine($"\nConfermi nuovo nome categoria: '{View.PascalCase(nome)}'? (s/n)");
                        cursore = Console.GetCursorPosition();
                        input = ValidaInput.GetSiNo(cursore.Left, cursore.Top);

                        if (input == "s")
                        {
                            //assegno il nuovo valore per l'attributo nome e salvo
                            c.Nome = nome;
                            _db.SaveChanges();
                        }

                    }
                    else
                    {
                        //non fa niente
                    }
                }
            }
        }
        #endregion

        #region D - Elimina categoria
        //l'applicazione non consente l'eliminiazione di una categoria
        #endregion

        #region Metodi accessori
        //eventuali metodi accessori
        #endregion
    }
}