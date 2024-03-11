namespace FoodexpMvc.Views
{
    public class View
    {
        /// <summary>
        /// Visualizza schermata di login iniziale
        /// </summary>
        public static void MenuLogin()
        {
            Console.WriteLine("Benvenuti in Foodexp\n");
            Console.WriteLine("1. Accedi");
            Console.WriteLine("2. Registrati");
            Console.WriteLine("e. Esci");
        }

        /// <summary>
        /// Visualizza schermata principale Foodexp
        /// </summary>
        public static void MenuPrincipale()
        {
            Console.WriteLine("FOODEXP\n");
            Console.WriteLine("1. Frigorifero");
            Console.WriteLine("2. Lista della spesa");
            Console.WriteLine("3. Gestione alimenti");
            Console.WriteLine("4. Gestione categorie");
            Console.WriteLine("5. Gestione utenti");
            Console.WriteLine("e. Esci");
            Console.WriteLine("\nseleziona opzione");
        }

        /// <summary>
        /// Messaggio "...torno al menu principale" con attesa (default ms = 600).
        /// </summary>
        /// <param name="ms">Tempo di attesa per il Thread.Sleep (600 ms default)</param>
        public static void MessaggioTornaMenuPrincipale(int ms = 600)
        {
            Console.WriteLine("\n...torno al menu principale"); //TO DO spectre
            Thread.Sleep(ms);
        }

        /// <summary>
        /// Messaggio "...torno al menu precedente" con attesa (default ms = 600).
        /// </summary>
        /// <param name="ms">Tempo di attesa per il Thread.Sleep (600 ms default)</param>
        public static void MessaggioTornaMenuPrecedente(int ms = 600)
        {
            Console.WriteLine("\n...torno al menu precedente"); //TO DO spectre
            Thread.Sleep(ms);
        }

        /// <summary>
        /// Messaggio "...selezione errata" con attesa (default ms = 600). <br/>
        /// Puo anche ripristinare il cursore a fine messaggio cancellandolo.
        /// </summary>
        /// <param name="ms">Tempo di attesa per il Thread.Sleep (600 ms default)</param>
        /// <param name="resetCursore">Se true cancella il messaggio e ripristina il cursore a prima di esso</param>
        /// <param name="righe">Numero di righe da cancellare</param>
        /// <param name="left">Posizione sinistra del cursore da ripristinare</param>
        public static void MessaggioSelezioneErrata(int ms = 600, bool resetCursore = false, int righe = 0, int left = 0)
        {
            var cursore = Console.GetCursorPosition();
            Console.Write("\n...selezione errata"); //TO DO spectre
            Thread.Sleep(600);
            if (resetCursore)
            {
                Console.SetCursorPosition(left, cursore.Top - 1);
                for (int i = 0; i < righe; i++)
                {
                    Console.WriteLine("                                                              ");
                }
                Console.SetCursorPosition(left, cursore.Top - 1);
            }
        }

        /// <summary>
        /// Pulisce la console e ripristina il cursore a prima del messaggio
        /// </summary>
        /// <param name="left">Posizione left del cursore prima del messaggio</param>
        /// <param name="top">Posizione top del cursore prima del messaggio</param>
        public static void PulisciRiga(int left, int top)
        {
            Console.SetCursorPosition(left, top);
            for (int i = 0; i < top; i++)
            {
                Console.WriteLine("                                     ");
            }
            Console.SetCursorPosition(left, top);
        }
    }
}