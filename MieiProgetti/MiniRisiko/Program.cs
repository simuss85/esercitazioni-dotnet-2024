﻿class Program
{
    static void Main(string[] args)
    {
        #region Tipi di dati e variabili
        string benvenuto = "Benvenuto a MiniRisiko";
        string? input;
        string pathSave = @"./files/save.csv";
        string pathRules = @"./files/rules.txt";
        string[] player1 = ["Nome", "black"];
        string[] palyer2 = ["PC", "default"]; //in caso di gioco vs altro utente il nome verrà sovrascritto
        bool giocoInCorso = true;
        bool primoAvvio = true;
        Random random = new Random();

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

        //metodo SimulaLancioDadi
        // for (int i = 0; i < 5; i++)
        // {
        //     int x = random.Next(1, 7);
        //     int y = random.Next(1, 7);
        //     SimulaLancioDadi(x, y);
        //     Console.ReadLine();
        // }

        // Console.ReadKey();     //ferma l'esecuzuone     
        #endregion

        do
        {
            Console.Clear();
            //messaggio di benvenuto
            Console.WriteLine($"{benvenuto}\n");
            if (primoAvvio)
            {
                SchermataLoading('.', 10, 100);
                primoAvvio = false;
            }

            //visualizzo il menù iniziale del gioco
            CreaMenuSelezionePrincipale();
            input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Clear();

                    Console.WriteLine("Il tuo avversario sarà il PC");
                    Console.Write("Inserisci il tuo nome: ");
                    player1[0] = Console.ReadLine()!;
                    Console.WriteLine("Seleziona il colore della tua armata");
                    MenuSelezioneColoreUtente();
                    Console.ReadKey();

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

    #region "Metodi interfaccia utente e grafica"

    //Visualizza il menu di selezione principale
    static void CreaMenuSelezionePrincipale()
    {
        Console.WriteLine("Seleziona l'opzione:\n");
        Console.WriteLine("1. Gioca contro il pc");
        Console.WriteLine("2. Gioca contro altro utente");
        Console.WriteLine("3. Carica ultima partita");
        Console.WriteLine("4. Regole del gioco");
        Console.WriteLine("5. Esci");
    }

    //Visualizza il menu per la selezione del colore giocatore
    static void MenuSelezioneColoreUtente()
    {
        var currentBackground = Console.BackgroundColor;    //memorizza il colore attuale
        Console.BackgroundColor = ConsoleColor.Red;
        Console.WriteLine("r. Rosso");
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.WriteLine("b. Blu");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.WriteLine("n. Nero");
        Console.BackgroundColor = ConsoleColor.Yellow;
        Console.WriteLine("g. Giallo");
        Console.BackgroundColor = ConsoleColor.Green;
        Console.WriteLine("v. Verde");
        Console.BackgroundColor = currentBackground;        //ripristina il colore attuale
    }

    //Visualizza le opzioni di gioco nel turno di ogni giocatore
    static void MenuDiGioco()
    {
        Console.WriteLine("1. Lancia i dadi");
        Console.WriteLine("2. Modalità rischio");
        Console.WriteLine("s. Salva il gioco ed esci");
        Console.WriteLine("'ctrl'+'M' Visualizza mappa");
    }

    //Visualizza una breve sintesi della mappa aggiornata con i colori
    static void DisegnaMappa()
    {
        Console.WriteLine("           Mappa del mondo");
        Console.WriteLine("   |AMERICA|EUROPA|ASIA|POLO NORD|");
        Console.WriteLine("|SUD AMERICA|AFRICA|OCEANIA|POLO SUD|");

    }

    //Visualizza le opzioni per la scelta della modalità di rischio
    static void MenuModalitaRischio()
    {
        Console.WriteLine("1. Scommetti su pari o dispari (costo 1 continente)");
        Console.WriteLine("2. Scommetti sul numero esatto (costo 2 continenti)");
        Console.WriteLine("r. Ritorna alla schermata precedente");
    }
    #endregion

    #region "Metodi accessori o utility"

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
        var currentBackground = Console.BackgroundColor;    //memorizzo il colore attuale
        var playerColor = currentBackground;

        switch (player[1])
        {
            case "red":
                playerColor = ConsoleColor.Red;
                break;

            case "blue":
                playerColor = ConsoleColor.Blue;
                break;

            case "black":
                playerColor = ConsoleColor.Black;
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
        Console.BackgroundColor = playerColor;
        Console.WriteLine($"{player[0]}");
        Console.BackgroundColor = currentBackground;
    }

    //Simula un lancio di dadi con grafica da terminale
    static void SimulaLancioDadi(int x, int y)
    {
        #region SEI
        string[] dadoSei =
        [
            " _______",
            "| *   * |",
            "| *   * |",
            "|_*___*_|",
        ];
        #endregion

        #region CINQUE
        string[] dadoCinque =
        [
            " _______",
            "| *   * |",
            "|   *   |",
            "|_*___*_|",
        ];
        #endregion

        #region QUATTRO
        string[] dadoQuattro =
        [
            " _______",
            "| *   * |",
            "|       |",
            "|_*___*_|",
        ];
        #endregion

        #region TRE
        string[] dadoTre =
        [
            " _______",
            "|     * |",
            "|   *   |",
            "|_*_____|",
        ];
        #endregion

        #region DUE
        string[] dadoDue =
        [
            " _______",
            "|     * |",
            "|       |",
            "|_*_____|",
        ];
        #endregion

        #region UNO
        string[] dadoUno =
        [
            " _______",
            "|       |",
            "|   *   |",
            "|_______|",
        ];
        #endregion

        string[][] dadi = [dadoSei, dadoCinque, dadoQuattro, dadoTre, dadoDue, dadoUno];

        for (int i = 0; i < 2; i++) //cicla 5 volte scrivi e cancella 
        {
            StampaDueDadi(dadi, true);
        }

        string[] dadoX = dadoUno, dadoY = dadoUno;
        string[][] risultato;

        //salvo il primo dado
        switch (x)
        {
            case 1:
                dadoX = dadoUno;
                break;

            case 2:
                dadoX = dadoDue;
                break;

            case 3:
                dadoX = dadoTre;
                break;

            case 4:
                dadoX = dadoQuattro;
                break;

            case 5:
                dadoX = dadoCinque;
                break;

            case 6:
                dadoX = dadoSei;
                break;

            default:
                Console.WriteLine("Errore di runtime! SimulaLancioDadi");
                return;
        }

        //salvo il primo dado
        switch (y)
        {
            case 1:
                dadoY = dadoUno;
                break;

            case 2:
                dadoY = dadoDue;
                break;

            case 3:
                dadoY = dadoTre;
                break;

            case 4:
                dadoY = dadoQuattro;
                break;

            case 5:
                dadoY = dadoCinque;
                break;

            case 6:
                dadoY = dadoSei;
                break;

            default:
                Console.WriteLine("Errore di runtime! SimulaLancioDadi");
                return;
        }

        risultato = [dadoX, dadoY];
        Console.Clear();
        for (int i = 0; i < risultato.Length; i++)
        {
            for (int j = 0; j < risultato[i].Length; j++)
            {
                try
                {
                    Console.WriteLine($" {risultato[i][j]}\t{risultato[i + 1][j]}");
                }
                catch (Exception)
                {
                    //non fa niente
                }
            }

        }
        Console.WriteLine($"\nHai ottenuto {x} + {y} = {x + y}");
    }

    /*Metodo accessorio che visualizza a schermo i dadi simulando il lancio
    
      Input: string[][] dadi ---> contiene elementi di tipo array che rappresentano i dadi
             bool ciclo --------> se true effettua una simulazione del rotolamento dei dadi
    */


    private static void StampaDueDadi(string[][] dadi, bool ciclo)
    {
        foreach (string[] n in dadi)
        {
            if (ciclo)
            {
                Console.Clear();
            }

            foreach (string dado in n)
            {
                Console.WriteLine($" {dado}\t{dado}");
            }
            if (ciclo)
            {
                Thread.Sleep(100);
            }

        }
    }

    #endregion

    #region "Metodi di gioco"

    static void GiocaVsPc()
    {

    }

    static void GiocaVsUtente()
    {

    }

    private static void AvvioGioco()
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