class Program
{
    static void Main(string[] args)
    {
        #region Tipi di dati e variabili
        //variabili di inizializzazione file e sessione
        string pathSave = @"./files/save.csv";
        string pathCopia = @"./files/temp/copiaSave.csv"; //in caso di errore
        string pathRules = @"./files/rules.txt";
        string ID = DateTime.Now.ToString();

        //varibili giocatore [nome,colore,lista dei territori da index 3 a 10 (max 8 territori)]
        string[] player1 = ["ID", "Nome", "1", "_", "_", "_", "_", "_", "_", "_", "_"];
        string[] player2 = ["ID", "PC", "2", "_", "_", "_", "_", "_", "_", "_", "_"]; //in caso di gioco vs altro utente il nome verrà sovrascritto

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
                case '1':   //GIOCA VS PC: 

                    //creo player1
                    Console.Clear();
                    CreaGiocatore(player1);
                    Console.Write("\npremi invio...");
                    Console.ReadKey();

                    //creo  PC
                    CreaGiocatorePC(player2, player1[2]);

                    //messaggio di sfida
                    Console.Clear();
                    Console.Write("Si sfideranno ");
                    MessaggioAColori(player1[1], player1[2], 'b');
                    Console.Write(" vs ");
                    MessaggioAColori(player2[1], player2[2], 'b');
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
                    MessaggioAColori(player1[1], player1[2], 'b');
                    Console.Write(" vs ");
                    MessaggioAColori(player2[1], player2[2], 'b');
                    Console.Write("\n\npremi invio...");
                    Console.ReadKey();
                //SalvaPartita(pathSave, player1, player2);   //DEBUG

                GiocaVsUtente:

                    vittoria = Gioca(player1, player2, pathSave, territoriP1, territoriP2, territori);


                    break;

                case '3':   //CARICAMENTO: funzionante

                    CaricaPartita(pathSave, pathCopia, player1, player2);
                    MessaggioAColori("Caricamento completato!", "verde", 'f');

                    //aggiorno le liste dei territori con i dati caricati
                    // Console.Clear();                                    //DEBUG
                    // Console.WriteLine("Memorizzo p1");                  //DEBUG
                    MemorizzaSuLista(player1, territoriP1, territori);
                    // Console.ReadKey();                                  //DEBUG
                    // Console.WriteLine("Memorizzo p2");                  //DEBUG
                    MemorizzaSuLista(player2, territoriP2, territori);
                    Console.ReadKey();
                    Console.Clear();

                    if (player2[1] == "PC")
                    {
                        Console.Write("Bentornato ");
                        MessaggioAColori(player1[1], player1[2], 'b');
                        Thread.Sleep(1200);
                        goto GiocaVsPc;
                    }
                    else
                    {
                        Console.Write("Bentornati ");
                        MessaggioAColori(player1[1], player1[2], 'b');
                        Console.Write(" e ");
                        MessaggioAColori(player2[1], player2[2], 'b');
                        Thread.Sleep(1200);
                        goto GiocaVsUtente;
                    }

                //DEBUG
                #region DEBUG CARICA GIOCATORI
                // foreach (string valore in player1)      //DEBUG
                // {
                //     Console.Write($"{valore},");
                // }
                // Console.WriteLine();
                // foreach (string valore in player2)      //DEBUG
                // {
                //     Console.Write($"{valore},");
                // }
                // Console.ReadKey();
                #endregion DEBUG   


                case '4':   //REGOLE DI GIOCO: funzionante e testato
                    RegoleGioco(pathRules);
                    Console.WriteLine("Premi un tasto per tornare indietro...");
                    Console.ReadKey();
                    break;

                case '5':   //EXIT: funzionante e testato
                    SchermataLoading();
                    MessaggioAColori("Arrivederci alla prossima partita!!!", "blu", 'f');
                    vittoria = true;
                    break;

                default:
                    Console.WriteLine("Errore di digitazione");
                    SchermataLoading('°', 10, 100);
                    break;
            }

        }
        while (!vittoria);


    }

    #region "Metodi interfaccia utente e grafica"

    //Visualizza il menu di selezione principale
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
    static void MenuDiGioco()
    {
        Console.WriteLine("Cosa vuoi fare?\n");
        Console.WriteLine("1. Lancia i dadi");
        Console.WriteLine("2. Modalità rischio");
        Console.WriteLine("s. Salva il gioco ed esci");
        Console.WriteLine("'ctrl'+'Y' Visualizza mappa");
    }

    //Visualizza una breve sintesi della mappa aggiornata con i colori
    static void DisegnaMappa()
    {

        Console.WriteLine("\n           Mappa del mondo");
        Console.WriteLine("   |AMERICA|EUROPA|ASIA|POLO NORD|");
        Console.WriteLine("|SUD AMERICA|AFRICA|OCEANIA|POLO SUD|");
        Console.WriteLine();

    }

    //Visualizza le opzioni per la scelta della modalità di rischio
    static void MenuModalitaRischio()
    {
        Console.WriteLine("1. Scommetti su pari o dispari (costo 1 territorio)");
        Console.WriteLine("2. Scommetti sul numero esatto (costo 2 territori)");
        Console.WriteLine("r. Ritorna alla schermata precedente");
    }
    #endregion

    #region "Metodi accessori o utility"

    //Stampa a video il contenuto della lista
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
    static void SchermataLoading(char c = '°', int punti = 20, int ms = 50)
    {
        for (int i = 0; i < punti; i++)
        {
            Console.Write(c);
            Thread.Sleep(ms);
        }
        Console.Write("\r");
        Console.Write("                   \r");
    }

    /*Stampa sullo schermo la scritta "Giocatore è il tuo turno"
      con il colore del nome scelto dall'utente

      Input: string[] player -----> array player giocatore attuale
    */
    static void MessaggioTurno(string[] player)
    {
        MessaggioAColori(player[1], player[2], 'b');
        Console.WriteLine(" è il tuo turno");
    }

    /*Stampa il messaggio in rosso e attende 800 ms. Non va a capo
    */
    static void SelezioneErrata()
    {
        //caso digitazione errata
        MessaggioAColori("Selezione errata", "rosso", 'f');
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

        MessaggioAColori(player1[1], player1[2], 'b');
        Console.Write(messaggio + p1);
        for (int i = 0; i < spazi; i++)
        {
            Console.Write(" ");
        }
        MessaggioAColori(player2[1], player2[2], 'b');
        Console.WriteLine(messaggio + p2 + "\n");
    }

    /*Stampa sullo schermo la scritta "Giocatore hai vinto la sfida"
      con il colore del nome scelto dall'utente

      Input: string[] player -----> array player giocatore attuale
             bool fineGioco ------> se true stampa il messaggio finale
    */
    static void MessaggioVittoria(string[] player, bool fineGioco = false)
    {
        if (fineGioco)
        {
            MessaggioAColori("VITTORIA!!!", "verde", 'f');
            Thread.Sleep(1000);
            Console.Clear();

            MessaggioAColori(player[1], player[2], 'b');
            Console.WriteLine(" hai vinto la partita.");
            Console.WriteLine("\n premi invio per uscire!");
            Console.ReadKey();
        }
        else
        {
            MessaggioAColori(player[1], player[2], 'b');
            Console.WriteLine(" hai vinto la sfida");
        }

    }

    /*Stampa sullo schermo la scritta "Giocatore hai vinto la sfida"
      con il colore del nome scelto dall'utente

      Input: string[] player -----> array player giocatore attuale
    */
    static void MessaggioSconfitta(string[] player)
    {
        MessaggioAColori(player[1], player[2], 'b');
        Console.WriteLine(" hai perso la sfida");
    }

    /*Scrive nel formato del player attuale il messaggio di conquista
      del territorio. 
      Va a capo dopo il messaggio

      Input: string[] player ------> array giocatore attuale
             string territorio ----> il territorio appena conquistato/selezionato
    */
    static void MessaggioTerritorioConquistato(string[] player, string territorio)
    {
        MessaggioAColori(player[1], player[2], 'b');
        Console.Write(" hai conquistato il seguente territorio: ");
        MessaggioAColori(territorio, player[2], 'f');
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
    static void MessaggioAColori(string messaggio, string colore, char opzione)
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
                MessaggioAColori("Errore [AssegnaPatternDado]!!!", "rosso", 'f');
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
    static bool Gioca(string[] player1, string[] player2, string path,
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
                rispostaPlayer = SceltaGioco(player1);
            }
            else        //inizia player2
            {
                rispostaPlayer = SceltaGioco(player2);
            }

            switch (rispostaPlayer)
            {
                case '1':   //lancio dadi
                    if (!cambioTurno)
                    {
                        vincitore = LanciaDadi(player1, player2);   //turno player1

                        cambioTurno = true;

                        if (vincitore == 1) //se vince plauyer1
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
                    MenuModalitaRischio();
                    break;

                case 's':   //salva
                    vittoria = SalvaPartita(path, player1, player2, territoriP1, territoriP2); //se va tutto bene, torna il valore true
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

            risultati[turno] = $"{risultatoP1}\t   {risultatoP2}";
            turno++;

            Console.Write(" ");
            if (risultatoP1 < risultatoP2)
            {   //vince player1
                vincitore = 2;
                vittorieP1++;
                if (vittorieP1 == 3)
                {
                    cambioTurno = true;
                }
                MessaggioAColori(player2[1], player2[2], 'b');
            }
            else
            {   //vince player2
                vincitore = 1;
                vittorieP2++;
                if (vittorieP2 == 3)
                {
                    cambioTurno = true;
                }
                MessaggioAColori(player1[1], player1[2], 'b');
            }
            Console.Write($" vince il round {turno}\n");
            Console.Write("\n premi invio...");
            Console.ReadKey();
            Console.Clear();

        }
        while (!cambioTurno);

        //risultati a schermo
        //riga del titolo
        Console.WriteLine("Risultato turno:\n");
        //riga dei nomi
        MessaggioAColori(player1[1], player1[2], 'b');    //nome1
        Console.Write("   vs   ");   //spazio tra i nomi
        MessaggioAColori(player2[1], player2[2], 'b');    //nome2
        Console.WriteLine();
        //riga dei punteggi
        foreach (string risultato in risultati)
        {
            Console.WriteLine(risultato);
        }
        return vincitore;
    }

    /* Permette di selezionare il territorio dalla lista dei territori disponibili
       Se c'è solo 1 territorio nella lista allora lo assegna in automatico
    */
    static void ConquistaTerritorio(string[] player, List<string> territoriP, List<string> territori)
    {
        //se c'è ancora un territorio libero
        if (territori.Count > 0)
        {
            if (territori.Count == 1)   //se rimane solo 1 lo assegna in automatico
            {
                MessaggioAColori("E' rimasto un solo territorio libero\n", "verde", 'f');
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

                    MessaggioAColori(player[1], player[2], 'b');
                    Console.WriteLine(" scegli il territorio:\n");
                    VisualizzaListaNumerata(territori);
                    Console.Write("\nScegli: ");

                    input = Console.ReadLine()!;
                    if (!int.TryParse(input, out n))
                    {
                        MessaggioAColori("Seleziona correttamente il territorio\r", "rosso", 'f');
                        Thread.Sleep(800);
                    }
                    else if (n < 1 || n > territori.Count)
                    {
                        MessaggioAColori("Seleziona correttamente il territorio\r", "rosso", 'f');
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
    static void AssegnaTerritorio(List<string> player1, string territorioScelto, List<string> territori)

    {
        //aggiunge il territorio nella lista utente
        if (player1.Contains(territorioScelto))
        {
            MessaggioAColori("Errore [SceltaTerritorio]!!!", "rosso", 'f');
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
    static void CaricaPlayer(string[] copiaDaFile, string[] player)
    {
        for (int i = 0; i < player.Length; i++)
        {
            player[i] = copiaDaFile[i];
        }
    }
    /*Carica una partita salvata e riptistina gli array players con i dati
      contenuti nel file save.csv
      Gestisce le eccezioni sui file

      INPUT: string pathSave ----> il path del file di salvataggio 
           string[] player1 ---> array del player1
           string[] player2 ---> array del player2
    */
    static void CaricaPartita(string path, string pathCopia, string[] player1, string[] player2)
    {
        bool trovato = false;

        //eseguo una copia del file in caso di errore durante l'esecuzione.
        GestisciCopiaCSV(path, pathCopia);

        do
        {
            Console.WriteLine("Inserisci codice del salvataggio: ");
            string ID = InputCodiceID();
            //Console.WriteLine("DEBUG ID: " + ID);   //DEBUG
            //Console.ReadKey();

            try
            {
                string[] file = File.ReadAllLines(path);
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

                    EliminaRigaDalFile(contaRighe, path);    //aggiorno il file 
                }
                else
                {
                    MessaggioAColori("Codice salvataggio errato o inesistente\r", "rosso", 'f');
                    Thread.Sleep(800);
                }
            }
            catch (Exception)
            {
                // Console.WriteLine(e.Message);
                MessaggioAColori("\nNessun salvataggio trovato", "rosso", 'f');
                Thread.Sleep(800);
            }
        }
        while (!trovato);
    }

    /*Metodo accessorio che prende il file dopo essere stato caricato 
      ed elimina le righe del salvatagio

      INPUT: int index -----------> indice della riga da cancellare
             string path ---------> il file da cui eliminare le righe
    */
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

    /*Metodo ausiliario dei metodi CaricaPartita e SalvaPartita. Crea o elimina
      una copia del file di salvataggio per prevenire la perdita durante errori
      di esecuzione del programma. 
      Cartella di destinazione ./files/temp

      INPUT: char azione -------> 'c' crea copia, 'r' ripristina salvataggio perso
             string pathCopia --> path del file per la copia

    */
    static void GestisciCopiaCSV(string path, string pathCopia)
    {
        char azione = 'c';

        //se la copia è piu grande dell'originale allora ho perso dei dati e li ripristino
        if(File.Exists(pathCopia) & File.ReadAllLines(path).Length < File.ReadAllLines(pathCopia).Length)
        {
            azione = 'r';
        }

        switch (azione)
        {
            case 'c':   //copia il file originale su una copia
                if (!File.Exists(pathCopia))
                {
                    File.Create(pathCopia).Close();
                }
                File.Copy(path, pathCopia);
                break;

            case 'r':   //ripristina

                if (!File.Exists(path))     //se non esiste il file lo creo
                {
                    File.Create(path).Close();
                }
                File.Copy(pathCopia, path);
                break;

            default:
                break;
        }
    }

    /*Metodo accessorio al metodo CaricaPartita. Chiede l'input del codice di
      4 cifre in formato string. Restituisce un valore string di 4 caratteri
      numerici

      OUTPUT: restituisce una stringa di un numero a 4 cifre
    */
    static string InputCodiceID()
    {
        bool corretto = false;
        string value = "";
        do
        {
            Console.Clear();
            MessaggioAColori("Carica ultima partita", "verde", 'f');
            Console.WriteLine();
            Console.Write("Inserisci codice salvataggio: ");
            value = Console.ReadLine()!;

            if (!int.TryParse(value, out int n))
            {
                MessaggioAColori("Il codice deve essere di 4 numeri\r", "rosso", 'f');
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

    /*Metodo che salva in un file csv i dati della partita attuali che sono
      presenti nell'array di ogni giocatore (player1 e player2). 
      Se il file non esiste lo crea da zero includendo le varie etichette.

      Input: string path --------------> il percorso del file di salvataggio
             string[] player1 ---------> array del player1
             string[] player2 ---------> array del player2
             List<string> territoriP1--> territori attuali player1
             List<string> territoriP2--> territori attuali player2
    */
    static bool SalvaPartita(string path, string[] player1, string[] player2,
                    List<string> territoriP1, List<string> territoriP2)
    {
        Console.Clear();

        if (!File.Exists(path))     //se non esiste il file lo creo
        {
            MessaggioAColori("Il file di salvataggio non è presente", "rosso", 'f');
            Thread.Sleep(600);
            MessaggioAColori("Creo un file di salvataggio", "verde", 'f');
            SchermataLoading('°', 28, 60);
            Console.Clear();

            File.Create(path).Close();
            File.WriteAllText(path, "ID,Giocatori,Colori,t,e,r,r,i,t,o,r,\n");
            Console.WriteLine("\nFile creato e inizializzato.");
        }
        string[] righe = File.ReadAllLines(path);

        //aggiorno gli array dei giocatori coi i territori nelle liste
        MemorizzaSuArray(player1, territoriP1);
        MemorizzaSuArray(player2, territoriP2);


        foreach (string valore in player1)
        {
            File.AppendAllText(path, $"{valore},");
        }
        File.AppendAllText(path, "\n");
        foreach (string valore in player2)
        {
            File.AppendAllText(path, $"{valore},");
        }
        File.AppendAllText(path, "\n");

        Console.WriteLine("Salvataggio partita in corso");
        SchermataLoading('°', 28, 80);    //simula attesa
        Console.Clear();

        Console.WriteLine("Partita salvata correttamente.");
        Console.WriteLine($"Memorizza il seguente codice per caricare la partita: ");

        //stampa il codice di salvataggio
        MessaggioAColori("\n\t" + player1[0] + "\n", "magenta", 'f');
        Console.Write("\npremi invio...\n");
        Console.ReadKey();
        MessaggioAColori("Arrivederci alla prossima partita!!!\n", "blu", 'f');
        return false;
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

    /*Metodo che permette di creare un gioctore. Scelta del nome, del colore e
      messaggio di benvenuto.
      giocatore

      Input: string[] player --------> array del giocatore player1 o player2
             string? colorePlayer1 --> colore gia scelto dal player1
      
    */
    static void CreaGiocatore(string[] player, string? colorePlayer1 = null)
    {
        bool corretto = false;

        //previene l'inserimento nullo del nome o nome troppo corti o lunghi:
        //il nome deve essere almeno di 3 caratteri e massimo 20
        while (!corretto)
        {
            Console.Clear();
            //iserisci il nome
            Console.Write("Inserisci il tuo nome: ");
            player[1] = Console.ReadLine()!;
            if (player[1].Length > 2)
            {
                if (player[1].Length < 21)
                {
                    corretto = true;
                }
                else
                {
                    MessaggioAColori("Il nome deve essere di massimo 20 caratteri\n", "rosso", 'f');
                    Thread.Sleep(1000);
                }
            }
            else
            {
                MessaggioAColori("Il nome deve essere di almeno 3 caratteri\n", "rosso", 'f');
                Thread.Sleep(1000);
            }
        }

        Console.Clear();

        //seleziona il colore
        if (colorePlayer1 == null) //se è il player1 non ci sono restrizioni
        {
            SceltaColore(player, player[2][..1]);  //invia array e primo carattere del colore 
        }
        else //il player2 ha una scelta di meno 
        {
            SceltaColore(player, colorePlayer1[..1]);  //invia array e primo carattere del colore 
        }

        Console.Clear();

        //messaggio di saluto
        Console.Write("Ciao ");
        MessaggioAColori(player[1], player[2], 'b');
        Console.WriteLine();
    }

    /*Metoro che crea il secondo giocatore prendendo il colore gia scelto
      dall'altro giocatore.

      Input: string[] player2 -----> array del giocatore player2
             string colorePlayer1--> colore del giocatore player1
    */
    static void CreaGiocatorePC(string[] player2, string colorePlayer1)
    {
        if (player2[1] == "PC")
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

    /*Memorizza la scelta fatta nel menu di gioco per ogni giocatore 
      restituendo il carattere digitato dall'utente dell'opzione scelta.

      Input: string[] player1 ----> array del giocatore
    */
    static char SceltaGioco(string[] player)
    {
        bool corretto = false;
        char c = '0';
        do  //controlla finche l'inserimento non è corretto
        {
            Console.Clear();
            MessaggioTurno(player);
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
                    MessaggioTurno(player);
                    DisegnaMappa();
                    Console.Write("\npremi invio...");
                    Console.ReadKey();

                }
            }
            else    //controlla se l'utente ha inserito l'opzione corretta
            {
                switch (keyInfo.KeyChar)
                {
                    case '1':
                        // LanciaDadi(player1, player2);

                        Console.Write("lancio dadi");   //breve messaggio dopo la selezione
                        Thread.Sleep(800);                  //della durata di 800ms
                        Console.Clear();                    //poi si cancella lo schermo

                        c = '1';
                        corretto = true;
                        break;

                    case '2':
                        // PariDispari(player1, player2);
                        Console.Write("rischio");       //breve messaggio dopo la selezione
                        Thread.Sleep(800);                  //della durata di 800ms
                        Console.Clear();                    //poi si cancella lo schermo

                        c = '2';
                        corretto = true;
                        break;

                    case 's':
                        //NumeroEsatto(player1, player2);
                        Console.Write("salvataggio");   //breve messaggio dopo la selezione
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

    #endregion

}