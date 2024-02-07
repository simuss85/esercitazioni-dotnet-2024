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
                    StampaAlimento(pathDirJson);
                    Console.ReadKey();

                    break;

                case '3':
                    // VisualizzaAlimenti(opzione);
                    Console.Clear();
                    StampaAlimento(pathDirJson, "exp");
                    Console.ReadKey();

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
      
      OUTPUT: bool corretto -----> true se l'inserimento va a buon fine; 
    */
    static bool InserisciDaTastiera()
    {
        bool corretto = false;
        string alimento, scadenza;
        int quantita;

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
               - del ----> visualizza tutti con titolo diverso

      INPUT: string opz ----------> default "all"
             string pathDirJson ---> path della cartella JSON
      
      OUTPUT: bool frigoVuoto ----> true se è vuoto; false se c'è almeno un alimento
     */
    static bool StampaAlimento(string pathDirJson, string opz = "all")
    {
        if (opz == "all")
        {
            ScriviAColori("Elenco alimenti\n", "blu");
        }
        else if (opz == "exp")
        {
            ScriviAColori("Elenco scadenza/esaurimento\n", "blu");
        }
        else if (opz == "del")
        {
            ScriviAColori("Elimina alimento\n", "blu");
        }

        Console.WriteLine();

        //memorizzo il path di tutti i files JSON
        string[] files = Directory.GetFiles(pathDirJson);
        int conta = 1;  //conta il numero degli elementi
        bool frigoVuoto;

        if (files.Length == 0)
        {
            frigoVuoto = true;
            ScriviAColori("frigo vuoto\n", "verde");
        }
        else
        {
            frigoVuoto = false;

            foreach (string file in files)
            {
                string jsonFile = File.ReadAllText(file);
                dynamic obj = JsonConvert.DeserializeObject(jsonFile)!;
                string scadenza = obj.scadenza;
                int quantita = obj.quantita;
                string alimento = obj.alimento;

                if (ControllaScadenza(scadenza))    //se scaduto scrive in rosso
                {
                    ScriviAColori($"{conta}. {alimento} {quantita} {scadenza} --scaduto--\n", "rosso");
                }
                else if (ControllaScadenza(scadenza, 3))   //se in scadenza entro 2 giorni 
                {
                    ScriviAColori($"{conta}. {alimento} {quantita} {scadenza} --in scadenza--\n", "magenta");
                }
                else if (quantita < 2)    //se ne rimangono meno di 2 scrive in giallo
                {
                    ScriviAColori($"{conta}. {alimento} {quantita} {scadenza} --in esaurimento--\n", "giallo");
                }
                else    //stampa normale
                {
                    if (opz == "all" || opz == "del")
                    {
                        Console.Write($"{conta}. {alimento} {quantita} {scadenza}\n");
                    }
                }
                conta++;
            }

        }
        if (opz != "del")
        {
            Console.Write("\npremi invio...");
        }

        return frigoVuoto;
    }

    /*Metodo che gestisce l'eliminazione degli alimenti. 
      Utilizza StampaAlimento() per visualizzare la lista aggiornata.
      Utilizza il metodo accessorio SelezionaElimina()

      INPUT: string pathDirJson -----> il path della directory JSON
    */
    static void Elimina(string pathDirJson)
    {
        bool ripetiOperazione = false;

        do
        {
            Console.Clear();
            //visualizza lista alimenti, opz = "del" scrive il titolo corretto del menu elimina
            ripetiOperazione = StampaAlimento(pathDirJson, "del");

            if (!ripetiOperazione)
            {
                ripetiOperazione = SelezioneElimina(pathDirJson);
            }
            else
            {
                Console.ReadKey();
            }

        }
        while (!ripetiOperazione);
    }

    /*Metodo accessorio che elimina o modifica i file JSON a seconda della selezione
      dell'utente.
    
      INPUT: string pathDirJson -----> il path della directory JSON

      OUTPUT: bool eseguito ---------> true torna al menu principale;
    */
    static bool SelezioneElimina(string pathDirJson)
    {
        //seleziono tutti i file della cartella JSON
        string[] files = Directory.GetFiles(pathDirJson);
        int conta = files.Length;   // conto i file
        bool eseguito = false;

        Console.WriteLine("\nVuoi eliminare qualcosa? (s/n) ");
        string input = Console.ReadLine()!;
        if (input == "n")
        {
            eseguito = true;    //se non voglio piu inserire torno al menu principale
        }
        else if (input == "s")
        {
            Console.WriteLine("\nCosa vuoi eliminare?");
            try
            {
                //memorizzo il numero scelto dall'utente che corrisponde 
                //all'elemento N-esimo della lista visualizzata a schermo
                int selezionato = int.Parse(Console.ReadLine()!);

                if (selezionato < 1 || selezionato > conta)
                {
                    throw new Exception(); //se non rientra nel range corretto
                }

                string file = files[selezionato - 1]; //path del file da modificare/cancellare
                string jsonFile = File.ReadAllText(file);   //il contenuto del file JSON
                dynamic obj = JsonConvert.DeserializeObject(jsonFile)!;
                string alimento = obj.alimento;
                int quantita = obj.quantita;
                string scadenza = obj.scadenza;

                //se ne rimane 1 solo alimento di quel tipo chiedo se eliminare
                if (quantita == 1)
                {
                    Console.Write("Vuoi eliminare ");
                    ScriviAColori($"{obj.alimento}", "verde");
                    Console.Write(" ? (s/n)");
                    string risposta = Console.ReadLine()!.ToLower();

                    if (risposta == "s")
                    {
                        File.Delete(file);
                    }
                }
                else
                {
                    bool corretto = false;
                    do
                    {
                        Console.Clear();

                        Console.WriteLine($"Ci sono {quantita} alimenti del tipo ");
                        ScriviAColori($"{obj.alimento}", "verde");
                        Console.Write("\nQuanti ne vuoi eliminare? ");
                        try
                        {
                            int quantitaDaEliminare = int.Parse(Console.ReadLine()!);
                            if (quantitaDaEliminare > quantita)
                            {
                                throw new Exception();
                            }
                            else if (quantitaDaEliminare == quantita)
                            {
                                Console.Write("Vuoi eliminare ");
                                ScriviAColori($"{obj.alimento}", "verde");
                                Console.Write(" ? (s/n)");
                                string risposta = Console.ReadLine()!.ToLower();

                                if (risposta == "s")
                                {
                                    File.Delete(file);
                                    ScriviAColori("Alimento eliminato", "verde");
                                    Thread.Sleep(800);
                                    corretto = true;
                                }
                            }
                            else
                            {
                                quantita -= quantitaDaEliminare;
                                // Console.WriteLine("DEBUG prima di inviare il codice" + quantita);   //DEBUG
                                CreaAlimentoJSON(alimento, quantita, scadenza);    //modifico e sovrascrivo
                                ScriviAColori("Aggiornato", "verde");
                                Thread.Sleep(800);
                                Console.ReadKey();
                                corretto = true;
                            }
                        }
                        catch (Exception)
                        {
                            ScriviAColori("Selezione quantita errata", "rosso");
                            Thread.Sleep(800);
                        }
                    }
                    while (!corretto);
                }
            }
            catch (Exception)
            {
                ScriviAColori("Selezione errata", "rosso");
                Thread.Sleep(800);
            }
        }
        return eseguito;
    }

    /*Metodo accessorio che crea un file JSON per ogni alimento inserito, nomina il file
      con il nome dell'alimento e parte della data: 
      esempio alimento_gg_mm.json 
      Se il file non esiste ne crea uno nuovo.
      
      INPUT: string nome -------> nome alimento 
             string quantita ---> quantita alimento
             string data -------> data di scadenza
      
      OUTPUT: true se tutto è andato a buon fine; 
    */
    static bool CreaAlimentoJSON(string alimento, int quantita, string scadenza)
    {
        // Console.WriteLine($"alimento: {alimento} quantita: {quantita} scadenza: {scadenza}");   //DEBUG
        // Console.ReadKey();                                                                      //DEBUG

        string nomeFile = alimento + "_" + scadenza[..2] + "_" + scadenza.Substring(3, 2);

        string pathJson = @"./files/JSON/" + nomeFile + ".json";
        try
        {
            if (!File.Exists(pathJson)) //se non c'è alcun prodotto lo creo
            {
                File.Create(pathJson).Close();
            }

            //inserisco i dati nel file JSON
            File.WriteAllText(pathJson, JsonConvert.SerializeObject(new { alimento, quantita, scadenza }));
            return true;
        }
        catch
        {
            ScriviAColori("Errore [CreaAlimentoJSON]!!!", "rosso");
            return false;
        }
    }

    /*Conta tutti gli elementi nella directory JSON
    
      INPUT: string pathDirJson -----> il path della directory JSON.

      OUTPUT: il numero dei files contenuti nella cartella JSON.
    */
    static int ContaJson(string pathDirJson)
    {
        string[] files = Directory.GetFiles(pathDirJson);
        return files.Length;
    }

    /* Metodo accessorio che permette la lettura del file csv e lo salva nel json corretto
       
       OUTPUT: false se non è presente il file csv; true se è presente
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
                alimenti[i] = righe[i].Split(",");  //per ogni riga del file csv creo un array alimento
            }

            try
            {
                for (int i = 1; i < alimenti.Length; i++)
                {
                    int quantita = int.Parse(alimenti[i][1]);
                    CreaAlimentoJSON(alimenti[i][0], quantita, alimenti[i][2]);
                }

            }
            catch (Exception)
            {
                ScriviAColori("Errore [InserisciDaCSV]", "rosso");
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

      OUTPUT: int quantita ---> contiene l'input dell'utente
    */
    static int FormatoQuantita()
    {
        bool corretto = false;
        int quantita = 0;
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
        return quantita;
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
                int anno = int.Parse(data[2]);
                int mese = int.Parse(data[1]);
                int giorno = int.Parse(data[0]);
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
                else if (anno >= annoInCorso)      //anno attuale verifico mese e giorno
                {
                    if (mese > 13 || mese < 1)  //mese errato
                    {
                        throw new Exception();
                    }
                    if (giorno > 31 || giorno < 1)  //giorno errato
                    {
                        throw new Exception();
                    }

                    if (anno == annoInCorso && mese < meseInCorso) //anno in  corso ma scaduto
                    {
                        ScriviAColori(erroreScaduto + "\r", "rosso");
                        PulisciRiga(erroreScaduto.Length, 17, 4);
                        continue;
                    }
                    else if (anno == annoInCorso && mese == meseInCorso)   //anno in corso e mese in corso
                    {
                        if (giorno < oggi)  //scaduto
                        {
                            ScriviAColori(erroreScaduto + "\r", "rosso");
                            PulisciRiga(erroreScaduto.Length, 17, 4);
                            continue;
                        }
                    }
                }

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
      
      OUTPUT: bool scade ---------> true se sta per scadere; false se ancora buono
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
            int anno = int.Parse(data[2]);
            int mese = int.Parse(data[1]);
            int giorno = int.Parse(data[0]);

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