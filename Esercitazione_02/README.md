# ESERCITAZIONE BASE SU C# .NET CORE

Ecco alcune esercitazioni base su C# .NET Core senza l'utilizzo di namespaces.

**dotnet new console >> creare un nuovo progetto console.**

**dotnet run >> eseguire il progetto console.**

- 01 - Tipi di dato e variabili
- 02 - Operatori
- 03 - Strutture di dati
- 04 - Condizioni
- 05 - Cicli

## 01 - Esercitazioni su tipi di dato e variabili:

### 01 - Dichiarare una variabile di tipo stringa:

```c#
class Program
{
    static void Main(string[] args)
    {
        string nome = "Simone";
        Console.WriteLine($"Ciao {nome}");
    }
}

// oppure

class Program
{
    static void Main(string[] args)
    {
        string nome = "Simone";
        Console.WriteLine($"Ciao {nome}");
        Console.WriteLine("Ciao " + nome);
        Console.WriteLine($"Ciao {nome} Ussi");
    } 
}

```

### 02 - Dichiarare una variabile di tipo intero:

```c#
class Program
{
    static void Main(string[] args)
    {
        int eta = 20;
        Console.WriteLine($"Hai {eta} anni");
    }
}

```

### 03 - Dichiarare variabili di tipo booleano:

```c#
class Program
{
    static void Main(string[] args)
    {
        bool maggiorenne = true;
        Console.WriteLine($"Sei maggiorenne? {maggiorenne}");
    }
}
```

### 04 - Dichiarare una variabile di tipo decimale:

```c#
class Program
{
    static void Main(string[] args)
    {
        decimal altezza = 1.80M;
        Console.WriteLine($"Sei alto {altezza} metri");
    } 
}
```

### 05 - Dichiarare una variabile di tipo data:

```c#
class Program
{
    static void Main(string[] args)
    {
        DateTime dataDiNascita = new DateTime(1985, 7, 30);
        Console.WriteLine($"Sei nato il {dataDiNascita}");
    } 
}
```

### 06 - Dichiarare una variabile di tipo data utilizzando il metodo ToShortDateString():

```c#
class Program
{
    static void Main(string[] args)
    {
        DateTime dataDiNascita = new DateTime(1985, 7, 30);
        Console.WriteLine($"Sei nato il {dataDiNascita.ToShortDateString()}");
    } 
}

```

### 07 - Dichiarare una variabile di tipo data e utilizzare il metodo ToLongDateString():

```c#
class Program
{
    static void Main(string[] args)
    {
        DateTime dataDiNascita = new DateTime(1985, 7, 30);
        Console.WriteLine($"Sei nato il {dataDiNascita.ToLongDateString()}");
    } 
}
```

### 08 - Utilizzare l'operatore + per sommare due interi:

```c#
class Program
{
    static void Main(string[] args)
    {
        int a = 10;
        int b = 20;
        int c = a + b;
        System.Console.WriteLine($"La somma di {a} e {b} è {c}");
    } 
}
```

### 09 - Utilizzare l'operatore + per sommare due interi e un decimale:

```c#
class Program
{
    static void Main(string[] args)
    {
        int a = 10;
        int b = 20;
        decimal c = 1.5m;
        decimal d = a + b + c;
        System.Console.WriteLine($"La somma di {a}, {b}, {c} è {d}");
    } 
}
```

### 10 - Utilizzare l'operatore == per confrontare due stringhe:

```c#
class Program
{
    static void Main(string[] args)
    {
        string nome = "Mario";
        string cognome = "Mario";
        bool uguali = (nome == cognome);
        System.Console.WriteLine($"I due nomi sono uguali? {uguali}");

    } 
}
```

### 11 - Utilizzare l'operatore != per confrontare due stringhe:

```c#
class Program
{
    static void Main(string[] args)
    {
        string nome = "Mario";
        string cognome = "Mario";
        bool diversi = (nome != cognome);
        System.Console.WriteLine($"I due nomi sono uguali? {diversi}");

    } 
}
```

### 12 - Utilizzare l'operatore > per confrontare due interi:

```c#
class Program
{
    static void Main(string[] args)
    {
        int a = 10;
        int b = 20;
        bool maggiore = (a > b);
        System.Console.WriteLine($"Il primo numero è maggiore del secondo? {maggiore}");
    }
}
```

### 13 - Dichiarare un array di stringhe: 

```c#
class Program
{
    static void Main(string[] args)
    {
        string[] nomi = new string[3]; // array con numero predeterminato elementi
        nomi[0] = "Mario";             // si puo' inserire un elemento in una posizione specifica
        nomi[1] = "Luigi";             // deve contenere dati dello stesso tipo
        nomi[2] = "Giovanni";
        System.Console.WriteLine($"Ciao {nomi[0]}, {nomi[1]} e {nomi[2]}");
    }
}
```

### 14 - Dichiarare un array di interi:

```c#
class Program
{
    static void Main(string[] args)
    {
        int[] numeri = new int[3];
        numeri[0] = 10;
        numeri[1] = 20;
        numeri[2] = 20;
        // numeri[3] = "30"; // elemento non di tipo numerico
        // array che non c'e'
        // System.Console.WriteLine($"I numeri sono {numeri[0]}, {numeri[1]}, {numeri[2]} e {numeri[3]}");
        System.Console.WriteLine($"I numeri sono {numeri[0]}, {numeri[1]} e {numeri[2]}");
    }
}
```

### 15 - Dichiarare un array di stringhe e utilizzare il metodo Length:

```c#
class Program
{
    static void Main(string[] args)
    {
        string[] nomi = new string[3];
        nomi[0] = "Mario";
        nomi[1] = "Luigi";
        nomi[2] = "Giovanni"; 
        System.Console.WriteLine($"Ciao {nomi[0]}, {nomi[1]} e {nomi[2]}");
        System.Console.WriteLine($"Il numero di elementi e' {nomi.Length}");
        
    }
}
```

### 16 - Dichiarare una lista di stringhe:

```c#
class Program
{
    static void Main(string[] args)
    {   
        // utilizziamo il diamond invece di parentesi quadre
        List<string> nomi = new List<string>();
        nomi.Add("Mario"); // aggiungo elemento con metodo add
        nomi.Add("Luigi");
        nomi.Add("Giovanni");

        System.Console.WriteLine($"Ciao {nomi[0]}, {nomi[1]} e {nomi[2]}");
    }
}
```

### 17 - Dichiarare una lista di interi:

```c#
class Program
{
    static void Main(string[] args)
    {   
        // utilizziamo il diamond invece di parentesi quadre
        List<int> numeri = new List<int>();
        numeri.Add(10); // aggiungo elemento con metodo add
        numeri.Add(20);
        numeri.Add(30);

        System.Console.WriteLine($"Ciao {numeri[0]}, {numeri[1]} e {numeri[2]}");
    }
}
```

### 18 - Dichiarare una lista di stringhe e utilizzare il metodo Count:

```c#
class Program
{
    static void Main(string[] args)
    {   
        // utilizziamo il diamond invece di parentesi quadre
        List<string> nomi = new List<string>();
        nomi.Add("Mario"); // aggiungo elemento con metodo add
        nomi.Add("Luigi");
        nomi.Add("Giovanni");

        System.Console.WriteLine($"Ciao {nomi[0]}, {nomi[1]} e {nomi[2]}");
        System.Console.WriteLine($"Il numero di elementi e' {nomi.Count}");
    }
}
```

### 19 - Dichiarare una pila di stringhe:

```c#
class Program
{
    static void Main(string[] args)
    {   
        // utilizziamo il diamond invece di parentesi quadre
        Stack<string> nomi = new Stack<string>();
        nomi.Push("Mario"); // aggiungo elemento con metodo Push
        nomi.Push("Luigi");
        nomi.Push("Giovanni");

        System.Console.WriteLine($"Ciao {nomi.Pop()}, {nomi.Pop()} e {nomi.Pop()}");
        
    }
}
```

### 20 - Dichiarare una coda di stringhe:

```c#
class Program
{
    static void Main(string[] args)
    {   
        // utilizziamo il diamond invece di parentesi quadre
        Queue<string> nomi = new Queue<string>();
        nomi.Enqueue("Mario"); // aggiungo elemento con metodo Enqueue
        nomi.Enqueue("Luigi");
        nomi.Enqueue("Giovanni");

        System.Console.WriteLine($"Ciao {nomi.Dequeue()}, {nomi.Dequeue()} e {nomi.Dequeue()}");
        
    }
}
```

### 21 - Esempio di array Join:

```c#
class Program
{

    static void Main(string[] args)
    {
        // riordino lista numerica
        
        System.Console.WriteLine($"Ciao {nomiConcatenati}");   
        
    }

}
```

### 22 - Riordino di una lista con metodo Sort e funzione di stampa:

```c#
class Program
{

    static void Main(string[] args)
    {
        // riordino lista numerica
        List<int> numeri = new List<int> {2,1,5,25,9,10,15};
        numeri.Sort();

        stampa(numeri);   
        
    }

    static void stampa(List<int> listString)
    {   
        System.Console.WriteLine("Funzione stampa lista di stringhe:");

        for(int i = 0; i < listString.Count; i++)
        {
            System.Console.Write(listString[i] + ", ");
        }

        System.Console.WriteLine("\n"); //  ritorno a capo


    }
}
```

### 23 - Utilizzare l'istruzione if:

```c#
class Program
{
    static void Main(string[] args)
    {
        int a = 10;
        int b = 20;
        if (a > b) // la condizione da verificare si scrive tra parentesi
        {
            System.Console.WriteLine($"{a} e' maggiore di {b}");
        }
        System.Console.WriteLine("Fine!");
    }
}

```

### 24 - Utilizzare istruzione if con else:

```c#
class Program
{
    static void Main(string[] args)
    {
        int a = 10;
        int b = 20;
        if (a > b) // la condizione da verificare si scrive tra parentesi
        {
            System.Console.WriteLine($"{a} e' maggiore di {b}");
        }
        else
        {
            System.Console.WriteLine($"{a} e' minore di {b}");
        }
        
    }
}
```

### 25 - Utilizzare istruzione if con else-if else:

```c#
class Program
{
    static void Main(string[] args)
    {
        int a = 10;
        int b = 20;
        if (a > b) // la condizione da verificare si scrive tra parentesi
        {
            System.Console.WriteLine("{a} e' maggiore di {b}");
        }
        if (a < b)
        {
            System.Console.WriteLine("{a} e' minore di {b}");
        }
        else
        {
            System.Console.WriteLine($"{a} e' uguale a {b}");
        }

    }
}
```

### 26 - Utilizzare l'istruzione switch:

```c#
class Program
{
    static void Main(string[] args)
    {
        int a = 10;
        // int b = 20;
        switch (a)
        {
            case 10:
                System.Console.WriteLine($"{a} e' uguale a 10");
                break;
            case 20:
                System.Console.WriteLine($"{a} e' uguale a 20");
                break;
            default:
                System.Console.WriteLine($"{a} non e' uguale a 10 o 20");
                break;
        }

    }
}
```

### 27 - Dichiarare un dizionario di stringhe:

```c#
class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, string> nomi = new Dictionary<string, string>();
        nomi.Add("Mario", "Rossi");
        nomi.Add("Luigi", "Verdi");
        nomi.Add("Giovanni", "Bianchi");
        System.Console.WriteLine($"Ciao {nomi["Mario"]} {nomi["Luigi"]} e {nomi["Giovanni"]}");

    }
}
```

### 28 - Inizializzare dizionario senza metodo Add:

```c#
class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, int> nomi = new Dictionary<string, int>()
        {
            {"Mario", 25},
            {"Luigi", 30},
            {"Giovanni", 35}
        };

        System.Console.WriteLine($"Le vostre età sono {nomi["Mario"]} {nomi["Luigi"]} e {nomi["Giovanni"]}");

    }
}
```

### 29 - Utilizzare il ciclo for:

```c#
class Program
{
    static void Main(string[] args)
    {
        for (int i = 0; i < 10; i++)
        {
            System.Console.WriteLine($"Il valore di i è {i}");
        }

    }
}
```

### 30 - Utilizzare il ciclo foreach con un array di stringhe:

```c#
class Program
{
    static void Main(string[] args)
    {
        string[] nomi = new string[3];
        nomi[0] = "Mario";
        nomi[1] = "Luigi";
        nomi[2] = "Giovanni";

        foreach (string nome in nomi)
        {
            System.Console.WriteLine($"Ciao {nome}");
        }
        
    }
}
```

### 31 - Utilizzare il ciclo foreach con una lista:

```c# 
class Program
{
    static void Main(string[] args)
    {
        List<string> nomi = new List<string>();
        nomi.Add("Mario");
        nomi.Add("Luigi");
        nomi.Add("Giovanni");

        foreach (string nome in nomi)
        {
            System.Console.WriteLine($"Ciao {nome}");
        }
     
    }
}
```

### 32 - Utilizzare foreach per scoprire quali key contiene un dictionary:

```c#
class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, int> eta = new ()
        {
            {"Mario", 25},
            {"Luigi", 30},
            {"Giovanni", 35}
        };

        foreach (string nome in eta.Keys)
        {
            System.Console.WriteLine($"Ciao {nome} hai {eta[$"{nome}"]} anni");
        }

    }
}
```

### 33 - Cerca un valore string in un array e lo copia in una lista:

```c#
class Program
{
    static void Main(string[] args)
    {
        string[] nomi = new string[5];
        nomi[0] = "Luigi";
        nomi[1] = "Mario";
        nomi[2] = "Luca";
        nomi[3] = "Mario";
        nomi[4] = "Mario";

        List<string> lista = new List<string>();

        foreach (string nome in nomi)
        {
            if (nome == "Mario")
            {
                System.Console.WriteLine("Trovato!");
                lista.Add(nome);
            }
        }

        System.Console.WriteLine($"La lista contiene {lista.Count} elementi");

    }
}
```

### 34 - Utilizzare ciclo while con array di stringhe:

```c#
class Program
{
    static void Main(string[] args)
    {
        string[] nomi = ["Luigi", "Mario", "Luca"];

        int i = 0; // creo contatore

        while (i < nomi.Length)
        {
            Console.WriteLine($"Ciao {nomi[i]}");
            i++; // incremento contatore
        }

        System.Console.WriteLine($"Fine");
    }
}
```

### 35 - Utilizzare ciclo while con List:

```c#
class Program
{
    static void Main(string[] args)
    {
        List<string> nomi = ["Mario", "Luca", "Paolo"];
        int i = 0; // creo contatore

        while (i < nomi.Count)
        {
            Console.WriteLine($"Ciao {nomi[i]}");
            i++; // incremento contatore
        }

        System.Console.WriteLine($"Fine");
    }
}
```

### 36 - Utilizzare la classe ConsoleKeyInfo e il ciclo while. Premi N per uscire:

```c#
class Program
{
    static void Main(string[] args)
    {
       System.Console.WriteLine("Premi 'N' per temrinare...");

       // ciclo loop
       while (true)
       {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.N)
            {
                break; // esce dal ciclo se viene premuto N
            }  
       }
    }
}
```

### 37 - Utilizzare ConsoleKeyInfo e ciclo while. Premi 'Ctrl'+'Q':

```c#
class Program
{
    static void Main(string[] args)
    {
       Console.WriteLine("Premi 'Ctrl' + 'N' per terminare...");

       // ciclo loop
       while (true)
       {
            // aspetta finche non viene premuto un tasto
            ConsoleKeyInfo keyInfo = Console.ReadKey(true); // ???

            // verifica se il tasto 'Ctrl' è tenuto premuto
            if ((keyInfo.Modifiers & ConsoleModifiers.Control) != 0)
            {
                // controlla se il tasto premuto è N
                if (keyInfo.Key == ConsoleKey.N)
                {
                    Console.WriteLine("Combinazione 'Ctrl' + 'N' rilevata...");
                    break; ///
                }
            }  
       }
    }
}
```

### 38 - Menu di selezione semplice:

```c#
class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            System.Console.WriteLine("Menu di selezione");
            System.Console.WriteLine("1. Opzione Uno");
            System.Console.WriteLine("2. Opzione Due");
            System.Console.WriteLine("3. Opzione Tre");
            System.Console.WriteLine("4. Esci");

            System.Console.WriteLine("\nInserisci il numero dell'opzione desiderata: ");
            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    System.Console.WriteLine("Hai selezionato l'opzione 1");
                    break;

                case "2":
                    System.Console.WriteLine("Hai selezionato l'opzione 2");
                    break;

                case "3":
                    System.Console.WriteLine("Hai selezionato l'opzione 3");
                    break;

                case "4":
                    System.Console.WriteLine("Uscita in corso..");
                    return;
                    
                default :
                    System.Console.WriteLine("Errore nella selezione. Riprova");
                    break;
            }

            System.Console.WriteLine("Premi un tasto per continuare");
            Console.ReadKey();
            
        }
    }
}
```

### 39 - Menu di selezione doppio controllo:

```c#
class Program
{
    static void Main(string[] args)
    {   
        Console.Clear();
        System.Console.WriteLine("Inserisci un comando speciale ('cmd:info', 'cmd:exit')");

        while (true)
        {
            //
            string? input = Console.ReadLine();

            if (input.StartsWith("cmd:"))
            {
                string comando = input.Substring(4);

                switch (comando)
                {
                    case "info":
                        System.Console.WriteLine("Comando 'info' riconosciuto. Ecco le informazioni...");
                        break;

                    case "exit":
                        System.Console.WriteLine("Comando 'exit' riconosciuto. Uscita in corso...");
                        return;
                    
                    default:
                        System.Console.WriteLine($"Comando '{comando}' non riconosciuto.");
                        break;
                }
            }
            else
            {
                System.Console.WriteLine("Input non valido. Inserisci un comando valido");
            }

            System.Console.WriteLine("\nInserisci un altro comando");
            
        }
    }
}
```

```c#
class Program
{
    static void Main(string[] args)
    {
        System.Console.WriteLine("Inserisci il tuo nome");
        string? nome = Console.ReadLine();

        while (true)
        {
            Console.Clear();
            System.Console.WriteLine("Selezione un opzione:");
            System.Console.WriteLine("1 - saluto");
            System.Console.WriteLine("e - exit");

            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    System.Console.WriteLine($"Ciao {nome}");
                    break;

                case "e":
                    return;

                default:
                    System.Console.WriteLine($"Opzione {input} non valida. Riprova");
                    break;
            }

            System.Console.WriteLine("Premi un tasto per continuare...");
            Console.ReadKey();
            
        }

    }
}

```

### 40 - Drag and Drop di un file per leggerne il contenuto:

```c#
class Program
{
    static void Main(string[] args)
    {
        System.Console.WriteLine("Trascina un file qui e premi invio:");
        string? filePath = Console.ReadLine().Trim('"'); // rimuove le virgolette

        try
        {
            string contenuto = File.ReadAllText(filePath);
            System.Console.WriteLine("Contenuto del file: ");
            System.Console.WriteLine(contenuto);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Si è verificato un errore: {ex.Message}");
            
        }
        
    }
}
```
### 41 - Menu con opzioni:

```c# 
class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        System.Console.WriteLine("Seleziona l'opzione:");
        System.Console.WriteLine("1 - Nascondi il cursore");
        System.Console.WriteLine("2 - Mostra il cursore");
        System.Console.WriteLine("3 - Pulisci console");
        System.Console.WriteLine("4 - Emetti beep");
        System.Console.WriteLine("5 - Emetti beep prolungato");
        System.Console.WriteLine("6 - Imposta il titolo");
        System.Console.WriteLine("e - exit\n");

        while (true)
        {
            System.Console.WriteLine("Digita...");
            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.CursorVisible = false;
                    break;

                case "2":
                    Console.CursorVisible = true;
                    break;

                case "3":
                    Console.Clear();
                    break;

                case "4":
                    Console.Beep();
                    break;

                case "5":
                    System.Console.WriteLine("Inserisci la frequenza");
                    int freq = Int32.Parse(Console.ReadLine());

                    System.Console.WriteLine("Inserisci durata in ms");
                    int ms = Int32.Parse(Console.ReadLine());

                    Console.Beep(freq, ms);
                    break;

                case "6":
                    Console.Title = "La mia app";
                    break;

                case "e":
                    return;

                default:
                    System.Console.WriteLine("Opzione errata:");
                    break;

            }

        }

    }
}
```

### 42 - Gestione del timeout nell'inserimento di un input asincrono con TASK

```c#
class Program
{
    static async Task Main(string[] args)
    {
        int timeoutInSeconds = 5; // imposta il tempo di attesa in secondi

        Task inputTask = Task.Run(() =>
        {
            Console.WriteLine($"Inserisici un input entro {timeoutInSeconds} secondi:");            
            return Console.ReadLine();
        });

        Task delayTask = Task.Delay(TimeSpan.FromSeconds(timeoutInSeconds));

        if (await Task.WhenAny(inputTask, delayTask) == inputTask)
        {
            // l'utente ha inserito un input
            string input = await (inputTask as Task<string>);
            Console.WriteLine($"Hai inserito: {input}");            
        }
        else 
        {
            // il tempo è scaduto
            System.Console.WriteLine("Tempo scaduto!");
        }

    }
}
```

### 43 - Gestione del timeout nell'inserimento di un input semplice

```c#
class Program
{
    static void Main(string[] args)
    {
        int timeoutInSeconds = 5;
        Console.WriteLine($"Inserisci input entro {timeoutInSeconds} secondi:");

        bool inputReceived = false;
        string? input = "";

        DateTime endTime = DateTime.Now.AddSeconds(timeoutInSeconds);

        while (DateTime.Now < endTime)
        {
            if (Console.KeyAvailable)
            {
                input = Console.ReadLine();
                inputReceived = true;
                break;
            }
            // Thread.Sleep(400);
            // System.Console.WriteLine($"{DateTime.Now}");
        }

        if (inputReceived)
        {
            Console.WriteLine($"Hai inserito: {input}");
            
        }
        else
        {
            System.Console.WriteLine("Tempo scaduto!");
        }
        

    }
}
```