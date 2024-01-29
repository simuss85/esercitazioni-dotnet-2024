class Program
{
    static void Main(string[] args)
    {
        #region "Tipi di dati e variabili"
        string benvenuto = "Benvenuto a MiniRisiko";
        string? input;
        string pathSave = @"save.txt";
        string[] player1 = ["Nome", "black"];
        string[] palyer2 = ["PC", "default"]; //in caso di gioco vs altro utente il nome verrà sovrascritto
        bool giocoInCorso = true;

        #endregion

        Console.Clear();
        //messaggio di benvenuto
        Console.WriteLine($"{benvenuto}\n");
        FingiDiPensare(5, 600);

        // ColoreUtente(player1);      //DEBUG 
        // ColoreUtente(palyer2);      //DEBUG
        // Console.ReadKey();          //DEBUG

        //visualizzo il menù iniziale del gioco
        CreaMenuSelezionePrincipale();

        do
        {
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

                case "4":

                    break;

                case "5":

                    break;

                default:
                    Console.WriteLine("Errore di digitazione");
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

    /*Simula un caricamento del programma mediante l'utilizzo del separatore '.'.
      Stampa i puntini in base al numero inserito in input e ritorna con il cursore
      sulla stessa linea.
      Si consiglia di inserire un tempo in ms entro i 1000.

      Input: int punti --> numero di puntini da visualizzare a schermo
             int ms -----> tempo di attesa in ms per la funzione Sleep
    */
    static void FingiDiPensare(int punti, int ms)
    {
        for (int i = 0; i < punti; i++)
        {
            Console.Write(".");
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

    static void RegoleGioco()
    {

    }
    #endregion

}