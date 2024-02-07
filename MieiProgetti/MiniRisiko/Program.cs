﻿class Program
{
    static void Main(string[] args)
    {
        #region Tipi di dati e variabili
        //variabili di inizializzazione file e sessione
        string pathSave = @"./files/save.csv";
        string pathCopia = @"./files/temp/copiaSave.csv"; //in caso di errore
        // string pathRules = @"./files/rules.txt";
        string ID = DateTime.Now.ToString();

        //varibili giocatore [nome,colore,lista dei territori da index 3 a 10 (max 8 territori)]
        string[] player1 = ["ID", "Nome", "1", "_", "_", "_", "_", "_", "_", "_", "_"];
        string[] player2 = ["ID", "CPU", "2", "_", "_", "_", "_", "_", "_", "_", "_"]; //in caso di gioco vs altro utente il nome verrà sovrascritto

        List<string> territoriP1 = [];  //contiene i territori del player1
        List<string> territoriP2 = [];  //contiene i territori del player2
        List<string> territori =    //elenco di tutti i territori
        [
            "AMERICA",
            "SUD AMERICA",
            "EUROPA",
            "AFRICA",
            "ASIA",
            "OCEANIA",
            "POLO NORD",
            "POLO SUD"
        ];

        string benvenuto = "Benvenuto a MiniRisiko";
        bool primoAvvio = true;     //per la prima schermata di loading
        bool vittoria = false;      //decreta la fine del gioco


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
        // Random random = new();
        // for (int i = 0; i < 5; i++)
        // {
        //     int x1 = random.Next(1, 7);
        //     int y1 = random.Next(1, 7);
        //     int x2 = random.Next(1, 7);
        //     int y2 = random.Next(1, 7);
        //     SimulaLancioDadi(x1, y1, x2, y2, player1, player2);
        //     Console.ReadLine();
        // }

        //metodo SalvaPartita
        // SalvaPartita(pathSave,player1,palyer2);

        //metodo SceltaColore
        // SceltaColore(player1);
        // Console.WriteLine($"{player1[1]},{player1[2]}");

        //metodo VisualizzaListaNumerata
        // VisualizzaListaNumerata(territori);

        // Console.ReadKey();     //ferma l'esecuzuone     
        #endregion

        //calcola ID della partita attuale e lo memorizzo nell 'utente
        ID = CalcolaID(ID);
        player1[0] = ID;
        player2[0] = ID;

        //verifico l'integrità del file di salvataggio e nel caso lo ripristino
        GestisciCSV(pathCopia, pathSave);

        do
        {
            Console.Clear();
            //messaggio di benvenuto
            Console.WriteLine($"{benvenuto}\n");
            if (primoAvvio)
            {
                SchermataLoading();
                primoAvvio = false;
            }

            //visualizzo il menù iniziale del gioco
            MenuSelezionePrincipale();
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            switch (keyInfo.KeyChar)
            {
                case '1':   //GIOCA VS CPU: 

                    //creo player1
                    Console.Clear();
                    CreaGiocatore(player1);
                    Console.Write("\npremi invio...");
                    Console.ReadKey();

                    //creo  CPU
                    CreaGiocatorePC(player2, player1[2]);

                    //messaggio di sfida
                    Console.Clear();
                    Console.Write("Si sfideranno ");
                    ScriviAColori(player1[1], player1[2], 'b');
                    Console.Write(" vs ");
                    ScriviAColori(player2[1], player2[2], 'b');
                    Console.Write("\n\npremi invio...");
                    Console.ReadKey();

                //SalvaPartita(pathSave, player1, player2); //DEBUG
                GiocaVsPc:

                    vittoria = Gioca(player1, player2, pathSave, territoriP1, territoriP2, territori);


                    break;

                case '2':   //GIOCA VS UTENTE: 

                    //creo player1
                    Console.Clear();
                    CreaGiocatore(player1);
                    Console.Write("\npremi invio...");
                    Console.ReadKey();

                    //creo player2
                    Console.Clear();
                    CreaGiocatore(player2, player1[2]);
                    Console.Write("\npremi invio...");
                    Console.ReadKey();

                    //messaggio di sfida
                    Console.Clear();
                    Console.Write("Si sfideranno ");
                    ScriviAColori(player1[1], player1[2], 'b');
                    Console.Write(" vs ");
                    ScriviAColori(player2[1], player2[2], 'b');
                    Console.Write("\n\npremi invio...");
                    Console.ReadKey();
                //SalvaPartita(pathSave, player1, player2);   //DEBUG

                GiocaVsUtente:

                    vittoria = Gioca(player1, player2, pathSave, territoriP1, territoriP2, territori);


                    break;

                case '3':   //CARICAMENTO: funzionante

                    //se ho un file di salvataggio carico la partita
                    if (CaricaPartita(pathSave, player1, player2, territoriP1, territoriP2, territori))
                    {
                        if (player2[1] == "CPU")
                        {
                            Console.Write("Bentornato ");
                            ScriviAColori(player1[1], player1[2], 'b');
                            Thread.Sleep(1500);
                            goto GiocaVsPc;
                        }
                        else
                        {
                            Console.Write("Bentornati ");
                            ScriviAColori(player1[1], player1[2], 'b');
                            Console.Write(" e ");
                            ScriviAColori(player2[1], player2[2], 'b');
                            Thread.Sleep(1500);
                            goto GiocaVsUtente;
                        }
                    }
                    else    //se non ho alcun salvataggio torna avviso e torno al menu principale
                    {
                        ScriviAColori("Nessun file di salvataggio presente", "rosso", 'f');
                        Thread.Sleep(1000);
                    }
                    break;

                case '4':   //REGOLE DI GIOCO: funzionante e testato
                    RegoleGioco();
                    Console.WriteLine("Premi un tasto per tornare indietro...");
                    Console.ReadKey();
                    break;

                case '5':   //EXIT: funzionante e testato
                    SchermataLoading();
                    Console.WriteLine();
                    ScriviAColori("Arrivederci alla prossima partita!!!", "blu", 'f');
                    vittoria = true;
                    break;

                default:
                    ScriviAColori("Selezione errata", "rosso", 'f');
                    Thread.Sleep(800);
                    break;
            }

        }
        while (!vittoria);


    }

    #region "Metodi interfaccia utente e grafica"

    //Visualizza il menu di selezione principale

    /// <summary>
    /// 
    /// </summary>
    static void MenuSelezionePrincipale()
    {
        Console.WriteLine("Seleziona l'opzione:\n");
        Console.WriteLine("1. Gioca contro il pc");
        Console.WriteLine("2. Gioca contro altro utente");
        Console.WriteLine("3. Carica ultima partita");
        Console.WriteLine("4. Regole del gioco");
        Console.WriteLine("5. Esci");
    }

    /*Visualizza il menu per la selezione del colore giocatore, nel caso
      tocchi al secondo giocatore il menù esclude il colore gia scelto.

      Input: string c -----> contiene il carattere del colore gia scelto
    */

    /// <summary>
    /// 
    /// </summary>
    /// <param name="c"></param>
    static void MenuSelezioneColoreUtente(string c)
    {
        var currentBackground = Console.BackgroundColor;    //memorizza il colore attuale
        // Console.WriteLine($"Valore passato : {c}\n");     //DEBUG
        Console.WriteLine("Seleziona il colore della tua armata");
        switch (c.ToLower())
        {
            case "r":
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine("b. Blu");
                Console.BackgroundColor = ConsoleColor.Magenta;
                Console.WriteLine("m. magenta");
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine("g. Giallo");
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine("v. Verde");
                break;

            case "b":
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("r. Rosso");
                Console.BackgroundColor = ConsoleColor.Magenta;
                Console.WriteLine("m. magenta");
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine("g. Giallo");
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine("v. Verde");
                break;

            case "m":
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("r. Rosso");
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine("b. Blu");
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine("g. Giallo");
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine("v. Verde");
                break;

            case "g":
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("r. Rosso");
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine("b. Blu");
                Console.BackgroundColor = ConsoleColor.Magenta;
                Console.WriteLine("m. magenta");
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine("v. Verde");
                break;

            case "v":
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("r. Rosso");
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine("b. Blu");
                Console.BackgroundColor = ConsoleColor.Magenta;
                Console.WriteLine("m. magenta");
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine("g. Giallo");
                break;

            default:
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("r. Rosso");
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine("b. Blu");
                Console.BackgroundColor = ConsoleColor.Magenta;
                Console.WriteLine("m. magenta");
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine("g. Giallo");
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine("v. Verde");
                break;
        }
        Console.BackgroundColor = currentBackground;        //ripristina il colore attuale
    }

    //Visualizza le opzioni di gioco nel turno di ogni giocatore

    /// <summary>
    /// 
    /// </summary>
    static void MenuDiGioco()
    {
        Console.WriteLine("Cosa vuoi fare?\n");
        Console.WriteLine("1. Lancia i dadi");
        Console.WriteLine("2. Modalità rischio");
        Console.WriteLine("s. Salva il gioco ed esci");
        Console.WriteLine("'ctrl'+'Y' Visualizza mappa");
    }

    //Visualizza una breve sintesi della mappa aggiornata con i colori

    /// <summary>
    /// 
    /// </summary>
    /// <param name="player1">Array dati del giocatore player1</param>
    /// <param name="player2">Array dati del giocatore player2</param>
    static void DisegnaMappa(string[] player1, string[] player2)
    {

        Console.WriteLine("\n           Mappa del mondo");
        Console.Write("   |");
        DisegnaTerritorio("AMERICA", player1, player2);
        DisegnaTerritorio("EUROPA", player1, player2);
        DisegnaTerritorio("ASIA", player1, player2);
        DisegnaTerritorio("POLO NORD", player1, player2);
        Console.Write("\n|");
        DisegnaTerritorio("SUD AMERICA", player1, player2);
        DisegnaTerritorio("AFRICA", player1, player2);
        DisegnaTerritorio("OCEANIA", player1, player2);
        DisegnaTerritorio("POLO SUD", player1, player2);
        Console.WriteLine();

    }

    /*Metodo accessorio a DisegnaMappa che colora i territori in base al colore del giocatore
      in suo possesso.

      INPUT: string territorio -----> il nome del territorio da controllare
             string[] player1 ------> array del giocatore player1
             string[] player2 ------> array del giocatore player2

    */

    /// <summary>
    /// 
    /// </summary>
    /// <param name="territorio">Il nome del territorio da controllare</param>
    /// <param name="player1">Array dati del giocatore player1</param>
    /// <param name="player2">Array dati del giocatore player2</param>
    static void DisegnaTerritorio(string territorio, string[] player1, string[] player2)
    {
        bool trovato = false;

        for (int i = 3; i < 11; i++)
        {
            if (player1[i] == territorio)
            {
                ScriviAColori(territorio, player1[2], 'f');
                Console.Write("|");
                trovato = true;
                break;
            }
            else if (player2[i] == territorio)
            {
                ScriviAColori(territorio, player2[2], 'f');
                Console.Write("|");
                trovato = true;
                break;
            }
        }

        if (!trovato)
        {
            Console.Write(territorio + "|");
        }

    }
    //Visualizza le opzioni per la scelta della modalità di rischio

    /// <summary>
    /// 
    /// </summary>
    static void MenuModalitaRischio()
    {
        ScriviAColori("MODALITA' RISCHIO", "magenta", 'f');
        Console.WriteLine();
        Console.WriteLine("1. Scommetti su pari o dispari (costo 1 territorio)");
        Console.WriteLine("2. Scommetti sul numero esatto (costo 2 territori)");
        Console.WriteLine("r. Regole\n");
    }
    #endregion

    #region "Metodi accessori o utility"

    //Stampa a video il contenuto della lista

    /// <summary>
    /// 
    /// </summary>
    /// <param name="lista">Lista da visualizzare come elenco numerato</param>
    static void VisualizzaListaNumerata(List<string> lista)
    {
        int count = 1;
        foreach (string elemento in lista)
        {
            Console.WriteLine($"{count}. {elemento}");
            count++;
        }
    }

    /*Metodo che calcola un ID univoco per la partita in corso, utile per i salvataggi.
      Utilizza la data attuale in formato DD/MM/YYYY hh:mm:ss, estrae la parte numerica, 
      la somma e restituisce un numero di tipo intero.

      Input: string ID -----> una stringa che contiene la data attuale 

    */

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    static string CalcolaID(string ID)
    {
        string[] valoriSingoli = ID.Split(['/', ':', ' ']);
        int totale = 0;
        foreach (string n in valoriSingoli)
        {
            totale += int.Parse(n);
        }
        return totale.ToString();
    }

    /*Simula un caricamento del programma mediante l'utilizzo del separatore scelto
      dall'utente di tipo char.
      Stampa i puntini in base al numero inserito in input e ritorna con il cursore
      sulla stessa linea.
      Si consiglia di inserire un tempo in ms entro i 1000.

      Input: char c -----> tipo di carattere da utilizzare a schermo
             int punti --> numero di caratteri da visualizzare a schermo
             int ms -----> tempo di attesa in ms per la funzione Sleep
    */

    /// <summary>
    /// 
    /// </summary>
    /// <param name="c"></param>
    /// <param name="punti"></param>
    /// <param name="ms"></param>
    static void SchermataLoading(char c = '°', int punti = 19, int ms = 50)
    {
        for (int i = 0; i < punti; i++)
        {
            Console.Write(c);
            Thread.Sleep(ms);
        }
        Console.Write("\r");
        Console.Write("                   \r");
    }

    /* Metodo ausiliario a LanciaDadi che prende i risultati e li visualizza in una tabella
       formattata a seconda del nome dei giocatoni nel formato seguente:

       ---> spazioA1___risultatoP1_spazioA2_tab_spazioB1___risultatoP2

       Lo spazio viene calcolato come la metà del nome di ogni gicatore.
       Lo spazio iniziale per ogni punteggio varia a seconda che il numero sia di 1 o due cifre.
       Non va a capo alla fine della stampa.

        INPUT: string[] player1 ------> array giocatore player1
               string[] player2 ------> array giocatore player2
               string[] risultati ----> formattati nel modo n1,n2
    */

    /// <summary>
    /// 
    /// </summary>
    /// <param name="player1">Array dati del giocatore player1</param>
    /// <param name="player2">Array dati del giocatore player2</param>
    /// <param name="risultati"></param>
    static void StampaPunteggioRound(string[] player1, string[] player2, string[] risultati)
    {
        string[] risultatiFormattati = new string[risultati.Length];

        string spazioA1 = "", spazioA2 = "", spazioB1 = "";
        string tab = "\t    ";
        string[] valori;    //per memrizzare i numeri

        //calcolo gli spazi prima e dopo il primo numero
        for (int i = 1; i < player1[1].Length / 2; i++)
        {
            spazioA1 += " ";
            spazioA2 += " ";

        }
        if (player1[1].Length % 2 == 1) //se il nome è dispari aggiungo uno spazio in coda
        {
            spazioA2 += " ";
        }

        //calcolo gli spazi prima e dopo il secondo numero
        for (int i = 1; i < player1[1].Length / 2; i++)
        {
            spazioB1 += " ";
        }

        int n = 0;  //contatore per array finale da stampare
        foreach (string risultato in risultati)
        {
            if (risultato == null)
            {
                continue;
            }
            valori = risultato.Split(",");  //divido i numeri 
                                            //nel caso di numero a 1 cifra aggingo uno spazio in testa

            risultatiFormattati[n] = spazioA1;

            //se il primo risultato ha 1 cifra aggiungo uno spazio
            if (valori[0].Length < 2)
            {
                risultatiFormattati[n] += " ";
            }

            risultatiFormattati[n] += valori[0] + spazioA2 + tab + spazioB1;

            ///se il secondo risultato ha 1 cifra aggiungo uno spazio
            if (valori[1].Length < 2)
            {
                risultatiFormattati[n] += " ";
            }

            risultatiFormattati[n] += valori[1];
            n++;
        }
        ScriviAColori(player1[1], player1[2], 'b');
        Console.Write("   vs   ");
        ScriviAColori(player2[1], player2[2], 'b');
        Console.WriteLine();
        foreach (string risultato in risultatiFormattati)
        {
            Console.WriteLine(risultato);
        }
    }

    /*Stampa sullo schermo la scritta "Giocatore è il tuo turno"
      con il colore del nome scelto dall'utente

      Input: string[] player -----> array player giocatore attuale
    */

    /// <summary>
    /// 
    /// </summary>
    /// <param name="player">Array dati del giocatore player attuale</param>
    static void MessaggioTurno(string[] player)
    {
        ScriviAColori(player[1], player[2], 'b');
        Console.WriteLine(" è il tuo turno");
    }

    /*Stampa il messaggio in rosso e attende 800 ms. Non va a capo
    */
    static void SelezioneErrata()
    {
        //caso digitazione errata
        ScriviAColori("Selezione errata", "rosso", 'f');
        Thread.Sleep(800);
    }

    /*Visualizza la frase sopra il lancio dei dadi e va a capo. Formatta
      gli spazi tra i nomi in base alla lunghezza del primo nome. A seconda
      degli inpunt esegue una stampa dei soli nomi oppure dei nomi con il risultato
      
      INPUT: string[] player1 -----> array del giocatore che attacca
             string[] player2 -----> array del giocatore che difende
             string p1--------- ---> i risultati del lancio dei dadi di player1
             string p2--------- ---> i risultati del lancio dei dadi di player2
    */

    /// <summary>
    /// 
    /// </summary>
    /// <param name="player1">Array dati del giocatore player1</param>
    /// <param name="player2">Array dati del giocatore player2</param>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    static void MessaggioRoundDadi(string[] player1, string[] player2, string? p1 = null, string? p2 = null)
    {
        int spazi;
        string messaggio = "";
        Console.Write(" ");
        if (p1 != null)
        {
            //levo il nome, il messaggio di base, il numero di caratteri del risultato (1 o 2)
            spazi = 26 - player1[1].Length - p1.Length;
            messaggio = " ha ottenuto ";
        }
        else
        {
            spazi = 39 - player1[1].Length;
        }

        ScriviAColori(player1[1], player1[2], 'b');
        Console.Write(messaggio + p1);
        for (int i = 0; i < spazi; i++)
        {
            Console.Write(" ");
        }
        ScriviAColori(player2[1], player2[2], 'b');
        Console.WriteLine(messaggio + p2 + "\n");
    }

    /*Stampa sullo schermo la scritta "Giocatore hai vinto la sfida"
      con il colore del nome scelto dall'utente

      Input: string[] player -----> array player giocatore attuale
             bool fineGioco ------> se true stampa il messaggio finale
    */

    /// <summary>
    /// 
    /// </summary>
    /// <param name="player">Array dati del giocatore player attuale</param>
    /// <param name="fineGioco"></param>
    static void MessaggioVittoria(string[] player, bool fineGioco = false)
    {
        if (fineGioco)
        {
            ScriviAColori("VITTORIA!!!", "verde", 'f');
            Thread.Sleep(1000);
            Console.Clear();

            ScriviAColori(player[1], player[2], 'b');
            Console.WriteLine(" hai vinto la partita.");
            Console.WriteLine("\n premi invio per uscire!");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine();
            ScriviAColori(player[1], player[2], 'b');
            Console.WriteLine(" hai vinto la sfida");
        }

    }

    /*Stampa sullo schermo la scritta "Giocatore hai vinto la sfida"
      con il colore del nome scelto dall'utente

      Input: string[] player -----> array player giocatore attuale
    */

    /// <summary>
    /// 
    /// </summary>
    /// <param name="player">Array dati del giocatore player attuale</param>
    static void MessaggioSconfitta(string[] player)
    {
        ScriviAColori(player[1], player[2], 'b');
        Console.WriteLine(" hai perso la sfida");
    }

    /*Scrive nel formato del player attuale il messaggio di conquista
      del territorio. 
      Va a capo dopo il messaggio

      Input: string[] player ------> array giocatore attuale
             string territorio ----> il territorio appena conquistato/selezionato
    */

    /// <summary>
    /// /
    /// </summary>
    /// <param name="player">Array dati del giocatore player attuale</param>
    /// <param name="territorio">Il territorio selezionato/conquistato</param>
    static void MessaggioTerritorioConquistato(string[] player, string territorio)
    {
        ScriviAColori(player[1], player[2], 'b');
        Console.Write(" hai conquistato il seguente territorio: ");
        ScriviAColori(territorio, player[2], 'f');
        Console.WriteLine();
    }

    /*Esegue la stampa a video di un messaggio a colori scelto dall'utente
      tra i seguenti: -rosso
                      -verde
                      -magenta
                      -blu
                      -giallo
      Il messaggio non prevede il ritorno a capo.

      Input: string messaggio -----> il messaggio da stampare a schermo
             string colore --------> il colore scelto per la stampa
             char opzione ---------> f cambia il testo; b cambia lo sfondo
    
    */

    /// <summary>
    /// 
    /// </summary>
    /// <param name="messaggio"></param>
    /// <param name="colore"></param>
    /// <param name="opzione"></param>
    static void ScriviAColori(string messaggio, string colore, char opzione = 'f')
    {
        var currentColor = Console.ForegroundColor;         //salvo il carattere attuale
        var currentBackground = Console.BackgroundColor;    //salvo lo sfondo attuale
        switch (colore)
        {
            case "rosso":
                if (opzione == 'f')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                }
                break;

            case "verde":
                if (opzione == 'f')
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                }
                break;

            case "magenta":
                if (opzione == 'f')
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Magenta;
                }
                break;

            case "blu":
                if (opzione == 'f')
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                }
                break;

            case "giallo":
                if (opzione == 'f')
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                }
                break;

            default:
                Console.WriteLine("Errore [MessaggioAColori]!!!");
                break;
        }
        Console.Write(messaggio);
        Console.ForegroundColor = currentColor;         //ripristino colore testo
        Console.BackgroundColor = currentBackground;    //ripristimo colore sfondo
    }

    /*Metodo che assegna il colore all'utente in base alla sua scelta.
      Scrive il risultato nell array player1[2] = "colore"; player2[2] = "colore"

      Input: string[] player -----> array del giocatore player1 o player2
              string c --------> indica il colore che è gia stato preso
    */

    /// <summary>
    /// 
    /// </summary>
    /// <param name="player">Array dati del giocatore player attuale</param>
    /// <param name="c"></param>
    static void SceltaColore(string[] player, string c)
    {
        bool corretto = false;
        do  //controlla finche l'inserimento non è corretto
        {
            Console.Clear();
            MenuSelezioneColoreUtente(c);
            Console.Write("\nScegli: ");
            string input = Console.ReadLine()!.ToLower();
            switch (input)
            {
                case "r" when c != input:
                    player[2] = "rosso";
                    corretto = true;
                    break;

                case "b" when c != input:
                    player[2] = "blu";
                    corretto = true;
                    break;

                case "m" when c != input:
                    player[2] = "magenta";
                    corretto = true;
                    break;

                case "g" when c != input:
                    player[2] = "giallo";
                    corretto = true;
                    break;

                case "v" when c != input:
                    player[2] = "verde";
                    corretto = true;
                    break;

                default:
                    //caso digitazione errata
                    SelezioneErrata();
                    corretto = false;
                    break;
            }
        }
        while (!corretto);
    }

    /*Simula un lancio di dadi con grafica da terminale
      Restituisce la somma dei dadi 

      Input: int x ------> valore random dadoX
             int y ------> valore random dadoY
    */

    /// <summary>
    /// 
    /// </summary>
    /// <param name="x1"></param>
    /// <param name="y1"></param>
    /// <param name="x2"></param>
    /// <param name="y2"></param>
    /// <param name="player1">Array dati del giocatore player1</param>
    /// <param name="player2">Array dati del giocatore player2</param>
    static void SimulaLancioDadi(int x1, int y1, int x2, int y2, string[] player1, string[] player2)
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

        string[][] dadi = [dadoUno, dadoDue, dadoTre, dadoQuattro, dadoCinque, dadoSei];

        SimulaRotazioneDadi(dadi, player1, player2, 2);

        //creo i contenitori per i 4 dadi da stampare
        string[] dado1P1, dado2P1, dado1P2, dado2P2;

        //salvo i pattern dei numeri usciti 
        dado1P1 = AssegnaPatternDado(x1, dadi);
        dado2P1 = AssegnaPatternDado(y1, dadi);
        dado1P2 = AssegnaPatternDado(x2, dadi);
        dado2P2 = AssegnaPatternDado(y2, dadi);

        string[][] risultato = [dado1P1, dado2P1, dado1P2, dado2P2];
        Console.Clear();
        Stampa4Dadi(risultato);
    }

    /*Metodo accessorio a SimulaLancioDadi che visualizza a schermo una coppia di dadi
    
      Input: string[][] totDadi ---> contiene elementi di tipo array che rappresentano i dadi
    */

    /// <summary>
    /// 
    /// </summary>
    /// <param name="totDadi"></param>
    static void Stampa4Dadi(string[][] totDadi)
    {
        for (int i = 0; i < 1; i++)
        {
            for (int j = 0; j < totDadi[i].Length; j++)
            {
                try
                {
                    Console.WriteLine($" {totDadi[i][j]}\t{totDadi[i + 1][j]}" + "\t\t" +
                                      $"{totDadi[i + 2][j]}\t{totDadi[i + 3][j]}");
                }
                catch (Exception)
                {
                    //non fa niente
                }
            }
        }
    }

    /* Metodo accessorio di SimulaLancioDadi che assegna il pattern corretto al numero uscito
    */

    /// <summary>
    /// 
    /// </summary>
    /// <param name="n"></param>
    /// <param name="dadi"></param>
    /// <returns></returns>
    static string[] AssegnaPatternDado(int n, string[][] dadi)
    {
        string[] dado = new string[4];

        switch (n)
        {
            case 1:
                for (int j = 0; j < dado.Length; j++)
                {
                    dado[j] = dadi[n - 1][j];
                }
                break;

            case 2:
                for (int j = 0; j < dado.Length; j++)
                {
                    dado[j] = dadi[n - 1][j];
                }
                break;

            case 3:
                for (int j = 0; j < dado.Length; j++)
                {
                    dado[j] = dadi[n - 1][j];
                }
                break;

            case 4:
                for (int j = 0; j < dado.Length; j++)
                {
                    dado[j] = dadi[n - 1][j];
                }
                break;

            case 5:
                for (int j = 0; j < dado.Length; j++)
                {
                    dado[j] = dadi[n - 1][j];
                }
                break;

            case 6:
                for (int j = 0; j < dado.Length; j++)
                {
                    dado[j] = dadi[n - 1][j];
                }
                break;

            default:
                ScriviAColori("Errore [AssegnaPatternDado]!!!", "rosso", 'f');
                break;
        }
        // Console.WriteLine("Numero dado: " + n);  //DEBUG
        // Console.ReadKey();                              //DEBUG
        // foreach (string linea in dado)      //DEBUG
        // {
        //     Console.WriteLine(linea);
        // }
        // Console.ReadKey();                  //DEBUG
        return dado;
    }


    /*Metodo accessorio di SimulaLancioDadi che crea un animazione di 4 dadi 

      Input: string[][] dadi ----> contiene elementi di tipo array che rappresentano i dadi
             string[] player1 ---> array del giocatore player1 (usa il nome)
             string[] player2 ---> array del giocatore player2 (usa il nome)
             int xRotazioni -----> 6 * xRotazioni = totale rotazioni dado
    */

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dadi"></param>
    /// <param name="player1">Array dati del giocatore player1</param>
    /// <param name="player2">Array dati del giocatore player2</param>
    /// <param name="xRotazioni"></param>
    private static void SimulaRotazioneDadi(string[][] dadi, string[] player1, string[] player2, int xRotazioni)
    {
        for (int i = 0; i < xRotazioni; i++)
        {
            foreach (string[] n in dadi)
            {
                Console.Clear();
                foreach (string dado in n)
                {

                    Console.WriteLine($" {dado}\t{dado}\t\t{dado}\t{dado}");
                }
                Console.WriteLine();
                MessaggioRoundDadi(player1, player2);
                Thread.Sleep(100);  //default 100
            }
        }
    }

    #endregion

    #region "Metodi di gioco"

    /*Avvia il gioco contro il pc 
    */

    /// <summary>
    /// 
    /// </summary>
    /// <param name="player1">Array dati del giocatore player1</param>
    /// <param name="player2">Array dati del giocatore player2</param>
    /// <param name="pathSave">Path del file di salvataggio</param>
    /// <param name="territoriP1">Lista dei territori conquistati dal giocatore player1</param>
    /// <param name="territoriP2">Lista dei territori conquistati dal giocatore player2</param>
    /// <param name="territori">Lista dei territori liberi</param>
    /// <returns></returns>
    static bool Gioca(string[] player1, string[] player2, string pathSave,
                        List<string> territoriP1, List<string> territoriP2, List<string> territori)
    {
        char rispostaPlayer;
        int vincitore;    //int[0] = il numero del vincitore, 
        bool cambioTurno = false;   //se true si cambia l'ordine dei giocatori attivi
        bool vittoria = false; //finchè true si può giocare 
        Console.Clear();

        while (!vittoria)
        {
            if (!cambioTurno)   //inizia player1
            {
                rispostaPlayer = SceltaGioco(player1, player2);
                // Console.WriteLine("Risposta player1: " + rispostaPlayer);   //DEBUG
                // Console.ReadKey();                                          //DEBUG

            }
            else        //inizia player2
            {
                rispostaPlayer = SceltaGioco(player2, player1);
                // Console.WriteLine("Risposta player2: " + rispostaPlayer);   //DEBUG
                // Console.ReadKey();                                          //DEBUG
            }

            switch (rispostaPlayer)
            {
                case '1':   //lancio dadi

                    ScriviAColori("Lancio dadi", "verde", 'f');
                    Console.WriteLine("\n\npremi invio...");
                    Console.ReadKey();

                    if (!cambioTurno)
                    {
                        vincitore = LanciaDadi(player1, player2);   //turno player1

                        cambioTurno = true;

                        if (vincitore == 1) //se vince player1
                        {
                            MessaggioVittoria(player1);
                            Console.Write("\npremi invio...");
                            Console.ReadKey();
                            Console.Clear();

                            //se player1 vince può scegliere i territori
                            ConquistaTerritorio(player1, territoriP1, territori);

                            if (territoriP1.Count == 8) //vince il gioco player1
                            {
                                MessaggioVittoria(player1, true);
                                vittoria = true;
                            }
                        }
                        else        //se vince player2
                        {
                            MessaggioSconfitta(player1);
                            Console.Write("\npremi invio...");
                            Console.ReadKey();
                            Console.Clear();
                        }

                    }
                    else
                    {
                        vincitore = LanciaDadi(player2, player1);   //turno player2

                        cambioTurno = false;

                        if (vincitore == 1)
                        {
                            MessaggioVittoria(player2);
                            Console.Write("\npremi invio...");
                            Console.ReadKey();
                            Console.Clear();

                            //se player2 vince può scegliere i territori
                            ConquistaTerritorio(player2, territoriP2, territori);

                            if (territoriP2.Count == 8) //vince il gioco player1
                            {
                                MessaggioVittoria(player2, true);
                                vittoria = true;
                            }
                        }
                        else
                        {
                            MessaggioSconfitta(player2);
                            Console.Write("\npremi invio...");
                            Console.ReadKey();
                            Console.Clear();
                        }
                    }
                    break;

                case '2':   //rischio

                    char opz;   //gestisce la scelta dell'utente della modalità rischio

                    if (!cambioTurno)   //se il turno è di player1
                    {
                        opz = SceltaRischio(player1);
                        if (opz == '1')
                        {
                            PariDispari(player1, player2);
                        }
                        else if (opz == '2')
                        {
                            IndovinaIlNumero(player1, player2, territoriP1, territoriP2);
                        }
                        else if (opz == 'r')
                        {
                            DisegnaMappa(player1, player2);
                        }
                        // Console.WriteLine("Risposta player1: " + rispostaPlayer);   //DEBUG
                        // Console.ReadKey();                                          //DEBUG
                    }
                    else    //se il turno è di player2
                    {
                        opz = SceltaRischio(player2);
                        if (opz == '1')
                        {
                            PariDispari(player2, player1);
                        }
                        else if (opz == '2')
                        {
                            IndovinaIlNumero(player2, player1, territoriP2, territoriP1);
                        }
                        else if (opz == 'r')
                        {
                            DisegnaMappa(player2, player1);
                        }
                        // Console.WriteLine("Risposta player2: " + rispostaPlayer);   //DEBUG
                        // Console.ReadKey();                                          //DEBUG
                    }
                    Console.WriteLine("Ritorno al menu di gioco...");
                    Thread.Sleep(800);
                    break;

                case 's':   //salva
                    vittoria = SalvaPartita(pathSave, player1, player2, territoriP1, territoriP2); //se va tutto bene, torna il valore true
                    break;

                default:
                    Console.WriteLine("Errore [Gioca]!!!");
                    break;
            }
        }
        return vittoria;
    }

    /*Esegue il calcolo dei numeri random, simula graficamente la rotazione
      dei dadi e visualizza a schermo il vincitore del turno alla meglio di 5,
      ovvero il primo che arriva a 3 vittorie vince il turno.

      Input: string[] player1 -----> array player1
             string[] player2 -----> array player2

      Output: int -------> 1 se vince player1;  2 se vince player2
    */

    /// <summary>
    /// 
    /// </summary>
    /// <param name="player1">Array dati del giocatore player1</param>
    /// <param name="player2">Array dati del giocatore player2</param>
    /// <returns></returns>
    static int LanciaDadi(string[] player1, string[] player2)
    {
        int vittorieP1 = 0, vittorieP2 = 0;  //il primo che arriva a 3 vince
        int vincitore;   //1 o 2 in caso di vittoria player1 o player2
        int risultatoP1, risultatoP2;
        string[] risultati = new string[5]; //memorizzo i lanci fatti di ogni giocatore 
        int turno = 0;
        int dado1P1, dado2P1, dado1P2, dado2P2;
        Random random = new();
        bool cambioTurno = false;

        do
        {
            //valore dadi player1
            dado1P1 = random.Next(1, 7);
            dado2P1 = random.Next(1, 7);
            risultatoP1 = dado1P1 + dado2P1;
            //valore dadi player2
            dado1P2 = random.Next(1, 7);
            dado2P2 = random.Next(1, 7);
            risultatoP2 = dado1P2 + dado2P2;
            SimulaLancioDadi(dado1P1, dado2P1, dado1P2, dado2P2, player1, player2);
            Console.WriteLine();

            MessaggioRoundDadi(player1, player2, risultatoP1.ToString(), risultatoP2.ToString());

            risultati[turno] = $"{risultatoP1},{risultatoP2}";
            turno++;

            Console.Write(" ");
            if (risultatoP1 < risultatoP2)
            {   //vince player2
                vincitore = 2;
                vittorieP1++;
                if (vittorieP1 == 3)
                {
                    cambioTurno = true;
                }
                Console.Write("\t\t");
                ScriviAColori(player2[1], player2[2], 'b');
            }
            else
            {   //vince player1
                vincitore = 1;
                vittorieP2++;
                if (vittorieP2 == 3)
                {
                    cambioTurno = true;
                }
                Console.Write("\t\t");
                ScriviAColori(player1[1], player1[2], 'b');
            }
            Console.Write($" vince il round {turno}\n");
            Console.Write("\n\t\tpremi invio...");
            Console.ReadKey();
            Console.Clear();

        }
        while (!cambioTurno);

        //risultati a schermo
        //riga del titolo
        Console.WriteLine("Risultato turno:\n");
        StampaPunteggioRound(player1, player2, risultati);
        Console.WriteLine();

        return vincitore;
    }

    /* Permette di selezionare il territorio dalla lista dei territori disponibili
       Se c'è solo 1 territorio nella lista allora lo assegna in automatico
    */

    /// <summary>
    /// 
    /// </summary>
    /// <param name="player">Array dati del giocatore player attuale</param>
    /// <param name="territoriP">Lista dei territori conquistati dal giocatore player attuale</param>
    /// <param name="territori">Lista dei territori liberi</param>
    static void ConquistaTerritorio(string[] player, List<string> territoriP, List<string> territori)
    {
        //se c'è ancora un territorio libero
        if (territori.Count > 0)
        {
            if (territori.Count == 1)   //se rimane solo 1 lo assegna in automatico
            {
                ScriviAColori("E' rimasto un solo territorio libero\n", "verde", 'f');
                Thread.Sleep(1500);
                Console.Clear();

                MessaggioTerritorioConquistato(player, territori.First());
                AssegnaTerritorio(territoriP, territori.First(), territori);
                Console.WriteLine("\npremi invio...");
                Console.ReadKey();
                Console.Clear();
            }
            else            //permette la scelta dalla lista territori aggiornata
            {
                int n = 0;
                bool corretto = false;
                string? input;
                do
                {
                    Console.Clear();

                    ScriviAColori(player[1], player[2], 'b');
                    Console.WriteLine(" scegli il territorio:\n");
                    VisualizzaListaNumerata(territori);
                    Console.Write("\nScegli: ");

                    input = Console.ReadLine()!;
                    if (!int.TryParse(input, out n))
                    {
                        ScriviAColori("Seleziona correttamente il territorio\r", "rosso", 'f');
                        Thread.Sleep(800);
                    }
                    else if (n < 1 || n > territori.Count)
                    {
                        ScriviAColori("Seleziona correttamente il territorio\r", "rosso", 'f');
                        Thread.Sleep(800);
                    }
                    else
                    {
                        n--;
                        corretto = true;
                    }
                }
                while (!corretto);

                Console.Clear();
                MessaggioTerritorioConquistato(player, territori.ElementAt(n));
                AssegnaTerritorio(territoriP, territori.ElementAt(n), territori);
                Console.WriteLine("\nLista aggiornata:\n");
                VisualizzaListaNumerata(territori);
                Console.Write("\npremi invio...");
                Console.ReadKey();
                Console.Clear();

            }
        }
        else
        {
            Console.WriteLine("DEVI CONQUISTARE DAL GIOCATORE AVVERSARIO");
            Console.ReadKey();
            Console.Clear();
        }
    }

    /*Esegue il salvataggio del territorio nell'array player, elimina il territorio dalla lista

      Input: List<string> player -------------> array del giocatore che effettua la scelta
             string territorioScelto -----> il nome del territorio selezionato 
             List<string> territori ------> elenco aggiornato dei territori liberi
    */

    /// <summary>
    /// 
    /// </summary>
    /// <param name="player1">Array dati del giocatore player1</param>
    /// <param name="territorioScelto">Il nome del territorio scelto dall'utente</param>
    /// <param name="territori">Lista dei territori liberi</param>
    static void AssegnaTerritorio(List<string> player1, string territorioScelto, List<string> territori)

    {
        //aggiunge il territorio nella lista utente
        if (player1.Contains(territorioScelto))
        {
            ScriviAColori("Errore [SceltaTerritorio]!!!", "rosso", 'f');
        }
        else
        {
            player1.Add(territorioScelto);
            territori.Remove(territorioScelto);
        }
        // Console.WriteLine("Eseguito");  //DEBUG
        // Console.ReadKey();              //DEBUG
    }

    /*Copia i territori conquistati dal giocatore nel suo array in modo da
      essere pronto per il salvataggio sul file csv.

      Input: string[] player ------------> array del player
             List<string> territoriP ----> lista dei suoi territori

    */

    /// <summary>
    /// 
    /// </summary>
    /// <param name="player">Array dati del giocatore player attuale</param>
    /// <param name="territoriP">Lista dei territori conquistati dal giocatore player attuale</param>
    static void MemorizzaSuArray(string[] player, List<string> territoriP)
    {
        int n = 3;
        foreach (string territorio in territoriP)   //salvo i territori del player
        {                                           //nel suo array personale 
            player[n] = territorio;                 //a partire dall'indice 3 
            n++;
        }
    }

    /*Copia i territori conquistati dal giocatore nel suo array in modo da
      essere pronto per il salvataggio sul file csv.

      Input: string[] player ------> array del giocatore caricato
             List<string> listaP --> lista vuota dei suoi territori
    */

    /// <summary>
    /// 
    /// </summary>
    /// <param name="player">Array dati del giocatore player attuale</param>
    /// <param name="territoriP">Lista dei territori conquistati dal giocatore player attuale</param>
    /// <param name="territori">Lista dei territori liberi</param>
    static void MemorizzaSuLista(string[] player, List<string> territoriP, List<string> territori)
    {
        for (int i = 3; i < player.Length; i++)
        {
            if (player[i] == "_")
            {
                // Console.WriteLine("DEBUG FINE TERRITORI!!!");   //DEBUG
                // Console.ReadKey();                              //DEBUG
            }
            else
            {
                territoriP.Add(player[i]);
                // Console.WriteLine("DEBUG: aggiunto alla lista " + player[i]);   //DEBUG
                // VisualizzaListaNumerata(territoriP);                           //DEBUG
                // Console.WriteLine();                                           //DEBUG
                // Console.ReadKey();                                             //DEBUG
                territori.Remove(player[i]);
                // Console.WriteLine("DEBUG: rimosso dalla lista " + player[i]);   //DEBUG
                // VisualizzaListaNumerata(territori);                //DEBUG
                // Console.ReadKey();                                 //DEBUG
            }
        }
    }

    /*Permette di aggiornare array player con i dati caricati e presenti
      nell array copiaDaFile

      INPUT: string[] copiaDaFile ------> copia dei dati caricati
             string[] player -----------> array player da aggiornare
    */

    /// <summary>
    /// 
    /// </summary>
    /// <param name="copiaDaFile"></param>
    /// <param name="player">Array dati del giocatore player attuale</param>
    static void CaricaPlayer(string[] copiaDaFile, string[] player)
    {
        for (int i = 0; i < player.Length; i++)
        {
            player[i] = copiaDaFile[i];
        }
    }
    /*Riptistina gli array players dopo il caricamento dei dati dal file save.csv
      Gestisce le eccezioni sui file

      INPUT: string pathSave ----> il path del file di salvataggio 
           string[] player1 ---> array del player1
           string[] player2 ---> array del player2
    */

    /// <summary>
    /// 
    /// </summary>
    /// <param name="pathSave"></param>
    /// <param name="player1">Array dati del giocatore player1</param>
    /// <param name="player2">Array dati del giocatore player2</param>
    /// <param name="territoriP1">Lista dei territori conquistati dal giocatore player1</param>
    /// <param name="territoriP2">Lista dei territori conquistati dal giocatore player1</param>
    /// <param name="territori">Lista dei territori liberi</param>
    /// <returns></returns>
    static bool CaricaPartita(string pathSave, string[] player1, string[] player2,
                        List<string> territoriP1, List<string> territoriP2, List<string> territori)
    {
        bool trovato = false;

        if (File.ReadAllLines(pathSave).Length < 3)
        {
            return trovato;
        }

        do
        {
            Console.WriteLine("Inserisci codice del salvataggio: ");
            string ID = InputCodiceID();
            //Console.WriteLine("DEBUG ID: " + ID);   //DEBUG
            //Console.ReadKey();

            try
            {
                string[] file = File.ReadAllLines(pathSave);
                Console.Clear();
                Console.WriteLine("Lettura del file in corso");
                SchermataLoading('°', 15, 60);

                int contaRighe = 0;
                foreach (string riga in file)   //controllo se presente nel file
                {
                    if (!riga.StartsWith(ID))
                    {
                        contaRighe++;   //indica l'ultima riga in cui compare ID (quella del player2 )
                    }
                    else
                    {
                        trovato = true;
                        break;
                    }
                }

                if (trovato)
                {                           //se è nella lista eseguo la copia ed elimino dal file e
                    CaricaPlayer(file[contaRighe].Split(","), player1);       //formatto a 11 index
                    CaricaPlayer(file[contaRighe + 1].Split(","), player2);   //formatto a 11 index

                    EliminaRigaDalFile(contaRighe, pathSave);    //aggiorno il file 
                }
                else
                {
                    ScriviAColori("Codice salvataggio errato o inesistente\r", "rosso", 'f');
                    Thread.Sleep(800);
                }
            }
            catch (Exception)
            {
                // Console.WriteLine(e.Message);
                ScriviAColori("\nNessun salvataggio trovato", "rosso", 'f');
                Thread.Sleep(800);
            }
        }
        while (!trovato);

        //aggiorno le liste dei territori con i dati caricati
        // Console.Clear();                                    //DEBUG
        // Console.WriteLine("Memorizzo p1");                  //DEBUG
        MemorizzaSuLista(player1, territoriP1, territori);
        // Console.ReadKey();                                  //DEBUG
        // Console.WriteLine("Memorizzo p2");                  //DEBUG
        MemorizzaSuLista(player2, territoriP2, territori);

        ScriviAColori("Caricamento completato!", "verde", 'f');
        Thread.Sleep(1200);
        Console.Clear();

        return trovato;
    }

    /*Metodo accessorio per la gestione del file csv che in caso di errori
      durante l'esecuzione*/
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="pathCopia"></param>
    /// <param name="pathSave"></param>
    static void GestisciCSV(string pathCopia, string pathSave)
    {
        //se il file è corrotto o non esiste, lo creo
        if (!File.Exists(pathSave))
        {
            File.Create(pathSave).Close();
        }

        if (File.ReadAllLines(pathSave).Length < 1) //nel caso in cui il file è vuoto
        {
            File.WriteAllText(pathSave, "ID,Giocatori,Colori,t,e,r,r,i,t,o,r,\n");
            Console.WriteLine("\nFile creato e inizializzato.");
        }

        //creo il file di copia 
        if (!File.Exists(pathCopia))
        {
            File.Create(pathCopia).Close();
        }
        //nel caso in cui il file di salvataggio ha delle righe in meno rispetto alla copia
        //ho sicuramente un problema di integrità del file e lo devo ripristinare dalla copia
        if (File.ReadAllLines(pathSave).Length < File.ReadAllLines(pathCopia).Length)
        {
            //ripristino il file di salvataggio
            File.WriteAllLines(pathSave, File.ReadAllLines(pathCopia));
        }
        if (File.ReadAllLines(pathSave).Length > File.ReadAllLines(pathCopia).Length)
        {   //creo una copia di sicurezza del file save.txt
            File.WriteAllLines(pathCopia, File.ReadAllLines(pathSave));
        }
    }

    /// <summary>
    /// Metodo accessorio che prende il file dopo essere stato caricato ed elimina <br/>
    /// tutte le righe del salvataggio attuale.
    /// </summary>
    /// <param name="index">Indice della riga da cancellare</param>
    /// <param name="path">Path del file da cui eliminare le righe</param>
    static void EliminaRigaDalFile(int index, string path)
    {
        string[] righe = File.ReadAllLines(path);
        string[] copia = new string[righe.Length - 2]; //creo una copia con 2 elementi in meno
        righe[index] = "_";
        righe[index + 1] = "_";

        // Console.WriteLine("righe file originale: " + righe.Length); //DEBUG
        // Console.WriteLine("righe file aggiornato: " + copia.Length);//DEBUG
        // Console.ReadKey();                                          //DEBUG

        int count = 0;

        foreach (string riga in righe)      //copio tutto l'array del file tranne le 2 righe vuote
        {
            // Console.WriteLine(riga);        //DEBUG
            // Console.ReadKey();              //DEBUG

            if (riga != "_")
            {
                copia[count] = riga;
                // Console.WriteLine("copia: " + copia[count]);    //DEBUG
                count++;
            }
        }
        File.WriteAllLines(path, copia);    //eseguo la copia del file aggiornata
    }

    /// <summary>
    /// Metodo accessorio al metodo <i> CaricaPartita(). </i> Chiede all'utente di inserire <br/>
    /// un numero di 4 cifre e verifica il corretto inserimento.
    /// </summary>
    /// <returns>Un numero di 4 cifre in formato stringa</returns>
    static string InputCodiceID()
    {
        bool corretto = false;
        string value = "";
        do
        {
            Console.Clear();
            ScriviAColori("Carica ultima partita", "verde", 'f');
            Console.WriteLine();
            Console.Write("Inserisci codice salvataggio: ");
            value = Console.ReadLine()!;

            if (!int.TryParse(value, out int n))
            {
                ScriviAColori("Il codice deve essere di 4 numeri\r", "rosso", 'f');
                Thread.Sleep(800);
            }
            else
            {
                corretto = true;
            }
        }
        while (!corretto);

        return value;
    }

    /// <summary>
    /// Salva in un file csv i dati della partia presenti negli array di ogni giocatore player.
    /// </summary>
    /// <param name="pathSave">Path del file di salvataggio</param>
    /// <param name="player1">Array dati del giocatore player1</param>
    /// <param name="player2">Array dati del giocatore player2</param>
    /// <param name="territoriP1">Lista dei territori conquistati dal giocatore player1</param>
    /// <param name="territoriP2">Lista dei territori conquistati dal giocatore player2</param>
    /// <returns></returns>
    static bool SalvaPartita(string pathSave, string[] player1, string[] player2,
                    List<string> territoriP1, List<string> territoriP2)
    {
        Console.Clear();

        if (!File.Exists(pathSave))     //se non esiste il file lo creo
        {
            ScriviAColori("Il file di salvataggio non è presente", "rosso", 'f');
            Thread.Sleep(600);
            ScriviAColori("Creo un file di salvataggio", "verde", 'f');
            SchermataLoading('°', 28, 60);
            Console.Clear();

            File.Create(pathSave).Close();
            File.WriteAllText(pathSave, "ID,Giocatori,Colori,t,e,r,r,i,t,o,r,\n");
            Console.WriteLine("\nFile creato e inizializzato.");
        }
        string[] righe = File.ReadAllLines(pathSave);

        //aggiorno gli array dei giocatori coi i territori nelle liste
        MemorizzaSuArray(player1, territoriP1);
        MemorizzaSuArray(player2, territoriP2);


        foreach (string valore in player1)
        {
            File.AppendAllText(pathSave, $"{valore},");
        }
        File.AppendAllText(pathSave, "\n");
        foreach (string valore in player2)
        {
            File.AppendAllText(pathSave, $"{valore},");
        }
        File.AppendAllText(pathSave, "\n");

        Console.WriteLine("Salvataggio partita in corso");
        SchermataLoading('°', 28, 80);    //simula attesa
        Console.Clear();

        Console.WriteLine("Partita salvata correttamente.");
        Console.WriteLine($"Memorizza il seguente codice per caricare la partita: ");

        //stampa il codice di salvataggio
        ScriviAColori("\n\t" + player1[0] + "\n", "magenta", 'f');
        Console.Write("\npremi invio...\n");
        Console.ReadKey();
        Console.WriteLine();
        ScriviAColori("Arrivederci alla prossima partita!!!\n", "blu", 'f');
        return true;
    }

    /*Visualizza a schermo le regole del gioco presenti nel file rules.txt.
      Nel caso il file non esista lo crea da capo utilizzando il metodo accessorio
      ScriviRegole().
      #!NOTE ---> implementare il controllo nel caso il contenuto del file sia corrotto

      Input: string pathRules ---> il percorso del file rules.txt
    */
    /// <summary>
    /// Visualizza a schermo le regole del gioco presenti nel file rules.txt. <br/>
    /// Se il file non esiste lo crea e lo inizializza con il testo utilizzando: <br/>
    /// <i>ScriviRegole()</i>
    /// 
    /// </summary>
    static void RegoleGioco()
    {
        string pathRules = @"./files/rules.txt";
        //se non esiste il file delle regole lo crea da zero
        if (!File.Exists(pathRules))
        {
            File.Create(pathRules).Close();
            string[] regole = ScriviRegole();

            foreach (string riga in regole)
            {
                File.AppendAllText(pathRules, $"{riga}\n");
            }
        }

        string[] righe = File.ReadAllLines(pathRules);
        //stampa a schermo delle regole
        foreach (string riga in righe)
        {
            Console.WriteLine(riga);
        }

    }

    /// <summary>
    /// Scrive le regole del gioco in un array. Il testo è formattato per essere visualizzato <br/>
    /// nel terminale.
    /// </summary>
    /// <returns>Le regole del gioco da scrivere nel file txt </returns>
    private static string[] ScriviRegole()
    {
        string[] regole =
        [
            "                               Descrizione del gioco:",
            "********************************************************************************************",
            "|Gioco stile Risiko versione super semplificata, con la mappa costituita da 8 territori.   |",
            "|L'obiettivo finale è quello di conquistare tutti i territori lanciando i due dadi.        |",
            "|Il gioco prevede anche una 'modalità rischio' attivabile solo 1 volta per giocatore.      |",
            "********************************************************************************************",
            "|Regole:                                                                                   |",
            "|1.Lancio dadi: con il punteggio maggiore 1 territorio libero a scelta sulla mappa.        |",
            "|2.Pari o dispari(costa 1 territorio): si scommette 1 proprio territorio e si utilizza un  |",
            "|  dado a 36 facce. Prima del lancio a turno si scommette se il numero che uscirà sarà pari|",
            "|  o dispari. Si scommette ad oltranza fino a quando uno dei due non sbaglia la predizione.|",
            "|  Si vince il territorio scommesso dall'avversario più uno a scelta tra quelli liberi solo|",
            "|  se presenti.                                                                            |",
            "|3.Numero esatto(costa 2 territori): si scommettono 2 propri territori e si utilizza un    |",
            "|  dado a 50 facce. Prima del lancio entrambi i giocatori fanno una previsione sul numero  |",
            "|  che potrebbe uscire. Chi si avvicina di più entro un range minimo di 3 numeri vince la  |",
            "|  scommessa. In caso di parità si procede ad oltranza. Per range di 3 numeri si intende ad|",
            "|  esempio se il numero segreto è 23 un utente può vincere se il numero scommesso è uno tra|",
            "|  questi (21,22,23,24,25) e l'utente avversario scommette un numero più distante.         |",
            "|  Esempio: il numero segreto uscito è il 23                                               |",
            "|           utente1 sceglie 20; utente2 sceglie 22; fine utente2                           |",
            "|           utente1 sceglie 22; utente2 sceglie 24; PAREGGIO (stessa distanza nel range)   |",
            "|           utente1 sceglie 20; utente2 sceglie 40; PAREGGIO (entrambi fuori dal range)    |",
            "********************************************************************************************"
        ];

        return regole;
    }

    /// <summary>
    /// Crea un giocatore player, permette la scelta del nome, del colore e scrive un <br/>
    /// messaggio di benvenuto per l'utente. <br/>
    /// Permette la creazione di player 2 aggiungendo il colore scelto da player1.
    /// </summary>
    /// <param name="player1">Array dati del giocatore player1</param>
    /// <param name="colorePlayer1">Colore scelto dal giocatore player1</param>
    static void CreaGiocatore(string[] player1, string? colorePlayer1 = null)
    {
        bool corretto = false;

        //previene l'inserimento nullo del nome o nome troppo corti o lunghi:
        //il nome deve essere almeno di 3 caratteri e massimo 20
        while (!corretto)
        {
            Console.Clear();
            //iserisci il nome
            Console.Write("Inserisci il tuo nome: ");
            player1[1] = Console.ReadLine()!;
            if (player1[1].Length > 2)
            {
                if (player1[1].Length < 21)
                {
                    corretto = true;
                }
                else
                {
                    ScriviAColori("Il nome deve essere di massimo 20 caratteri\n", "rosso", 'f');
                    Thread.Sleep(1000);
                }
            }
            else
            {
                ScriviAColori("Il nome deve essere di almeno 3 caratteri\n", "rosso", 'f');
                Thread.Sleep(1000);
            }
        }

        Console.Clear();

        //seleziona il colore
        if (colorePlayer1 == null) //se è il player1 non ci sono restrizioni
        {
            SceltaColore(player1, player1[2][..1]);  //invia array e primo carattere del colore 
        }
        else //il player2 ha una scelta di meno 
        {
            SceltaColore(player1, colorePlayer1[..1]);  //invia array e primo carattere del colore 
        }

        Console.Clear();

        //messaggio di saluto
        Console.Write("Ciao ");
        ScriviAColori(player1[1], player1[2], 'b');
        Console.WriteLine();
    }

    /// <summary>
    /// Assegna il colore al giocatore CPU in base al colore rimasto 
    /// dopo la scelta <br/> del giocatore player1.
    /// </summary>
    /// <param name="player2">Array dati del giocatore player2</param>
    /// <param name="colorePlayer1">Colore scelto in precedenza dal giocatore player1</param>
    static void CreaGiocatorePC(string[] player2, string colorePlayer1)
    {
        if (player2[1] == "CPU")
        {
            switch (colorePlayer1)
            {
                case "rosso":
                    player2[2] = "verde";
                    break;

                case "blu":
                    player2[2] = "giallo";
                    break;

                case "magenta":
                    player2[2] = "verde";
                    break;

                case "giallo":
                    player2[2] = "magenta";
                    break;

                case "verde":
                    player2[2] = "rosso";
                    break;
            }
        }
    }

    /// <summary>
    /// Memorizza la scelta effettuata dall'utente nel menu di gioco per ogni giocatore <br/>
    /// restituendo il carattere digitato dall'utente come opzione scelta.
    /// </summary>
    /// <param name="player1">Array dati del giocatore player1</param>
    /// <param name="player2">Array dati del giocatore player1</param>
    /// <returns>opzione scelta dell'utente in formato char</returns>
    static char SceltaGioco(string[] player1, string[] player2)
    {
        bool corretto = false;
        char c = '0';
        do  //controlla finche l'inserimento non è corretto
        {
            Console.Clear();
            MessaggioTurno(player1);
            MenuDiGioco();
            Console.Write("\nScegli: ");

            // aspetta finche non viene premuto un tasto
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            // verifica se il tasto 'Ctrl' è tenuto premuto
            if ((keyInfo.Modifiers & ConsoleModifiers.Control) != 0)
            {
                // controlla se il tasto premuto è N
                if (keyInfo.Key == ConsoleKey.Y)
                {
                    Console.Clear();
                    MessaggioTurno(player1);
                    DisegnaMappa(player1, player2);
                    Console.Write("\npremi invio...");
                    Console.ReadKey();

                }
            }
            else    //controlla se l'utente ha inserito l'opzione corretta
            {
                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:
                        // LanciaDadi
                        //breve messaggio dopo la selezione
                        ScriviAColori("lancio dadi", "verde", 'f');
                        Thread.Sleep(800);                  //della durata di 800ms
                        Console.Clear();                    //poi si cancella lo schermo

                        c = '1';
                        corretto = true;
                        break;

                    case ConsoleKey.D2:
                        // Modalità rischio (necessita di almeno 1 territorio per accedere)
                        if (player1[3] == "_")
                        {
                            ScriviAColori("devi avere almento 1 territorio", "rosso", 'f');
                            Thread.Sleep(800);
                            Console.Clear();
                            corretto = false;
                        }
                        else
                        {
                            //breve messaggio dopo la selezione
                            ScriviAColori("modalità rischio", "magenta", 'f');
                            Thread.Sleep(800);                  //della durata di 800ms
                            Console.Clear();                    //poi si cancella lo schermo

                            c = '2';
                            corretto = true;
                        }


                        break;

                    case ConsoleKey.S:
                        // Salva partita 
                        ScriviAColori("salvataggio", "blu", 'f');   //breve messaggio dopo la selezione
                        Thread.Sleep(800);                  //della durata di 800ms
                        Console.Clear();                    //poi si cancella lo schermo

                        c = 's';
                        corretto = true;
                        break;

                    default:
                        //caso digitazione errata
                        SelezioneErrata();
                        corretto = false;
                        break;
                }
            }
        }
        while (!corretto); //controlla finche l'inserimento non è corretto

        return c;
    }

    /// <summary>
    /// Memorizza la scelta fatta nel menu "modalità rischio" per ogni giocatore <br/>
    /// restituendo il carattere digitato dall'utente come opzione scelta.
    /// </summary>
    /// <param name="player">Array dati del giocatore player attuale</param>
    /// <returns>opzione scelta dell'utente in formato char</returns>
    static char SceltaRischio(string[] player)
    {
        bool corretto = false;
        char selezionato = '0';

        do  //controlla finche l'inserimento non è corretto
        {
            Console.Clear();
            MenuModalitaRischio();
            MessaggioTurno(player);
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            switch (keyInfo.Key)
            {
                case ConsoleKey.D1:
                    //Pari e dispari
                    //breve messaggio dopo la selezione
                    ScriviAColori("OK...costa 1 territorio", "rosso", 'f');
                    Thread.Sleep(800);
                    Console.Clear();
                    selezionato = '1';
                    corretto = true;
                    break;

                case ConsoleKey.D2:   //Necessita di 2 territori
                    //Indovina il numero

                    if (player[4] == "_")
                    {
                        ScriviAColori("devi avere almeno 2 territori", "rosso", 'f');
                        Thread.Sleep(800);
                        Console.Clear();
                        corretto = false;
                    }
                    else
                    {
                        //breve messaggio dopo la selezione
                        ScriviAColori("OK...costa 2 territori", "rosso", 'f');
                        Thread.Sleep(800);
                        Console.Clear();
                        selezionato = '2';
                        corretto = true;
                    }

                    break;

                case ConsoleKey.R:
                    //regole del gioco
                    //breve messaggio
                    selezionato = 'r';
                    corretto = true;
                    break;

                case ConsoleKey.Enter:

                    corretto = true;
                    break;

                default:
                    //caso digitazione errata
                    SelezioneErrata();
                    corretto = false;
                    break;
            }

        }
        while (!corretto);
        return selezionato;
    }

    /// <summary>
    /// Gestisce il mini-gioco "pari e dispari"
    /// </summary>
    /// <param name="player1">Array dati del giocatore player1</param>
    /// <param name="player2">Array dati del giocatore player2</param>
    static void PariDispari(string[] player1, string[] player2)
    {

    }

    /// <summary>
    /// Gestisce il mini-gioco "indovina il numero"
    /// </summary>
    /// <param name="player1">Array dati del giocatore player1</param>
    /// <param name="player2">Array dati del giocatore player 2</param>
    /// <param name="territoriP1">Lista dei territori conquistati dal giocatore player1</param>
    /// <param name="territoriP2">Lista dei territori conquistati dal giocatore player2</param>
    static void IndovinaIlNumero(string[] player1, string[] player2, List<string> territoriP1, List<string> territoriP2)
    {
        ScriviAColori("Indovina il numero segreto\n", "blu");    //titolo della pagina
        Console.WriteLine();
        //output per il player1 che sceglie per primo
        ScriviAColori(player1[1], player1[2], 'b');
        Console.WriteLine(" scegli 2 dei tuoi territori da scommettere");
        VisualizzaListaNumerata(territoriP1);
        
        //input dell'utente player1
        int selezioneTerritorio;
        bool corretto = false;
        int conta = 0;
        do
        {
            Console.Write("\nseleziona: ");
            try
            {
                selezioneTerritorio = int.Parse(Console.ReadLine()!);   //prova a convertire in intero

                if (selezioneTerritorio > territoriP1.Count || selezioneTerritorio < 0)
                {
                    throw new Exception();  //se fuori dal range del menù allora lancia eccezione
                }
                else
                {
                    conta++;
                }
                if (conta == 2)
                {
                    corretto = true;
                }
            }
            catch(Exception)
            {
                SelezioneErrata();
            }
        }
        while (!corretto);
    }

    #endregion

}