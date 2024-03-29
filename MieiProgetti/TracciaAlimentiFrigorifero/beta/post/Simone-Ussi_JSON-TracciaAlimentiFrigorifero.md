## TRACCIA ALIMENTI FRIGORIFERO

Programma che tiene traccia di tutti gli alimenti inseriti nel frigorifero. Si possono inserire i dati da tastiera o da file.csv.  
Avvisa ad ogni avvio gli alimenti prossimi alla scadenza o quelli che stanno per finire (ad esempio ne rimane solo 1).  
Si tiene traccia del nome prodotto, quantità e data di scadenza.

## PUBBLICO TARGET
- L'applicazione è pensata per chiunque possieda un frigorifero.

## DEFINIZIONE DEI REQUISITI E ANALISI

- [x] L'applicazione deve consentire all'utente di inserire un prodotto da tastiera.
- [x] L'applicazione deve poter cancellare un alimento.
- [x] L'applicazione deve mostrare un messaggio di errore in caso di inserimento quantita nel formato errato.
- [x] L'applicazione deve mostrare un messaggio di errore in caso di inserimento data scadenza nel formato errata.
- [x] L'applicazione deve permettere di aggiungere uno stesso prodotto incrementando la quantità ma solo con stessa data di scadenza.
- [x] L'applicazione deve differenziare tra oggetti con lo stesso nome ma con data di scadenza diversa.
- [x] L'applicazione deve poter mostrare una tabella aggiornata di tutti i prodotti nel frigorifero.
- [x] L'applicazione deve poter mostrare un elenco di prodotti prossimi alla scadenza.
- [x] L'applicazione deve poter mostrare un elenco di prodotti in esaurimento (ne rimane solo 1).

## PIANIFICAZIONE E DESIGN DELL'ARCHITETTURA

- [x] L'applicazione deve poter leggere da una lista di prodotti in un file csv (prodotto,quantità,data_scadenza).
- [x] L'applicazione deve memorizzare ogni prodotto in un file JSON.
- [x] L'applicazione utilizza i colori per evidenziare i prodotti in scadenza nella tabella generale.
- [x] L'applicazione utilizza i colori per evidenziare i prodotti in esaurimento.
- [x] L'applicazione utilizza un menu principale per la selezione delle opzioni:
    >  **Menu principale**
    > - 1.Inserisci alimento
    > - 2.Visualizza tutti 
    > - 3.Alimenti in scadenza/esaurimento
    > - 4.Elimina alimento
    > - e.Esci
- [x] L'applicazione utilizza un sotto menu per l'opzione 1:
    > **INSERISCI ALIMENTO**
    > - 1.Inserisci da tastiera
    > - 2.Importa da file csv
    > - r.Torna indietro

## DEFINIZIONE DI STRUTTURE E CONVENZIONI

- [ ] I nomi delle classi devono essere PascalCase.
- [x] I nomi dei metodi devono essere PascalCase.
- [x] I nomi delle variabili devono essere camelCase.
- [x] I nomi delle costanti devono essere UPPERCASE.
- [x] I nomi dei file devono essere lowercase.
- [x] I nomi dei progetti devono essere PascalCase.
- [x] I nomi dei namespace devono essere PascalCase.

## SVILUPPO DEI COMPONENTI

- [x] Creare un progetto console per l'applicazione.
- [ ] Creare un progetto di test per i test unitari.

## TEST E DEBUGGING

- [ ] Scrivere test unitari per i componenti dell'applicazione.
- [ ] Eseguire il debugging per individuare e risolvere i bug.

## DOCUMENTAZIONE

- [x] Documentare il codice e l'architettura dell'applicazione.
- [ ] Documentare i test unitari.
- [ ] Documentare la fase di Beta Testing.
- [ ] Documentare la fase di post Beta Testing.

## CODICE

```csharp
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
    ///<summary>
    /// Visualizza il menu principale del programma
    /// </summary>    
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

    /// <summary>
    /// Visualizza menu dell'opzione 1.Inserisci alimento
    /// </summary>
    static void MenuInserisci()
    {
        ScriviAColori("INSERISCI ALIMENTO", "blu");
        Console.WriteLine("\n");
        Console.WriteLine("1. Inserisci da tastiera");
        Console.WriteLine("2. Importa da file csv");
        Console.WriteLine("r. Torna indietro");
    }

    /// <summary>
    /// Messaggio informativo per l'utente su come viene gestito l'import del file csv.<br/>
    /// Va a capo dopo il messaggio
    /// </summary>
    static void MessaggioInfoCsv()
    {
        ScriviAColori("Avviso: il file csv viene importato\nautomaticamente da altra applicazione!!!\n", "verde");
    }
    #endregion

    #region Logica del programma

    /*Metodo che permette l'inserimento di un alimento da tastiera o da file csv a seconda
      dell'opzione inserita. Verifica la correttezza dei dati inseriti e il giusto formato.
      Opzione: 't'  inserisci da tastiera
               'f'  inserisci da file csv

      INPUT: char opzione -----> default 't'
    */

    /// <summary>
    /// Metodo che permette l'inserimento di un alimento da tastiera o da file csv a seconda <br/>
    /// dell'opzione inserita. <br/> Verifica la correttezza dei dati inseriti e il giusto formato. <br/><br/>
    /// <list type="table">
    /// <listheader>
    /// <description>Opzioni:</description>
    /// </listheader>
    ///     <item>
    ///         <term>'t'</term>
    ///         <description>inserisci da tastiera</description>
    ///     </item>
    ///     <item>
    ///         <term>'f'</term>
    ///         <description>inserisci da file csv</description>
    ///     </item>
    /// </list>
    /// 
    /// </summary>
    /// <param name="opzione">default 't'</param>
    static void Inserisci(char opzione)
    {
        bool eseguito;
        //inserisci da file csv
        if (opzione == 'f')
        {
            //messaggio per l'utente sui file csv
            Console.Clear();
            MessaggioInfoCsv();

            Console.Write("\npremi un tasto per continuare...");
            Console.ReadKey();
            Console.Clear();
            //fine del messaggio

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

    /// <summary>
    /// Gestisce l'inserimento dei dati mediante i metodi di controllo input:<br/>  
    /// InserisciNome() ---> verifica il formato del nome <br/>
    /// InserisciQuantita--> verifica il formato quantita <br/>
    /// InserisciData------> verifica la data di scadenza <br/>
    /// </summary>
    /// <returns>
    /// <b>true</b> se l'inserimento va a buon fine, <b>false</b> altrimenti
    /// </returns>
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
            corretto = CreaAlimentoJSON(alimento, quantita, scadenza, 'a');
        }

        return corretto;
    }

    /// <summary>
    /// Visualizza l'elenco completo di tutti gli alimenti nel frigo con quantita e data <br/>
    /// sotto forma di tabella. <br/>
    /// Opzioni: <br/>
    /// - "all" ----> visualizza tutti <br/>
    /// - "exp" ----> visualizza solo exp <br/>
    /// - "del" ----> visualizza tutti con titolo diverso <br/>
    /// </summary>
    /// <param name="pathDirJson">path della cartella JSON</param>
    /// <param name="opz">Opzione: default "all"</param>
    /// <returns><b>true</b> se è vuoto, <b>false</b> se c'è almeno un alimento</returns>
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
        if (opz != "del" || frigoVuoto)
        {
            Console.Write("\npremi un tasto...");
        }

        return frigoVuoto;
    }

    /// <summary>
    /// Gestisce l'eliminazione degli alimenti, utilizza i seguenti metodi: <br/>
    /// <i>StampaAlimento()</i> per visualizzare la lista aggiornata. <br/>
    /// <i>SelezionaElimina()</i> 
    /// </summary>
    /// <param name="pathDirJson">Path della directory JSON</param>
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

    /// <summary>
    /// Metodo accessorio che permette di eliminare alimenti (file JSON) o di modificare <br/>
    /// la quantita di uno di essi (modifica il campo quantita nel file JSON).
    /// </summary>
    /// <param name="pathDirJson"></param>
    /// <returns><b>true</b> se non voglio più inserire alimenti, <b>false</b> se continuo a eliminare</returns>
    static bool SelezioneElimina(string pathDirJson)
    {
        //seleziono tutti i file della cartella JSON
        string[] files = Directory.GetFiles(pathDirJson);
        int conta = files.Length;   // conto i file
        bool eseguito = false;

        string messaggioSiNo = "\nVuoi eliminare qualcosa? (s/n) ";
        Console.WriteLine(messaggioSiNo);
        string input = Console.ReadLine()!;
        if (input == "n")
        {
            eseguito = true;    //se non voglio piu inserire torno al menu principale
        }
        else if (input == "s")
        {
            var cursore = Console.GetCursorPosition();
            PulisciRiga(messaggioSiNo.Length, 0, cursore.Top - 2);
            Console.WriteLine("Cosa vuoi eliminare?");
            Console.Write(" \r");
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
                                Thread.Sleep(600);
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
        else
        {
            string errore = "Selezione errata\r";
            ScriviAColori(errore, "rosso");
            PulisciRiga(errore.Length, 0, 1);
        }
        return eseguito;
    }

    /// <summary>
    /// Metodo accessorio che crea un file JSON per ogni alimento inserito nel formato: <br/>
    /// - alimento_gg_mm.json <br/>
    /// Se il file non esiste lo crea.
    /// 
    /// </summary>
    /// <param name="alimento">Il nome dell'alimento da inserire nel JSON</param>
    /// <param name="quantita">La quantita dell'alimento da inserire nel JSON</param>
    /// <param name="scadenza">La data di scadenza dell'alimento da inseire nel JSON</param>
    /// <param name="opz">'e' - elimina (default); 'a' - aggiungi</param>
    /// <returns><b>true</b> se la serializzazione va a buon fine, <b>false</b> in caso di errore</returns>
    static bool CreaAlimentoJSON(string alimento, int quantita, string scadenza, char opz = 'e')
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
                //inserisco i dati nel file JSON
                File.WriteAllText(pathJson, JsonConvert.SerializeObject(new { alimento, quantita, scadenza }));
            }
            else    //se c'è gia, gestisce la quantita (elimina o aggiunge)
            {
                if (opz == 'a') //se opzione 'a' ---> aggiungi alimento
                {
                    string jsonFile = File.ReadAllText(pathJson);
                    dynamic obj = JsonConvert.DeserializeObject(jsonFile)!;
                    int quantitaDaAggiornare = obj.quantita;
                    quantita += quantitaDaAggiornare;   //aggiorno la quantita dell'alimento
                }
                //inserisco i dati nel file JSON
                File.WriteAllText(pathJson, JsonConvert.SerializeObject(new { alimento, quantita, scadenza }));
            }

            return true;
        }
        catch
        {
            ScriviAColori("Errore [CreaAlimentoJSON]!!!", "rosso");
            return false;
        }
    }

    /// <summary>
    /// Metodo accessorio che conta tutti i file nella cartella JSON
    /// </summary>
    /// <param name="pathDirJson">Il path della directory JSON</param>
    /// <returns>Il numero dei files contenuti nella cartella JSON</returns>
    static int ContaJson(string pathDirJson)
    {
        string[] files = Directory.GetFiles(pathDirJson);
        return files.Length;
    }

    /// <summary>
    /// Metodo accessorio che permette la lettura del file csv e lo salva nel json corretto. <br/>
    /// Dopo la lettura dei dati, il file csv viene spostato nella directory ./files/temp/.
    /// </summary>
    /// <returns><b>false</b> se non è presente il file csv, <b>true</b> altrimenti</returns>
    static bool InserisciDaCSV()
    {
        string pathCSV = @"./files/inserisci.csv";
        string pathTemp = @"./files/temp/";
        if (!File.Exists(pathCSV))
        {
            ScriviAColori("Nessun file csv trovato", "rosso");
            Thread.Sleep(800);
            Console.Clear();
            Console.WriteLine("Vuoi importare un file di prova per il primo avvio?  (s/n)");
            bool corretto = false;
            while (!corretto)   //verifica inserimento
            {
                string input = Console.ReadLine()!.ToLower();
                if (input == "s")
                {
                    CreaCsvProva(pathCSV);
                    corretto = true;
                }
                else
                {
                    string errore = "Selezione errata\r";
                    ScriviAColori(errore, "rosso");
                    PulisciRiga(errore.Length, 0, 1);
                }

            }
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
            if (!Directory.Exists(pathTemp))
            {
                Directory.CreateDirectory(pathTemp);

            }
            if (File.Exists(pathTemp + "inserito.csv"))
            {
                File.Delete(pathTemp + "inserito.csv");
            }
            File.Move(pathCSV, $"{pathTemp}inserito.csv");
        }
        return true;
    }

    /// <summary>
    /// Utility che crea un file csv di prova per il primo avvio del programma.
    /// </summary>
    /// <param name="pathCSV">Path del file csv da creare</param>
    static void CreaCsvProva(string pathCSV)
    {
        File.Create(pathCSV).Close();

        string[] contenutoCSV = [

            "alimento,quantita,scadenza",
            "yogurt,4,15/02/2024",
            "formaggio,2,30/04/2024",
            "yogurt,2,20/02/2024",
            "mozzarella,1,20/02/2024",
            "spinaci,3,08/02/2024",
            "prosciutto cotto,2,15/02/2024",
            "prosciutto cotto,1,02/02/2024"
        ];

        foreach (string alimento in contenutoCSV)
        {
            File.AppendAllText(pathCSV, alimento + "\n");
        }
        ScriviAColori("\nFile creato correttamente", "verde");
        Console.Write("\npremi un tasto...");
        Console.ReadKey();
    }

    /// <summary>
    /// Gestisce l'iserimento del nome dell'alimento, controlla l'input inserito.
    /// </summary>
    /// <returns>Il nome dell'alimento inserito dall'utente.</returns>
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

    /// <summary>
    /// Gestisce l'iserimento della quantita dell'alimento, controlla l'input inserito.
    /// 
    /// </summary>
    /// <returns>La quantita dell'alimento inserito dall'utente (verifica l'input)</returns>
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

    /// <summary>
    /// Gestisce l'iserimento della data di scadenza dell'alimento, controlla l'input inserito.
    /// </summary>
    /// <returns>La data di scadenza inserita dall'utente, formattata e verificata</returns>
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

    /// <summary>
    /// Verifica se il prodotto è prossimo alla scadenza controllando la data di oggi e quella del prodotto.
    /// 
    /// </summary>
    /// <param name="scadenza">Data di scadenza dell'alimento da controllare</param>
    /// <param name="offset">Entro quanti giorni verificare se un alimento sta per scadere</param>
    /// <returns><b>true</b> se l'alimento sta per scadere, <b>false</b> se ancora valido</returns>
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

    /// <summary>
    /// Gestisce l'input dell'utente alla richiesta di selezione nel menu inserimento alimenti.
    /// </summary>
    /// <returns>opzione scelta dell'utente in formato char</returns>
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
    /// Metodo accessorio che permette di scrivere un testo a colori.<br/>
    /// Scrive il contenuto di 'messaggio' nel colore scelto e reimposta <br/>
    /// il colore di default alla fine. Non va a capo. <br/><br/>
    /// Colori disponibili: <br/>
    /// - "rosso" <br/>
    /// - "blu" <br/>
    /// - "magenta" <br/>
    /// - "verde" <br/>
    /// - "giallo" <br/>
    /// 
    /// </summary>
    /// <param name="messaggio">Il messaggio da stampare a colori</param>
    /// <param name="colore">Il colore in formato string es. "rosso"</param>
    /// <param name="opz">Opzione: 'f' default; 'b per lo sfondo</param>
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
```

```json
{
    "alimento": "mozzarella",
    "quantita": 1,
    "scadenza": "20/02/2024"
}
```
 >Possibilità di creare il file "inserisci.csv" automaticamente dal menu di inserimento.
 
```csv
alimento,quantita,scadenza
yogurt,4,15/02/2024
formaggio,2,30/04/2024
yogurt,2,20/02/2024
mozzarella,1,20/02/2024
spinaci,3,08/02/2024
prosciutto cotto,2,15/02/2024
prosciutto cotto,1,02/02/2024
```