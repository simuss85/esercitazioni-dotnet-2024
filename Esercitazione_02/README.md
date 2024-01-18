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
<details>
    <summary> codice </summary>

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
</details>

### 02 - Dichiarare una variabile di tipo intero:
<details>
    <summary> codice </summary>

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
</details>

### 03 - Dichiarare variabili di tipo booleano:
<details>
    <summary> codice </summary>

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
</details>

### 04 - Dichiarare una variabile di tipo decimale:
<details>
    <summary> codice </summary>

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
</details>

### 05 - Dichiarare una variabile di tipo data:
<details>
    <summary> codice </summary>

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
</details>

### 06 - Dichiarare una variabile di tipo data utilizzando il metodo ToShortDateString():
<details>
    <summary> codice </summary>

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
</details>

### 07 - Dichiarare una variabile di tipo data e utilizzare il metodo ToLongDateString():
<details>
    <summary> codice </summary>

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
</details>

### 08 - Utilizzare l'operatore + per sommare due interi:
<details>
    <summary> codice </summary>

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
</details>

### 09 - Utilizzare l'operatore + per sommare due interi e un decimale:
<details>
    <summary> codice </summary>

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
</details>

### 10 - Utilizzare l'operatore == per confrontare due stringhe:
<details>
    <summary> codice </summary>

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
</details>

### 11 - Utilizzare l'operatore != per confrontare due stringhe:
<details>
    <summary> codice </summary>

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
</details>

### 12 - Utilizzare l'operatore > per confrontare due interi:
<details>
    <summary> codice </summary>

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
</details>

### 13 - Dichiarare un array di stringhe: 
<details>
    <summary> codice </summary>

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
</details>

### 14 - Dichiarare un array di interi:
<details>
    <summary> codice </summary>

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
</details>

### 15 - Dichiarare un array di stringhe e utilizzare il metodo Length:
<details>
    <summary> codice </summary>

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
</details>

### 16 - Dichiarare una lista di stringhe:
<details>
    <summary> codice </summary>

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
</details>

### 17 - Dichiarare una lista di interi:
<details>
    <summary> codice </summary>

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
</details>

### 18 - Dichiarare una lista di stringhe e utilizzare il metodo Count:
<details>
    <summary> codice </summary>

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
</details>

### 19 - Dichiarare una pila di stringhe:
<details>
    <summary> codice </summary>

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
</details>

### 20 - Dichiarare una coda di stringhe:
<details>
    <summary> codice </summary>

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
</details>

### 21 - Esempio di array Join:
<details>
    <summary> codice </summary>

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
</details>

### 22 - Riordino di una lista con metodo Sort e funzione di stampa:
<details>
    <summary> codice </summary>

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
</details>

### 23 - Utilizzare l'istruzione if:
<details>
    <summary> codice </summary>

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
</details>

### 24 - Utilizzare istruzione if con else:
<details>
    <summary> codice </summary>

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
</details>

### 25 - Utilizzare istruzione if con else-if else:
<details>
    <summary> codice </summary>

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
</details>

### 26 - Utilizzare l'istruzione switch:
<details>
    <summary> codice </summary>

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
</details>

### 27 - Dichiarare un dizionario di stringhe:
<details>
    <summary> codice </summary>

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
</details>

### 28 - Inizializzare dizionario senza metodo Add:
<details>
    <summary> codice </summary>

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
</details>

### 29 - Utilizzare il ciclo for:
<details>
    <summary> codice </summary>

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
</details>

### 30 - Utilizzare il ciclo foreach con un array di stringhe:
<details>
    <summary> codice </summary>

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
</details>

### 31 - Utilizzare il ciclo foreach con una lista:
<details>
    <summary> codice </summary>

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
</details>

### 32 - Utilizzare foreach per scoprire quali key contiene un dictionary:
<details>
    <summary> codice </summary>

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
</details>

### 33 - Cerca un valore string in un array e lo copia in una lista:
<details>
    <summary> codice </summary>

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
</details>

### 34 - Utilizzare ciclo while con array di stringhe:
<details>
    <summary> codice </summary>

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
</details>

### 35 - Utilizzare ciclo while con List:
<details>
    <summary> codice </summary>

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
</details>

### 36 - Utilizzare la classe ConsoleKeyInfo e il ciclo while. Premi N per uscire:
<details>
    <summary> codice </summary>

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
</details>

### 37 - Utilizzare ConsoleKeyInfo e ciclo while. Premi 'Ctrl'+'Q':
<details>
    <summary> codice </summary>

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
</details>

### 38 - Menu di selezione semplice:
<details>
    <summary> codice </summary>

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
</details>

### 39 - Menu di selezione doppio controllo:
<details>
    <summary> codice </summary>

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
</details>
<details>
    <summary> codice </summary>

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
</details>

### 40 - Drag and Drop di un file per leggerne il contenuto:
<details>
    <summary> codice </summary>

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
</details>

### 41 - Menu con opzioni:
<details>
    <summary> codice </summary>

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
</details>

### 42 - Gestione del timeout nell'inserimento di un input asincrono con TASK:
<details>
    <summary> codice </summary>

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
</details>

### 43 - Gestione del timeout nell'inserimento di un input semplice:
<details>
    <summary> codice </summary>

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
</details>

### 44 - Utilizzare la classe Random per generare un numero casuale compreso tra 1 e 10 e lo somma 10 volte:
<details>
    <summary> codice </summary>

```c#
class Program
{
    // questo programma genera 10 numeri casuali e ne calcola la somma
    static void Main(string[] args)
    {
        Random random = new Random();           // Generatore di numeri casuali
        int somma = 0;
        for (int i = 0; i < 10; i++)
        {
            int numero = random.Next(1,10);     // Genera un numero casuale tra 1 e 10 si dice che l'intervallo è [1,11)
            somma += numero;
            Console.WriteLine($"Il numero casuale è {numero}"); // interpolazione di stringhe
            
        }
        
        Console.WriteLine($"La somma è {somma}");    
    }

}
```
</details>

### 45 - Esempio 44 modificato con output colorato:
<details>
    <summary> codice </summary>

```c#
class Program
{
    // questo programma genera 10 numeri casuali e ne calcola la somma
    static void Main(string[] args)
    {
        Random random = new Random();           // Generatore di numeri casuali
        int somma = 0;
        for (int i = 0; i < 10; i++)
        {
            int numero = random.Next(1,10);     // Genera un numero casuale tra 1 e 10 si dice che l'intervallo è [1,11)
            somma += numero;
            Console.WriteLine($"Il numero casuale è {numero}"); // interpolazione di stringhe
            Thread.Sleep(500); // rallenta visualizzazione output
        }
        Console.Write("La somma è "); // usato il write per non andare a capo
        Console.ForegroundColor = ConsoleColor.DarkCyan;   
        Console.WriteLine($"{somma}");
        Console.ResetColor();  
    }
}
```
</details>

### 46 - Genera un numero casuale per sorteggiare un nome dall'array:
<details>
    <summary> codice </summary>

```c#
class Program
{
    // questo programma genera un numero casuale per sorteggiare un array:
    static void Main(string[] args)
    {
        string[] nomi = ["Mario", "Luigi", "Giovanni"];
        Random random = new Random();
        int indice = random.Next(0, nomi.Length);
        Console.WriteLine($"Il nome sorteggiato è {nomi[indice]}");
    }
}
```
</details>

### 47 - Genera un numero casuale per sorteggiare un nome da una lista:
<details>
    <summary> codice </summary>

```c#
class Program
{
    // questo programma genera un numero casuale per sorteggiare una lista:
    static void Main(string[] args)
    {
        List<string> nomi = ["Alex", "Simone", "Fabio", "Giada",
                             "Carlo", "Dylan", "Natalia", "Ale"];
        Random random = new Random();
        int i = 0;
        while (i < 10)
        {
            int indice = random.Next(0, nomi.Count);
            Console.WriteLine($"Il nome sorteggiato è {nomi[indice]}");
            i++;
        }
    }
}
```
</details>

### 48 - Crea matrice 2x2 e la visualizza:
<details>
    <summary> codice </summary>

```c#
class Program
{
    // stampa matrice 2x2:
    static void Main(string[] args)
    {
        int[][] matrice = {[ 1, 2, 3], [ 4, 5, 6]};
        Console.WriteLine("");
        
        for (int i = 0; i < matrice.Length; i++)
        {
            for (int j = 0; j < matrice[i].Length; j++)
            {
                Console.Write($"{matrice[i][j]} ");   
            }
            Console.WriteLine("");
        } 
    }
}
```
</details>

### 49 - Buzz & Fizz con menu di scelta (for o Random):
<details>
    <summary> codice </summary>

```c#
class Program
{
    // Gin & Fizz...
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Benvenuti a Fizz & Buzz!");
        do
        {
            Console.Clear();
            Console.WriteLine("Seleziona il metodo da usare:");
            Console.WriteLine("f - metodo for");
            Console.WriteLine("r - metodo Random");
            Console.WriteLine("e - exit");
            string? input = Console.ReadLine();

            Console.Clear();

            switch (input)
            {
                case "f":
                    Console.Write("Inserisci il valore massimo: ");
                    int max = Int32.Parse(Console.ReadLine());

                    Console.Clear();

                    for (int i = 1; i < max; i++)
                    {
                        // Console.Write($"{i} ");        //### debug ###

                        if ((i % 3 == 0) && (i % 5 == 0)) // divisibile per 3 e 5
                        {
                            Console.WriteLine("Fizz & Buzz");
                        }
                        else if (i % 3 == 0) // divisibile per 3
                        {
                            Console.WriteLine("Fizz");
                        }
                        else if (i % 5 == 0) // divisibile per 5
                        {
                            Console.WriteLine("Buzz");
                        }
                        else                // non divisibile
                        {
                            Console.Write("Il numero è ");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine($"{i}");
                            Console.ResetColor();
                        }
                        Thread.Sleep(300);

                    }
                    Console.WriteLine("Premi per continuare...");
                    Console.ReadKey();
                    break;

                case "r":
                    Console.Write("Inserici il numero di prove da verificare: ");
                    int prove = Int32.Parse(Console.ReadLine());

                    Console.Clear();

                    Random random = new();
                    int count = 0;

                    while (count < prove)
                    {
                        int numero = random.Next(1, 100);

                        if ((numero % 3 == 0) && (numero % 5 == 0)) // divisibile per 3 e 5
                        {
                            Console.WriteLine("Fizz & Buzz");

                        }
                        else if (numero % 3 == 0) // divisibile per 3
                        {
                            Console.WriteLine("Fizz");
                        }
                        else if (numero % 5 == 0) // divisibile per 5
                        {
                            Console.WriteLine("Buzz");
                        }
                        else                      // non divisibile
                        {
                            Console.Write("Il numero è ");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine($"{numero}");  // stampo il numero di un altro colore
                            Console.ResetColor();            // reset colore console
                        }
                        Thread.Sleep(700);
                        count++;
                    }
                    break;

                case "e":
                    Console.WriteLine("Uscita...");
                    Thread.Sleep(500);
                    return;

                default:
                    Console.WriteLine("Selezione errata!");
                    break;
            }
        } while (true);
    }
}
```
</details>

### 50 - Buzz & Fizz ver_2:
<details>
    <summary> codice </summary>

```c#
class Program
{
    // Gin & Fizz...v2
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Benvenuti a Fizz & Buzz!");

        List<int> fizzList = new();
        List<int> buzzList = new();
        List<int> fizzNbuzzList = new();

        do
        {
            Console.Clear();
            Console.WriteLine("Seleziona il metodo da usare:");
            Console.WriteLine("f - metodo for");
            Console.WriteLine("r - metodo Random");
            Console.WriteLine("v - visualizza liste");
            Console.WriteLine("e - exit");
            string? input = Console.ReadLine();

            Console.Clear();

            switch (input)
            {
                case "f":
                    Console.Write("Inserisci il valore massimo: ");
                    int max = Int32.Parse(Console.ReadLine() ?? string.Empty);

                    Console.Clear();

                    for (int i = 1; i < max; i++)
                    {
                        // Console.Write($"{i} ");        //### debug ###

                        if ((i % 3 == 0) && (i % 5 == 0)) // divisibile per 3 e 5
                        {
                            Console.Write($"{i} - ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Fizz & Buzz");
                            Console.ResetColor();

                            if (!(fizzNbuzzList.Contains(i)))
                            {
                                fizzNbuzzList.Add(i);
                            }
                            // fizzNbuzzList.Add(i);

                        }
                        else if (i % 3 == 0) // divisibile per 3
                        {
                            Console.Write($"{i} - ");
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine("Fizz");
                            Console.ResetColor();

                            if (!(fizzList.Contains(i)))
                            {
                                fizzList.Add(i);
                            }
                            // fizzList.Add(i);

                        }
                        else if (i % 5 == 0) // divisibile per 5
                        {
                            Console.Write($"{i} - ");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Buzz");
                            Console.ResetColor();

                            if (!(buzzList.Contains(i)))
                            {
                                buzzList.Add(i);
                            }
                            // buzzList.Add(i);
                        }
                        else                // non divisibile
                        {
                            Console.WriteLine($"{i}");
                        }
                        Thread.Sleep(300);

                    }
                    Console.WriteLine("Premi per continuare...");
                    Console.ReadKey();
                    break;

                case "r":
                    Console.Write("Inserici il numero di prove da verificare: ");
                    int prove = Int32.Parse(Console.ReadLine() ?? string.Empty);

                    Console.Clear();

                    Random random = new();
                    int count = 0;

                    while (count < prove)
                    {
                        int numero = random.Next(1, 100);

                        if ((numero % 3 == 0) && (numero % 5 == 0)) // divisibile per 3 e 5
                        {
                            Console.WriteLine($"{numero} - Fizz & Buzz");
                            if (!(fizzNbuzzList.Contains(numero)))
                            {
                                fizzNbuzzList.Add(numero);
                            }
                        }
                        else if (numero % 3 == 0) // divisibile per 3
                        {
                            Console.WriteLine($"{numero} - Fizz");
                            if (!(fizzList.Contains(numero)))
                            {
                                fizzList.Add(numero);
                            }

                        }
                        else if (numero % 5 == 0) // divisibile per 5
                        {
                            Console.WriteLine($"{numero} - Buzz");
                            if (!(buzzList.Contains(numero)))
                            {
                                buzzList.Add(numero);
                            }

                        }
                        else                      // non divisibile
                        {
                            Console.WriteLine($"{numero}");  
                        }
                        Thread.Sleep(300);
                        count++;
                    }
                    break;

                case "v":
                    Console.WriteLine("Visualizzo le liste salvate");
                    // fizzNbuzz
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Fizz & Buzz:");
                    Console.ResetColor();
                    Console.Write(" [");
                    
                    if (fizzNbuzzList.Count == 0)   // verifica lista vuota
                    {
                        Console.WriteLine("vuota]");
                    }

                    for (int i = 0; i < fizzNbuzzList.Count; i++)
                    {
                        if (i == fizzNbuzzList.Count - 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write($"{fizzNbuzzList[i]}");
                            Console.ResetColor();
                            Console.WriteLine("]");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write($"{fizzNbuzzList[i]}");
                            Console.ResetColor();
                            Console.Write(", ");

                        }
                    }
                    
                    // fizz 
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("Fizz:");
                    Console.ResetColor();
                    Console.Write(" [");

                    if (fizzList.Count == 0)   // verifica lista vuota
                    {
                        Console.WriteLine("vuota]");
                    }

                    for (int i = 0; i < fizzList.Count; i++)
                    {
                        if (i == fizzList.Count - 1)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write($"{fizzList[i]}");
                            Console.ResetColor();
                            Console.WriteLine("]");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write($"{fizzList[i]}");
                            Console.ResetColor();
                            Console.Write(", ");

                        }
                    }
                    
                    // buzz
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Buzz:");
                    Console.ResetColor();
                    Console.Write(" [");

                    if (buzzList.Count == 0)   // verifica lista vuota
                    {
                        Console.WriteLine("vuota]");
                    }
                    for (int i = 0; i < buzzList.Count; i++)
                    {
                        if (i == buzzList.Count - 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write($"{buzzList[i]}");
                            Console.ResetColor();
                            Console.WriteLine("]");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write($"{buzzList[i]}");
                            Console.ResetColor();
                            Console.Write(", ");

                        }
                    }

                    Console.WriteLine("Premi un tasto per continuare...");
                    Console.ReadKey();

                    break;

                case "e":
                    Console.WriteLine("Uscita...");
                    Thread.Sleep(300);
                    return;

                default:
                    Console.WriteLine("Selezione errata!");
                    break;
            }
        } while (true);
    }
}
```
</details>

### 51 - Funzione Lambda:
<details>
    <summary> codice </summary>

```c#
 class Program
    {
        // programma per le prove 
        static void Main(string[] args)
        {
            List<int> list = [1,2,3];

            list.ForEach(s => Console.Write($"{s} ")); // funzione lambda per la stampa
        }
    }
```
</details>

### 53 - Calcolatrice base con interi, chiede prima l'opzione:
<details>
    <summary> codice </summary>
    
```c#
class Program
{
    static void Main(string[] args)
    {
        // semplice calcolatrice con quattro operatori e selettore switch
        int x, y, risultato;
        string? input;

        do
        {
            Console.Clear();

            Console.WriteLine("**********************");
            Console.WriteLine("**** CALCOLATRICE ****");
            Console.WriteLine("**********************");
            Console.WriteLine("**  +  somma        **");
            Console.WriteLine("**  *  prodotto     **");
            Console.WriteLine("**  -  sottrazione  **");
            Console.WriteLine("**  /  divisione    **");
            Console.WriteLine("**********************\n");

            Console.Write("Seleziona opzione: ");

            input = Console.ReadLine();

            switch (input)
            {
                case "+":       // esegue la somma tra due numeri e visualizza il risultato
                    Console.WriteLine("Inserisci il primo numero");
                    input = Console.ReadLine();

                    while (!(int.TryParse(input, out x))) // controllo sul primo numero inserito
                    {
                        Console.WriteLine("Devi inserire un numero intero");
                        Console.Write("Inserisci il primo numero: ");
                        input = Console.ReadLine();
                    }
                    Console.Write("Inserisci il secondo numero: ");
                    input = Console.ReadLine();

                    while (!(int.TryParse(input, out y))) // controllo sul secondo numero inserito
                    {
                        Console.WriteLine("Devi inserire un numero intero");
                        Console.Write("Inserisci il secondo numero: ");
                        input = Console.ReadLine();
                    }

                    risultato = x + y;
                    Console.WriteLine($"La somma tra {x} e {y} = {risultato}");
                    Console.WriteLine("Premi per continuare...");
                    Console.ReadKey();


                    break;

                case "*":       // esegue la somma tra due numeri e visualizza il risultato
                    Console.WriteLine("Inserisci il primo numero");
                    input = Console.ReadLine();

                    while (!(int.TryParse(input, out x))) // controllo sul primo numero inserito
                    {
                        Console.WriteLine("Devi inserire un numero intero");
                        Console.Write("Inserisci il primo numero: ");
                        input = Console.ReadLine();
                    }
                    Console.Write("Inserisci il secondo numero: ");
                    input = Console.ReadLine();

                    while (!(int.TryParse(input, out y))) // controllo sul secondo numero inserito
                    {
                        Console.WriteLine("Devi inserire un numero intero");
                        Console.Write("Inserisci il secondo numero: ");
                        input = Console.ReadLine();
                    }

                    risultato = x * y;
                    Console.WriteLine($"Il prodotto tra {x} e {y} = {risultato}");
                    Console.WriteLine("Premi per continuare...");
                    Console.ReadKey();

                    break;

                case "-":       // esegue la somma tra due numeri e visualizza il risultato
                    Console.WriteLine("Inserisci il primo numero");
                    input = Console.ReadLine();

                    while (!(int.TryParse(input, out x))) // controllo sul primo numero inserito
                    {
                        Console.WriteLine("Devi inserire un numero intero");
                        Console.Write("Inserisci il primo numero: ");
                        input = Console.ReadLine();
                    }
                    Console.Write("Inserisci il secondo numero: ");
                    input = Console.ReadLine();

                    while (!(int.TryParse(input, out y))) // controllo sul secondo numero inserito
                    {
                        Console.WriteLine("Devi inserire un numero intero");
                        Console.Write("Inserisci il secondo numero: ");
                        input = Console.ReadLine();
                    }

                    risultato = x - y;
                    Console.WriteLine($"La sottrazione tra {x} e {y} = {risultato}");
                    Console.WriteLine("Premi per continuare...");
                    Console.ReadKey();

                    break;

                case "/":       // esegue la somma tra due numeri e visualizza il risultato
                    Console.WriteLine("Inserisci il primo numero");
                    input = Console.ReadLine();

                    while (!(int.TryParse(input, out x))) // controllo sul primo numero inserito
                    {
                        Console.WriteLine("Devi inserire un numero intero");
                        Console.Write("Inserisci il primo numero: ");
                        input = Console.ReadLine();
                    }
                    Console.Write("Inserisci il secondo numero: ");
                    input = Console.ReadLine();

                    while (!(int.TryParse(input, out y)) || (int.Parse(input) == 0)) // controllo sul secondo numero inserito
                    {
                        Console.WriteLine("\nATTENZIONE!!!\nDevi inserire un numero intero e diverso da ZERO\n");
                        Console.Write("Inserisci il secondo numero: ");
                        input = Console.ReadLine();
                    }

                    risultato = x / y;
                    int resto = x % y;
                    Console.WriteLine($"La divisione intera tra {x} e {y} = {risultato} con resto {resto}");
                    Console.WriteLine("Premi per continuare...");
                    Console.ReadKey();

                    break;

                default:
                    Console.WriteLine("Selezione errata.");
                    Console.WriteLine("Premi per continuare...");
                    Console.ReadKey();
                    break;

            }

        }
        while (true);
    }

}
```
</details>

### 54 - Calcolatrice base con interi, chede prima i numeri:
<details>
    <summary> codice </summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        // semplice calcolatrice con quattro operatori e selettore switch
        int x, y, risultato = 0;
        string? input, outputString = "";

        do
        {
            Console.Clear();

            Console.WriteLine("**********************");
            Console.WriteLine("**** CALCOLATRICE ****");
            Console.WriteLine("**********************");
            Console.WriteLine("**  +  somma        **");
            Console.WriteLine("**  *  prodotto     **");
            Console.WriteLine("**  -  sottrazione  **");
            Console.WriteLine("**  /  divisione    **");
            Console.WriteLine("**********************\n");

            Console.WriteLine("Inserisci il primo numero");
            input = Console.ReadLine();

            while (!(int.TryParse(input, out x))) // controllo sul primo numero inserito
            {
                Console.WriteLine("Devi inserire un numero intero");
                Console.Write("Inserisci il primo numero: ");
                input = Console.ReadLine();
            }

            Console.Write("Inserisci il secondo numero: ");
            input = Console.ReadLine();

            while (!(int.TryParse(input, out y))) // controllo sul secondo numero inserito
            {
                Console.WriteLine("Devi inserire un numero intero");
                Console.Write("Inserisci il secondo numero: ");
                input = Console.ReadLine();
            }

            Console.Write("Seleziona opzione: ");
            input = Console.ReadLine();

        Verifica:
            switch (input)
            {
                case "+":       // esegue la somma tra due numeri e visualizza il risultato
                    risultato = x + y;
                    outputString = "La somma";
                    break;

                case "*":       // esegue la somma tra due numeri e visualizza il risultato
                    risultato = x * y;
                    outputString = "Il prodotto";
                    break;

                case "-":       // esegue la somma tra due numeri e visualizza il risultato
                    risultato = x - y;
                    outputString = "La sottrazione";
                    break;

                case "/":       // esegue la somma tra due numeri e visualizza il risultato
                    while (y == 0)
                    {
                        Console.WriteLine("Non puoi dividere per ZERO!");
                        while (!(int.TryParse(input, out y)) || (int.Parse(input) == 0)) // controllo sul secondo numero inserito
                        {
                            Console.WriteLine("Devi inserire un numero intero");
                            Console.Write("Inserisci il secondo numero: ");
                            input = Console.ReadLine();
                        }

                    }
                    risultato = x / y;
                    int resto = x % y;
                    outputString = "La divisione";
                    break;

                default:
                    Console.WriteLine("Selezione errata.");
                    Console.Write("Seleziona opzione: ");
                    input = Console.ReadLine();
                    goto Verifica;

            }
            Console.WriteLine($"{outputString} tra {x} e {y} = {risultato}");
            Console.WriteLine("Vuoi continuare? s/n");
            input = Console.ReadLine();
            if (input == "n")
            {
                return;
            }
        }
        while (true);
    }

}
```
</details>