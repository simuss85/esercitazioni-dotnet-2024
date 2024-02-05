using Newtonsoft.Json;

class Program
{
    static void Main(string[] args)
    {
        #region Tipi di dati e variabili

        bool finito = false;
        char opz;

        #endregion

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
                    opz = SelezioneInserimento();
                    if (opz != 'r')
                    {
                        Inserisci(opz);
                    }
                    // InserisciCSV();
                    break;

                case '2':
                    // VisualizzaAlimenti();
                    Console.Clear();

                    break;

                case '3':
                    // VisualizzaAlimenti(opzione);
                    Console.Clear();

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
        Console.WriteLine();
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
    static bool Inserisci(char opzione)
    {
        bool eseguito;
        //inserisci da file csv
        if (opzione == 'f')
        {
            //lettura del file csv
            eseguito = InserisciDaCSV();
        }
        else     //inserisci da tastiera
        {
            Console.Clear();
            eseguito = InserisciDaTastiera();
        }

        return eseguito;
    }

    /*Gestisce l'inserimento dei dati mediante i metodi di controllo input:
      - InserisciNome() ---> verifica il formato del nome
      - InserisciQuantita--> verifica il formato quantita
      - InserisciData------> verifica la data di scadenza
      
      */
    static bool InserisciDaTastiera()
    {
        bool corretto = false;
        string nome, quantita, data;

        while (!corretto)
        {
            ScriviAColori("Inserisci gli alimenti", "verde");
            Console.WriteLine("\n");
            Console.Write("Alimento: ");
            nome = FormatoNome();
            Console.Write("Quantità: ");
            quantita = FormatoQuantita();
            Console.Write("Data gg/mm/aaaa: ");
            data = FormatoData();

            //se i controlli vanno a buon fine procedo con l'inserimento
            //inserisci i dati nel file JSON
            corretto = CreaAlimentoJSON(nome, quantita, data);
        }


        return corretto;



    }

    /*Metodo accessorio, crea un file JSON per ogni alimento, nel caso fosse 
      gia presente lo rinomina.
      
      INPUT: string nome -------> nome alimento 
             string quantita ---> quantita alimento
             string data -------> data di scadenza
      
      OUTPUT: true se tutto è andato a buon fine; 
    */
    static bool CreaAlimentoJSON(string nome, string quantita, string data)
    {
        string pathJson = @"./files/JSON/" + nome + ".json";
        int count = 1;
        try
        {
            if (!File.Exists(pathJson)) //se non c'è alcun prodotto lo creo
            {
                File.Create(pathJson).Close();
            }
            else    //se c'è gia quell'alimento ne creo uno nuovo
            {
                pathJson = @"./files/JASON/" + nome + count + ".json";
            }
            //inserisco i dati nel file JSON
            File.AppendAllText(pathJson, JsonConvert.SerializeObject(new { nome, quantita, data }));
            return true;
        }
        catch
        {
            ScriviAColori("Errore [InserisciJSON]!!!", "rosso");
            return false;
        }

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
                Console.SetCursorPosition(10,2);
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

        while (!corretto)
        {
            try
            {
                quantita = Int16.Parse(Console.ReadLine()!);
                corretto = true;
            }
            catch (Exception)
            {
                ScriviAColori("deve essere un numero\r", "rosso");
                Thread.Sleep(1000);
                Console.Write("                      ");
                Console.SetCursorPosition(10,3);
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

                if (anno < annoInCorso) //anno precedente quindi scaduto
                {
                    ScriviAColori("alimento gia scaduto\r", "rosso");
                    Thread.Sleep(1000);
                    Console.Write("                    \rData gg/mm/aaaa: ");
                    continue;
                }
                else if (anno == annoInCorso)      //anno attuale verifico mese e giorno
                {
                    if (mese < meseInCorso) //mese
                    {
                        ScriviAColori("alimento gia scaduto\r", "rosso");
                        Thread.Sleep(1000);
                        Console.Write("                    \rData gg/mm/aaaa: ");
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
                            ScriviAColori("alimento gia scaduto\r", "rosso");
                            Thread.Sleep(1000);
                            Console.Write("                    \rData gg/mm/aaaa: ");
                            continue;
                        }
                        else if (giorno > 31)   //giorno inserito errato
                        {
                            throw new Exception();
                        }
                    }
                }
            }
            catch (Exception)
            {
                ScriviAColori("formato data errato\r", "rosso");
                Thread.Sleep(1000);
                Console.Write("                    \rData gg/mm/aaaa: ");
                continue;
            }
            corretto = true;
        }
        return input;
    }

    /*Gestisce la scelta del menu di inserimento

      OUTPUT: char opz ---> opzione scelta dall'utente
    */
    static char SelezioneInserimento()
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