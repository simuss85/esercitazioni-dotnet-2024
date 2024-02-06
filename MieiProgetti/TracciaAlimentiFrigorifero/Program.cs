using Newtonsoft.Json;

class Program
{
    static void Main(string[] args)
    {
        #region Tipi di dati e variabili

        bool finito = false;
        char opz;
        //per utilizzare il percorso relativo delle cartelle
        string pathDirJson = @"./files/JSON";

        #endregion

        if (!Directory.Exists(pathDirJson))
        {
            Directory.CreateDirectory(pathDirJson);
        }

        do
        {
            Console.Clear();

            MenuSelezione();
            //richiesta input utente
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            switch (keyInfo.KeyChar)
            {
                case '1':
                    Console.Clear();

                    MenuInserisci();
                    opz = SelezioneInserisci();
                    if (opz != 'r')
                    {
                        Inserisci(opz);
                    }
                    // InserisciCSV();
                    break;

                case '2':
                    // VisualizzaAlimenti();
                    Console.Clear();
                    StampaElenco(pathDirJson);

                    break;

                case '3':
                    // VisualizzaAlimenti(opzione);
                    Console.Clear();
                    //StampaElenco(pathDirJson, false);  DA SISTEMARE!!!

                    break;

                case '4':
                    // EliminaAlimenti();
                    Console.Clear();
                    Elimina(pathDirJson);

                    break;

                case 'e':
                    // SalvaFile();
                    ScriviAColori("Uscita in corso.", "blu");
                    Thread.Sleep(800);
                    finito = true;
                    break;

                default:
                    ScriviAColori("Scelta errata", "rosso");
                    Thread.Sleep(1000);
                    break;
            }
        }
        while (!finito);

    }

    #region  Metodi interfaccia utente e grafica
    /*Visualizza il menu principale del programma
    */
    static void MenuSelezione()
    {
        ScriviAColori("Traccia Alimenti Frigorifero", "blu");
        Console.WriteLine("\n");
        Console.WriteLine("1. Inserisci alimento");
        Console.WriteLine("2. Visualizza tutti");
        Console.WriteLine("3. Alimenti in scadenza/esaurimento");
        Console.WriteLine("4. Elimina alimento");
        Console.WriteLine("e. Esci");
    }

    /*Visualizza menu dell'opzione 1.Inserisci alimento*/
    static void MenuInserisci()
    {
        ScriviAColori("INSERISCI ALIMENTO", "blu");
        Console.WriteLine("\n");
        Console.WriteLine("1. Inserisci da tastiera");
        Console.WriteLine("2. Importa da file csv");
        Console.WriteLine("r. Torna indietro");
    }
    #endregion

    #region Logica del programma

    /*Metodo che permette l'inserimento di un alimento da tastiera o da file csv a seconda
      dell'opzione inserita. Verifica la correttezza dei dati inseriti e il giusto formato.
      Opzione: 't'  inserisci da tastiera
               'f'  inserisci da file csv

      INPUT: char opzione -----> default 't'
    */
    static void Inserisci(char opzione)
    {
        bool eseguito;
        //inserisci da file csv
        if (opzione == 'f')
        {
            //lettura del file csv
            eseguito = InserisciDaCSV();
            if (eseguito)
            {
                ScriviAColori("\nCopia del file completata", "verde");
                Thread.Sleep(1200);
            }
        }
        else     //inserisci da tastiera
        {
            Console.Clear();
            eseguito = InserisciDaTastiera();
            if (eseguito)
            {
                ScriviAColori("\nInserimento completato", "verde");
                Thread.Sleep(1200);
            }
        }
    }

    /*Gestisce l'inserimento dei dati mediante i metodi di controllo input:
      - InserisciNome() ---> verifica il formato del nome
      - InserisciQuantita--> verifica il formato quantita
      - InserisciData------> verifica la data di scadenza
      
      */
    static bool InserisciDaTastiera()
    {
        bool corretto = false;
        string alimento, quantita, scadenza;

        while (!corretto)
        {
            ScriviAColori("Inserisci gli alimenti", "verde");
            Console.WriteLine("\n");
            Console.Write("Alimento: ");
            alimento = FormatoNome();
            Console.Write("Quantità: ");
            quantita = FormatoQuantita();
            Console.Write("Data gg/mm/aaaa: ");
            scadenza = FormatoData();

            //se i controlli vanno a buon fine procedo con l'inserimento
            //inserisci i dati nel file JSON
            corretto = CreaAlimentoJSON(alimento, quantita, scadenza);
        }

        return corretto;
    }

    /*Visualizza l'elenco completo di tutti gli alimenti nel frigo con quantita e data
      sotto forma di tabella. 

      Opzioni: - all ----> visualizza tutti
               - exp ----> visualizza solo exp
               - del ----> elimina elemento

      INPUT: string opz ----> default "all"; se true visualizzo solo prodotti 
                                                            in scadenza o in esaurimento
      
     */
    static void StampaElenco(string pathDirJson, string opz = "all")
    {
        int conta = 1;
        if (opz == "all")
        {
            ScriviAColori("Elenco alimenti\n", "blu");
        }
        else
        {
            ScriviAColori("Elenco scadenza/esaurimento\n", "blu");
        }

        Console.WriteLine();

        string[] files = Directory.GetFiles(pathDirJson);
        if (files.Length == 0)
        {
            ScriviAColori("frigo vuoto", "verde");
        }
        foreach (string file in files)
        {
            string jsonFile = File.ReadAllText(file);
            dynamic obj = JsonConvert.DeserializeObject(jsonFile)!;
            string scadenza = obj.scadenza;
            short quantita = obj.quantita;

            if (ControllaScadenza(scadenza))    //se scaduto scrive in rosso
            {
                ScriviAColori($"{conta}. {obj.alimento} {obj.quantita} {obj.scadenza} --scaduto--\n", "rosso");
            }
            else if (ControllaScadenza(scadenza, 3))   //se in scadenza entro 2 giorni 
            {
                ScriviAColori($"{conta}. {obj.alimento} {obj.quantita} {obj.scadenza} --in scadenza--\n", "magenta");
            }
            else if (quantita < 2)    //se ne rimangono meno di 2 scrive in giallo
            {
                ScriviAColori($"{conta}. {obj.alimento} {obj.quantita} {obj.scadenza} --in esaurimento--\n", "giallo");
            }
            else    //stampa normale
            {
                if (opz == "all")
                {
                    Console.WriteLine($"{conta}. {obj.alimento} {obj.quantita} {obj.scadenza}");
                }

            }

            conta++;
        }
        Console.ReadKey();

    }

    /*Metodo che elimina un alimento se è presente il suo file JSON.

    
    */
    static void Elimina(string pathDirJson)
    {
        bool ripetiOperazione = true;
        bool eliminato = false;

        do
        {
            ScriviAColori("Elimina alimento", "magenta");
            Console.WriteLine("\n");
            StampaElenco(pathDirJson);
            Console.WriteLine("\nr. Torna indietro");
            Console.Write("Seleziona: ");


        }
        while (ripetiOperazione);
    }

    /*Metodo accessorio, crea un file JSON per ogni alimento, nel caso fosse 
      gia presente lo rinomina.
      
      INPUT: string nome -------> nome alimento 
             string quantita ---> quantita alimento
             string data -------> data di scadenza
      
      OUTPUT: true se tutto è andato a buon fine; 
    */
    static bool CreaAlimentoJSON(string alimento, string quantita, string scadenza)
    {
        string pathJson = @"./files/JSON/" + alimento + ".json";
        int count = 1;
        try
        {
            if (!File.Exists(pathJson)) //se non c'è alcun prodotto lo creo
            {
                File.Create(pathJson).Close();
            }
            else    //se c'è gia quell'alimento ne creo uno nuovo
            {
                pathJson = @"./files/JSON/" + alimento + count + ".json";
            }
            //inserisco i dati nel file JSON
            File.AppendAllText(pathJson, JsonConvert.SerializeObject(new { alimento, quantita, scadenza }));
            return true;
        }
        catch
        {
            ScriviAColori("Errore [CreaAlimentoJSON]!!!", "rosso");
            return false;
        }
    }

    /*Conta tutti gli elementi nella directory JSON
    
    */
    static short ContaJson(string pathDirJson)
    {
        string[] files = Directory.GetFiles(pathDirJson);
        return (short)files.Length;
    }

    /* Metodo accessorio che permette la lettura del file csv e lo salva nel json corretto

    */
    static bool InserisciDaCSV()
    {
        string pathCSV = @"./files/inserisci.csv";
        if (!File.Exists(pathCSV))
        {
            ScriviAColori("Nessun file csv trovato", "rosso");
            Thread.Sleep(800);
            return false;
        }
        else
        {   //leggo tutto il file csv compresa l intestazione
            string[] righe = File.ReadAllLines(pathCSV);
            string[][] alimenti = new string[righe.Length][];

            for (int i = 0; i < righe.Length; i++)
            {
                alimenti[i] = righe[i].Split(",");
            }

            int count = 1; //per inserire prodotti dello stesso tipo ma con scadenza diversa
            for (int i = 1; i < alimenti.Length; i++)
            {
                //prova a creare il file json, se gia presente ne crea uno con stesso nome
                //piu un numero sequenziale, esempio: file.json   file2.json  file3.json
                string pathJson = "./files/JSON/" + alimenti[i][0] + ".json";

                if (!File.Exists(pathJson))
                {
                    File.Create(pathJson).Close();
                }
                else
                {
                    pathJson = "./files/JSON/" + alimenti[i][0] + count + ".json";
                    count++;
                    File.Create(pathJson).Close();
                }
                File.AppendAllText(pathJson, JsonConvert.SerializeObject(new
                {
                    alimento = alimenti[i][0],
                    quantita = alimenti[i][1],
                    scadenza = alimenti[i][2]
                }));

            }
        }
        return true;
    }

    /*Gestisce l'iserimento del nome dell'alimento, controlla l'input inserito.

      OUTPUT: string nome ---> contiene l'input dell'utente

    */
    static string FormatoNome()
    {
        bool corretto = false;
        string nome = "";

        while (!corretto)
        {
            nome = Console.ReadLine()!;
            if (nome == "")  //regular expression cerca se la prima cifra
            {
                ScriviAColori("Errore di digitazione\r", "rosso");
                Thread.Sleep(1000);
                Console.Write("                     ");
                Console.SetCursorPosition(10, 2);
            }
            else
            {
                corretto = true;
            }
        }
        return nome;
    }

    /*Gestisce l'iserimento della quantita dell'alimento, controlla l'input inserito.

      OUTPUT: string quantita ---> contiene l'input dell'utente

    */
    static string FormatoQuantita()
    {
        bool corretto = false;
        short quantita = 0;
        string erroreFormato = "deve essere un numero";

        while (!corretto)
        {
            try
            {
                quantita = Int16.Parse(Console.ReadLine()!);
                corretto = true;
            }
            catch (Exception)
            {
                ScriviAColori(erroreFormato + "\r", "rosso");
                PulisciRiga(erroreFormato.Length, 10, 3);

            }
        }
        return quantita.ToString();
    }

    /*Gestisce l'iserimento della data_scadenza dell'alimento, controlla l'input inserito.

      OUTPUT: string data ---> contiene l'input dell'utente 

    */
    static string FormatoData()
    {
        bool corretto = false;
        string input = "";
        string erroreScaduto = "alimento gia scaduto";
        string erroreFormato = "formato data errato";
        string[] data = new string[3];
        var annoInCorso = DateTime.Now.Year;    //memorizzo l anno in corso
        var meseInCorso = DateTime.Now.Month;
        var oggi = DateTime.Now.Day;

        while (!corretto)
        {
            input = Console.ReadLine()!;

            try
            {
                data = input.Split("/");
                //converto in valore numerico per facilitare i controlli
                short anno = Int16.Parse(data[2]);
                short mese = Int16.Parse(data[1]);
                short giorno = Int16.Parse(data[0]);
                // Console.WriteLine("anno: " + anno); //DEBUG
                // Console.WriteLine("mese: " + mese); //DEBUG
                // Console.WriteLine("giorno: " + giorno); //DEBUG
                // Console.ReadKey();                      //DEBUG


                if (anno < annoInCorso) //anno precedente quindi scaduto
                {
                    if (anno < 2000)
                    {
                        throw new Exception();
                    }

                    ScriviAColori(erroreScaduto + "\r", "rosso");
                    PulisciRiga(erroreScaduto.Length, 17, 4);
                    continue;
                }
                else if (anno == annoInCorso)      //anno attuale verifico mese e giorno
                {
                    if (mese < meseInCorso) //mese
                    {
                        ScriviAColori(erroreScaduto + "\r", "rosso");
                        PulisciRiga(erroreScaduto.Length, 17, 4);
                        continue;
                    }
                    else if (mese > 13) //mese inserito errato
                    {
                        throw new Exception();
                    }
                    else if (mese == meseInCorso)   //mese in corso
                    {
                        if (giorno < oggi)
                        {
                            ScriviAColori(erroreScaduto + "\r", "rosso");
                            PulisciRiga(erroreScaduto.Length, 17, 4);
                            continue;
                        }
                        else if (giorno > 31)   //giorno inserito errato
                        {
                            throw new Exception();
                        }
                    }
                }
                else //caso corretto 
                {
                    //correggo il formato dell'output
                    if (data[1].Length < 2)
                    {
                        data[1] = "0" + data[1];    //mese formattato a 2 cifre
                    }
                    if (data[0].Length < 2)
                    {
                        data[0] = "0" + data[0];    //giorno formattato a 2 cifre
                    }
                    input = $"{data[0]}/{data[1]}/{data[2]}";
                }

            }
            catch (Exception)
            {
                ScriviAColori(erroreFormato + "\r", "rosso");
                PulisciRiga(erroreFormato.Length, 17, 4);
                continue;
            }
            corretto = true;
        }
        return input;
    }

    /*Verifica se il prodotto è prossimo alla scadenza controllando la data di oggi e
      quella del prodotto 
      
      INPUT: string scadenza -----> data di scadenza dell'alimento da controlare
             int offset ----------> entro quanti giorni verificare la scadenza;  default = 0

    */
    static bool ControllaScadenza(string scadenza, int offset = 0)
    {
        var annoInCorso = DateTime.Now.Year;    //memorizzo l anno in corso
        var meseInCorso = DateTime.Now.Month;
        var oggi = DateTime.Now.Day;
        bool scade = false;

        string[] data = scadenza.Split("/");

        try
        {
            //converto in valore numerico per facilitare i controlli
            short anno = Int16.Parse(data[2]);
            short mese = Int16.Parse(data[1]);
            short giorno = Int16.Parse(data[0]);

            if (anno < annoInCorso)
            {
                scade = true;
            }
            else if (anno == annoInCorso)
            {
                if (mese < meseInCorso)
                {
                    scade = true;
                }
                else if (mese == meseInCorso)
                {
                    if (giorno - offset < oggi)
                    {
                        scade = true;
                    }
                }
            }
        }
        catch
        {
            ScriviAColori("Errore [ControllaScadenza]!!!", "rosso");
        }
        return scade;
    }

    /*Gestisce la scelta del menu di inserimento

      OUTPUT: char opz ---> opzione scelta dall'utente
    */
    static char SelezioneInserisci()
    {
        bool corretto = false;
        char opz = '0';
        do
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            switch (keyInfo.KeyChar)
            {
                case '1':   //inserisci da tastiera
                    opz = 't';
                    corretto = true;
                    break;

                case '2':   //inserisci da file
                    opz = 'f';
                    corretto = true;
                    break;

                case 'r':   //torna indietro
                    opz = 'r';
                    corretto = true;
                    break;

                default:
                    ScriviAColori("Selezione errata\r", "rosso");
                    Thread.Sleep(1000);
                    Console.Write("                 \r");
                    break;
            }
        }
        while (!corretto);

        return opz;
    }

    /*Gestisce la scelta del menu di inserimento

      OUTPUT: char opz ---> opzione scelta dall'utente
    */
    static char SelezioneElimina(string pathDirJson)
    {
        bool corretto = false;
        char opz = '0';
        do
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            switch (keyInfo.KeyChar)
            {
                case 'r':   //torna indietro
                    opz = 'r';
                    corretto = true;
                    break;

                default:

                    try //prova a convertire in numero
                    {
                        short alimentoN = Int16.Parse(keyInfo.ToString()!);
                        if (alimentoN > ContaJson(pathDirJson) || alimentoN < 1)
                        {
                            throw new Exception();
                        }
                        else
                        {
                            corretto = true;
                        }
                    }
                    catch
                    {
                        ScriviAColori("Selezione errata\r", "rosso");
                        Thread.Sleep(1000);
                        Console.Write("                 \r");
                    }

                    break;
            }
        }
        while (!corretto);

        return opz;
    }

    #endregion

    #region Metodi di utility

    /*Metodo accessorio che cancella il contenuto della riga dopo l'inserimento
      dell' input da parte dell' utente.

      INPUT: int lunghezzaErrore -----> numero di caratteri dell'errore 
             int posizioneX ----------> posizione cursore ascisse variabile data dalla 
                                        lunghezza del messaggio di inserimento
                                         es (Inserisci: ) = 11 caratteri
             int posizioneY ----------> posizione cursore ordinate fissato a priori
      
    */
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
        for (int i = 0; i < 20; i++)
        {
            Console.Write(" ");
        }
        Console.SetCursorPosition(posizioneX, posizioneY);
    }

    /*Metodo accessorio che permette di scrivere un testo a colori.
      Scrive il contenuto di 'messaggio' nel colore scelto e reimposta
      il colore di default alla fine. 
      Non va a capo.
      Utilizza l'opzione 'f' per cambiare colore del font
      Utilizza l'opzione .b per cambiare il colore dello sfondo.
      Colori: - rosso
              - blu
              - magenta
              - verde

      INPUT: string messaggio ----> il messaggio da stampare
             string colore -------> il colore scelto
             char opz ------------> default 'f'
    */
    static void ScriviAColori(string messaggio, string colore, char opz = 'f')
    {
        //memorizzo i colori attuali
        var currentBackground = Console.BackgroundColor;
        var currentForeground = Console.ForegroundColor;

        switch (colore)
        {
            case "rosso":
                if (opz == 'b')
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                break;

            case "blu":
                if (opz == 'b')
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                break;

            case "magenta":
                if (opz == 'b')
                {
                    Console.BackgroundColor = ConsoleColor.Magenta;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                }
                break;

            case "verde":
                if (opz == 'b')
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                break;

            case "giallo":
                if (opz == 'b')
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                break;

            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Errore [ScriviAColori]!!!");
                break;
        }
        Console.Write(messaggio);   //stampa il messaggio a colori
                                    //ripristino i colori 
        Console.BackgroundColor = currentBackground;
        Console.ForegroundColor = currentForeground;
    }
    #endregion




}