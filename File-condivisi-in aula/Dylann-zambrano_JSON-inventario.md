# Gestionale di un negozio di strumenti musicali

## README
<p>Un programma che serve a gestire l'inventario di un negozio (in questo caso uno che si occupa di strumenti musicali)<br>
Le sue funzioni: ricerca di articoli in diversi modi, aggiunta di articoli e termine del programma (in futuro verranno aggiunte altre funzionalità)
</p>

## CODICE


### File di una categoria

```json
{
    "nome":"Aerofoni",
    "quantita":0,
    "numero":1,
    "something":false
    }
```


### File csv
```csv
Aerofoni,Cordofoni,Membranofoni,Idiofoni,Misc
```

### C#
<details>
    <summary>IL CODICE</summary>
    <pre style="height: 500px; overflow: scroll;">


```c#
using System.Text.Json.Nodes;
using Newtonsoft.Json;

class Program
{

    /*
    inizio
    check se c'è tutto
    manca il csv? tutto si rinizia
    manca solo qualche json? usa il csv per capire quali mancano
    all done? inizio del vero e proprio programma
    per ora diamo per scontato che i file son come da programma
    menù.... pensa prima all'inizio per ora

    menù: 1 opzione di ricerca, 1 opzione di aggiunta, un opzione di uscita
    la ricerca avrà altre opzioni: ricerca diretta, ricerca da tag e ricerca da categoria
        diretta equivale a sapere perfettamente il nome dell'articolo
        da tag equivale invece a vole vedere tutti quelli che hanno una determinata caratteristica
        da categoria, mostra solo tutti quelli che rientrano in una categoria, unica che non necessita di imettere un nome da tastiera
    Le prime due modalità avranno un opzione per uscire in caso di tentativo fallito di ricerca, se non è una ricerca diretta
    il programma chiederà quale vedere in specifico tra gli articoli
    L'aggiunta, oltre ad obbligare al gestore di mettere delle cose di default, permetterà di mettere dei tag extra
    L'uscita sai già cosa fa
    */
    static void Main(string[] args)
    {
        //nome della cartella di default
        string pathDir = @"inventory";
        //messaggio iniziale, lo si può anche commentare
        Console.WriteLine("Salve, salve, stavo appena cercando il menù, mi dia un secondo");
        //try catch onde ad evitare che ci sia stato qualche errore nella ricerca della cartella
        try
        {
            //il csv delle categorie è fondamentale, se non esiste allora c'è un problema alla radice, meglio rinizializzare
            string[] files = Directory.GetFiles(pathDir, "Categorie.csv");
            //si controlla cosa contiene
            string[] lines = File.ReadAllLines(pathDir + @"\Categorie.csv");
            string[][] nomi = new string[lines.Length][];
            //serve per poter leggere i nomi completi, separati dalla virgola in questo caso
            for (int i = 0; i < lines.Length; i++)
            {
                nomi[i] = lines[i].Split(",");
            }
            //si raccolgono tutti i nomi dei file json esistenti in quella cartella
            files = Directory.GetFiles(pathDir, "*.json");
            //e si controlla che ci siano i file delle categorie, prese precedentemente dal file csv
            for (int i = 0; i < nomi[0].Length; i++)
            {
                //puramente per mostrare cosa conteneva la matrice nomi
                //Console.WriteLine(nomi[0][i]);

                //necessario per sapere se si trova il file ricercato
                bool esiste = false;
                //il path del file ricercato
                string filePath = pathDir + @"\" + nomi[0][i] + ".json";
                //si fa un controllo con tutti i file trovati nella cartella
                foreach (string file in files)
                {
                    //puramente per debug le seguenti due linee
                    //Console.Write(file);
                    //Console.WriteLine($" against {filePath}");
                    //se ha trovato, allora segna nel bool
                    if (file == filePath)
                    {
                        esiste = true;
                    }
                }
                //se non si fosse riuscito a trovare il file, lo si ricrea a parte
                if (!esiste)
                {
                    CreaCateMancante(filePath, nomi[0][i], i + 1);
                }
                //Console.WriteLine("£ To the next, To the best we're set £");
                //Thread.Sleep(1200);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"C'è stato qualche problema nella ricerca delle categorie, reinizializzazione in corso\n{e.Message}");
            Directory.CreateDirectory(pathDir);
            CreaFileCate(pathDir);
        }
        //Thread.Sleep(1200);

        //inizio vero e proprio del programma
        bool end = false;
        while (!end)
        {
            //per ordine visivo
            Console.Clear();
            //appare il menu, pensavo in futuro di renderlo largo 2 invece di 1 sola colonna
            Console.WriteLine("Selezioni un opzione da eseguire:\n\n1. Ricerca di un articolo\n2. Aggiunta di un articolo\n3. Uscire");
            //bool per uscire dal while, finchè è attivo, vuol dire che il gestore non ha scelto ancora l'opzione
            bool selezionando = true;
            while (selezionando)
            {
                //lo disattivo subito per evitare di dover attivarlo per tutti i casi aldifuori del Default case
                selezionando = false;
                ConsoleKeyInfo opzione = Console.ReadKey();
                switch (opzione.Key)
                {
                    //ho messo entrambi i modi per mettere uno in caso il gestore preferisse metterlo dal pad
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        //da mettere la funzione dedicata alla ricerca
                        Console.WriteLine("\nRicerco e chiudo");
                        RicercArto(pathDir);
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        //da mettere la funzione dedicata all'aggiunta
                        Console.WriteLine("\nAggiungo... niente, chiudo :D");
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        //messaggio di chiusura programma
                        Console.WriteLine("\nAddio");
                        //si attiva il token per avvisare al programma del termine
                        end = true;
                        break;
                    //in caso non si sia premuta un azione
                    default:
                        Console.Write("\r");
                        //si riattiva il token per forzare a mettere l'opzione giusta
                        selezionando = true;
                        break;
                }
            }
        }

    }


    //Funzione per inizializzare una struttra personalizzata
    static void CreaFileCate(string direPath, bool custom)
    //direPath è la cartella dove creare l'inventario, invece custom è un bool per procedere con l'operazione
    {
        //infatti, prima si vede se effettivamente chi l'ha richiamato, vuole farlo customizzato
        if (custom)
        {
            //Creazione del csv contenente tutte le categorie di default
            string path = direPath + @"\Categorie.csv";
            File.Create(path).Close();

            bool finish = false;
            int i = 0;
            while (!finish)
            {
                Console.WriteLine("Inserisci la categoria:");
                string cate = Console.ReadLine()!;
                File.AppendAllText(path, cate);
                i++;
                string path2 = direPath + @"\" + cate + ".json";
                File.Create(path2).Close();
                //creazione json della categoria
                File.AppendAllText(path2, JsonConvert.SerializeObject(new { nome = cate, quantita = 0, numero = i, something = false }));
                //creazione della cartella dedicata
                //Directory.CreateDirectory(direPath+@"\"+cate);
                //questa parte è solo per vedere cosa ha fatto
                string json = File.ReadAllText(path2);
                dynamic obj = JsonConvert.DeserializeObject(json)!;
                Console.WriteLine($"Nome categoria: {obj.nome}, con {obj.quantita} articoli, numero di serie {obj.numero}, and its fullnes...{obj.something}");
                Console.WriteLine("vuoi aggiungere un altra categoria?");
                if (RispoInvioSiNoBreve("s", "n"))
                {
                    File.AppendAllText(path, ",");
                }
                else
                {
                    finish = true;
                }
            }
        }
        //altrimenti... si richiama la versione standard della funzione
        else
        {
            CreaFileCate(direPath);
        }
    }
    //Funzione per inizializzare la struttura
    static void CreaFileCate(string direPath)   //direPath contiene il luogo in cui la cartella contenente l'inventario sarà situato
    {
        //Creazione del csv contenente tutte le categorie di default
        string path = direPath + @"\Categorie.csv";
        File.Create(path).Close();
        //probailmente vedrò di creare una versione in cui puoi dinamicamente scegliere te quante farne e nominarli da te
        File.WriteAllText(path, "Aerofoni,Cordofoni,Membranofoni,Idiofoni,Misc");

        //copia del testo csv
        string[] lines = File.ReadAllLines(path);
        string[][] nomi = new string[lines.Length][];
        //dichiarazione variabile, servirà che sia rimodificabile anche al di fuori di un ciclo
        int i = 0;
        for (i = 0; i < lines.Length; i++)
        {
            nomi[i] = lines[i].Split(",");
        }
        i = 0;

        //Creazione dei file json e cartelle dedicate
        foreach (string[] nome in nomi)
        {
            //dato che il csv ha solo una linea, per ora ho fatto questo doppio ciclo
            foreach (string n in nome)
            {
                //i è per mettere una variabile
                i++;
                string path2 = direPath + @"\" + n + ".json";
                File.Create(path2).Close();
                //creazione json della categoria
                File.AppendAllText(path2, JsonConvert.SerializeObject(new { nome = n, quantita = 0, numero = i, something = false }));
                //creazione della cartella dedicata
                //Directory.CreateDirectory(direPath+@"\"+n);
                //questa parte è solo per vedere cosa ha fatto
                string json = File.ReadAllText(path2);
                dynamic obj = JsonConvert.DeserializeObject(json)!;
                Console.WriteLine($"Nome categoria: {obj.nome}, con {obj.quantita} articoli, numero di serie {obj.numero}, and its fullnes...{obj.something}");
            }
        }
    }
    //Funzione per inizializzare un file json specifico
    static void CreaCateMancante(string filePath, string name, int num)
    //filePath contiene l'indirizzo del file mancante, name invece il nome della categoria e num l'id della categoria
    {
        //vien creato un nuovo file, tramite il path ricevuto come parametro
        File.Create(filePath).Close();
        File.WriteAllText(filePath, JsonConvert.SerializeObject(new { nome = name, quantita = 0, numero = num, something = false }));
        //puramente per sapere cosa contiene, lo si può anche commentare/cancellare
        string json = File.ReadAllText(filePath);
        dynamic obj = JsonConvert.DeserializeObject(json)!;
        Console.WriteLine($"Nome categoria: {obj.nome}, con {obj.quantita} articoli, numero di serie {obj.numero}, and its fullnes...{obj.something}");
    }

    //funzione per scegliere tra due opzioni, risposta messa con invio
    static bool RispoInvioSiNoBreve(string conf, string nega) //le due stringhe son le opzioni che l'utente dovrà digitare
    {
        //bool per terminare un ciclo non forzatamente
        bool end = false;
        //la risposta che verrà usata per il return
        bool rispo = false;
        //iniziando con falso, end diviene vero solamente quando l'utente digita una delle risposte
        while (!end)
        {
            //risposta da tastiera
            string reply = Console.ReadLine()!;
            //i tolower è per non essere pignoli anche con il case, non dovrebbe esserci il bisogno
            if (reply.ToLower() == conf.ToLower())
            {
                //unico momento in cui rispo cambia di valore, essendo dichiarato come falso all'inizio
                rispo = true;
                end = true;
            }
            else
            if (reply.ToLower() == nega.ToLower())
            {
                end = true;
            }
            //il ciclo non termina finchè l'utente non scrive una delle alternative
            else
            {
                Console.WriteLine($"Per favore, le chiedo di digitare tra {conf} o {nega}");
            }
        }
        return rispo;
    }

    //funzione che si occupa della ricerca dell'articolo
    static void RicercArto(string direPath)
    //percorso dellla cartella dell'inventario, sarà necessario averla per altre funzioni
    {
        //per ordine visivo
        Console.Clear();
        Console.WriteLine("Come vuoi ricercare l'articolo:\n\n1. Ricerca diretta\n2. Ricerca da tag\n3. Mostra una categoria\n4. Torna indietro");
        //bool per uscire dal while, finchè è attivo, vuol dire che il gestore non ha scelto ancora l'opzione
        bool selezionando = true;
        while (selezionando)
        {
            //lo disattivo subito per evitare di dover attivarlo per tutti i casi aldifuori del Default case
            selezionando = false;
            ConsoleKeyInfo opzione = Console.ReadKey();
            switch (opzione.Key)
            {
                //ho messo entrambi i modi per mettere uno in caso il gestore preferisse metterlo dal pad
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    //si richiama la funzione dedicata alla ricerca diretta
                    RicercaDirettArto(direPath);
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    //si richiama la funzione per cercare tramite tag
                    RicercaArTag(direPath);
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    //si richiama la funzione per cercare tramite categoria
                    RicerCategoria(direPath);
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    //non si fa niente, il ciclo che l'ha richiamato farà il resto
                    Console.WriteLine("\nEcche");
                    break;
                //in caso non si sia premuta un azione
                default:
                    Console.Write("\r");
                    //si riattiva il token per forzare a mettere l'opzione giusta
                    selezionando = true;
                    break;
            }
        }
    }
    //funzione per la ricerca diretta
    static void RicercaDirettArto(string direPath)
    //direPath= percorso della cartella dell'inventario
    {
        //end è per finire il ciclo
        bool end = false;
        Console.WriteLine("Dimmi il nome specifico dello strumento che cerchi");
        while (!end)
        {
            end=true;
            //si inserirà un nome
            string look = Console.ReadLine()!;
            //bool per avvisare che non si ha trovato il nome
            bool miss=false;
            //array che dovrebbe avere solo un percorso, dato che il nome del file è un nome specifico
            string [] temp=Directory.GetFiles(direPath,look+"_*.json");
            string filePath="";
            //per evitare che alla fine ci sia stato qualche problema nel trovare il file
            if(temp==null)
                miss=true;
            else
            {
                filePath=temp[0];
                Console.WriteLine(filePath);
                Console.ReadKey();
            }

            //se non esiste (o semplicemente non si ha messo niente)
            if (look == ""||miss)
            {
                end=false;
                //si darà l'opzione di riprovare, ma stavolta tramite invio, vediamo di evitare di rifare l'operazione non voluta stavolta
                Console.WriteLine("Well... that was awkward\nVuoi riscrivere o tornare indietro?\n(1 per riscrivere/2 per tornare al menù)");
                //in caso si decidesse di no
                if (!RispoInvioSiNoBreve("1", "2"))
                {
                    //si avvisa al ciclo che si è finito con l'operazione di ricerca
                    Console.WriteLine("Allora mi faccia riprendere il menù...");
                    Thread.Sleep(1200);
                    end=true;
                }
            }
            //se si trova invece, si mostreranno tutte le informazioni dell'articolo trovato
            else
            {

                //da aggiungere un modo per estrapolare TUTTE le informazioni dell'articolo
                Console.WriteLine("Trovato:\n");
                StampArtoCompl(filePath!);
                //si lascerà al gestore vedere per quanto tempo vuole, basta toccare qualcosa per tornare al menù... magari è meglio dopo aver premuto invio
                Console.WriteLine("Tocchi un pulsante quando vuole ritornare al menù");
                Console.ReadKey();
            }
        }
    }
    //funzione per la ricerca via tag
    //WIP
    static void RicercaArTag(string direPath)
    //direPath= percorso della cartella dell'inventario
    {
        bool end = false;
        Console.WriteLine("Dimmi che caratteristica stai cercando");
        while (!end)
        {
            string look = Console.ReadLine()!;
            //onde ad evitare che prenda anche i file json dedicate alle categorie, aggiungo *_ per prendere solo gli articoli
            string[] arti= Directory.GetFiles(direPath, "*_"+"*.json");
            //bool per avvisare se non si ha trovato l'articolo col tag
            bool miss=false;
            if(arti==null)
            {
                miss=true;
                Console.WriteLine("Sfortunatamente, non ho trovato nemmeno un articolo, ti toccherà aggiungere qualcosa");
                //attivo già end per terminare questa parte di codice, è alquanto inutile cercare un articolo quando non ce nè nessuno
                end=true;
            }
            //trova un modo per controllare tutti i parametri di un file
            string[] specificArti=new string [arti!.Length];
            //da qui, o faccio una funzione che me lo faccia in automatico, o lo faccio qui un ciclo
            //scelto di farlo in un ciclo

            //counter per tener conto di quanti file hai trovato il tag
            int count=0;
            //si controlla se almeno si è trovato un file articolo
            if(!miss)
            {
                //bool solo per evitare di ristampare una cosa più volte
                bool wrote=false;
                //si controlla ogni file json
                foreach (string arto in arti!)
                {
                    //si deserializza il file json per poter controllare tutte le sue chiavi
                    string json=File.ReadAllText(arto);
                    dynamic obj=JsonConvert.DeserializeObject(json)!;
                    //si controlla tramite foreach le chiavi del file json
                    foreach(KeyValuePair<string, JsonNode?>subObj in obj)
                    {
                        //se la chiave ha un valore uguale a quello che l'operatore cerca
                        if(obj.subObj.key==look)
                        {
                            if(!wrote)
                            {
                                Console.WriteLine("Ecco a te l'elenco che ho trovato:\n");
                                wrote=true;
                            }
                            //lo aggiunge alla lista di file da poi mostrare
                            specificArti[count]=arto;
                            count++;
                            //e si fa una stampa in modo che l'operatore sappia cosa ha trovato
                            Console.Write($"{count}. ");
                            StampArtoSimple(arto);
                        }
                    }
                }
            }
            //il resize è per questione di memoria... per ora
            Array.Resize(ref specificArti, count);
            if(count<=0)
            {
                miss=true;
            }
            //se non si trova una caratteristica dell'articolo
            if ((look == ""||miss)&&!end)
            {
                //si lascerà l'opzione di andarsene invece di riprovare
                Console.WriteLine("Well... that was awkward\nVuoi riscrivere o tornare indietro?\n(1 per riscrivere/2 per tornare al menù)");
                if (!RispoInvioSiNoBreve("1", "2"))
                {
                    Console.WriteLine("Allora mi faccia riprendere il menù...");
                    end = true;
                    Thread.Sleep(1200);
                }
            }/*
            //altrimenti, si mostra in breve una lista di tutti gli articoli
            else
            {
                //da lì dare il numero di path, passare l'array da parametro con il massim in una funzione a parte
                Console.WriteLine("Ecco a te l'elenco che ho trovato:\n");
                //i serve per sapere quanti ne ha trovati, servirà per la selezione
                int i = 0;
                foreach (string arto in arti!)
                {
                    //i aumenta per ogni articolo
                    i++;
                    Console.Write(i+". ");
                    StampArtoSimple(arto);
                }
                Console.WriteLine("\nQuale vuole vedere in particolare?\n(se non si vuole vedere, basta inviare 0)");
                ScegliXOpzioni(i, arti);
            }*/
        }
        Console.WriteLine("Tocchi un pulsante quando vuole ritornare al menù");
        Console.ReadKey();
    }
    //funzione per la ricerca delle categorie
    static void RicerCategoria(string direPath)
    //questa è la versione di default, richiamalo solamente se non hai voluto personalizzare/modificare le categorie
    {
        //try catch per evitare problemi durante la ricerca del file
        try
        {
            string[] paths = Directory.GetFiles(direPath, @"*.json");
            //while per tornare in caso una catogoria non avesse niente (il menù è stato designato per ripulire tutto)
            bool end = false;
            while (!end)
            {
                //pulizia visiva
                Console.Clear();
                //Richiesta all'operatore di scegliere tra 5 opzioni
                Console.WriteLine("Selezioni tra le seguenti categorie:\n");
                //un ulteriore try-catch in caso ci fosse un errore nel ritrovare i file json di default
                //quindi un modo per capire di preciso cosa è andato storto
                try
                {
                    //i è unicamente per grafica in questo caso
                    int i = 0;
                    foreach (string cate in paths)
                    {
                        //do per scontato che non ci sia nessun underscore nemmeno nella cartella contenente tutti i file
                        if (!cate.Contains("_"))
                        {
                            string json=File.ReadAllText(cate);
                            dynamic obj = JsonConvert.DeserializeObject(json)!;
                            Console.WriteLine($"{i + 1}. {obj.nome}");
                            i++;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Welp, probabilmente non ho manco trovato la struttura originare, ti mostro che mi dice il mio compare\n{e.Message}\nIo terminerei qui il programma");
                }
                //volevo evitare qualsiasi azione successiva se ci fosse stato qualche problema
                finally
                {
                    //lo si mette già a true, dato che molte azioni non son designate per rifare questa parte di codice
                    end = true;
                    //bool per uscire dal while, finchè è attivo, vuol dire che il gestore non ha scelto ancora l'opzione
                    bool selezionando = true;
                    //servirà per la ricerca di diversi file
                    string scelta = "";
                    while (selezionando)
                    {
                        //lo disattivo subito per evitare di dover attivarlo per tutti i casi aldifuori del Default case
                        selezionando = false;
                        ConsoleKeyInfo opzione = Console.ReadKey();
                        switch (opzione.Key)
                        {
                            //ho messo entrambi i modi per mettere uno in caso il gestore preferisse metterlo dal pad
                            case ConsoleKey.D1:
                            case ConsoleKey.NumPad1:
                                //la prima categoria erano gli aerofoni
                                Console.WriteLine("\nAerofoni");
                                scelta = "Aerofoni";
                                //ricorda, la ricerca dovrebbe rilevare l'occorrenza nel nome dei file json, divisi da _
                                break;
                            case ConsoleKey.D2:
                            case ConsoleKey.NumPad2:
                                //la seconda categoria erano i cordofoni
                                Console.WriteLine("\nCordofoni");
                                scelta = "Cordofoni";
                                //ricorda, la ricerca dovrebbe rilevare l'occorrenza nel nome dei file json, divisi da _
                                break;
                            case ConsoleKey.D3:
                            case ConsoleKey.NumPad3:
                                //la terza categoria erano i membranofoni
                                Console.WriteLine("\nMembranofoni");
                                scelta = "Membranofoni";
                                //ricorda, la ricerca dovrebbe rilevare l'occorrenza nel nome dei file json, divisi da _
                                break;
                            case ConsoleKey.D4:
                            case ConsoleKey.NumPad4:
                                //la quarta categoria erano gli idiofoni
                                Console.WriteLine("\nIdiofoni");
                                scelta = "Idiofoni";
                                //ricorda, la ricerca dovrebbe rilevare l'occorrenza nel nome dei file json, divisi da _
                                break;
                            case ConsoleKey.D5:
                            case ConsoleKey.NumPad5:
                                //la quinta categoria erano cose extra, abbreviato con Misc
                                Console.WriteLine("\nMisc");
                                scelta = "Misc";
                                //ricorda, la ricerca dovrebbe rilevare l'occorrenza nel nome dei file json, divisi da _
                                break;
                            //in caso non si sia premuta un azione
                            default:
                                Console.Write("\r");
                                //si riattiva il token per forzare a mettere l'opzione giusta
                                selezionando = true;
                                break;
                        }
                    }
                    //ora di mostrare tutti i file appartenenti alla categoria

                    string json=File.ReadAllText(direPath + @"\" + scelta + ".json");
                    //ma prima farei un controllo se la categoria ha effettivamente qualcosa
                    dynamic obj = JsonConvert.DeserializeObject(json)!;
                    if ((bool)obj.something)
                    {
                        //ho specificato l'underscore in modo da evitare di includere la categoria in sè
                        string[] arti = Directory.GetFiles(direPath, "*_" + scelta + "_*.json");
                        //i serve per sapere quanti ne ha trovati, servirà per la selezione
                        int i = 0;
                        foreach (string arto in arti)
                        {
                            //i aumenta per ogni articolo
                            i++;
                            StampArtoSimple(arto);
                            Console.WriteLine();
                        }
                        Console.WriteLine("\nQuale vuole vedere in particolare?\n(se non si vuole vedere, basta inviare 0)");
                        ScegliXOpzioni(i, arti);
                    }
                    //se non c'è nessun articolo, non si ci può fare niente
                    else
                    {
                        Console.WriteLine($"Sfortunatamente, {scelta} non ha nessun articolo associato, vuole controllare un altra categoria?\n(s per si, n per no)");
                        if (RispoInvioSiNoBreve("s", "n"))
                        {
                            end = false;
                        }
                    }
                }
            }
        }
        //pensavo che se davvero non si trovava questo file, qualcuno avrà forzatamente manipolato i file
        //quindi magari dare l'opzione al gestore di resettare i file principali
        catch
        {
            Console.WriteLine("Guess c'è qualche problema a livello di file, potrei anche resettare le categorie, se lo ritiene necessario\n(s per resettare le categorie/n per lasciare perdere)");
            if (RispoInvioSiNoBreve("s", "n"))
            {
                CreaFileCate(direPath);
            }
        }
    }

    //funzione per stampare le informazioni minime di un articolo
    static void StampArtoSimple(string nomePath)    //il nomePath è il percorso del file
    //pensavo, magari fare un return del mero nome, ma lo tengo come una possibile idea
    {
        /*
        struttura di un articolo:
        nome specifico
        Nome familia
        Categoria
        Prezzo
        <not important anymore>
        descrizione
        categorie e sottocategoria
        */
        string json=File.ReadAllText(nomePath);
        dynamic obj = JsonConvert.DeserializeObject(json)!;
        //stampa dell'informazione
        Console.WriteLine($"{obj.nomeProprio}, {obj.nomeGen}, {obj.categoria}, {obj.prezzo}");
    }
    //funzione per stampare le informazioni minime di un articolo
    static void StampArtoCompl(string nomePath)    //il nomePath è il percorso del file
    //pensavo, magari fare un return del mero nome, ma lo tengo come una possibile idea
    {
        /*
        struttura di un articolo:
        nome specifico
        Nome familia
        Categoria
        Prezzo
        <not important anymore>
        descrizione
        tag e subtag (what the hell are ya talking about, developer?)
        */
        //ricorda che bisogna prima LEGGERE IL TESTO DEL FILE
        string json=File.ReadAllText(nomePath);
        dynamic obj = JsonConvert.DeserializeObject(json)!;
        //stampa dell'informazione
        Console.WriteLine($"Nome completo: {obj.nomeProprio}\nOggetto: {obj.nomeGen}\nCategoria: {obj.categoria}\nPrezzo: {obj.prezzo}\n\nDescrizione:\n{obj.descrizione}");
    }

    //funzione per scegliere tra x opzioni da stampare in completo, usato mainly per le ricerche tag e categoria
    static void ScegliXOpzioni(int max, string[] pathArti)
    //int max serve per avere un massimo in cui l'operatore può scegliere, l'array paths contiene diversi percorsi di file, gli articoli insomma
    {
        bool selezionando = true;
        string message = "";
        while (selezionando)
        {
            selezionando = false;
            try
            {
                int look = Convert.ToInt32(Console.ReadLine()!);
                //0 equivale a non voler vedere niente in particolare
                if (look == 0)
                {
                    Console.WriteLine("Well, ya wanker, lascia che riprenda il menù");
                    Thread.Sleep(1500);
                }
                else
                if (look > 0 || look < max)
                {
                    Console.WriteLine("Lemme prendere tutte le sue info");
                    //si mette il path riferito all'articolo desiderato, per ora non stampa però delle cose extra
                    StampArtoCompl(pathArti[look]);
                    Console.WriteLine("\n\nPremi qualsiasi pulsante per tornare al menù");
                    Console.ReadKey();
                }
                //in realtà pensavo anche in caso fosse un opzione al di fuori degli articoli
                else
                {
                    message = "Opzione non presente... (premi un pulsante per riprovare)";
                    Console.Write(message + "\r");
                    selezionando = true;
                }
            }
            catch
            {
                message = "Necessito un numero (premi un pulsante per riprovare)";
                Console.Write(message + "\r");
                selezionando = true;
            }
            //volevo far presente all''operatore dell'errore, ma non perdere di vista la lista di articoli stampata
            if (message != "" && selezionando)
            {
                Console.ReadKey();
                for (int i = 0; i < message.Length; i++)
                {
                    Console.Write(" ");
                }
                Console.Write("\r");
            }
        }
    }




    //possibilità
    //funzione per la ricerca delle categorie
    //probabilmente verrà ignorato finchè la parte standard non è finita
    static void RicerCategoriaCustom(string direPath)
    //direPath=percorso della cartella dell'inventario
    {
        /*
        Trova un modo per far selezionare una categoria
        MA che il numero di categorie sia dinamico, magari da csv,
        in modo da poter prendere la quantità e i nomi di ogni categoria
        perchè prendere tramite i nomi json non conviene granché
        */
        //try catch per evitare problemi durante la ricerca del file
        try
        {
            string path = direPath + @"\Categorie.csv";
            //Richiesta all'operatore di scegliere tra x opzioni
            Console.WriteLine("Selezioni tra le seguenti categorie:\n");


            //copia del testo csv
            string[] lines = File.ReadAllLines(path);
            string[][] nomi = new string[lines.Length][];
            //dichiarazione variabile, servirà che sia rimodificabile anche al di fuori di un ciclo
            int i = 0;
            for (i = 0; i < lines.Length; i++)
            {
                nomi[i] = lines[i].Split(",");
            }
            i = 0;

            //Creazione dei file json e cartelle dedicate
            foreach (string[] nome in nomi)
            {
                //dato che il csv ha solo una linea, per ora ho fatto questo doppio ciclo
                foreach (string n in nome)
                {
                    //i è per poi utilizzarlo nella scelta delle opzioni
                    i++;
                    Console.WriteLine($"{i}. {n}");
                }
            }


        }
        //pensavo che se davvero non si trovava questo file, qualcuno avrà forzatamente manipolato i file
        //quindi magari dare l'opzione al gestore di resettare i file principali
        catch
        {
            //Console.WriteLine("Guess c'è qualche problema a livello di file, porei anche resettare le categorie, se lo ritiene necessario");
        }
    }
    
}
```
</pre>
</details>



### Main

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">


```c#
static void Main(string[] args)
    {
        //nome della cartella di default
        string pathDir = @"inventory";
        //messaggio iniziale, lo si può anche commentare
        Console.WriteLine("Salve, salve, stavo appena cercando il menù, mi dia un secondo");
        //try catch onde ad evitare che ci sia stato qualche errore nella ricerca della cartella
        try
        {
            //il csv delle categorie è fondamentale, se non esiste allora c'è un problema alla radice, meglio rinizializzare
            string[] files = Directory.GetFiles(pathDir, "Categorie.csv");
            //si controlla cosa contiene
            string[] lines = File.ReadAllLines(pathDir + @"\Categorie.csv");
            string[][] nomi = new string[lines.Length][];
            //serve per poter leggere i nomi completi, separati dalla virgola in questo caso
            for (int i = 0; i < lines.Length; i++)
            {
                nomi[i] = lines[i].Split(",");
            }
            //si raccolgono tutti i nomi dei file json esistenti in quella cartella
            files = Directory.GetFiles(pathDir, "*.json");
            //e si controlla che ci siano i file delle categorie, prese precedentemente dal file csv
            for (int i = 0; i < nomi[0].Length; i++)
            {
                //puramente per mostrare cosa conteneva la matrice nomi
                //Console.WriteLine(nomi[0][i]);

                //necessario per sapere se si trova il file ricercato
                bool esiste = false;
                //il path del file ricercato
                string filePath = pathDir + @"\" + nomi[0][i] + ".json";
                //si fa un controllo con tutti i file trovati nella cartella
                foreach (string file in files)
                {
                    //puramente per debug le seguenti due linee
                    //Console.Write(file);
                    //Console.WriteLine($" against {filePath}");
                    //se ha trovato, allora segna nel bool
                    if (file == filePath)
                    {
                        esiste = true;
                    }
                }
                //se non si fosse riuscito a trovare il file, lo si ricrea a parte
                if (!esiste)
                {
                    CreaCateMancante(filePath, nomi[0][i], i + 1);
                }
                //Console.WriteLine("£ To the next, To the best we're set £");
                //Thread.Sleep(1200);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"C'è stato qualche problema nella ricerca delle categorie, reinizializzazione in corso\n{e.Message}");
            Directory.CreateDirectory(pathDir);
            CreaFileCate(pathDir);
        }
        //Thread.Sleep(1200);

        //inizio vero e proprio del programma
        bool end = false;
        while (!end)
        {
            //per ordine visivo
            Console.Clear();
            //appare il menu, pensavo in futuro di renderlo largo 2 invece di 1 sola colonna
            Console.WriteLine("Selezioni un opzione da eseguire:\n\n1. Ricerca di un articolo\n2. Aggiunta di un articolo\n3. Uscire");
            //bool per uscire dal while, finchè è attivo, vuol dire che il gestore non ha scelto ancora l'opzione
            bool selezionando = true;
            while (selezionando)
            {
                //lo disattivo subito per evitare di dover attivarlo per tutti i casi aldifuori del Default case
                selezionando = false;
                ConsoleKeyInfo opzione = Console.ReadKey();
                switch (opzione.Key)
                {
                    //ho messo entrambi i modi per mettere uno in caso il gestore preferisse metterlo dal pad
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        //da mettere la funzione dedicata alla ricerca
                        Console.WriteLine("\nRicerco e chiudo");
                        RicercArto(pathDir);
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        //da mettere la funzione dedicata all'aggiunta
                        Console.WriteLine("\nAggiungo... niente, chiudo :D");
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        //messaggio di chiusura programma
                        Console.WriteLine("\nAddio");
                        //si attiva il token per avvisare al programma del termine
                        end = true;
                        break;
                    //in caso non si sia premuta un azione
                    default:
                        Console.Write("\r");
                        //si riattiva il token per forzare a mettere l'opzione giusta
                        selezionando = true;
                        break;
                }
            }
        }

    }
```
</pre>
</details>

### Funzioni

<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">


```c#
//Funzione per inizializzare una struttra personalizzata
    static void CreaFileCate(string direPath, bool custom)
    //direPath è la cartella dove creare l'inventario, invece custom è un bool per procedere con l'operazione
    {
        //infatti, prima si vede se effettivamente chi l'ha richiamato, vuole farlo customizzato
        if (custom)
        {
            //Creazione del csv contenente tutte le categorie di default
            string path = direPath + @"\Categorie.csv";
            File.Create(path).Close();

            bool finish = false;
            int i = 0;
            while (!finish)
            {
                Console.WriteLine("Inserisci la categoria:");
                string cate = Console.ReadLine()!;
                File.AppendAllText(path, cate);
                i++;
                string path2 = direPath + @"\" + cate + ".json";
                File.Create(path2).Close();
                //creazione json della categoria
                File.AppendAllText(path2, JsonConvert.SerializeObject(new { nome = cate, quantita = 0, numero = i, something = false }));
                //creazione della cartella dedicata
                //Directory.CreateDirectory(direPath+@"\"+cate);
                //questa parte è solo per vedere cosa ha fatto
                string json = File.ReadAllText(path2);
                dynamic obj = JsonConvert.DeserializeObject(json)!;
                Console.WriteLine($"Nome categoria: {obj.nome}, con {obj.quantita} articoli, numero di serie {obj.numero}, and its fullnes...{obj.something}");
                Console.WriteLine("vuoi aggiungere un altra categoria?");
                if (RispoInvioSiNoBreve("s", "n"))
                {
                    File.AppendAllText(path, ",");
                }
                else
                {
                    finish = true;
                }
            }
        }
        //altrimenti... si richiama la versione standard della funzione
        else
        {
            CreaFileCate(direPath);
        }
    }
```
</pre>
</details>
<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">


```c#
 //Funzione per inizializzare la struttura
    static void CreaFileCate(string direPath)   //direPath contiene il luogo in cui la cartella contenente l'inventario sarà situato
    {
        //Creazione del csv contenente tutte le categorie di default
        string path = direPath + @"\Categorie.csv";
        File.Create(path).Close();
        //probailmente vedrò di creare una versione in cui puoi dinamicamente scegliere te quante farne e nominarli da te
        File.WriteAllText(path, "Aerofoni,Cordofoni,Membranofoni,Idiofoni,Misc");

        //copia del testo csv
        string[] lines = File.ReadAllLines(path);
        string[][] nomi = new string[lines.Length][];
        //dichiarazione variabile, servirà che sia rimodificabile anche al di fuori di un ciclo
        int i = 0;
        for (i = 0; i < lines.Length; i++)
        {
            nomi[i] = lines[i].Split(",");
        }
        i = 0;

        //Creazione dei file json e cartelle dedicate
        foreach (string[] nome in nomi)
        {
            //dato che il csv ha solo una linea, per ora ho fatto questo doppio ciclo
            foreach (string n in nome)
            {
                //i è per mettere una variabile
                i++;
                string path2 = direPath + @"\" + n + ".json";
                File.Create(path2).Close();
                //creazione json della categoria
                File.AppendAllText(path2, JsonConvert.SerializeObject(new { nome = n, quantita = 0, numero = i, something = false }));
                //creazione della cartella dedicata
                //Directory.CreateDirectory(direPath+@"\"+n);
                //questa parte è solo per vedere cosa ha fatto
                string json = File.ReadAllText(path2);
                dynamic obj = JsonConvert.DeserializeObject(json)!;
                Console.WriteLine($"Nome categoria: {obj.nome}, con {obj.quantita} articoli, numero di serie {obj.numero}, and its fullnes...{obj.something}");
            }
        }
    }
```
</pre>
</details>
<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">


```c#
 ///Funzione per inizializzare un file json specifico
    static void CreaCateMancante(string filePath, string name, int num)
    //filePath contiene l'indirizzo del file mancante, name invece il nome della categoria e num l'id della categoria
    {
        //vien creato un nuovo file, tramite il path ricevuto come parametro
        File.Create(filePath).Close();
        File.WriteAllText(filePath, JsonConvert.SerializeObject(new { nome = name, quantita = 0, numero = num, something = false }));
        //puramente per sapere cosa contiene, lo si può anche commentare/cancellare
        string json = File.ReadAllText(filePath);
        dynamic obj = JsonConvert.DeserializeObject(json)!;
        Console.WriteLine($"Nome categoria: {obj.nome}, con {obj.quantita} articoli, numero di serie {obj.numero}, and its fullnes...{obj.something}");
    }
```
</pre>
</details>
<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">


```c#
 //funzione per scegliere tra due opzioni, risposta messa con invio
    static bool RispoInvioSiNoBreve(string conf, string nega) //le due stringhe son le opzioni che l'utente dovrà digitare
    {
        //bool per terminare un ciclo non forzatamente
        bool end = false;
        //la risposta che verrà usata per il return
        bool rispo = false;
        //iniziando con falso, end diviene vero solamente quando l'utente digita una delle risposte
        while (!end)
        {
            //risposta da tastiera
            string reply = Console.ReadLine()!;
            //i tolower è per non essere pignoli anche con il case, non dovrebbe esserci il bisogno
            if (reply.ToLower() == conf.ToLower())
            {
                //unico momento in cui rispo cambia di valore, essendo dichiarato come falso all'inizio
                rispo = true;
                end = true;
            }
            else
            if (reply.ToLower() == nega.ToLower())
            {
                end = true;
            }
            //il ciclo non termina finchè l'utente non scrive una delle alternative
            else
            {
                Console.WriteLine($"Per favore, le chiedo di digitare tra {conf} o {nega}");
            }
        }
        return rispo;
    }
```
</pre>
</details>
<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">


```c#
 //funzione che si occupa della ricerca dell'articolo
    static void RicercArto(string direPath)
    //percorso dellla cartella dell'inventario, sarà necessario averla per altre funzioni
    {
        //per ordine visivo
        Console.Clear();
        Console.WriteLine("Come vuoi ricercare l'articolo:\n\n1. Ricerca diretta\n2. Ricerca da tag\n3. Mostra una categoria\n4. Torna indietro");
        //bool per uscire dal while, finchè è attivo, vuol dire che il gestore non ha scelto ancora l'opzione
        bool selezionando = true;
        while (selezionando)
        {
            //lo disattivo subito per evitare di dover attivarlo per tutti i casi aldifuori del Default case
            selezionando = false;
            ConsoleKeyInfo opzione = Console.ReadKey();
            switch (opzione.Key)
            {
                //ho messo entrambi i modi per mettere uno in caso il gestore preferisse metterlo dal pad
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    //si richiama la funzione dedicata alla ricerca diretta
                    RicercaDirettArto(direPath);
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    //si richiama la funzione per cercare tramite tag
                    RicercaArTag(direPath);
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    //si richiama la funzione per cercare tramite categoria
                    RicerCategoria(direPath);
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    //non si fa niente, il ciclo che l'ha richiamato farà il resto
                    Console.WriteLine("\nEcche");
                    break;
                //in caso non si sia premuta un azione
                default:
                    Console.Write("\r");
                    //si riattiva il token per forzare a mettere l'opzione giusta
                    selezionando = true;
                    break;
            }
        }
    }
```
</pre>
</details>
<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">


```c#
 //funzione per la ricerca diretta
    static void RicercaDirettArto(string direPath)
    //direPath= percorso della cartella dell'inventario
    {
        //end è per finire il ciclo
        bool end = false;
        Console.WriteLine("Dimmi il nome specifico dello strumento che cerchi");
        while (!end)
        {
            end=true;
            //si inserirà un nome
            string look = Console.ReadLine()!;
            //bool per avvisare che non si ha trovato il nome
            bool miss=false;
            //array che dovrebbe avere solo un percorso, dato che il nome del file è un nome specifico
            string [] temp=Directory.GetFiles(direPath,look+"_*.json");
            string filePath="";
            //per evitare che alla fine ci sia stato qualche problema nel trovare il file
            if(temp==null)
                miss=true;
            else
            {
                filePath=temp[0];
                Console.WriteLine(filePath);
                Console.ReadKey();
            }

            //se non esiste (o semplicemente non si ha messo niente)
            if (look == ""||miss)
            {
                end=false;
                //si darà l'opzione di riprovare, ma stavolta tramite invio, vediamo di evitare di rifare l'operazione non voluta stavolta
                Console.WriteLine("Well... that was awkward\nVuoi riscrivere o tornare indietro?\n(1 per riscrivere/2 per tornare al menù)");
                //in caso si decidesse di no
                if (!RispoInvioSiNoBreve("1", "2"))
                {
                    //si avvisa al ciclo che si è finito con l'operazione di ricerca
                    Console.WriteLine("Allora mi faccia riprendere il menù...");
                    Thread.Sleep(1200);
                    end=true;
                }
            }
            //se si trova invece, si mostreranno tutte le informazioni dell'articolo trovato
            else
            {

                //da aggiungere un modo per estrapolare TUTTE le informazioni dell'articolo
                Console.WriteLine("Trovato:\n");
                StampArtoCompl(filePath!);
                //si lascerà al gestore vedere per quanto tempo vuole, basta toccare qualcosa per tornare al menù... magari è meglio dopo aver premuto invio
                Console.WriteLine("Tocchi un pulsante quando vuole ritornare al menù");
                Console.ReadKey();
            }
        }
    }
```
</pre>
</details>
<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">


```c#
static void RicercaArTag(string direPath)
    //direPath= percorso della cartella dell'inventario
    {
        bool end = false;
        Console.WriteLine("Dimmi che caratteristica stai cercando");
        while (!end)
        {
            string look = Console.ReadLine()!;
            //onde ad evitare che prenda anche i file json dedicate alle categorie, aggiungo *_ per prendere solo gli articoli
            string[] arti= Directory.GetFiles(direPath, "*_"+"*.json");
            //bool per avvisare se non si ha trovato l'articolo col tag
            bool miss=false;
            if(arti==null)
            {
                miss=true;
                Console.WriteLine("Sfortunatamente, non ho trovato nemmeno un articolo, ti toccherà aggiungere qualcosa");
                //attivo già end per terminare questa parte di codice, è alquanto inutile cercare un articolo quando non ce nè nessuno
                end=true;
            }
            //trova un modo per controllare tutti i parametri di un file
            string[] specificArti=new string [arti!.Length];
            //da qui, o faccio una funzione che me lo faccia in automatico, o lo faccio qui un ciclo
            //scelto di farlo in un ciclo

            //counter per tener conto di quanti file hai trovato il tag
            int count=0;
            //si controlla se almeno si è trovato un file articolo
            if(!miss)
            {
                //bool solo per evitare di ristampare una cosa più volte
                bool wrote=false;
                //si controlla ogni file json
                foreach (string arto in arti!)
                {
                    //si deserializza il file json per poter controllare tutte le sue chiavi
                    string json=File.ReadAllText(arto);
                    dynamic obj=JsonConvert.DeserializeObject(json)!;
                    //si controlla tramite foreach le chiavi del file json
                    foreach(KeyValuePair<string, JsonNode?>subObj in obj)
                    {
                        //se la chiave ha un valore uguale a quello che l'operatore cerca
                        if(obj.subObj.key==look)
                        {
                            if(!wrote)
                            {
                                Console.WriteLine("Ecco a te l'elenco che ho trovato:\n");
                                wrote=true;
                            }
                            //lo aggiunge alla lista di file da poi mostrare
                            specificArti[count]=arto;
                            count++;
                            //e si fa una stampa in modo che l'operatore sappia cosa ha trovato
                            Console.Write($"{count}. ");
                            StampArtoSimple(arto);
                        }
                    }
                }
            }
            //il resize è per questione di memoria... per ora
            Array.Resize(ref specificArti, count);
            if(count<=0)
            {
                miss=true;
            }
            //se non si trova una caratteristica dell'articolo
            if ((look == ""||miss)&&!end)
            {
                //si lascerà l'opzione di andarsene invece di riprovare
                Console.WriteLine("Well... that was awkward\nVuoi riscrivere o tornare indietro?\n(1 per riscrivere/2 per tornare al menù)");
                if (!RispoInvioSiNoBreve("1", "2"))
                {
                    Console.WriteLine("Allora mi faccia riprendere il menù...");
                    end = true;
                    Thread.Sleep(1200);
                }
            }/*
            //altrimenti, si mostra in breve una lista di tutti gli articoli
            else
            {
                //da lì dare il numero di path, passare l'array da parametro con il massim in una funzione a parte
                Console.WriteLine("Ecco a te l'elenco che ho trovato:\n");
                //i serve per sapere quanti ne ha trovati, servirà per la selezione
                int i = 0;
                foreach (string arto in arti!)
                {
                    //i aumenta per ogni articolo
                    i++;
                    Console.Write(i+". ");
                    StampArtoSimple(arto);
                }
                Console.WriteLine("\nQuale vuole vedere in particolare?\n(se non si vuole vedere, basta inviare 0)");
                ScegliXOpzioni(i, arti);
            }*/
        }
        Console.WriteLine("Tocchi un pulsante quando vuole ritornare al menù");
        Console.ReadKey();
    }
```
</pre>
</details>
<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">


```c#
   //funzione per la ricerca delle categorie
    static void RicerCategoria(string direPath)
    //questa è la versione di default, richiamalo solamente se non hai voluto personalizzare/modificare le categorie
    {
        //try catch per evitare problemi durante la ricerca del file
        try
        {
            string[] paths = Directory.GetFiles(direPath, @"*.json");
            //while per tornare in caso una catogoria non avesse niente (il menù è stato designato per ripulire tutto)
            bool end = false;
            while (!end)
            {
                //pulizia visiva
                Console.Clear();
                //Richiesta all'operatore di scegliere tra 5 opzioni
                Console.WriteLine("Selezioni tra le seguenti categorie:\n");
                //un ulteriore try-catch in caso ci fosse un errore nel ritrovare i file json di default
                //quindi un modo per capire di preciso cosa è andato storto
                try
                {
                    //i è unicamente per grafica in questo caso
                    int i = 0;
                    foreach (string cate in paths)
                    {
                        //do per scontato che non ci sia nessun underscore nemmeno nella cartella contenente tutti i file
                        if (!cate.Contains("_"))
                        {
                            string json=File.ReadAllText(cate);
                            dynamic obj = JsonConvert.DeserializeObject(json)!;
                            Console.WriteLine($"{i + 1}. {obj.nome}");
                            i++;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Welp, probabilmente non ho manco trovato la struttura originare, ti mostro che mi dice il mio compare\n{e.Message}\nIo terminerei qui il programma");
                }
                //volevo evitare qualsiasi azione successiva se ci fosse stato qualche problema
                finally
                {
                    //lo si mette già a true, dato che molte azioni non son designate per rifare questa parte di codice
                    end = true;
                    //bool per uscire dal while, finchè è attivo, vuol dire che il gestore non ha scelto ancora l'opzione
                    bool selezionando = true;
                    //servirà per la ricerca di diversi file
                    string scelta = "";
                    while (selezionando)
                    {
                        //lo disattivo subito per evitare di dover attivarlo per tutti i casi aldifuori del Default case
                        selezionando = false;
                        ConsoleKeyInfo opzione = Console.ReadKey();
                        switch (opzione.Key)
                        {
                            //ho messo entrambi i modi per mettere uno in caso il gestore preferisse metterlo dal pad
                            case ConsoleKey.D1:
                            case ConsoleKey.NumPad1:
                                //la prima categoria erano gli aerofoni
                                Console.WriteLine("\nAerofoni");
                                scelta = "Aerofoni";
                                //ricorda, la ricerca dovrebbe rilevare l'occorrenza nel nome dei file json, divisi da _
                                break;
                            case ConsoleKey.D2:
                            case ConsoleKey.NumPad2:
                                //la seconda categoria erano i cordofoni
                                Console.WriteLine("\nCordofoni");
                                scelta = "Cordofoni";
                                //ricorda, la ricerca dovrebbe rilevare l'occorrenza nel nome dei file json, divisi da _
                                break;
                            case ConsoleKey.D3:
                            case ConsoleKey.NumPad3:
                                //la terza categoria erano i membranofoni
                                Console.WriteLine("\nMembranofoni");
                                scelta = "Membranofoni";
                                //ricorda, la ricerca dovrebbe rilevare l'occorrenza nel nome dei file json, divisi da _
                                break;
                            case ConsoleKey.D4:
                            case ConsoleKey.NumPad4:
                                //la quarta categoria erano gli idiofoni
                                Console.WriteLine("\nIdiofoni");
                                scelta = "Idiofoni";
                                //ricorda, la ricerca dovrebbe rilevare l'occorrenza nel nome dei file json, divisi da _
                                break;
                            case ConsoleKey.D5:
                            case ConsoleKey.NumPad5:
                                //la quinta categoria erano cose extra, abbreviato con Misc
                                Console.WriteLine("\nMisc");
                                scelta = "Misc";
                                //ricorda, la ricerca dovrebbe rilevare l'occorrenza nel nome dei file json, divisi da _
                                break;
                            //in caso non si sia premuta un azione
                            default:
                                Console.Write("\r");
                                //si riattiva il token per forzare a mettere l'opzione giusta
                                selezionando = true;
                                break;
                        }
                    }
                    //ora di mostrare tutti i file appartenenti alla categoria

                    string json=File.ReadAllText(direPath + @"\" + scelta + ".json");
                    //ma prima farei un controllo se la categoria ha effettivamente qualcosa
                    dynamic obj = JsonConvert.DeserializeObject(json)!;
                    if ((bool)obj.something)
                    {
                        //ho specificato l'underscore in modo da evitare di includere la categoria in sè
                        string[] arti = Directory.GetFiles(direPath, "*_" + scelta + "_*.json");
                        //i serve per sapere quanti ne ha trovati, servirà per la selezione
                        int i = 0;
                        foreach (string arto in arti)
                        {
                            //i aumenta per ogni articolo
                            i++;
                            StampArtoSimple(arto);
                            Console.WriteLine();
                        }
                        Console.WriteLine("\nQuale vuole vedere in particolare?\n(se non si vuole vedere, basta inviare 0)");
                        ScegliXOpzioni(i, arti);
                    }
                    //se non c'è nessun articolo, non si ci può fare niente
                    else
                    {
                        Console.WriteLine($"Sfortunatamente, {scelta} non ha nessun articolo associato, vuole controllare un altra categoria?\n(s per si, n per no)");
                        if (RispoInvioSiNoBreve("s", "n"))
                        {
                            end = false;
                        }
                    }
                }
            }
        }
        //pensavo che se davvero non si trovava questo file, qualcuno avrà forzatamente manipolato i file
        //quindi magari dare l'opzione al gestore di resettare i file principali
        catch
        {
            Console.WriteLine("Guess c'è qualche problema a livello di file, potrei anche resettare le categorie, se lo ritiene necessario\n(s per resettare le categorie/n per lasciare perdere)");
            if (RispoInvioSiNoBreve("s", "n"))
            {
                CreaFileCate(direPath);
            }
        }
    }

```
</pre>
</details>
<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">


```c#
//funzione per stampare le informazioni minime di un articolo
    static void StampArtoSimple(string nomePath)    //il nomePath è il percorso del file
    //pensavo, magari fare un return del mero nome, ma lo tengo come una possibile idea
    {
        /*
        struttura di un articolo:
        nome specifico
        Nome familia
        Categoria
        Prezzo
        <not important anymore>
        descrizione
        categorie e sottocategoria
        */
        string json=File.ReadAllText(nomePath);
        dynamic obj = JsonConvert.DeserializeObject(json)!;
        //stampa dell'informazione
        Console.WriteLine($"{obj.nomeProprio}, {obj.nomeGen}, {obj.categoria}, {obj.prezzo}");
    }
    //funzione per stampare le informazioni minime di un articolo
    static void StampArtoCompl(string nomePath)    //il nomePath è il percorso del file
    //pensavo, magari fare un return del mero nome, ma lo tengo come una possibile idea
    {
        /*
        struttura di un articolo:
        nome specifico
        Nome familia
        Categoria
        Prezzo
        <not important anymore>
        descrizione
        tag e subtag (what the hell are ya talking about, developer?)
        */
        //ricorda che bisogna prima LEGGERE IL TESTO DEL FILE
        string json=File.ReadAllText(nomePath);
        dynamic obj = JsonConvert.DeserializeObject(json)!;
        //stampa dell'informazione
        Console.WriteLine($"Nome completo: {obj.nomeProprio}\nOggetto: {obj.nomeGen}\nCategoria: {obj.categoria}\nPrezzo: {obj.prezzo}\n\nDescrizione:\n{obj.descrizione}");
    }
```
</pre>
</details>
<details>
    <summary></summary>
    <pre style="height: 500px; overflow: scroll;">


```c#
//funzione per scegliere tra x opzioni da stampare in completo, usato mainly per le ricerche tag e categoria
    static void ScegliXOpzioni(int max, string[] pathArti)
    //int max serve per avere un massimo in cui l'operatore può scegliere, l'array paths contiene diversi percorsi di file, gli articoli insomma
    {
        bool selezionando = true;
        string message = "";
        while (selezionando)
        {
            selezionando = false;
            try
            {
                int look = Convert.ToInt32(Console.ReadLine()!);
                //0 equivale a non voler vedere niente in particolare
                if (look == 0)
                {
                    Console.WriteLine("Well, ya wanker, lascia che riprenda il menù");
                    Thread.Sleep(1500);
                }
                else
                if (look > 0 || look < max)
                {
                    Console.WriteLine("Lemme prendere tutte le sue info");
                    //si mette il path riferito all'articolo desiderato, per ora non stampa però delle cose extra
                    StampArtoCompl(pathArti[look]);
                    Console.WriteLine("\n\nPremi qualsiasi pulsante per tornare al menù");
                    Console.ReadKey();
                }
                //in realtà pensavo anche in caso fosse un opzione al di fuori degli articoli
                else
                {
                    message = "Opzione non presente... (premi un pulsante per riprovare)";
                    Console.Write(message + "\r");
                    selezionando = true;
                }
            }
            catch
            {
                message = "Necessito un numero (premi un pulsante per riprovare)";
                Console.Write(message + "\r");
                selezionando = true;
            }
            //volevo far presente all''operatore dell'errore, ma non perdere di vista la lista di articoli stampata
            if (message != "" && selezionando)
            {
                Console.ReadKey();
                for (int i = 0; i < message.Length; i++)
                {
                    Console.Write(" ");
                }
                Console.Write("\r");
            }
        }
    }
```
</pre>
</details>
