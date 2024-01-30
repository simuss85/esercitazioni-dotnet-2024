class Program
{
    static void Main(string[] args)
    {
        #region Tipi di dati e variabili
        string benvenuto = "Benvenuto a MiniRisiko";
        string? input;
        string pathSave = @"save.txt";
        string pathRules = @".rules.txt";
        string[] player1 = ["Nome", "black"];
        string[] palyer2 = ["PC", "default"]; //in caso di gioco vs altro utente il nome verrà sovrascritto
        bool giocoInCorso = true;
        bool primoAvvio = true;

        #endregion

        #region DEBUG
        //metodo ColoreUtente()
        // ColoreUtente(player1);       
        // ColoreUtente(palyer2);      

        //metodo ScriviRegole(solo formattazione testo)
        // string[] provaOutput = ScriviRegole();
        // foreach (string righe in provaOutput)
        // {
        //     Console.WriteLine(righe);
        // }

        //metodo RegoleGioco
        // RegoleGioco(pathRules);

        // Console.ReadKey();     //ferma l'esecuzuone     
        #endregion

        do
        { 
            Console.Clear();
            //messaggio di benvenuto
            Console.WriteLine($"{benvenuto}\n");
            if (primoAvvio)
            {
                SchermataLoading('.', 6, 100);
                primoAvvio = false;
            }
            
            //visualizzo il menù iniziale del gioco
            CreaMenuSelezionePrincipale();
            input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    GiocaVsPc();
                    break;

                case "2":
                    GiocaVsUtente();
                    break;

                case "3":
                    CaricaPartita(pathSave);
                    break;

                case "4":   //funzionante e testato
                    RegoleGioco(pathRules);
                    Console.WriteLine("Premi un tasto per tornare indietro...");
                    Console.ReadKey();
                    break;

                case "5":   //funzionante e testato
                    SchermataLoading('°', 20, 50);
                    Console.WriteLine("\nAlla prossima partita!!!");
                    return;

                default:
                    Console.WriteLine("Errore di digitazione");
                    SchermataLoading('°', 10, 100);
                    break;
            }

        }
        while (giocoInCorso);


    }

    #region "Metodi interfaccia l'utente"
    static void CreaMenuSelezionePrincipale()
    {
        Console.WriteLine("Seleziona l'opzione:\n");
        Console.WriteLine("1. Gioca contro il pc");
        Console.WriteLine("2. Gioca contro altro utente");
        Console.WriteLine("3. Carica ultima partita");
        Console.WriteLine("4. Regole del gioco");
        Console.WriteLine("5. Esci");
    }

    static void MenuSelezioneColoreUtente()
    {
        Console.WriteLine("r. Rosso");
        Console.WriteLine("b. Blu");
        Console.WriteLine("n. Nero");
        Console.WriteLine("g. Giallo");
        Console.WriteLine("v. Verde");
    }

    static void MenuDiGioco()
    {
        Console.WriteLine("1. Lancia i dadi");
        Console.WriteLine("2. Modalità rischio");
        Console.WriteLine("s. Salva il gioco ed esci");
        Console.WriteLine("'ctrl'+'M' Visualizza mappa");
    }

    static void DisegnaMappa()
    {
        Console.WriteLine("           Mappa del mondo");
        Console.WriteLine("   |AMERICA|EUROPA|ASIA|POLO NORD|");
        Console.WriteLine("|SUD AMERICA|AFRICA|OCEANIA|POLO SUD|");

    }

    static void MenuModalitaRischio()
    {
        Console.WriteLine("1. Scommetti su pari o dispari (costo 1 continente)");
        Console.WriteLine("2. Scommetti sul numero esatto (costo 2 continenti)");
        Console.WriteLine("r. Ritorna alla schermata precedente");
    }
    #endregion

    #region "Metodi accessori"

    /*Simula un caricamento del programma mediante l'utilizzo del separatore scelto
      dall'utente di tipo char.
      Stampa i puntini in base al numero inserito in input e ritorna con il cursore
      sulla stessa linea.
      Si consiglia di inserire un tempo in ms entro i 1000.

      Input: char c -----> tipo di carattere da utilizzare a schermo
             int punti --> numero di caratteri da visualizzare a schermo
             int ms -----> tempo di attesa in ms per la funzione Sleep
    */
    static void SchermataLoading(char c, int punti, int ms)
    {
        for (int i = 0; i < punti; i++)
        {
            Console.Write(c);
            Thread.Sleep(ms);
        }
        Console.Write("\r");
    }

    /*Cambia il colore del carattere in base all'utente attuale, prendere i dati dall'array 
      player. Scrive il nome del colore selezionato e resetta il colore di default
    
      Input: string[] player ---> array di due elementi ["nome","colore"]
      
    */
    static void ColoreUtente(string[] player)
    {
        // salvataggio colore corrente
        var currentColor = Console.ForegroundColor;
        var playerColor = currentColor;
        var currentBackground = Console.BackgroundColor;

        switch (player[1])
        {
            case "red":
                playerColor = ConsoleColor.Red;
                break;

            case "blue":
                playerColor = ConsoleColor.Blue;
                Console.BackgroundColor = ConsoleColor.White;
                break;

            case "black":
                playerColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                break;

            case "yellow":
                playerColor = ConsoleColor.Yellow;
                break;

            case "green":
                playerColor = ConsoleColor.Green;
                break;

            case "default":
                break;

            default:
                Console.WriteLine("Errore di runtime!!!");
                break;

        }
        Console.ForegroundColor = playerColor;
        Console.WriteLine($"{player[0]}");
        Console.ForegroundColor = currentColor;
        Console.BackgroundColor = currentBackground;
    }

    #endregion

    #region "Metodi di gioco"

    static void GiocaVsPc()
    {

    }

    static void GiocaVsUtente()
    {

    }

    /*Visualizza l'elenco delle partite in corso e permette la selezione di 
    una di esse ripristinando lo stato del gioco fino a quel momento. 
    Gestisce le eccezioni sui file

    
    INPUT: string pathSave ---> il path del file di salvataggio 
    */
    static void CaricaPartita(string path)
    {
        try
        {
            string[] file = File.ReadAllLines(path);
            foreach (string linea in file)
            {
                Console.WriteLine(linea);
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Problema di accesso al file!");
            return;
        }
    }

    static void SalvaPartita()
    {

    }

    /*Visualizza a schermo le regole del gioco presenti nel file rules.txt.
      Nel caso il file non esista lo crea da capo utilizzando il metodo accessorio
      ScriviRegole().
      #!NOTE ---> implementare il controllo nel caso il contenuto del file sia corrotto

      Input: string path ---> il percorso del file rules.txt
    */
    static void RegoleGioco(string path)
    {
        //se non esiste il file delle regole lo crea da zero
        if (!File.Exists(path))
        {
            File.Create(path).Close();
            string[] regole = ScriviRegole();

            foreach (string riga in regole)
            {
                File.AppendAllText(path, $"{riga}\n");
            }
        }

        string[] righe = File.ReadAllLines(path);
        //stampa a schermo delle regole
        foreach (string riga in righe)
        {
            Console.WriteLine(riga);
        }

    }

    /*Scrive un array di string contenente le regole del gioco formattate per righe

        Output: string[] regole ---> contiene le regole riga per riga
    */
    private static string[] ScriviRegole()
    {
        string[] regole =
        [
            "                               Descrizione del gioco:",
            "********************************************************************************************",
            "|Gioco stile Risiko versione super semplificata, con la mappa costituita da 8 continenti.  |",
            "|L'obiettivo finale è quello di conquistare tutti i continenti lanciando i due dadi.       |",
            "|Il gioco prevede anche una 'modalità rischio' attivabile solo 1 volta per giocatore.      |",
            "********************************************************************************************",
            "|Regole:                                                                                   |",
            "|1.Lancio dadi: con il punteggio maggiore 1 continente libero a scelta sulla mappa.        |",
            "|2.Pari o dispari(costa 1 continente): si scommette 1 proprio territorio e si utilizza un  |",
            "|  dado a 36 facce. Prima del lancio a turno si scommette se il numero che uscirà sarà pari|",
            "|  o dispari. Si scommette ad oltranza fino a quando uno dei due non sbaglia la predizione.|",
            "|  Si vince il continente scommesso dall'avversario più uno a scelta tra quelli liberi solo|",
            "|  se presenti.                                                                            |",
            "|3.Numero esatto(costa 2 continenti): si scommettono 2 propri continenti e si utilizza un  |",
            "|  dado a 50 facce. Prima del lancio entrambi i giocatori fanno una previsione sul numero  |",
            "|  che potrebbe uscire. Chi si avvicina di più entro un range minimo di 3 numeri vince la  |",
            "|  scommessa. In caso di parità si procede ad oltranza. Per range di 3 numeri si intende ad|",
            "|  esempio se il numero segreto è 23 un utente può vincere se il numero scommesso è uno tra|",
            "|  questi (21,22,23,24,25) e l'utente avversario scommette un numero più distante.         |",
            "|  Esempio: il numero segreto uscito è il 23                                               |",
            "|           utente1 sceglie 20; utente2 sceglie 22; VITTORIA utente2                       |",
            "|           utente1 sceglie 22; utente2 sceglie 24; PAREGGIO (stessa distanza nel range)   |",
            "|           utente1 sceglie 20; utente2 sceglie 40; PAREGGIO (entrambi fuori dal range)    |",
            "********************************************************************************************"
        ];

        return regole;
    }
    #endregion

}