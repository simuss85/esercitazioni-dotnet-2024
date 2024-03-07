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
        /// Visualizza opzioni sotto-menu "Filtra alimenti"
        /// </summary>
        public static void MenuFiltraAlimenti()
        {
            Console.WriteLine("Filtra alimenti\n");
            Console.WriteLine("1. Visualizza tutti");
            Console.WriteLine("2. Visualizza scaduti");
            Console.WriteLine("3. Visualizza in scadenza");
            Console.WriteLine("4. Visualizza in esaurimento");
            Console.WriteLine("5. Ordina per nome");
            Console.WriteLine("6. Ordina per data di scadenza");
            Console.WriteLine("7. Ordina per data di inserimento");
            Console.WriteLine("8. Ordina per quantità");
            Console.WriteLine("9. Ordina per categoria");
            Console.WriteLine("r. torna al menu principale");
            Console.WriteLine("\nseleziona opzione");
        }

        /// <summary>
        /// Visualizza opzioni sotto-meu "Lista della spesa"
        /// </summary>
        public static void MenuLitaSpesa()
        {
            Console.WriteLine("Lista della spesa\n");
            Console.WriteLine("1. Visualizza lista");
            Console.WriteLine("2. Inserisci alimento");
            Console.WriteLine("3. Modifica alimento");
            Console.WriteLine("4. Elimina alimento");
            Console.WriteLine("r. torna al menu principale");
            Console.WriteLine("\nseleziona opzione");
        }

        /// <summary>
        /// Visualizza opzioni sotto-meu "Gestione alimenti"
        /// </summary>
        public static void MenuGestioneAlimenti()
        {
            Console.WriteLine("Gestione alimenti\n");
            Console.WriteLine("1. Inserisci alimento");
            Console.WriteLine("2. Modifica alimento");
            Console.WriteLine("3. Elimina alimento");
            Console.WriteLine("r. torna al menu principale");
            Console.WriteLine("\nseleziona opzione");
        }

        /// <summary>
        /// Visualizza opzioni sotto-menu "Gestione categorie"
        /// </summary>
        public static void MenuGestioneCategorie()
        {
            Console.WriteLine("Gestione categorie\n");
            Console.WriteLine("1. Visualizza categorie");
            Console.WriteLine("2. Modifica categoria");
            Console.WriteLine("3. Elimina categoria");
            Console.WriteLine("r. torna al menu principale");
            Console.WriteLine("\nseleziona opzione");
        }

        /// <summary>
        /// Visualizza opzioni sotto-menu "Gestione utenti"
        /// </summary>
        public static void MenuGestioneUtenti()
        {
            Console.WriteLine("Gestione utenti\n");
            Console.WriteLine("1. Visualizza utenti");
            Console.WriteLine("2. Modifica password");
            Console.WriteLine("3. Elimina account");
            Console.WriteLine("r. tona al menu principale");
            Console.WriteLine("\nseleziona opzione");
        }

        public static void MessaggioTornaMenuPrincipale()
        {
            Console.WriteLine("\n...torno al menu principale"); //TO DO spectre
            Thread.Sleep(600);
        }

        public static void MessaggioSelezioneErrata()
        {
            Console.WriteLine("\n...uscita"); //TO DO spectre
            Thread.Sleep(600);
        }
    }
}