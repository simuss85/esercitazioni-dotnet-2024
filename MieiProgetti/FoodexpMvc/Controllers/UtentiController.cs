using FoodexpMvc.Models;
using FoodexpMvc.Views;

namespace FoodexpMvc.Controllers
{
    public class UtentiController
    {
        private static readonly Database _db = new();
        private static bool eseguito;

        #region Switch Selezione
        /// <summary>
        /// Gestisce la selezione del sotto-menu "Gestione utenti"
        /// </summary>
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
        #endregion

        #region C - Registra Utente
        /// <summary>
        /// Gestisce l'inserimento di un nuovo utente nel database. <br/>
        /// <b> Versione di base <b>
        /// </summary>
        public static void RegistraUtente()
        {
            Console.WriteLine("Inserisci il tuo nome: ");
            string nome = Console.ReadLine()!;
            Console.WriteLine("***Provvisorio password***");  //TO DO da migliorare?
            Console.WriteLine("Inserisci una password di 8 caratteri:");
            string password = Console.ReadLine()!;
            //verifica inserimento di almeno 8 caratteri
            while (!(password.Length == 8))
            {
                Console.WriteLine("Devi inseire almeno 8 caratteri");
                password = Console.ReadLine()!;
            }

            //ricerca dell'utente; true trovato, false non trovato
            if (EsisteUtente(nome, password))
            {
                Console.WriteLine("Utente gia presente.\nEsegui l'accesso nella schermata principale");
            }
            else
            {
                //creo utente e lo salvo nel db.Utenti
                Utente nuovoUtente = new Utente { Nome = nome, Password = password };
                _db.Utenti.Add(nuovoUtente);
                _db.SaveChanges();
            }
        }
        #endregion

        #region R - Leggi lista utenti
        /// <summary>
        /// Legge la tabella Utenti e memorizza i recordi in una lista di string.
        /// </summary>
        /// <returns>Lista di utenti in formato "id - Nome "</returns>
        public static List<string> LeggiUtenti()
        {
            List<string> listaUtenti = new();
            int id = 1; //per la stampa a schermo
            //scansiono db.Utenti
            var utenti = _db.Utenti.ToList();

            foreach (var u in utenti)
            {
                listaUtenti.Add($"{id} - {u.Nome}");
                id++;
            }
            return listaUtenti;
        }
        #endregion

        #region U - Modifica utente
        public static void ModificaUtente()
        {
            Console.WriteLine("Inserisci la passwod");
        }
        #endregion

        #region D - Elimina utente
        #endregion

        #region Verifica accesso Utente
        /// <summary>
        /// Controlla l'accesso da parte dell'utente, inserendo nome e password. Accede al db.Utenti <br/>
        /// e verifica la corrispondeza dei dati inseriti. Permette l'inserimento per massimo 3 volte <br/>
        /// poi esce dal controllo.
        /// </summary>
        /// <returns>True se l'utente è stato autenticato; false se non è stato trovato</returns>
        public static bool VerificaAccesso()
        {
            bool accesso = false;
            int contaErrori = 3;    //esegue al max per 3 volte
            string nome;
            string password;

            while (!accesso && contaErrori > 0)
            {
                Console.Clear();

                //TO DO da gestire gli errori di input
                if (contaErrori == 1)
                {
                    Console.WriteLine("Attenzione ultima possibilità");
                }
                else
                {
                    Console.WriteLine("Inserisci i dati di accesso");
                }

                Console.Write("Nome utente: ");
                nome = Console.ReadLine()!;
                Console.Write("\nPassword: ");
                password = Console.ReadLine()!;
                //ricerca dell'utente; true trovato, false non trovato
                accesso = EsisteUtente(nome, password);

                if (accesso == false)
                {
                    contaErrori--;
                    Console.WriteLine($"Utente non trovato.");
                }

            }

            if (contaErrori == 0)
            {
                View.MessaggioTornaMenuPrincipale();
            }

            return accesso;
        }
        #endregion

        #region Metodi accessori
        /// <summary>
        /// Metodo accessorio che scansiona il db.Utenti e verifica se esiste una corrispondenza con <br/>
        /// il nome e la password inserita.
        /// </summary>
        /// <param name="nome">Il nome da ricercare</param>
        /// <param name="password">La password associata al nome da cercare</param>
        /// <returns>True se l'utente è stato trovato; false se non è presente nella lista</returns>
        private static bool EsisteUtente(string nome, string password)
        {
            bool trovato = false;

            var utenti = _db.Utenti.ToList();
            foreach (var u in utenti)
            {
                if (u.Nome == nome && u.Password == password)
                {
                    trovato = true;
                    break;  //TO DO da controllare se la connessione rimane aperta o no
                }
            }
            return trovato;
        }
        #endregion
    }
}