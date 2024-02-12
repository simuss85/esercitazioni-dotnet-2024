class Program
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
            ScriviAColori($"{benvenuto}\n", "blu");
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
                    Console.Write("\npremi un tasto...");
                    Console.ReadKey();

                    //creo  CPU
                    AssegnaColorePC(player2, player1[2]);

                    //messaggio di sfida
                    Console.Clear();
                    Console.Write("Si sfideranno ");
                    ScriviAColori(player1[1], player1[2], 'b');
                    Console.Write(" vs ");
                    ScriviAColori(player2[1], player2[2], 'b');
                    Console.Write("\n\npremi un tasto...");
                    Console.ReadKey();

                GiocaVsPc:

                    vittoria = Gioca(player1, player2, pathSave, territoriP1, territoriP2, territori);


                    break;

                case '2':   //GIOCA VS UTENTE: 

                    //creo player1
                    Console.Clear();
                    CreaGiocatore(player1);
                    Console.Write("\npremi un tasto...");
                    Console.ReadKey();

                    //creo player2
                    Console.Clear();
                    CreaGiocatore(player2, player1[2]);
                    Console.Write("\npremi un tasto...");
                    Console.ReadKey();

                    //messaggio di sfida
                    Console.Clear();
                    Console.Write("Si sfideranno ");
                    ScriviAColori(player1[1], player1[2], 'b');
                    Console.Write(" vs ");
                    ScriviAColori(player2[1], player2[2], 'b');
                    Console.Write("\n\npremi un tasto...");
                    Console.ReadKey();

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

    /// <summary>
    /// Stampa il "menu principale" del programma
    /// </summary>
    static void MenuSelezionePrincipale()
    {
        Console.WriteLine("1. Gioca contro il pc");
        Console.WriteLine("2. Gioca contro altro utente");
        Console.WriteLine("3. Carica ultima partita");
        Console.WriteLine("4. Regole del gioco");
        Console.WriteLine("5. Esci");
    }

    /// <summary>
    /// Stampa il menu "Scelta colore" escludendo i colori gia scelti in precedenza.
    /// </summary>
    /// <param name="c">Il colore da escludere dal menu</param>
    static void MenuSelezioneColoreUtente(string c)
    {
        var currentBackground = Console.BackgroundColor;    //memorizza il colore attuale

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

    /// <summary>
    /// Stampa del menu turno di gioco del giocatore attuale.
    /// </summary>
    static void MenuDiGioco()
    {
        Console.WriteLine("Cosa vuoi fare?\n");
        Console.WriteLine("1. Lancia i dadi");
        Console.WriteLine("2. Modalità rischio");
        Console.WriteLine("s. Salva il gioco ed esci");
        Console.WriteLine("'ctrl'+'Y' Visualizza mappa");
    }

    /// <summary>
    /// Stampa a video una mappa del mondo in formato testuale e colorato <br/>
    /// a seconda dei colori scelti dai player.
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

    /// <summary>
    /// Metodo accessorio a <i>DisegnaMappa()</i> che colora i territori in base ai colori scelti dai giocatori.
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

    /// <summary>
    /// Stampa del menu "Modalita rischio".
    /// </summary>
    static void MenuModalitaRischio()
    {
        ScriviAColori("MODALITA' RISCHIO", "magenta", 'f');
        Console.WriteLine();
        Console.WriteLine("1. Scommetti su pari o dispari (costo 1 territorio)");
        Console.WriteLine("2. Scommetti sul numero esatto (costo 2 territori)");
        Console.WriteLine("3. Regole");
        Console.WriteLine("r. Rorna indietro...\n");
    }
    #endregion

    #region "Metodi accessori o utility"

    /// <summary>
    /// Metodo accessorio che cancella il contenuto della riga dopo l'inserimento 
    /// dell' input <br/> da parte dell' utente e posiziona il cursore nella corretta posizione. <br/>
    /// Necessita del rientro di cursore '\r' nel messaggio di errore precedente.
    /// </summary>
    /// <param name="lunghezzaErrore">Numero di caratteri del messaggio di errore</param>
    /// <param name="posizioneX">Posizione orizzontale del cursore che corrisponde alla lunghezza <br/>
    /// del messaggio di richiesta inserimento dato.</param>
    /// <param name="posizioneY">Posizione verticale del cursore</param>
    static void PulisciRiga(int lunghezzaErrore, int posizioneX, int posizioneY)
    {
        Thread.Sleep(1000);  //attende la lettura del messaggio

        //cancella il  messaggio di errore 
        for (int i = 0; i < lunghezzaErrore; i++)
        {
            Console.Write(" ");
        }

        //sposto il cursore al punto in cui l'utente ha inserito l'input
        //cancello il testo e mi riposiziono al punto corretto
        Console.SetCursorPosition(posizioneX, posizioneY);
        for (int i = 0; i < 80; i++)
        {
            Console.Write(" ");
        }
        Console.SetCursorPosition(posizioneX, posizioneY);
    }

    /// <summary>
    /// Stampa a video di una lista di elementi sotto forma di elenco numerato.
    /// </summary>
    /// <param name="lista">Lista da visualizzare come elenco numerato</param>
    static void StampaListaNumerata(List<string> lista)
    {
        if (lista.Count != 0)
        {
            int count = 1;
            foreach (string elemento in lista)
            {
                Console.WriteLine($"{count}. {elemento}");
                count++;
            }
        }
        else
        {
            // Console.WriteLine("DEBUG: lista vuota");
        }

    }

    /// <summary>
    /// Metodo accessorio che calcola in ID univoco prendendo la data attuale dal sistema.
    /// </summary>
    /// <param name="data">Contiene la data attuale in formato "gg/mm/aaaa hh:mm:ss"</param>
    /// <returns></returns>
    static string CalcolaID(string data)
    {
        string[] valoriSingoli = data.Split(['/', ':', ' ']);
        int totale = 0;
        foreach (string n in valoriSingoli)
        {
            totale += int.Parse(n);
        }
        return totale.ToString();
    }

    /// <summary>
    /// Utility che simula un caricamento in forma grafica con il carattere scelto dal programmatore. <br/>
    /// Non va a capo.
    /// </summary>
    /// <param name="c">Il carattere che verrà visualizzato a schermo.</param>
    /// <param name="punti">Quanti caratteri stampare a schermo</param>
    /// <param name="ms">La durata dell'animazione per ogni carattere</param>
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

    /// <summary>
    /// Metodo accessorio a <i>LanciaDadi()</i> che prende i risultati dei lanci dei dadi nel turno corrente <br/> 
    /// e li formatta in una tabella di max 5 righe e min 3 righe (in base al risultato del roud).
    /// 
    /// </summary>
    /// <param name="player1">Array dati del giocatore player1</param>
    /// <param name="player2">Array dati del giocatore player2</param>
    /// <param name="risultati">I due risultati per ogni coppia di dadi</param>
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

    /// <summary>
    /// Stampa del messaggio "Player è il tuo turno".<br/>
    /// La parola player è scritta con il colore scelto dal player. <br/>
    /// Va a capo alla fine.
    /// </summary>
    /// <param name="player">Array dati del giocatore player attuale</param>
    static void MessaggioTurno(string[] player)
    {
        ScriviAColori(player[1], player[2], 'b');
        Console.WriteLine(" è il tuo turno");
    }

    /// <summary>
    /// Stampa il messaggio "Selezione errata" in rosso. <br/>
    /// Non va a capo.
    /// </summary>
    static void MessaggioSelezioneErrata()
    {
        //caso digitazione errata
        ScriviAColori("Selezione errata", "rosso", 'f');
        Thread.Sleep(800);
    }

    /// <summary>
    /// Stampa del messaggio sotto la simulazione del lancio dei dadi. <br/>
    /// Lo spazio tra i nomi dei due player è formattato in base alla loro lunghezza.<br/>
    /// Visualizza anche il risultato del lancio dei dadi.
    /// </summary>
    /// <param name="player1">Array dati del giocatore player1</param>
    /// <param name="player2">Array dati del giocatore player2</param>
    /// <param name="p1">Risultato del lancio dei dadi player1 (la somma)</param>
    /// <param name="p2">Risultato del lancio dei dadi player2 (la somma)</param>
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

    /// <summary>
    /// Stampa del messaggio: <br/>
    /// "VITTORIA!!!" di colore 'verde'.<br/>
    /// "Player hai vinto la partita". <br/>
    /// "premi un tasto per uscire!" e attende l'inserimento di un tasto. <br/>
    ///  oppure<br/>
    /// "Player hai vinto la sfida". <br/>
    /// la parola player del colore scelto dal giocatore. <br/>
    /// Opzione: <br/>
    /// <b>true</b> -  tutti i territori conquistati; <br/>
    /// <b>false</b> - vittoria nelle sfide <br/>
    /// Va a capo dopo il messaggio.
    /// </summary>
    /// <param name="player">Array dati del giocatore player attuale</param>
    /// <param name="fineGioco"><b>true</b> se il gioco è finito.</param>
    static void MessaggioVittoria(string[] player, bool fineGioco = false)
    {
        if (fineGioco)
        {
            ScriviAColori("VITTORIA!!!", "verde", 'f');
            Thread.Sleep(1000);
            Console.Clear();

            ScriviAColori(player[1], player[2], 'b');
            Console.WriteLine(" hai vinto la partita.");
            Console.WriteLine("\n premi un tasto per uscire!");
            Console.ReadKey();
        }
        else
        {
            ScriviAColori(player[1], player[2], 'b');
            Console.WriteLine(" hai vinto la sfida");
        }
    }

    /// <summary>
    /// Stampa del messaggio "Player hai perso la sfida".<br/>
    /// Scrive la parola player a seconda del colore scelto dal giocatore. <br/>
    /// Va a capo dopo il messaggio.
    /// </summary>
    /// <param name="player">Array dati del giocatore player attuale</param>
    static void MessaggioSconfitta(string[] player)
    {
        ScriviAColori(player[1], player[2], 'b');
        Console.WriteLine(" hai perso la sfida");
    }

    /// <summary>
    /// Stampa del messaggio "Player hai conquistato il seguente territorio: ".<br/>
    /// Scrive la parola player a seconda del colore scelto dal giocatore. <br/>
    /// Va a capo dopo il messaggio.
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

    /// <summary>
    /// Stampa del messaggio "Hai conquistato i seguenti territori: t1,t2,t3,(t4 se presente)" <br/>
    /// con i territori colorati in base al colore scelto dal player vincitore.
    /// </summary>
    /// <param name="colorePlayer">Il colore del player vincitore del round</param>
    /// <param name="territoriInPalio">Lista dei territori messi in palio</param>
    static void MessaggioTerritorioConquistatoRischio(string colorePlayer, List<string> territoriInPalio)
    {
        Console.Write("Hai conquistato i seguenti territori: ");
        for (int i = 0; i < territoriInPalio.Count; i++)
        {
            ScriviAColori(territoriInPalio[i], colorePlayer);
            if (i != territoriInPalio.Count - 1)
            {
                Console.Write(", ");
            }
            else
            {
                Console.WriteLine(".");
            }
        }
    }

    /// <summary>
    /// Metodo accessorio che permette di scrivere un testo a colori.<br/>
    /// Scrive il contenuto di 'messaggio' nel colore scelto e reimposta <br/>
    /// il colore di default alla fine. Non va a capo. <br/>
    /// Colori disponibili: <br/>
    /// - "rosso" <br/>
    /// - "blu" <br/>
    /// - "magenta" <br/>
    /// - "verde" <br/>
    /// - "giallo" <br/>
    /// </summary>
    /// <param name="messaggio">Il messaggio da stampare a colori</param>
    /// <param name="colore">Il colore in formato string es. "rosso"</param>
    /// <param name="opz">Opzione: 'f' default; 'b per lo sfondo</param>
    static void ScriviAColori(string messaggio, string colore, char opz = 'f')
    {
        var currentColor = Console.ForegroundColor;         //salvo il carattere attuale
        var currentBackground = Console.BackgroundColor;    //salvo lo sfondo attuale
        switch (colore)
        {
            case "rosso":
                if (opz == 'f')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                }
                break;

            case "verde":
                if (opz == 'f')
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                }
                break;

            case "magenta":
                if (opz == 'f')
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Magenta;
                }
                break;

            case "blu":
                if (opz == 'f')
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                }
                break;

            case "giallo":
                if (opz == 'f')
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

    /// <summary>
    /// Assegna il colore al giocatore player attuale a seconda della sua scelta nel menu <br/>
    /// di selezione colore. Scrive il risultato del colore scelto nel suo array player. <br/>
    /// Esempio: <br/>
    /// scelta <b>(r. Rosso)</b> ---> stringa "rosso" salvato in posizione player[2].
    /// </summary>
    /// <param name="player">Array dati del giocatore player attuale</param>
    /// <param name="c">Indica il colore selezionato nel menu dal giocatore player attuale</param>
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
                    MessaggioSelezioneErrata();
                    corretto = false;
                    break;
            }
        }
        while (!corretto);
    }

    /// <summary>
    /// Metodo che simula il lancio dei dati con un animazione grafica da terminale <br/>
    /// della rotazione di 2 coppie di dati, messaggi a schermo, e risultato del lancio <br/>
    /// Utilizza i seguenti metodi accessori: <br/>
    /// <i>SimulaRotazioneDadi()</i> per la parte di rotazione in graficada terminale. <br/>
    /// <i>AssegnaPatternDado()</i> assegna una delle 6 facce al dado per essere stampato. <br/>
    /// <i>Stampa4Dadi()</i> visualizza a schermo la stampa di 2 coppie di dadi (4 facce dadi).
    /// </summary>
    /// <param name="x1">Risultato primo dado player1</param>
    /// <param name="y1">Risultato secondo dado player1</param>
    /// <param name="x2">Risultato primo dado player2</param>
    /// <param name="y2">Risultato secondo dado player2</param>
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

    /// <summary>
    /// Metodo accessorio per <i>SimulaLancioDadi()</i> che visualizza a schermo 2 coppie di dadi <br/>
    /// una per ogni giocatore, che rappresenta graficamente il risultato del lancio dei dadi.
    /// </summary>
    /// <param name="totDadi">Il risulato del lancio dei dadi in formato grafico (4 facce di dadi)</param>
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

    /// <summary>
    /// Metodo accessorio per <i>SimulaLancioDadi()</i> che assegna una rappresentazione grafica ad ogni numero random generato <br/>
    /// e contenuto nell'array dadi.
    /// </summary>
    /// <param name="n">Il valore random a cui va assegnata una delle 6 facce di un dado</param>
    /// <param name="dadi">L'insieme di tutti i patter grafici per ogni 6 facce del dado</param>
    /// <returns>La rappresentazione grafica della faccia del dado nel numero random</returns>
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
        return dado;
    }

    /// <summary>
    /// Metodo accessorio che genera un'animazione del lancio di 4 dadi su terminale.
    /// </summary>
    /// <param name="dadi">Una rappresenzatione grafica dei dadi sotto forma di linee e asterischi</param>
    /// <param name="player1">Array dati del giocatore player1</param>
    /// <param name="player2">Array dati del giocatore player2</param>
    /// <param name="xRotazioni">Il numero delle rotazioni calcolate. Totale rotazioni dado = 6 * xRotazioni</param>
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

    /// <summary>
    /// Avvia la partia
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
            if (territoriP1.Count == 8) //controllo se uno dei due player ha vinto
            {
                MessaggioVittoria(player1, true);
                return true;
            }
            else if (territoriP2.Count == 8)
            {
                MessaggioVittoria(player2, true);
                return true;
            }

            if (!cambioTurno)   //inizia player1
            {

                rispostaPlayer = SceltaGioco(player1, player2, territoriP1, territoriP2);
            }
            else        //inizia player2
            {
                #region CPU SCELTA GIOCO player2
                if (player2[1] == "CPU")    //se il player2 è CPU
                {
                    MessaggioTurno(player2);
                    MenuDiGioco();
                    Console.Write("\nScegli: ");

                    if (territori.Count < 1)    //territori liberi finiti
                    {
                        rispostaPlayer = '2';
                    }
                    else if (territoriP2.Count < 4) //territori CPU da 0 a 3
                    {
                        rispostaPlayer = '1';
                    }
                    else
                    {
                        Random random = new();
                        if (random.Next(1, 3) == 1) //sceglie 1 o 2 a caso
                        {
                            rispostaPlayer = '1';
                        }
                        else    //sceglie a caso 
                        {
                            rispostaPlayer = '2';
                        }
                    }
                    if (rispostaPlayer == '1')
                    {
                        ScriviAColori("lancio dadi", "verde", 'f');
                        Thread.Sleep(800);                  //della durata di 800ms
                        Console.Clear();
                    }
                    else
                    {
                        ScriviAColori("modalità rischio", "magenta", 'f');
                        Thread.Sleep(800);                  //della durata di 800ms
                        Console.Clear();                    //poi si cancella lo schermo
                    }
                    SchermataLoading();
                }
                #endregion
                else    //sceglie giocatore umano
                {
                    rispostaPlayer = SceltaGioco(player2, player1, territoriP2, territoriP1);
                }

            }

            switch (rispostaPlayer)
            {
                case '1':   //lancio dadi

                    ScriviAColori("Lancio dadi", "verde", 'f');
                    Console.Write("\n\npremi un tasto...");
                    Console.ReadKey();

                    if (!cambioTurno)
                    {
                        vincitore = LanciaDadi(player1, player2);   //turno player1

                        cambioTurno = true;

                        if (vincitore == 1) //se vince player1
                        {
                            MessaggioVittoria(player1);
                            Console.Write("\npremi un tasto...");
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
                            Console.Write("\npremi un tasto...");
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
                            Console.Write("\npremi un tasto...");
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
                            Console.Write("\npremi un tasto...");
                            Console.ReadKey();
                            Console.Clear();
                        }
                    }
                    break;

                case '2':   //rischio

                    char opz;   //gestisce la scelta dell'utente della modalità rischio
                    bool ripeti = true;

                    if (!cambioTurno)   //se il turno è di player1
                    {
                        while (ripeti)
                        {
                            #region  CPU player1 SCELTA RISCHIO 
                            if (player1[1] == "CPU")    //turno player 1
                            {
                                MessaggioTurno(player1);
                                SchermataLoading();
                                Random random = new();
                                if (random.Next(1, 3) == 1) //scelgo opzione 1 o 2 random
                                {
                                    opz = '1';
                                }
                                else
                                {
                                    opz = '2';
                                }
                            }
                            #endregion
                            else
                            {
                                opz = SceltaRischio(player1, territoriP1);
                            }

                            if (opz == '1')
                            {
                                PariDispari(player1, player2, territoriP1, territoriP2);    //turno player1
                                cambioTurno = true;
                                ripeti = false;
                            }
                            else if (opz == '2')
                            {
                                IndovinaIlNumero(player1, player2, territoriP1, territoriP2);   //turno player1
                                cambioTurno = true;
                                ripeti = false;
                            }
                            else if (opz == '3')
                            {
                                RegoleGioco();
                                Console.Write("\npremi un tasto...");
                                Console.ReadKey();
                            }
                            else if (opz == 'r')
                            {
                                ripeti = false;
                            }
                        }
                    }
                    else         //turno player2
                    {
                        while (ripeti)
                        {
                            #region  CPU player2 SCELTA RISCHIO 
                            if (player2[1] == "CPU")    //turno player 1
                            {
                                MessaggioTurno(player2);

                                SchermataLoading();
                                Random random = new();
                                if (random.Next(1, 3) == 1) //scelgo opzione 1 o 2 random
                                {
                                    opz = '1';
                                }
                                else
                                {
                                    opz = '2';
                                }
                            }
                            #endregion
                            else
                            {
                                opz = SceltaRischio(player2, territoriP2);
                            }

                            if (opz == '1')
                            {
                                PariDispari(player2, player1, territoriP2, territoriP1);    //turno player 2
                                cambioTurno = false;
                                ripeti = false;
                            }
                            else if (opz == '2')
                            {
                                IndovinaIlNumero(player2, player1, territoriP2, territoriP1);   //turno player 2
                                cambioTurno = false;
                                ripeti = false;
                            }
                            else if (opz == '3')
                            {
                                RegoleGioco();
                                Console.Write("\npremi un tasto...");
                                Console.ReadKey();

                            }
                            else if (opz == 'r')
                            {
                                ripeti = false;
                            }


                        }
                    }
                    Console.WriteLine("ritorno al menu di gioco...");
                    Thread.Sleep(1200);
                    Console.Clear();
                    break;

                case 's':   //salva
                    vittoria = SalvaPartita(pathSave, player1, player2); //se va tutto bene, torna il valore true
                    break;

                default:
                    Console.WriteLine("Errore [Gioca]!!!");
                    break;
            }
        }
        return vittoria;
    }

    /// <summary>
    /// Esegue la simulazione del lancio di 4 dadi, 2 per ogni giocatore utilizzando <br/>
    /// il metodo <i>Random()</i> e il metodo <i>SimulaLancioDadi()</i> che crea un'animazione <br/>
    /// del lancio di 4 dadi sul terminale. <br/>
    /// Il vincitore è assegnato alla meglio di 5, ovvero il primo che arriva a 3 punti.
    /// </summary>
    /// <param name="player1">Array dati del giocatore player1</param>
    /// <param name="player2">Array dati del giocatore player2</param>
    /// <returns><b>1</b> - nel caso in cui vince player1; <b> 2</b> - nel caso in cui vince player2 </returns>
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
            if (risultatoP1 <= risultatoP2)
            {   //vince player2
                vincitore = 2;
                vittorieP2++;
                if (vittorieP2 == 3)
                {
                    cambioTurno = true;
                }
                ScriviAColori(vittorieP1.ToString(), player1[2]);
                Console.Write("\t\t");
                ScriviAColori(player2[1], player2[2], 'b');
            }
            else
            {   //vince player1
                vincitore = 1;
                vittorieP1++;
                if (vittorieP1 == 3)
                {
                    cambioTurno = true;
                }
                ScriviAColori(vittorieP1.ToString(), player1[2]);
                Console.Write("\t\t");
                ScriviAColori(player1[1], player1[2], 'b');
            }
            Console.Write($" vince il round {turno}   ");
            ScriviAColori(vittorieP2.ToString(), player2[2]);
            Console.Write("\n\t\tpremi un tasto...");
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

    /// <summary>
    /// Permette di selezionare un territorio dalla lista dei territori liberi. <br/>
    /// Nel caso in cui sia rimasto 1 solo territorio lo assegna in automatico.
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
                AssegnaTerritorio(player, territoriP, territori.First(), territori);    //lo memorizzo nella lista
                Console.WriteLine("\npremi un tasto...");
                Console.ReadKey();
                Console.Clear();
            }
            else            //permette la scelta dalla lista territori aggiornata
            {               //gestisce anche la scelta automatica del pc
                int n = 0;
                bool corretto = false;
                string? input;

                #region CPU CONQUISTA TERRITORIO
                if (player[1] == "CPU") //se è il pc che sceglie
                {
                    Random random = new();
                    n = random.Next(1, territori.Count); //sceglie a caso un territorio
                }
                #endregion
                else
                {
                    do
                    {
                        Console.Clear();

                        ScriviAColori(player[1], player[2], 'b');
                        Console.WriteLine(" scegli il territorio:\n");
                        StampaListaNumerata(territori);
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
                }

                Console.Clear();
                MessaggioTerritorioConquistato(player, territori.ElementAt(n));
                AssegnaTerritorio(player, territoriP, territori.ElementAt(n), territori);
                Console.WriteLine("\nLista aggiornata:\n");
                StampaListaNumerata(territori);
                Console.Write("\npremi un tasto...");
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

    /// <summary>
    /// Esegue l'inserimento del territorio nella lista del giocatore player. <br/>
    /// Elimina il territorio dalla lista di quelli liberi.
    /// </summary>
    /// <param name="player">Array dati del giocatore player attuale</param>
    /// <param name="territorioScelto">Il nome del territorio scelto dall'utente</param>
    /// <param name="territoriP">Lista territori giocatore player attuale</param>
    /// <param name="territori">Lista dei territori liberi o lista scommessi</param>
    static void AssegnaTerritorio(string[] player, List<string> territoriP,
                                string territorioScelto, List<string>? territori)
    {
        //aggiunge il territorio nella lista utente
        territoriP.Add(territorioScelto);            //aggiungo alla lista del giocatore
        territori!.Remove(territorioScelto);          //rimuovo dalla lista dei territori liberi
        MemorizzaSuArray(player, territorioScelto, 'a');  //aggiorno array giocatore
    }

    /// <summary>
    /// Copia o rimuove il territorio conquistato dal giocatore nel suo array player.<br/>
    /// Opzioni: <br/>
    /// <b>'a'</b> - aggiunge territorio (default). <br/>
    /// <b>'r'</b> - rimuove territorio e ripristina placeholder "_"
    /// </summary>
    /// <param name="player">Array dati del giocatore player attuale</param>
    /// <param name="territorio">Il nome del territorio da salvare</param>
    /// <param name="opz"> 'a' default; 'r' opzione rimuovi</param>
    static void MemorizzaSuArray(string[] player, string territorio, char opz = 'a')
    {
        for (int n = 3; n < player.Length; n++)
        {
            if (opz == 'a') //aggiunge nell'array il territorio
            {
                if (player[n] == "_")   //se sono nella casella vuota
                {
                    player[n] = territorio; //aggiungo all array il territorio
                    break;
                }
            }
            else if (opz == 'r')        //rimuove il territorio e ripristina il placeholder "_"
            {
                if (player[n] == territorio)   //se trovo il territorio
                {
                    player[n] = "_";            //ripristino il placeholder
                    break;
                }
            }
        }
    }

    /// <summary>
    /// Copia i territori conquistati dal giocatore nella sua lista territori in modo da <br/>
    /// essere pronto per il salvataggio sul file csv. <br/>
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
                territori.Remove(player[i]);
            }
        }
    }

    /// <summary>
    /// Metodo accessorio che permette di aggiornare l'array del giocatore player attuale. <br/>
    /// Dopo aver caricato il file di salvataggio save.csv, i dati vengono caricati su un array  <br/>
    /// e passati a questo metodo per poter essere copiati uno a uno nell array del player. <br/>
    /// !!!POTREBBE NON SERVIRE!!!
    /// </summary>
    /// <param name="copiaDaFile">I dati prelevati dal file save.csv</param>
    /// <param name="player">Array dati del giocatore player attuale</param>
    static void CaricaPlayer(string[] copiaDaFile, string[] player)
    {
        for (int i = 0; i < player.Length; i++)
        {
            player[i] = copiaDaFile[i];
        }
    }

    /// <summary>
    /// Carica il contenuto del file save.csv, ripristina il contenuto degli array giocatori <br/>
    /// player1 e player2 e le liste dei territori.
    /// </summary>
    /// <param name="pathSave">Path del file di salvtaggio ./file/save.csv</param>
    /// <param name="player1">Array dati del giocatore player1</param>
    /// <param name="player2">Array dati del giocatore player2</param>
    /// <param name="territoriP1">Lista dei territori conquistati dal giocatore player1</param>
    /// <param name="territoriP2">Lista dei territori conquistati dal giocatore player1</param>
    /// <param name="territori">Lista dei territori liberi</param>
    /// <returns><b>false</b> nel caso in cui non trova un file di salvataggio save.csv, <b>true</b> se trova il file</returns>
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
        MemorizzaSuLista(player1, territoriP1, territori);
        MemorizzaSuLista(player2, territoriP2, territori);

        ScriviAColori("Caricamento completato!", "verde", 'f');
        Thread.Sleep(1200);
        Console.Clear();

        return trovato;
    }

    /// <summary>
    /// Metodo accessorio che permette di evitare la perdita dei dati in fase di caricamento <br/>
    /// del file save.csv.
    /// </summary>
    /// <param name="pathCopia">Path del file di copia ./files/temp </param>
    /// <param name="pathSave">Path del file di salvataggio ./file/</param>
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

        int count = 0;

        foreach (string riga in righe)      //copio tutto l'array del file tranne le 2 righe vuote
        {
            if (riga != "_")
            {
                copia[count] = riga;
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
    /// <returns></returns>
    static bool SalvaPartita(string pathSave, string[] player1, string[] player2)
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
        Console.Write("\npremi un tasto...\n");
        Console.ReadKey();
        Console.WriteLine();
        ScriviAColori("Arrivederci alla prossima partita!!!\n", "blu", 'f');
        return true;
    }

    /// <summary>
    /// Visualizza a schermo le regole del gioco presenti nel file rules.txt. <br/>
    /// Se il file non esiste lo crea e lo inizializza con il testo utilizzando <br/>
    /// il metodo <i>ScriviRegole().</i>
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
    static void AssegnaColorePC(string[] player2, string colorePlayer1)
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
    /// <param name="player1">Array dati del giocatore player che attacca </param>
    /// <param name="player2">Array dati del giocatore player che difende</param>
    /// <param name="territoriP1">Lista dei territori conquistati dal giocatore player1</param>
    /// <param name="territoriP2">Lista dei territori conquistati dal giocatore player1</param>
    /// <returns>opzione scelta dell'utente in formato char</returns>
    static char SceltaGioco(string[] player1, string[] player2, List<string> territoriP1, List<string> territoriP2)
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
                    Console.Write("\npremi un tasto...");
                    Console.ReadKey();
                }
            }
            else    //controlla se l'utente ha inserito l'opzione corretta
            {
                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:
                        // LanciaDadi
                        if (territoriP1.Count + territoriP2.Count == 8)
                        {
                            ScriviAColori("devi conquistare i territori dall'avversario", "rosso", 'f');
                            Thread.Sleep(1000);
                            Console.Clear();
                            corretto = false;
                        }
                        else
                        {
                            //breve messaggio dopo la selezione
                            ScriviAColori("lancio dadi", "verde", 'f');
                            Thread.Sleep(800);                  //della durata di 800ms
                            Console.Clear();                    //poi si cancella lo schermo

                            c = '1';
                            corretto = true;
                        }

                        break;

                    case ConsoleKey.D2:
                        // Modalità rischio (necessita di almeno 1 territorio per accedere)                      
                        if (territoriP1.Count < 2)
                        {
                            ScriviAColori("devi avere almento 1 territorio", "rosso", 'f');
                            Thread.Sleep(1000);
                            Console.Clear();
                            corretto = false;
                        }
                        else if (territoriP2.Count < 1)
                        {
                            ScriviAColori("il tuo avversario non ha territori da scommettere", "rosso", 'f');
                            Thread.Sleep(1000);
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
                        MessaggioSelezioneErrata();
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
    /// <param name="territoriP">Lista dei territori conquistati dal giocatore player attuale</param>
    /// <returns>opzione scelta dell'utente in formato char</returns>
    static char SceltaRischio(string[] player, List<string> territoriP)
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
                    if (territoriP.Count < 1)
                    {
                        ScriviAColori("devi avere almeno 2 territori", "rosso", 'f');
                        Thread.Sleep(800);
                        Console.Clear();
                        corretto = false;
                    }
                    else
                    {
                        //breve messaggio dopo la selezione
                        ScriviAColori("Ricorda...costa 1 territorio", "rosso", 'f');
                        Thread.Sleep(1000);
                        Console.Clear();
                        selezionato = '1';
                        corretto = true;
                    }
                    break;

                case ConsoleKey.D2:   //Necessita di 2 territori
                    //Indovina il numero

                    if (territoriP.Count < 2)
                    {
                        ScriviAColori("devi avere almeno 2 territori", "rosso", 'f');
                        Thread.Sleep(800);
                        Console.Clear();
                        corretto = false;
                    }
                    else
                    {
                        //breve messaggio dopo la selezione
                        ScriviAColori("Ricorda...costa 2 territori", "rosso", 'f');
                        Thread.Sleep(1000);
                        Console.Clear();
                        selezionato = '2';
                        corretto = true;
                    }
                    break;

                case ConsoleKey.D3:
                    //regole del gioco
                    selezionato = '3';
                    corretto = true;
                    break;

                case ConsoleKey.R:
                    //torna indietro
                    selezionato = 'r';
                    corretto = true;
                    break;

                default:
                    //caso digitazione errata
                    MessaggioSelezioneErrata();
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
    /// <param name="territoriP1">Lista dei territori conquistati dal giocatore player1</param>
    /// <param name="territoriP2">Lista dei territori conquistati dal giocatore player2</param>
    static void PariDispari(string[] player1, string[] player2, List<string> territoriP1, List<string> territoriP2)
    {
        List<string> territoriInPalio = []; //creo lista di appoggio per i territori in palio

        //avvio scelta giocatore player1        
        ScommettiTerritorio(player1, territoriP1, territoriInPalio, 1);
        //avvio scelta giocatore player2
        ScommettiTerritorio(player2, territoriP2, territoriInPalio, 1);

        ScriviAColori("Pari o dispari\n", "blu");    //titolo della pagina
        Console.WriteLine("\nElenco territori in palio:");
        StampaListaNumerata(territoriInPalio);
        Console.Write("\npremi un tasto...");
        Console.ReadKey();
        Console.Clear();

        if (GiocaPariDispari(player1, player2) == 1)    //se vince player1
        {
            //messaggio per il vincitore della sfida
            MessaggioVittoria(player1);
            MessaggioTerritorioConquistatoRischio(player1[2], territoriInPalio);
            //assegno i territori in palio al player1
            try
            {
                while (territoriInPalio.Count != 0)    //finche non è vuota la lista, copio e elimino il primo elemento
                {
                    AssegnaTerritorio(player1, territoriP1, territoriInPalio.First(), territoriInPalio);
                }
            }
            catch (Exception)
            {
                ScriviAColori("Errore [GiocaPariDispari]!!!", "rosso");
            }
        }
        else    //se vince player2
        {
            //messaggio per il vincitore della sfida
            MessaggioVittoria(player2);
            MessaggioTerritorioConquistatoRischio(player2[2], territoriInPalio);
            //assegno i territori in palio al player2
            try
            {
                while (territoriInPalio.Count != 0)    //finche non è vuota la lista, copio e elimino il primo elemento
                {
                    AssegnaTerritorio(player2, territoriP2, territoriInPalio.First(), territoriInPalio);
                }
            }
            catch (Exception)
            {
                ScriviAColori("Errore [GiocaPariDispari]!!!", "rosso");
            }

        }
        Console.Write("\npremi un tasto...");
        Console.ReadKey();
    }

    /// <summary>
    /// Gestisce il mini-gioco "indovina il numero". <br/>
    /// Utilizza il metodo accessorio <i>ScommettiTerritorio()</i> <br/>
    /// Utilizza il metodo accessorio <i>AssegnaTerritorio()</i> <br/>
    /// </summary>
    /// <param name="player1">Array dati del giocatore player1</param>
    /// <param name="player2">Array dati del giocatore player2</param>
    /// <param name="territoriP1">Lista dei territori conquistati dal giocatore player1</param>
    /// <param name="territoriP2">Lista dei territori conquistati dal giocatore player2</param>
    static void IndovinaIlNumero(string[] player1, string[] player2, List<string> territoriP1, List<string> territoriP2)
    {
        List<string> territoriInPalio = []; //creo lista di appoggio per i territori in palio

        //avvio scelta giocatore player1        
        ScommettiTerritorio(player1, territoriP1, territoriInPalio);
        //avvio scelta giocatore player2
        ScommettiTerritorio(player2, territoriP2, territoriInPalio);

        ScriviAColori("Indovina il numero segreto\n", "blu");    //titolo della pagina
        Console.WriteLine("\nElenco territori in palio:");
        StampaListaNumerata(territoriInPalio);
        Console.Write("\npremi un tasto...");
        Console.ReadKey();
        Console.Clear();

        if (GiocaIndovinaIlNumero(player1, player2) == 1)   //se vince player1
        {
            //messaggio per il vincitore della sfida
            MessaggioVittoria(player1);
            MessaggioTerritorioConquistatoRischio(player1[2], territoriInPalio);
            //assegno i territori in palio al player1
            try
            {
                while (territoriInPalio.Count != 0)    //finche non è vuota la lista, copio e elimino il primo elemento
                {
                    AssegnaTerritorio(player1, territoriP1, territoriInPalio.First(), territoriInPalio);
                }
            }
            catch (Exception)
            {
                ScriviAColori("Errore [GiocaIndovinaIlNumero]!!!", "rosso");
            }
        }
        else    //se vince player2
        {
            //messaggio per il vincitore della sfida
            MessaggioVittoria(player2);
            MessaggioTerritorioConquistatoRischio(player2[2], territoriInPalio);
            //assegno i territori in palio al player2
            try
            {
                while (territoriInPalio.Count != 0)    //finche non è vuota la lista, copio e elimino il primo elemento
                {
                    AssegnaTerritorio(player2, territoriP2, territoriInPalio.First(), territoriInPalio);
                }
            }
            catch (Exception)
            {
                ScriviAColori("Errore [GiocaIndovinaIlNumero]!!!", "rosso");
            }

        }
        Console.Write("\npremi un tasto...");
        Console.ReadKey();
    }

    /// <summary>
    /// Metodo accessorio che avvia la logica del gioco "Pari o dispari".
    /// </summary>
    /// <returns>Il vincitore del gioco: <b>1</b> giocatore che attacca; <b>2</b> giocatore che difende</returns>
    /// <param name="player1">Array dati del giocatore player1</param>
    /// <param name="player2">Array dati del giocatore player2</param>
    /// <returns></returns>
    static int GiocaPariDispari(string[] player1, string[] player2)
    {
        int vincitore = 0;
        bool corretto = false;
        Random random = new();
        int x, n;   //x per il numero random, n per la scelta del giocatore PC
        bool rispostaP1 = false, rispostaP2 = false; //variabile per il controllo risposta utente
        bool xPari;
        string input;

        while (vincitore == 0)  //finche uno dei due non vince ripeti il gioco
        {
            //player1 è il tuo turno

            ScriviAColori(player1[1], player1[2], 'b');
            Console.Write(" indovina se il numero è pari o dispari...");
            Thread.Sleep(600);
            Console.WriteLine();

            //genero il numero ad ogni turno
            x = random.Next(1, 11);  //il numero segreto tra 1 e 10
            xPari = x % 2 == 0;     //true se pari, false se dispari

            do
            {
                Console.Write("Pari o dispari? (p/d): ");

                #region CPU SCELTA P/D player1
                if (player1[1] == "CPU")
                {
                    n = random.Next(1, 3);
                    if (n == 1)
                    {
                        rispostaP1 = true;
                        Console.WriteLine("p");
                        corretto = true;

                    }
                    else
                    {
                        rispostaP1 = false;
                        Console.WriteLine("d");
                        corretto = true;
                    }
                    SchermataLoading();
                }
                #endregion
                else    //scelta player umano
                {
                    try
                    {
                        input = Console.ReadLine()!.ToLower();
                        if (input == "p")   //giocatore sceglie pari
                        {
                            rispostaP1 = true;
                            corretto = true;
                        }
                        else if (input == "d") //giocatore sceglie dispari
                        {
                            rispostaP1 = false;
                            corretto = true;
                        }
                        else
                        {
                            throw new Exception();
                        }

                    }
                    catch (Exception)
                    {
                        string errore = "Inserimento errato";
                        ScriviAColori(errore + "\r", "rosso");
                        //cancella messaggio di errore e posiziona il cursore correttamente
                        PulisciRiga(errore.Length, 0, 1);   //TODO
                    }
                }

            }
            while (!corretto);

            if (rispostaP1 == xPari) //verifica risposta del giocatore player1
            {
                ScriviAColori("Hai indovinato", "verde");
                rispostaP1 = true;  //indovinato
            }
            else
            {
                rispostaP1 = false; //perso
                ScriviAColori("Hai sbagliato", "rosso");
                Console.Write("\npremi un tasto...");
                Console.ReadKey();
            }

            Thread.Sleep(1000);
            Console.Clear();

            //player2 è il tuo turno

            ScriviAColori(player2[1], player2[2], 'b');
            Console.Write(" indovina se il numero è pari o dispari...");
            Thread.Sleep(600);
            Console.WriteLine();

            //genero il numero ad ogni turno
            x = random.Next(1, 11);  //il numero segreto tra 1 e 10
            xPari = x % 2 == 0;     //true se pari, false se dispari
            do
            {

                Console.Write("Pari o dispari? (p/d): ");

                #region CPU SCELTA P/D player2
                if (player2[1] == "CPU")
                {
                    n = random.Next(1, 3);
                    if (n == 1)
                    {
                        rispostaP2 = true;
                        Console.WriteLine("p");

                    }
                    else
                    {
                        rispostaP2 = false;
                        Console.WriteLine("d");
                    }
                    SchermataLoading();
                }
                #endregion
                else    //scelta player umano
                {
                    try
                    {
                        input = Console.ReadLine()!.ToLower();
                        if (input == "p")   //giocatore sceglie pari
                        {
                            rispostaP2 = true;
                            corretto = true;
                        }
                        else if (input == "d") //giocatore sceglie dispari
                        {
                            rispostaP2 = false;
                            corretto = true;
                        }
                        else
                        {
                            throw new Exception();
                        }

                    }
                    catch (Exception)
                    {
                        string errore = "Inserimento errato";
                        ScriviAColori(errore + "\r", "rosso");
                        //cancella messaggio di errore e posiziona il cursore correttamente
                        PulisciRiga(errore.Length, 0, 1);   //TODO
                    }
                }
            }
            while (!corretto);

            if (rispostaP2 == xPari) //verifica risposta del giocatore player1
            {
                rispostaP2 = true;  //indovinato
                ScriviAColori("Hai indovinato", "verde");
                Console.Write("\npremi un tasto...");
                Console.ReadKey();
            }
            else
            {
                rispostaP2 = false; //perso
                ScriviAColori("Hai sbagliato", "rosso");
                Console.Write("\npremi un tasto...");
                Console.ReadKey();
            }

            Console.Clear();

            //verifica del vincitore, 
            if (rispostaP1 == rispostaP2)   //pareggio true & true oppure false & false
            {
                Console.WriteLine("Pareggio!!!");
                Console.Write("\npremi un tasto...");
                Console.ReadKey();
                Console.Clear();
            }
            else if (rispostaP1)
            {
                vincitore = 1;
            }
            else
            {
                vincitore = 2;
            }

        }
        return vincitore;
    }

    /// <summary>
    /// Metodo accessorio che avvia la logica del gioco "Indovina il numero".
    /// </summary>
    /// <returns>Il vincitore del gioco: <b>1</b> giocatore che attacca; <b>2</b> giocatore che difende</returns>
    /// <param name="player1">Array dati del giocatore player1</param>
    /// <param name="player2">Array dati del giocatore player2</param>

    static int GiocaIndovinaIlNumero(string[] player1, string[] player2)
    {
        int vincitore = 0;
        bool inserito = false;
        Random random = new();
        int x = random.Next(1, 51);  //il numero segreto tra 1 e 50
        int rispostaP1 = 0, rispostaP2 = 0;
        int turno = 0;
        string aiuto = "tra 1 e 50: ";

        while (vincitore == 0)  //finche uno dei due non vince ripeti il gioco
        {
            if (turno > 3)
            {
                if (x < 17)
                {
                    aiuto = "tra 1 e 16: ";
                }
                else if (x < 34)
                {
                    aiuto = "tra 17 e 33: ";
                }
                else
                {
                    aiuto = "tra 34 e 50: ";
                }
            }
            //player1 è il tuo turno
            #region CPU player1 INDOVINA IL NUMERO
            if (player1[1] == "CPU")    //se player1 è la CPU
            {
                SchermataLoading();
                ScriviAColori("\n" + player1[1], player1[2], 'b');
                Console.Write(" scegli un numero " + aiuto);
                Thread.Sleep(800);
                Console.WriteLine();
                SchermataLoading();
                rispostaP1 = random.Next(1, 51); //inscerisce un numero a caso
            }
            #endregion
            else    //se il player1 è umano
            {
                //chiudi gli occhi player 2
                if (player2[1] != "CPU")
                {
                    ScriviAColori(player2[1], player2[2], 'b');
                    Console.Write(" chiudi gli occhi e non guardare il numero inserito...premi un tasto");
                    Console.ReadKey();
                    Console.WriteLine();
                }

                do
                {
                    ScriviAColori("\n" + player1[1], player1[2], 'b');
                    Console.Write(" scegli un numero " + aiuto);
                    try
                    {
                        rispostaP1 = int.Parse(Console.ReadLine()!);
                        if (rispostaP1 < 1 || rispostaP1 > 50)
                        {
                            throw new Exception();
                        }
                        inserito = true;
                    }
                    catch (Exception)
                    {
                        string errore = "Inserimento errato";
                        ScriviAColori(errore + "\r", "rosso");
                        //cancella messaggio di errore e posiziona il cursore correttamente
                        PulisciRiga(errore.Length, 0, 1);
                    }
                }
                while (!inserito);
            }

            Thread.Sleep(700);
            Console.Clear();

            inserito = false;   //resetto per il secondo inserimento

            //player2 è il tuo turno
            #region CPU player2 INDOVINA IL NUMERO
            if (player2[1] == "CPU")    //se player2 è la CPU
            {
                SchermataLoading();
                ScriviAColori("\n" + player2[1], player2[2], 'b');
                Console.Write(" scegli un numero " + aiuto);
                Thread.Sleep(800);
                Console.WriteLine();
                SchermataLoading();
                rispostaP2 = random.Next(1, 51);
            }
            #endregion
            else    //player2 è umano
            {
                //chiudi gli occhi player 1
                if (player1[1] != "CPU")
                {
                    ScriviAColori(player1[1], player1[2], 'b');
                    Console.Write(" chiudi gli occhi e non guardare il numero inserito...premi un tasto");
                    Console.ReadKey();
                    Console.WriteLine();
                }

                do
                {
                    ScriviAColori("\n" + player2[1], player2[2], 'b');
                    Console.Write(" scegli un numero " + aiuto);
                    try
                    {
                        rispostaP2 = int.Parse(Console.ReadLine()!);
                        if (rispostaP2 < 1 || rispostaP2 > 50)
                        {
                            throw new Exception();
                        }
                        inserito = true;
                    }
                    catch (Exception)
                    {
                        string errore = "Inserimento errato";
                        ScriviAColori(errore + "\r", "rosso");
                        //cancella messaggio di errore e posiziona il cursore correttamente
                        PulisciRiga(errore.Length, 0, 1);
                    }
                }
                while (!inserito);
            }

            Console.Clear();

            //verifica del vincitore, 
            //numero player 1 piu vicino dell'altro giocatore nel range di 3 posizioni
            if (Math.Abs(x - rispostaP1) < Math.Abs(x - rispostaP2) && Math.Abs(x - rispostaP1) < 3)
            {
                vincitore = 1;
            }
            //numero player 2 piu vicino dell'altro giocatore nel range di 3 posizioni
            else if (Math.Abs(x - rispostaP2) < Math.Abs(x - rispostaP1) && Math.Abs(x - rispostaP2) < 3)
            {
                vincitore = 2;
            }
            else    //pareggio, si ripete tutto
            {
                turno++;
                Console.WriteLine("Pareggio!!!");
                Thread.Sleep(800);
                Console.Clear();
            }
        }
        return vincitore;
    }

    /// <summary>
    /// Metodo accessorio di <i>IndovinaIlNumero</i> e <i>PariDispari()</i> che permette al giocatore player attuale di scegliere <br/>
    /// tra 1 o 2 territori a seconda dell'opzione inserita. <br/>
    /// Opzioni: <br/>
    /// <b>0</b> per indovina il numero (deafult); <br/>
    /// <b>1</b> per pari e dispari
    /// 
    /// </summary>
    /// <param name="player">Array dati del giocatore player attuale</param>
    /// <param name="territoriP">Lista dei territori conquistati dal giocatore player attuale</param>
    /// <param name="territoriInPalio">Lista dei territori messi in palio dai giocatori</param>
    /// <param name="opz">Numero di scelte possibili</param>
    static void ScommettiTerritorio(string[] player, List<string> territoriP, List<string> territoriInPalio, int opz = 0)
    {
        //input dell'utente player attuale
        int n;
        bool corretto = false;
        int conta = opz;
        //se player2 che si difende ha 1 territorio e siamo a indovina il numero
        if (territoriP.Count == 1 && opz == 0)
        {
            conta++;
        }
        do
        {
            Console.Clear();
            ScriviAColori("Indovina il numero segreto\n", "blu");    //titolo della pagina
            Console.WriteLine();
            //output per il player1 che sceglie per primo
            ScriviAColori(player[1], player[2], 'b');
            Console.WriteLine(" scegli territorio da scommettere");
            StampaListaNumerata(territoriP);

            Console.Write("\nseleziona: ");
            try
            {
                if (conta < 2)  //se devo ancora inserire chiedo l'input
                {
                    #region CPU SCELTA SCOMMESSA
                    if (player[1] == "CPU")
                    {
                        Random random = new();
                        n = random.Next(1, territoriP.Count + 1);
                        SchermataLoading();
                    }
                    #endregion
                    else    //scelta del player umano
                    {
                        n = int.Parse(Console.ReadLine()!);   //prova a convertire in intero
                    }

                    if (n > territoriP.Count || n < 0)
                    {
                        throw new Exception();  //se fuori dal range del menù allora lancia eccezione
                    }
                    else
                    {   //selezione corretta
                        ScriviAColori("OK!", "verde");
                        Thread.Sleep(600);
                        territoriInPalio.Add(territoriP.ElementAt(n - 1));   //aggiungo alla lista di appoggio lelemento in posizione n-1
                        MemorizzaSuArray(player, territoriP.ElementAt(n - 1), 'r'); //rimuovo dall array
                        territoriP.RemoveAt(n - 1);                          //rimuovo dalla lista del giocatore

                        conta++;
                    }
                }
                else
                {
                    corretto = true;
                }
            }
            catch (Exception)
            {
                MessaggioSelezioneErrata();
                Console.WriteLine();
            }
        }
        while (!corretto);
        Console.Clear();
    }

    #endregion

}