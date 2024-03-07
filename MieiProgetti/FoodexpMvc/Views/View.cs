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
        /// Messaggio "...uscita" con attesa (default ms = 600).
        /// </summary>
        /// <param name="ms">Tempo di attesa per il Thread.Sleep (600 ms default)</param>
        public static void MessaggioSelezioneErrata(int ms = 600)
        {
            Console.WriteLine("\n...uscita"); //TO DO spectre
            Thread.Sleep(600);
        }
    }
}