using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        #region Tipi di dati e variabili
        string benvenuto = "Benvenuto a MiniRisiko";
        char opzScelta;
        string pathSave = @"./files/save.csv";
        string pathRules = @"./files/rules.txt";

        //varibili giocatore [nome,colore,lista dei continenti da index 3 a 10 (max 8 continenti)]
        string[] player1 = ["ID", "Nome", "1", "c1", "c2", "c3", "c4", "c5", "c6", "c7", "c8"];
        string[] player2 = ["ID", "PC", "2", "c1", "c2", "c3", "c4", "c5", "c6", "c7", "c8"]; //in caso di gioco vs altro utente il nome verrà sovrascritto

        bool primoAvvio = true;     //per la prima schermata di loading
        bool fine = false;      //decreta la fine del gioco
        Random random = new Random();
        string ID = DateTime.Now.ToString();

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

        //metodo SalvaPartita
        // SalvaPartita(pathSave,player1,palyer2);

        //metodo SceltaColore
        // SceltaColore(player1);
        // Console.WriteLine($"{player1[1]},{player1[2]}");

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
                SchermataLoading('°', 15, 80);
                primoAvvio = false;
            }

            //visualizzo il menù iniziale del gioco
            MenuSelezionePrincipale();
            opzScelta = Console.ReadKey(false).KeyChar;

            switch (opzScelta)
            {
                case '1':

                    //creo player1
                    Console.Clear();
                    player1 = CreaGiocatore(player1);
                    Console.WriteLine("\npremi invio...");
                    Console.ReadKey();

                    //creo player2
                    player2 = CreaGiocatore(player2, player1[2]);

                    //messaggio di sfida
                    Console.Clear();
                    Console.Write("Si sfideranno ");
                    MessaggioAColori(player1[1], player1[2],'b');
                    Console.Write(" vs ");
                    MessaggioAColori(player2[1], player2[2],'b');
                    Console.WriteLine("\n\npremi invio....");
                    Console.ReadKey();

                    //SalvaPartita(pathSave, player1, player2); //DEBUG

                    while (!fine)
                    {
                        fine = GiocaVsPc(player1, player2, pathSave);
                    }

                    break;

                case '2':

                    //creo player1
                    Console.Clear();
                    Console.WriteLine("Giocatore 1");
                    Thread.Sleep(150);
                    player1 = CreaGiocatore(player1);
                    Console.WriteLine("\npremi invio...");
                    Console.ReadKey();

                    //creo player2
                    Console.Clear();
                    Console.WriteLine("Giocatore 2");
                    Thread.Sleep(150);
                    player2 = CreaGiocatore(player2, player1[2]);
                    Console.WriteLine("\npremi invio...");
                    Console.ReadKey();

                    //messaggio di sfida
                    Console.Clear();
                    Console.Write("Si sfideranno ");
                    MessaggioAColori(player1[1], player1[2],'b');
                    Console.Write(" vs ");
                    MessaggioAColori(player2[1], player2[2],'b');
                    Console.WriteLine("\n\npremi invio....");
                    Console.ReadKey();

                    //SalvaPartita(pathSave, player1, player2);   //DEBUG

                    while (!fine)
                    {
                        GiocaVsUtente(player1, player2, pathSave, fine);
                    }

                    break;

                case '3':
                    CaricaPartita(pathSave);
                    break;

                case '4':   //funzionante e testato
                    RegoleGioco(pathRules);
                    Console.WriteLine("Premi un tasto per tornare indietro...");
                    Console.ReadKey();
                    break;

                case '5':   //funzionante e testato
                    SchermataLoading('°', 20, 50);
                    MessaggioAColori("Arrivederci alla prossima partita!!!", "blu",'f');
                    fine = true;
                    break;

                default:
                    Console.WriteLine("Errore di digitazione");
                    SchermataLoading('°', 10, 100);
                    break;
            }

        }
        while (!fine);


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
        Console.WriteLine("'ctrl'+'V' Visualizza mappa");
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
        Console.WriteLine("1. Scommetti su pari o dispari (costo 1 continente)");
        Console.WriteLine("2. Scommetti sul numero esatto (costo 2 continenti)");
        Console.WriteLine("r. Ritorna alla schermata precedente");
    }
    #endregion

    #region "Metodi accessori o utility"

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
    
      Input: string[] player ---> array di giocatore; si utilizza player[2] = "Colore"
      
    */
    // static void CambiaColoreUtente(string[] player)
    // {
    //     // salvataggio colore corrente
    //     var currentBackground = Console.BackgroundColor;    //memorizzo il colore attuale
    //     var playerColor = currentBackground;

    //     switch (player[2])
    //     {
    //         case "rosso":
    //             playerColor = ConsoleColor.Red;
    //             break;

    //         case "blu":
    //             playerColor = ConsoleColor.Blue;
    //             break;

    //         case "magenta":
    //             playerColor = ConsoleColor.Magenta;
    //             break;

    //         case "giallo":
    //             playerColor = ConsoleColor.Yellow;
    //             break;

    //         case "verde":
    //             playerColor = ConsoleColor.Green;
    //             break;

    //         default:
    //             Console.WriteLine("Errore [CambiaColoreUtente]!!!");
    //             break;

    //     }
    //     Console.BackgroundColor = playerColor;
    //     Console.Write($"{player[1]}");
    //     Console.BackgroundColor = currentBackground;
    // }

    /*Stampa sullo schermo la scritta "Giocatore è il tuo turno"
      con il colore del nome scelto dall'utente

      Input: string[] player -----> array player giocatore attuale
    */
    static void MessaggioTurno(string[] player)
    {
        MessaggioAColori(player[1], player[2],'b');
        Console.WriteLine(" è il tuo turno");
    }

    /*Stampa sullo schermo la scritta "Giocatore hai vinto la sfida"
      con il colore del nome scelto dall'utente

      Input: string[] player -----> array player giocatore attuale
    */
    static void Messaggiofine(string[] player)
    {
        MessaggioAColori(player[1], player[2],'b');
        Console.WriteLine(" hai vinto la sfida");
    }

    /*Stampa sullo schermo la scritta "Giocatore hai vinto la sfida"
      con il colore del nome scelto dall'utente

      Input: string[] player -----> array player giocatore attuale
    */
    static void MessaggioSconfitta(string[] player)
    {
        MessaggioAColori(player[1], player[2],'b');
        Console.WriteLine(" hai perso la sfida");
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
      Scrive il risultato nell array player[2] = "colore"; player2[2] = "colore"

      Input: string[] g -----> array del giocatore player1 o player2
              string c --------> indica il colore che è gia stato preso
    */
    static void SceltaColore(string[] g, string c)
    {
        bool corretto = false;
        do  //controlla finche l'inserimento non è corretto
        {
            Console.Write("\nScegli: ");
            string input = Console.ReadLine()!.ToLower();
            switch (input)
            {
                case "r" when c != input:
                    g[2] = "rosso";
                    corretto = true;
                    break;

                case "b" when c != input:
                    g[2] = "blu";
                    corretto = true;
                    break;

                case "m" when c != input:
                    g[2] = "magenta";
                    corretto = true;
                    break;

                case "g" when c != input:
                    g[2] = "giallo";
                    corretto = true;
                    break;

                case "v" when c != input:
                    g[2] = "verde";
                    corretto = true;
                    break;

                default:
                    //caso digitazione errata
                    MessaggioAColori("Selezione errata", "rosso",'f');
                    Thread.Sleep(800);
                    Console.Clear();
                    MenuSelezioneColoreUtente(c);
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
    static int SimulaLancioDadi(int x, int y)
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
            SimulaRotazioneDadi(dadi);

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
                break;
        }

        //salvo il secondo dado
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
                break;
        }

        risultato = [dadoX, dadoY];
        Console.Clear();
        StampaDueDadi(risultato);
        Console.WriteLine($"\nHai ottenuto {x} + {y} = {x + y}");
        return x + y;
    }

    /*Metodo accessorio a SimulaLancioDadi che visualizza a schermo una coppia di dadi
    
      Input: string[][] dadi ---> contiene elementi di tipo array che rappresentano i dadi
    */
    private static void StampaDueDadi(string[][] dadi)
    {
        for (int i = 0; i < dadi.Length; i++)
        {
            for (int j = 0; j < dadi[i].Length; j++)
            {
                try
                {
                    Console.WriteLine($" {dadi[i][j]}\t{dadi[i + 1][j]}");
                }
                catch (Exception)
                {
                    //non fa niente
                }
            }
        }
    }
    /*Metodo accessorio a SimulaLancioDadi che crea un animazione dei dadi

      Input: string[][] dadi ---> contiene elementi di tipo array che rappresentano i dadi
    */
    private static void SimulaRotazioneDadi(string[][] dadi)
    {
        foreach (string[] n in dadi)
        {
            Console.Clear();

            foreach (string dado in n)
            {
                Console.WriteLine($" {dado}\t{dado}");
            }
            Thread.Sleep(100);
        }
    }

    #endregion

    #region "Metodi di gioco"

    static bool GiocaVsPc(string[] player1, string[] player2, string path)
    {
        Console.Clear();
        MessaggioTurno(player1);
        MenuDiGioco();
        char rispostaPlayer1 = SceltaGioco(player1);
        bool fine = false;
        switch (rispostaPlayer1)
        {
            case '1':
                if (LanciaDadi(player1, player2) == 1)
                {
                    Messaggiofine(player1);
                    Console.WriteLine("\npremi invio.....");
                    Console.ReadKey();
                }
                else
                {
                    MessaggioSconfitta(player1);
                    Console.WriteLine("\npremi invio.....");
                    Console.ReadKey();
                }
                break;

            case '2':
                MenuModalitaRischio();
                break;

            case 's':
                fine = SalvaPartita(path, player1, player2); //se va tutto bene, torna il valore true
                break;

            default:
                Console.WriteLine("Errore [GiocaVsPC]!!!");
                break;
        }
        return fine;

    }

    static void GiocaVsUtente(string[] player1, string[] player2, string path, bool fine)
    {
        Console.Clear();
        MessaggioTurno(player1);
        MenuDiGioco();
        Console.ReadKey();

    }
    /*Esegue il calcolo dei numeri random, simula graficamente la rotazione
      dei dadi e visualizza a schermo il vincitore del turno.

      Input: string[] player1 -----> array player1
             string[] player2 -----> array player2
      
      Output: int -------> 1 se vince player1;  2 se vince player2
    */

    static int LanciaDadi(string[] player1, string[] player2)
    {
        int dadoX, dadoY;
        Random random = new();

        //tira i dadi player1
        dadoX = random.Next(1, 7);
        dadoY = random.Next(1, 7);
        MessaggioTurno(player1);
        Console.WriteLine("\npremi invio per lanciare i dadi...");
        Console.ReadKey();
        int risultato1 = SimulaLancioDadi(dadoX, dadoY);
        Console.WriteLine("\npremi invio...");
        Console.ReadKey();
        Console.Clear();




        //tira i dadi player2
        dadoX = random.Next(1, 7);
        dadoY = random.Next(1, 7);
        MessaggioTurno(player2);
        Console.WriteLine("\npremi invio per lanciare i dadi...");
        Console.ReadKey();
        int risultato2 = SimulaLancioDadi(dadoX, dadoY);
        Console.WriteLine("\npremi invio...");
        Console.ReadKey();
        Console.Clear();

        //risultati a schermo
        //riga del titolo
        Console.WriteLine("Risultato turno:\n");
        //riga dei nomi
        MessaggioAColori(player1[1],player1[2],'b');    //nome1
        Console.Write("   vs   ");   //spazio tra i nomi
        MessaggioAColori(player2[1],player2[2],'b');    //nome2
        //riga dei punteggi
        Console.Write($"\n  {risultato1}    |");
        Console.Write($"   {risultato2}\n\n");

        


        return risultato2 >= risultato1 ? 2 : 1;
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

    /*Metodo che salva in un file csv i dati della partita attuali che sono
      presenti nell'array di ogni giocatore (player1 e player2). 
      Se il file non esiste lo crea da zero includendo le varie etichette.

      Input: string path -----> il percorso del file di salvataggio
             string[] player1 -----> array del player1
             string[] player2 -----> array del player2
    */
    static bool SalvaPartita(string path, string[] player1, string[] player2)
    {
        Console.Clear();

        if (!File.Exists(path))
        {
            Console.WriteLine("Il file di salvataggio non è presente.");
            Console.WriteLine("Creo un nuovo file");
            File.Create(path).Close();
            File.WriteAllText(path, "ID,Giocatori,Colori,c,o,n,t,i,n,e,n,\n");
            Console.WriteLine("\nFile creato e inizializzato.");
        }
        string[] righe = File.ReadAllLines(path);

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
        MessaggioAColori("\n\t" + player1[0] + "\n", "magenta",'f');
        Console.WriteLine("\npremi invio....\n");
        Console.ReadKey();
        MessaggioAColori("Arrivederci alla prossima partita!!!\n", "blu",'f');
        return true;


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
            "|           utente1 sceglie 20; utente2 sceglie 22; fine utente2                       |",
            "|           utente1 sceglie 22; utente2 sceglie 24; PAREGGIO (stessa distanza nel range)   |",
            "|           utente1 sceglie 20; utente2 sceglie 40; PAREGGIO (entrambi fuori dal range)    |",
            "********************************************************************************************"
        ];

        return regole;
    }

    /*Metodo che permette di creare un gioctore. Scelta del nome, del colore e
      messaggio di benvenuto.
      giocatore

      Input: string[] player -----> array del giocatore player1
      colore
    */
    static string[] CreaGiocatore(string[] player)
    {
        bool corretto = false;

        //previene l'inserimento nullo del nome o nome troppo corti
        //il nome deve essere almeno di 3 caratteri
        while (!corretto)
        {
            Console.Clear();
            //iserisci il nome
            Console.Write("Inserisci il tuo nome: ");
            player[1] = Console.ReadLine()!;
            if (player[1].Length > 2)
            {
                corretto = true;
            }
            else
            {
                MessaggioAColori("Il nome deve essere di almeno 3 caratteri\n", "rosso",'f');
                Thread.Sleep(1000);
            }
        }

        Console.Clear();

        //seleziona il colore
        MenuSelezioneColoreUtente(player[2][..1]);   //invia il primo carattere del colore 
        SceltaColore(player, player[2][..1]);  //invia array e primo carattere del colore 
        Console.Clear();

        //messaggio di saluto
        Console.Write("Ciao ");
        MessaggioAColori(player[1], player[2],'b');
        Console.WriteLine();

        return player;
    }
    /*Metodo che permette di creare un gioctore. Scelta del nome, del colore e
      messaggio di benvenuto.
      giocatore

      Input: string[] player2 -----> array del giocatore player2
      colore
    */
    static string[] CreaGiocatore(string[] player2, string colorePlayer1)
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
        else
        {
            //iserisci il nome
            Console.Write("Inserisci il tuo nome: ");
            player2[1] = Console.ReadLine()!;
            Console.Clear();

            //seleziona il colore
            MenuSelezioneColoreUtente(colorePlayer1[..1]);   //invia il primo carattere del colore 
            SceltaColore(player2, colorePlayer1[..1]);  //invia array e primo carattere del colore 
            Console.Clear();

            //messaggio di saluto
            Console.Write("Ciao ");
            MessaggioAColori(player2[1], player2[2],'b');
            Console.WriteLine();
        }

        return player2;
    }

    /*Memorizza la scelta fatta nel menu di gioco per ogni giocatore 
      restituendo il carattere digitato dall'utente dell'opzione scelta.

      Input: string[] player1 ----> array del giocatore
    */
    static char SceltaGioco(string[] player1)
    {
        bool corretto = false;
        char c = '0'; //valore di default
        do  //controlla finche l'inserimento non è corretto
        {
            Console.Write("\nScegli: ");

            // aspetta finche non viene premuto un tasto
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            // verifica se il tasto 'Ctrl' è tenuto premuto
            if ((keyInfo.Modifiers & ConsoleModifiers.Control) != 0)
            {
                // controlla se il tasto premuto è N
                if (keyInfo.Key == ConsoleKey.V)
                {
                    Console.Clear();
                    MessaggioTurno(player1);
                    DisegnaMappa();
                    Console.WriteLine("premi invio.......");
                    Console.ReadKey();
                    Console.Clear();

                }
            }
            switch (keyInfo.KeyChar)
            {
                case '1':
                    // LanciaDadi(player1, player2);

                    Console.WriteLine("lancio dadi");   //breve messaggio dopo la selezione
                    Thread.Sleep(800);                  //della durata di 800ms
                    Console.Clear();                    //poi si cancella lo schermo

                    c = '1';
                    break;

                case '2':
                    // PariDispari(player1, player2);
                    Console.WriteLine("rischio");       //breve messaggio dopo la selezione
                    Thread.Sleep(800);                  //della durata di 800ms
                    Console.Clear();                    //poi si cancella lo schermo

                    c = '2';
                    break;

                case 's':
                    //NumeroEsatto(player1, player2);
                    Console.WriteLine("salvataggio");   //breve messaggio dopo la selezione
                    Thread.Sleep(800);                  //della durata di 800ms
                    Console.Clear();                    //poi si cancella lo schermo

                    c = 's';
                    break;

                default:
                    //caso digitazione 
                    Console.Clear();
                    MessaggioTurno(player1);
                    MenuDiGioco();
                    corretto = false;
                    break;
            }
            return c;

        }
        while (!corretto); //controlla finche l'inserimento non è corretto

    }

    #endregion

}