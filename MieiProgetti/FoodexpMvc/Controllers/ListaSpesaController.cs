using FoodexpMvc.Models;
using FoodexpMvc.Views;
using Microsoft.EntityFrameworkCore;

namespace FoodexpMvc.Controllers
{
    public class ListaSpesaController : Controller
    {
        private static bool eseguito;

        #region Switch Selezione
        /// <summary>
        /// Gestisce la selezione del sotto-menu "Gestione lista della spesa"
        /// </summary>
        public static void SelezioneMenu()
        {
            //gestione lista della spesa
            eseguito = false;
            while (!eseguito)
            {
                Console.Clear();

                ListaSpesaView.MenuListaSpesa();
                string input = Console.ReadLine()!.ToLower();

                switch (input)
                {
                    case "1":
                        //viualizza lista
                        Console.Clear();

                        ListaSpesaView.VisualizzaLista(GetLista());
                        Console.Write("\n...premi un tasto ");
                        Console.ReadKey();
                        break;

                    case "2":
                        //aggiungi alimento
                        AggiungiInListaSpesa();
                        break;

                    case "3":
                        //modifica alimento
                        ModificaListaSpesa();
                        break;

                    case "4":
                        //elimina alimento
                        EliminaDaListaSpesa();
                        break;

                    case "r":
                        //torna al menu principale
                        View.MessaggioTornaMenuPrincipale();
                        break;

                    default:
                        //torna al menu principale
                        View.MessaggioSelezioneErrata();
                        break;
                }
            }
        }
        #endregion

        #region C - Aggiungi alimento lista
        /// <summary>
        /// Aggiunge un oggetto di tipo ListaSpesa al db.ListaSpesa
        /// </summary>
        public static void AggiungiInListaSpesa()
        {
            string input;

            eseguito = false;
            while (!eseguito)
            {
                Console.Clear();

                //nome
                Console.Write("Inserisci alimento: ");
                var cursore = Console.GetCursorPosition();
                string alimento = ValidaInput.GetString(cursore.Left, cursore.Top);

                //quantita
                Console.Write("Inserisci quantita: ");
                cursore = Console.GetCursorPosition();
                int quantita = ValidaInput.GetQuantita(cursore.Left, cursore.Top);

                //verifica se gia presente
                var r = _db.ListaSpesa.FirstOrDefault(l => l.Alimento == alimento);

                if (r != null)  //gia presente chiedo cosa fare
                {
                    Console.WriteLine("Alimento gia presente nella lista\n");
                    Console.WriteLine($"{r.Alimento} - {r.Quantita} - {_db.Categorie.First(c => c.Id == r.CategoriaId).Nome} - {_db.Utenti.First(u => u.Id == r.UtenteId).Nome}");

                    Console.Write("\nVuoi modificare la quantità? (s/n) ");
                    cursore = Console.GetCursorPosition();
                    input = ValidaInput.GetSiNo(cursore.Left, cursore.Top);

                    if (input == "s")   //modifico la quantita
                    {
                        //quantita
                        Console.Write("Inserisci quantita: ");
                        cursore = Console.GetCursorPosition();
                        quantita = ValidaInput.GetQuantita(cursore.Left, cursore.Top);

                        r.Quantita = quantita;
                        _db.SaveChanges();

                        //richiesta altro inserimento
                        Console.Write("\nVuoi aggiungere altro? (s/n)");
                        cursore = Console.GetCursorPosition();
                        input = ValidaInput.GetSiNo(cursore.Left, cursore.Top);
                        if (input == "n")
                        {
                            eseguito = true;
                        }
                    }

                }
                else    //alimento non presente quindi ne creo uno nuovo
                {
                    //categoria
                    Console.Clear();
                    //stampo elenco per l'utente
                    CategorieView.VisualizzaCategorie(CategorieController.GetCategorie());
                    int totaleCategorie = _db.Categorie.Count();
                    Console.Write("\nSeleziona categoria: ");
                    cursore = Console.GetCursorPosition();
                    int idCategoria = ValidaInput.GetIntElenco(totaleCategorie, cursore.Left, cursore.Top);

                    Console.Clear();

                    Console.WriteLine("Riepilogo inserimento\n");
                    Console.WriteLine($"Alimento: {alimento}\nQuantità: {quantita}\nCategoria: {_db.Categorie.FirstOrDefault(c => c.Id == idCategoria)!.Nome}\n");

                    //creo nuovo oggetto Alimento
                    ListaSpesa l = new ListaSpesa();

                    //assegno i valori per ogni attributo
                    l.Alimento = alimento;
                    l.Quantita = quantita;
                    l.CategoriaId = idCategoria;
                    l.UtenteId = UtenteAttuale!.Id;

                    //conferma
                    Console.WriteLine("\nConfermi inserimento? (s/n)");
                    cursore = Console.GetCursorPosition();
                    input = ValidaInput.GetSiNo(cursore.Left, cursore.Top);

                    if (input == "s")   //confermo inserimento
                    {
                        //inserisco nel db e salvo
                        _db.ListaSpesa.Add(l);
                        _db.SaveChanges();
                        Console.WriteLine("Alimento aggiunto alla lista");
                        Thread.Sleep(800);

                        //richiesta altro inserimento
                        Console.Write("\nVuoi aggiungere altro? (s/n)");
                        cursore = Console.GetCursorPosition();
                        input = ValidaInput.GetSiNo(cursore.Left, cursore.Top);
                        if (input == "n")
                        {
                            eseguito = true;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Aggiunge al db.ListaSpesa gli oggetti di tipo ListaSpesa presenti nella lista.
        /// </summary>
        /// <param name="listaSpesaDaAggiungere">La lista di oggetti di tipo ListaSpesa da aggiungere</param>
        public static void AggiungiListaSpesa(List<ListaSpesa> listaSpesaDaAggiungere)
        {
            foreach (var elemento in listaSpesaDaAggiungere)   //per ogni elemento della lista da inserire
            {
                //verifico che non sia gia nella lista
                var ldb = _db.ListaSpesa.FirstOrDefault(l => l.Alimento == elemento.Alimento);

                if (ldb != null)
                {
                    //elemento gia presente non fa niente
                }
                else
                {
                    _db.ListaSpesa.Add(elemento);
                    _db.SaveChanges();
                }
            }
        }
        #endregion

        #region R - Leggi tabella ListaSpesa
        /// <summary>
        /// Seleziona tutti gli elementi presenti in db.ListaSpesa
        /// </summary>
        /// <returns>La lista degli elementi da stampare</returns>
        public static List<string> GetLista()
        {
            List<string> lista = new();

            //scansiono db.ListaSpesa
            var ldb = _db.ListaSpesa.Include(c => c.Categoria).Include(u => u.Utente);

            foreach (var l in ldb)
            {
                lista.Add($"{l.Alimento} - {l.Quantita} - {l.Categoria!.Nome} - {l.Utente!.Nome}");
            }
            return lista;
        }
        #endregion

        #region U - Modifica alimento lista
        /// <summary>
        /// Permette di modificare un record da db.ListaSpesa selezionando da un elenco numerato.
        /// </summary>
        public static void ModificaListaSpesa()
        {
            eseguito = false;
            while (!eseguito)    //inizio la procedura di modifica
            {
                Console.Clear();

                ListaSpesaView.VisualizzaLista(GetLista());
                var lista = _db.ListaSpesa.ToList();   //per la corretta corrispondenza tra elenco e id
                int totLista = lista.Count;
                Console.WriteLine($"r - Torna al menu precedente");  //inserisco opzione di uscita dinamica
                Console.WriteLine("\nCosa vuoi modificare? ");
                var cursore = Console.GetCursorPosition();
                int id = ValidaInput.GetIntElenco(totLista, cursore.Left, cursore.Top, true);

                if (id == -1)   //premuto r - torna al menu precedente
                {
                    eseguito = true;
                    View.MessaggioTornaMenuPrecedente(800);
                }
                else    //ho selezionato un alimento dalla lista 
                {
                    eseguito = false;
                    id--;       //index parte da 0

                    //carico alimento da modificare
                    var l = lista[id];

                    //preparo le variabili di appoggio per l'inserimento dati dell'utente
                    string? alimento = l.Alimento;
                    int quantita = l.Quantita;
                    int idCategoria = l.CategoriaId;
                    int idUtente = l.UtenteId;
                    string input;

                    Console.Clear();

                    Console.WriteLine("Riepilogo alimento\n");
                    Console.WriteLine($"1 - Alimento: {alimento}\n2 - Quantità: {quantita}\n3 - Categoria: {_db.Categorie.First(c => c.Id == l.Id).Nome}\nr - Tutto corretto");
                    //richiesta di modifica
                    Console.Write("\nSeleziona l'elemento da modificare: ");
                    cursore = Console.GetCursorPosition();
                    int idSelezione = ValidaInput.GetIntElenco(3, cursore.Left, cursore.Top, true);

                    switch (idSelezione)
                    {
                        case 1:
                            //nome
                            Console.Write("Inserisci alimento: ");
                            cursore = Console.GetCursorPosition();
                            alimento = ValidaInput.GetString(cursore.Left, cursore.Top);
                            break;

                        case 2:
                            //quantita
                            Console.Write("Inserisci quantita: ");
                            cursore = Console.GetCursorPosition();
                            quantita = ValidaInput.GetQuantita(cursore.Left, cursore.Top);
                            break;

                        case 3:
                            //categoria
                            Console.Clear();
                            //stampo elenco per l'utente
                            CategorieView.VisualizzaCategorie(CategorieController.GetCategorie());
                            int totaleCategorie = _db.Categorie.Count();
                            Console.Write("\nSeleziona categoria: ");
                            cursore = Console.GetCursorPosition();
                            idCategoria = ValidaInput.GetIntElenco(totaleCategorie, cursore.Left, cursore.Top);
                            break;

                        case -1:
                            //tutto corretto non fa niente
                            eseguito = true;
                            View.MessaggioTornaMenuPrecedente();
                            Console.ReadKey();
                            return;

                        default:
                            Console.WriteLine("Selezione errata");
                            break;
                    }
                    Console.Clear();
                    Console.WriteLine("Riepilogo inserimento\n");
                    Console.WriteLine($"1 - Alimento: {alimento}\n2 - Quantità: {quantita}\n3 - Categoria: {_db.Categorie.First(c => c.Id == l.Id).Nome}\nr - Tutto corretto");

                    //conferma iserimento
                    Console.WriteLine("\nConfermi inserimento? (s/n)");
                    cursore = Console.GetCursorPosition();
                    input = ValidaInput.GetSiNo(cursore.Left, cursore.Top);

                    if (input == "s")
                    {
                        //assegno i valori per ogni attributo
                        l.Alimento = alimento;
                        l.Quantita = quantita;
                        l.CategoriaId = idCategoria;
                        l.UtenteId = UtenteAttuale!.Id;
                        _db.SaveChanges();
                    }
                }
            }
        }
        #endregion

        #region D- Elimina alimento lista
        /// <summary>
        /// Permette di eliminare un record di db.ListaSpesa da un elenco numerato fino a quando l'utente seleziona <br/>
        /// il carattere 0.
        /// </summary>
        private static void EliminaDaListaSpesa()
        {
            eseguito = false;
            while (!eseguito)
            {
                Console.Clear();

                ListaSpesaView.VisualizzaLista(GetLista()); //stampa elenco
                var lista = _db.ListaSpesa.ToList();        //per la corretta corrispondenza tra elenco e id
                int totLista = lista.Count;
                Console.WriteLine($"r - Torna al menu precedente");  //inserisco opzione di uscita dinamica
                Console.WriteLine("\nCosa vuoi eliminare? ");
                var cursore = Console.GetCursorPosition();
                int id = ValidaInput.GetIntElenco(totLista, cursore.Left, cursore.Top, true);

                if (id == -1)   //premuto r - torna al menu precedente
                {
                    eseguito = true;
                    View.MessaggioTornaMenuPrecedente(800);
                }
                else    //ho selezionato un alimento dalla lista 
                {
                    eseguito = false;
                    id--;       //index parte da 0

                    Console.WriteLine($"Vuoi eliminare {lista[id].Alimento}? (s/n)");
                    cursore = Console.GetCursorPosition();
                    string input = ValidaInput.GetSiNo(cursore.Left, cursore.Top);

                    if (input == "s")
                    {
                        //seleziono l'alimento in posizione [id] dalla lista di tipo Alimento
                        //seleziono poi il suo id che passo al metodo che elimina l'oggetto dal db.Alimento
                        EliminaDaListaPerId(lista[id].Id);
                        Console.WriteLine("Alimento cancellato dalla lista");
                    }
                }
            }
        }
        #endregion

        #region Metodi accessori
        /// <summary>
        /// Metodo accessorio che elimina un record da db.ListaSpesa tramite il suo Id
        /// </summary>
        /// <param name="id">L'id del record da eliminare</param>
        private static void EliminaDaListaPerId(int id)
        {
            foreach (var l in _db.ListaSpesa)
            {
                if (l.Id == id)
                {
                    _db.ListaSpesa.Remove(l);
                    _db.SaveChanges();
                }
            }
        }
        #endregion
    }
}