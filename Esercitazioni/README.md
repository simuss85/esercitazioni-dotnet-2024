# ESERCITAZIONE BASE SU C# .NET CORE

Ecco alcune esercitazioni base su C# .NET Core senza l'utilizzo di namespaces.

**dotnet new console >> creare un nuovo progetto console.**

**dotnet run >> eseguire il progetto console.**

- 01 - Tipi di dato e variabili
- 02 - Operatori
- 03 - Strutture di dati
- 04 - Condizioni
- 05 - Cicli


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

### 47 - Menu di selezione con il best-off dei programmi passati:
<details>
    <summary> codice </summary>

```c#
class Program
{
    static async Task Main(string[] args)
    {

        int freq, ms; // variabili per le opzioni 5, 6
        bool continua; // variabile per opzione 9
        string? prodotto = ""; // variabile per opzione 9
        List<string> listaSpesa = new List<string>();

        do
        {
            Console.Clear(); // pulisce lo schermo

            // stampa il menu
            Console.WriteLine("Menu delle opzioni:");
            Console.WriteLine("1 - Nascondi il cursore");
            Console.WriteLine("2 - Mostra il cursore");
            Console.WriteLine("3 - Drag&Drop");
            Console.WriteLine("4 - Emetti beep");
            Console.WriteLine("5 - Emetti beep prolungato");
            Console.WriteLine("6 - Crea melodia random");
            Console.WriteLine("7 - Saluto!");
            Console.WriteLine("8 - Timeout della console");
            Console.WriteLine("9 - Lista della spesa");
            Console.WriteLine("e - exit\n");
            Console.Write("Scegli un'opzione: ");

            string? input = Console.ReadLine()!.ToLower(); // prende anche input maiuscoli



            switch (input)
            {
                case "1":
                    Console.WriteLine("Hai selezionato l'opzione 1");
                    Console.CursorVisible = false;
                    break;

                case "2":
                    Console.WriteLine("Hai selezionato l'opzione 2");
                    Console.CursorVisible = true;
                    break;

                case "3":
                    // drag & drop
                    Console.WriteLine("Hai selezionato l'opzione 3");
                    Console.WriteLine("Trascina qui dentro un file...");

                    string? filePath = Console.ReadLine()!.Trim('"'); // rimuove le virgolette
                    Console.WriteLine("Premi invio...");
                    Console.ReadLine();

                    try
                    {
                        string contenuto = File.ReadAllText(filePath);
                        Console.WriteLine("Contenuto del file: ");
                        Console.WriteLine(contenuto);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Si è verificato un errore: {ex.Message}");

                    }
                    break;

                case "4":
                    Console.WriteLine("Hai selezionato l'opzione 4");
                    Console.Beep();
                    break;

                case "5":
                    Console.WriteLine("Hai selezionato l'opzione 5");
                    Console.WriteLine("Inserisci la frequenza");
                    freq = Int32.Parse(Console.ReadLine()!);

                    Console.WriteLine("Inserisci durata in ms");
                    ms = Int32.Parse(Console.ReadLine()!);

                    Console.Beep(freq, ms);
                    break;

                case "6":
                    //
                    Console.WriteLine("Hai selezionato l'opzione 6");
                    Console.WriteLine("Inserisci secondi");

                    int count = Int32.Parse(Console.ReadLine()!);
                    Random random = new Random(); // variabile random

                    for (int i = 0; i < count; i++)
                    {
                        freq = random.Next(1, 10) * 100; // crea un numero random tra 100 e 1000
                        Console.Beep(freq, 500);
                    }
                    break;

                case "7":
                    Console.WriteLine("Hai selezionato l'opzione 7");
                    Console.WriteLine("Inserici il tuo nome");
                    string? nome = Console.ReadLine();

                    Console.WriteLine($"\nCiao {nome}, piacere di conoscerti!");
                    break;

                case "8":
                    Console.WriteLine("Hai selezionato l'opzione 8");
                    Console.Write("Inserisci un timer per la console in secondi: ");
                    int timeoutInSeconds = Int32.Parse(Console.ReadLine()!);

                    Task inputTask = Task.Run(() =>
                    {
                        Console.WriteLine($"Inserisici un input entro {timeoutInSeconds} secondi:");
                        return Console.ReadLine();
                    });

                    Task delayTask = Task.Delay(TimeSpan.FromSeconds(timeoutInSeconds));

                    if (await Task.WhenAny(inputTask, delayTask) == inputTask)
                    {
                        // l'utente ha inserito un input
                        input = await (inputTask as Task<string>)!;
                        Console.WriteLine($"Hai inserito: {input}");
                    }
                    else
                    {
                        // il tempo è scaduto
                        Console.WriteLine("Tempo scaduto! Premi invio...");
                    }
                    break;

                case "9":

                    do
                    {
                        Console.Clear();

                        Console.WriteLine("Hai selezionato l'opzione 9");
                        Console.WriteLine("Lista della spesa:");
                        Console.WriteLine("v - Visualizza lista");
                        Console.WriteLine("a - Aggiungi");
                        Console.WriteLine("d - Elimina");
                        Console.WriteLine("r - Torna indietro\n");
                        Console.Write("Scegli un'opzione: ");

                        input = Console.ReadLine()!.ToLower(); // prende anche input minuscoli
                        continua = true;

                        switch (input)
                        {
                            case "v":
                                // visualizza gli elementi salvati nella lista
                                Console.Clear();

                                if (listaSpesa.Count != 0)
                                {
                                    Console.WriteLine("Lettura lista..\n");
                                    foreach (string elemento in listaSpesa)
                                    {
                                        Console.WriteLine($"- {elemento}");
                                    }
                                    Console.WriteLine("\nPremi per continuare...");
                                    Console.ReadKey();

                                }
                                else
                                {
                                    Console.WriteLine("\nLista vuota\n");
                                    Console.WriteLine("Premi per continuare...");
                                    Console.ReadKey();
                                }

                                break;

                            case "a":
                                // aggiunge elementi alla lista senza ripetizioni
                                bool inserisci = true;

                                while (inserisci)
                                {
                                    Console.Clear();

                                    Console.WriteLine("Premi 'ctrl'+'h' per terminare");
                                    Console.Write("Inserisci un prodotto: ");


                                    ConsoleKeyInfo keyInfo = Console.ReadKey(); // salva il primo carattere digitato

                                    if ((keyInfo.Modifiers & ConsoleModifiers.Control) != 0) // verifica se ho premuto 'ctrl'
                                    {
                                        if (keyInfo.Key == ConsoleKey.H)
                                        {
                                            Console.WriteLine("\nFine inserimento..");
                                            inserisci = false;
                                            break;
                                        }
                                    }
                                    else
                                    {

                                        prodotto = keyInfo.KeyChar + Console.ReadLine(); // concateno per non perdere il primo elemento
                                                                                         // Console.WriteLine($"Prova inserimento {prodotto}"); // debug
                                                                                         // Console.WriteLine("Premi invio..");
                                                                                         // Console.ReadLine();

                                        while (listaSpesa.Contains(prodotto)) // controlla che l elemento sia unico nella lista
                                        {
                                            Console.WriteLine("Hai gia inserito questo prodotto.");
                                            Console.Write("Riprova... ");
                                            prodotto = Console.ReadLine();
                                        }

                                        listaSpesa.Add(prodotto);
                                        Console.WriteLine($"Hai inserito '{prodotto}'\n");
                                        Thread.Sleep(1000);
                                    }
                                }

                                break;

                            case "d":
                                // elimina un elemento se nella lista
                                Console.Clear();

                                Console.WriteLine("Elimina prodotti");
                                if (listaSpesa.Count != 0) // se la lista non è gia vuota esegue il codice
                                {
                                    Console.WriteLine("Premi 'ctrl'+'h' per terminare");
                                    Console.Write("Inserisci il prodotto da eliminare: ");

                                    ConsoleKeyInfo keyInfo = Console.ReadKey();

                                    if ((keyInfo.Modifiers & ConsoleModifiers.Control) != 0)
                                    {
                                        if (keyInfo.Key == ConsoleKey.H)
                                        {
                                            Console.WriteLine("\nFine inserimento..");
                                            inserisci = false;
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        prodotto = keyInfo.KeyChar + Console.ReadLine();

                                        while (!(listaSpesa.Contains(prodotto)))
                                        {
                                            Console.WriteLine($"'{prodotto}' non presente nella lista");
                                            Console.WriteLine("Ecco la lista completa:");
                                            foreach (string elemento in listaSpesa)
                                            {
                                                Console.WriteLine($"- {elemento}");
                                            }
                                            Console.Write("\nQuale prodotto vuoi eliminare? ");
                                            prodotto = Console.ReadLine();

                                        }
                                        listaSpesa.Remove(prodotto);
                                        Console.WriteLine($"Hai eliminato '{prodotto}' dalla lista");
                                    }

                                }
                                else
                                {
                                    Console.WriteLine("La lista della spesa è vuota");
                                }
                                break;

                            case "r":
                                // torna al menu principale se premiamo 'crtl' + 'r'
                                Console.WriteLine("Salvataggio lista...");

                                // attende 3 secondi prima di proseguire per simulare un salvataggio
                                Thread.Sleep(1200);

                                Console.WriteLine("Fatto!");
                                continua = false;
                                break;

                            default:
                                // errore di selezione
                                Console.WriteLine("Selezione errata. Riprova");
                                break;
                        }
                    }
                    while (continua);

                    break;

                case "e":
                    Console.WriteLine("Uscita in corso...");
                    return;

                default:
                    Console.WriteLine("Selezione errata. Riprova");
                    break;

            }

            Console.WriteLine("\nPremi un tasto per continuare...");
            Console.ReadKey();

        }
        while (true);
    }
}
```
</details>

### 48 - Genera un numero casuale per sorteggiare un nome da una lista:
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

### 49 - Crea matrice 2x2 e la visualizza:
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

### 50 - Buzz & Fizz con menu di scelta (for o Random):
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

### 51 - Buzz & Fizz ver_2:
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

### 52 - Funzione Lambda:
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

### 53 - Genera un numero tra 1 e 100 e chiede di indovinare:
<details>
    <summary> codice </summary>
    
```c#
class Program
{
    static void Main(string[] args)
    {
        // programma che genera un numero tra 1 e 100 e chiede di indivinare il numero
        // se sbaglio esce, se indovino mi avvisa con un output

        Random random = new();
        int x = random.Next(1,100);
        int input;

        Console.WriteLine("Prova ad indovinare il numero segreto");
        input = int.Parse(Console.ReadLine()!);

        if (input == x)
        {
            Console.WriteLine("Che fortuna!!!");
        }
        else
        {
            Console.WriteLine($"Mi dispiace, il numero segreto era {x}");
        }
    }
}
```
</details>

### 54 - Calcolatrice base con interi, chiede prima l'opzione:
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

### 55 - Calcolatrice base con interi, chede prima i numeri:
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

### 56 - Indovina il numero segreto da 1 a 100 con tentativi:
<details>
    <summary> codice </summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        // programma che genera un numero tra 1 e 100 e chiede di indivinare il numero
        // se sbaglio esce, se indovino mi avvisa con un output. Ho a disposizione 
        // 10 tentativi

        Random random = new();
        int x = random.Next(1,5);
        int input, tentativi = 10;

        Console.Clear();
        
        Console.WriteLine("Prova ad indovinare il numero segreto");
        input = int.Parse(Console.ReadLine()!);

        while(tentativi != 1)
        {
            if (input == x)
            {
                Console.WriteLine("Che fortuna!!!");
                return;
            }
            tentativi--;
            Console.WriteLine($"Mi dispiace, hai ancora {tentativi} tentativi");
            input = int.Parse(Console.ReadLine()!);
        }

        Console.WriteLine($"HAI PERSO!\nIl numero era {x}");
        
    }
}
```
</details>

### 57 - Indovina il numero segreto da 1 a 100 con tentativi e gli aiuti:
<details>
    <summary> codice </summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        // programma che genera un numero tra 1 e 100 e chiede di indivinare il numero
        // se sbaglio esce, se indovino mi avvisa con un output. Ho a disposizione 
        // 10 tentativi. Invia suggerimenti per indovinare il numero (piu alto/basso).

        Random random = new();
        int x = random.Next(1, 100);
        int input, tentativi = 10;

        Console.Clear();

        Console.WriteLine("Prova ad indovinare il numero segreto");
        input = int.Parse(Console.ReadLine()!);

        while (tentativi != 1)
        {
            if (input == x)
            {
                if (tentativi == 10)
                {
                    Console.WriteLine("\nChe fortuna!!!");  // se si indovina alla prima sei fortunato
                }
                else
                {
                    Console.WriteLine("\nComplimenti hai indovinato!!!");
                }
                return;

            }
            tentativi--;
            Console.WriteLine($"\nMi dispiace, hai ancora {tentativi} tentativi");

            // introduco i suggerimenti
            Console.Write("Suggerimento. Il numero segreto è ");
            if (input < x)
            {
                Console.WriteLine("più alto!");
            }
            else
            {
                Console.WriteLine("più basso!");
            }
            Console.Write("\nInserisci: ");
            input = int.Parse(Console.ReadLine()!);
        }

        Console.WriteLine($"HAI PERSO!\nIl numero era {x}");
    }
}
```
</details>

### 58 - Indovina il numero segreto da 1 a 100 con tentativi e gli aiuti_v2:
<details>
    <summary> codice </summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        // programma che genera un numero tra 1 e 100 e chiede di indivinare il numero
        // se sbaglio esce, se indovino mi avvisa con un output. Ho a disposizione 
        // 10 tentativi. 
        // Suggerimenti: 
        //               - il numero è (piu alto/basso).
        //               - il numero è (pari o dispari).

        Random random = new();
        int x = random.Next(1, 100);
        int input, tentativi = 10;

        Console.Clear();

        Console.WriteLine("Prova ad indovinare il numero segreto");
        input = int.Parse(Console.ReadLine()!);

        while (tentativi != 1)
        {
            if (input == x)
            {
                if (tentativi == 10)
                {
                    Console.WriteLine("\nChe fortuna!!!");  // se si indovina alla prima sei fortunato
                }
                else
                {
                    Console.WriteLine("\nComplimenti hai indovinato!!!");
                }
                return;

            }
            tentativi--;
            Console.WriteLine($"\nMi dispiace, hai ancora {tentativi} tentativi");

            // introduco i suggerimenti
            Console.Write("Suggerimento. Il numero segreto è ");
            if (tentativi == 9)      // suggerimento pari o dispari al primo errore 
            {
                if (x % 2 == 0)
                {
                    Console.WriteLine("pari");
                }
                else
                {
                    Console.WriteLine("dispari");
                }

            }
            else
            {
                if (input < x)      // suggerimento se piu alto o piu basso
                {
                    Console.WriteLine("più alto!");
                }
                else
                {
                    Console.WriteLine("più basso!");
                }
            }
            // richiesta input in caso di errore
            Console.Write("\nInserisci: ");
            input = int.Parse(Console.ReadLine()!);
        }
        Console.WriteLine($"HAI PERSO!\nIl numero era {x}");
    }
}
```
</details>

### 59 - Indovina il numero segreto da 1 a 100 con tentativi e gli aiuti_v3:
<details>
    <summary> codice </summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        // programma che genera un numero tra 1 e 1000 e chiede di indivinare il numero
        // se sbaglio esce, se indovino mi avvisa con un output. Ho a disposizione 
        // 10 tentativi. 
        // Suggerimenti: 
        //               - il numero è (pari o dispari).
        //               - la somma delle cifre è.
        //               - il numero è (piu alto/basso).
        //               - la prima cifra è.

        Random random = new();
        int x = random.Next(1, 1000);
        int input, tentativi = 10;
        int sleep; // per il Thread.Sleep random
        int primaCifra = 0, somma, resto;

        Console.Clear();

        Console.WriteLine("Prova ad indovinare il numero segreto");
        input = int.Parse(Console.ReadLine()!);

        while (tentativi != 1)
        {   
            // Console.WriteLine($"numero segreto: {x}");      // #### debug ####
            if (input == x)
            {
                if (tentativi == 10)
                {
                    Console.WriteLine("\nChe fortuna!!!");  // se si indovina alla prima sei fortunato
                }
                else
                {
                    Console.WriteLine("\nComplimenti hai indovinato!!!");
                }
                return;

            }
            tentativi--;

            for (int i = 0; i < 3; i++)     // ci pensa su!!!
            {
                Console.Write(". ");
                Thread.Sleep(200);
            }

            Console.WriteLine($"\nMi dispiace, hai ancora {tentativi} tentativi");
            // introduco i suggerimenti


            switch (tentativi)
            {
                case 9:     // suggerimento pari o dispari al primo errore 

                    Console.Write("Suggerimento. Il numero segreto è ");
                    sleep = random.Next(1, 7);
                    Thread.Sleep(sleep);               // ci pensa su!!!

                    if (x % 2 == 0)
                    {
                        Console.WriteLine("pari");
                    }
                    else
                    {
                        Console.WriteLine("dispari");
                    }
                    break;

                case 8:     // suggerimento somma delle cifre del numero 
                    somma = x;
                    resto = 0;
                    string risp = "La somma delle cifre è ";

                    if (x < 10)
                    {   
                        risp += x.ToString();
                    }
                    else if (x < 100)
                    {
                        primaCifra = x / 10;
                        somma = primaCifra;
                        resto = x % 10; // rimane 1 cifra
                        somma += resto;
                        risp += somma.ToString();
                    }
                    else
                    {
                        primaCifra = x / 100;
                        somma = primaCifra;
                        resto = x % 100; // rimangono 2 cifre
                        somma += resto / 10;
                        resto %= 10;    // rimane 1 cifra
                        somma += resto;
                        risp += somma.ToString();
                    }

                    Console.Write(risp);
                    sleep = random.Next(1, 7);
                    Thread.Sleep(sleep);               // ci pensa su!!!
                    break;

                case 7:               // suggerimento se piu alto o piu basso
                case 6:               // per tre volte
                case 5:               // di fila 
                case 3:               // e per il 
                case 2:               // resto dei
                case 1:               // tentativi rimasti

                    if (input < x)
                    {
                        Console.WriteLine("più alto!");
                    }
                    else
                    {
                        Console.WriteLine("più basso!");
                    }

                    break;

                case 4:     // suggerimento prima cifra è
                    Console.WriteLine($"La prima cifra del numero segreto è {primaCifra}");
                    break;

                default:
                    Console.WriteLine("Errore imprevisto!!!");
                    return;
            }

            // richiesta input in caso di errore
            Console.Write("\nInserisci: ");
            input = int.Parse(Console.ReadLine()!);
        }
        Console.WriteLine($"HAI PERSO!\nIl numero era {x}");
    }
}
```
</details>

### 60 - Indovina il numero segreto da 1 a 100 con tentativi e gli aiuti_v4:
<details>
    <summary> codice </summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        // programma che genera un numero tra 1 e 1000 e chiede di indivinare il numero
        // se sbaglio esce, se indovino mi avvisa con un output. Ho a disposizione 
        // 10 tentativi. 
        // Suggerimenti: 
        //               - il numero è (pari o dispari).
        //               - la somma delle cifre è.
        //               - il numero è (piu alto/basso).
        //               - la prima cifra è.

        Random random = new();
        int maxRand = 1000;
        int x = random.Next(1, maxRand);
        int input, tentativi = 10;
        int sleep; // per il Thread.Sleep random
        int primaCifra = x / (maxRand/10); // memorizza la prima cifra
        int somma = 0, resto; // controlli per la somma tra le cifre

        Console.Clear();

        Console.WriteLine("Prova ad indovinare il numero segreto");
        input = int.Parse(Console.ReadLine()!);

        while (tentativi != 1)
        {   
            Console.WriteLine($"numero segreto: {x}");      // #### debug ####
            if (input == x)
            {
                if (tentativi == 10)
                {
                    Console.WriteLine("\nChe fortuna!!!");  // se si indovina alla prima sei fortunato
                }
                else
                {
                    Console.WriteLine($"\nComplimenti hai indovinato con {10-tentativi} tentativi!!!");
                }
                return;

            }
            tentativi--;

            for (int i = 0; i < 3; i++)     // ci pensa su!!!
            {
                Console.Write(". ");
                Thread.Sleep(280);
            }

            Console.WriteLine($"\nMi dispiace, hai ancora {tentativi} tentativi");
            // introduco i suggerimenti


            switch (tentativi)
            {
                case 9:     // suggerimento pari o dispari al primo errore 

                    Console.Write("Suggerimento. Il numero segreto è ");
                    sleep = random.Next(1, 5);
                    Thread.Sleep(sleep*500);               // ci pensa su!!!

                    if (x % 2 == 0)
                    {
                        Console.WriteLine("pari");
                    }
                    else
                    {
                        Console.WriteLine("dispari");
                    }
                    break;

                case 5:     // suggerimento somma delle cifre del numero 

                    resto = x;
                    while (resto > 0)
                    {
                        somma += resto % 10;
                        resto /= 10;
                    }

                    Console.Write($"La somma delle cifre è ");
                    sleep = random.Next(1, 5);
                    Thread.Sleep(sleep*500);               // ci pensa su!!!
                    Console.WriteLine($"{somma}");
                    break;

                case 8:               // suggerimento se piu alto o piu basso
                case 7:               // per tre volte
                case 6:               // di fila 
                case 3:               // e per il 
                case 2:               // resto dei
                case 1:               // tentativi rimasti
                    
                    Console.Write("Suggerimento. Il numero segreto è ");
                    sleep = random.Next(1, 5);
                    Thread.Sleep(sleep*500);               // ci pensa su!!!

                    if (input < x)
                    {
                        Console.WriteLine("più alto!");
                    }
                    else
                    {
                        Console.WriteLine("più basso!");
                    }
                    
                    break;

                case 4:     // suggerimento prima cifra è
                    Console.WriteLine($"La prima cifra del numero segreto è {primaCifra}");
                    break;

                default:
                    Console.WriteLine("Errore imprevisto!!!");
                    return;
            }

            // richiesta input in caso di errore
            Console.Write("\nInserisci: ");
            input = int.Parse(Console.ReadLine()!);
        }
        Console.WriteLine($"HAI PERSO!\nIl numero era {x}");
    }
}
```
</details>

### 61 - Indovina il numero segreto 'THE GAME':
<details>
    <summary> codice </summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        // programma che genera un numero tra 1 e N e chiede di indivinare il numero.
        // Ee sbaglio esce, se indovino mi avvisa con un output. Ho a disposizione 
        // X tentativi. N e X sono chiesti in input al giocatore mendiante selezione e input.
        // Visualizza un punteggio finale. Permette di avviare una
        // nuova partita e di accumulare i punti. Visualizza premio finale.
        // Suggerimenti: 
        // case 9,8,7,4,2,1          - il numero è (piu alto/basso). (bonus - 0.5)
        // case 5 (solo per m e d)   - il numero è (pari o dispari). (bonus - 1)
        // case 6 (solo per d)       - la somma delle cifre è.       (bonus - 2)
        // case 3 (solo per m e d)   - la prima cifra è.             (bonus - 3)

        // Punteggio: 
        //           moltiplicatore = 1.2 se facile, 1.6 se normale, 2.1 se difficile
        //           bonus = (3 facile, 6 normale, 10 difficile) - maxTentativi
        //           punteggio = bonus * moltiplicatore
        //           punteggioTotale += punteggio

        Random random = new();
        string input;
        int mioNumero, tentativi, maxTentativi;
        int somma = 0, resto; // controlli per la somma tra le cifre
        bool continua = true; // controllo per la nuova partita
        bool indovinato; // contrtollo per numero sbagliato
        // per il punteggio e i premi
        double punteggio = 0, punteggioTotale = 0, moltiplicatore, bonus;
        int maxRand; // per il range di numeri random scelto dall'utente
        
        // premi in palio !!!
        Dictionary<int,string> premi = [];
        premi.Add(12,"Coniglietto");
        premi.Add(20,"Gattino");
        premi.Add(30,"Teddy");

        do
        {
            Console.Clear();

            // inserimento dell'input
            Console.WriteLine("Prova ad indovinare il numero segreto");
            Console.WriteLine($"Punteggio attuale: {punteggioTotale} punti");

            Console.WriteLine("\nScegli la difficoltà: ");
            Console.WriteLine("f - facile (numeri da 1 a 10)");       // il punteggio è 1/3 dello standard
            Console.WriteLine("m - medio (numeri da 1 a 100)");       // il punteggio è standard
            Console.WriteLine("d - difficile (numeri da 1 a 1000)\n");  // il punteggio è 1,5 * standard

            input = Console.ReadLine()!;        // selezione opzione

        SelezionaOpzione:   // preparazione variabili del gioco
            switch (input)
            {
                case "f":

                    Console.WriteLine("Scegli il numero di tentativi (max 3).");
                    maxTentativi = int.Parse(Console.ReadLine()!);

                    while (!(maxTentativi <= 3 && maxTentativi > 0))
                    {
                        Console.WriteLine("Puoi fare un massimo di 3 tentativi in modalità facile");
                        Console.WriteLine("Scegli il numero di tentativi ");
                        maxTentativi = int.Parse(Console.ReadLine()!);
                    }
                    maxRand = 10;
                    moltiplicatore = 1.2;
                    bonus = 3;
                    break;

                case "m":

                    Console.WriteLine("Scegli il numero di tentativi (max 6).");
                    maxTentativi = int.Parse(Console.ReadLine()!);

                    while (!(maxTentativi <= 6 && maxTentativi > 0))
                    {
                        Console.WriteLine("Puoi fare un massimo di 6 tentativi in modalità normale");
                        Console.WriteLine("Scegli il numero di tentativi ");
                        maxTentativi = int.Parse(Console.ReadLine()!);
                    }
                    maxRand = 100;
                    moltiplicatore = 1.6;
                    bonus = 6;
                    break;

                case "d":

                    Console.WriteLine("Scegli il numero di tentativi (max 10).");
                    maxTentativi = int.Parse(Console.ReadLine()!);

                    while (!(maxTentativi <= 10 && maxTentativi > 0))
                    {
                        Console.WriteLine("Puoi fare un massimo di 10 tentativi in modalità difficile");
                        Console.WriteLine("Scegli il numero di tentativi ");
                        maxTentativi = int.Parse(Console.ReadLine()!);
                    }
                    maxRand = 1000;
                    moltiplicatore = 2.1;
                    bonus = 10;
                    break;

                default:
                    Console.WriteLine("Selezione errata. Digita il tasto corretto");
                    input = Console.ReadLine()!;

                    goto SelezionaOpzione;
            }

            tentativi = maxTentativi;

            // parte il gioco
            Console.Clear();

            int x = random.Next(1, maxRand);    // genero numero casuale

            Console.WriteLine($"Inizia il gioco. Indovina il numero tra 1 e {maxRand}");
            Console.WriteLine($"Hai {tentativi} tentativi");
            indovinato = false;
            // Console.WriteLine($"numero segreto: {x}");      // #### debug ####

            while (!indovinato && tentativi > 0) // finche non indovino e ho ancora tentativi
            {
                // richiesta del numero in input
                input = Console.ReadLine()!;
                // verifica input utente 
                while (!(int.TryParse(input, out mioNumero)))
                {
                    Console.Write("Digita il numero correttamente: ");
                    input = Console.ReadLine()!;
                }

                if (mioNumero == x)
                {
                    for (int i = 0; i < 3; i++)     // ci pensa su!!!
                    {
                        Console.Write(". ");
                        Thread.Sleep(280);
                    }
                    if (tentativi == maxTentativi)
                    {
                        Console.WriteLine("\nChe fortuna!!!");  // se si indovina alla prima sei fortunato
                        indovinato = true;
                    }
                    else
                    {
                        Console.WriteLine($"\nComplimenti hai indovinato con {maxTentativi - tentativi + 1} tentativi!!!");
                        indovinato = true;
                    }

                    // assegno il punteggio partita in corso arrotondato alle 2 cifre per eccesso
                    punteggio = Math.Round(bonus * moltiplicatore, 2, MidpointRounding.ToEven);
                    Console.WriteLine($"\nHai guadagnato {punteggio} punti.");

                }
                else
                {

                    for (int i = 0; i < 3; i++)     // ci pensa su!!!
                    {
                        Console.Write(". ");
                        Thread.Sleep(280);
                    }

                    tentativi--;

                    // introduco i suggerimenti
                    switch (tentativi)
                    {
                        case 5:     // suggerimento pari o dispari al primo errore 
                            Console.WriteLine($"\nMi dispiace, hai ancora {tentativi} tentativi");
                            Console.Write("Suggerimento. Il numero segreto è ");

                            bonus--;    // aggiorno il bonus

                            if (x % 2 == 0)
                            {
                                Console.WriteLine("pari");
                            }
                            else
                            {
                                Console.WriteLine("dispari");
                            }
                            break;

                        case 6:     // suggerimento somma delle cifre del numero 
                            Console.WriteLine($"\nMi dispiace, hai ancora {tentativi} tentativi");

                            bonus -= 2; // aggiorno il bonus

                            resto = x;
                            while (resto > 0)
                            {
                                somma += resto % 10;
                                resto /= 10;
                            }

                            Console.Write($"La somma delle cifre è ");
                            Console.WriteLine($"{somma}");
                            break;

                        case 3:     // suggerimento prima cifra è
                            Console.WriteLine($"\nMi dispiace, hai ancora {tentativi} tentativi");

                            bonus -= 3; // aggiorno il bonus

                            int primaCifra = x / (maxRand / 10); // memorizza la prima cifra
                            Console.WriteLine($"La prima cifra del numero segreto è {primaCifra}");
                            break;

                        case 0:
                            Console.WriteLine($"\nHAI PERSO!\nIl numero era {x}");
                            punteggio = 0;
                            break;


                        default:
                            Console.WriteLine($"\nMi dispiace, hai ancora {tentativi} tentativi");

                            bonus -= 0.5;   // aggiorno il bonus

                            Console.Write("Suggerimento. Il numero segreto è ");

                            if (mioNumero < x)
                            {
                                Console.WriteLine("più alto!");
                            }
                            else
                            {
                                Console.WriteLine("più basso!");
                            }

                            break;
                    }
                }
            }
            punteggioTotale += punteggio;
            Console.WriteLine($"\nIl tuo punteggio attuale è {punteggioTotale}");
            Console.WriteLine($"\nLista premi: ");
            
            foreach (int valore in premi.Keys)
            {
                Console.WriteLine($"            {valore} - {premi[valore]}");
                
            }

            
            Console.WriteLine("\nVuoi continuare? s/n");
            input = Console.ReadLine()!;

            if (input == "n")
            {
                continua = false;
            }

        }
        while (continua);

        Console.WriteLine($"Hai accumulato {punteggioTotale} punti\n");
   
        Console.WriteLine("Hai vinto il premio seguente...");
        foreach (int valore in premi.Keys)
        {
            if (punteggioTotale < valore)
            {
                continue;
            }
            else
            {
                Console.WriteLine($"\n{premi[valore]}");
                return;
            }
        }

    }
}
```
</details>

### 62 - Gestione errori: verifcare l'input utente numero tra 1 e 10:
<details>
    <summary>codice</summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Inserisci un numero tra 1 e 10");
        int numero = int.Parse(Console.ReadLine()!);
        if (numero < 1 || numero > 10)
        {
            Console.WriteLine("Il numero non è valido");
            return;
        }
        Console.WriteLine($"Il numero inserito è {numero}");
        
    }
}
```
</details>

### 63 - Gestione errori: verifcare l'input utente numero tra 1 e 10 con try-catch di base:
<details>
    <summary>codice</summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Inserisci un numero tra 1 e 10");
        try
        {
            int numero = int.Parse(Console.ReadLine()!);
            if (numero < 1 || numero > 10)
            {
                Console.WriteLine("Il numero non è valido!!!!");
                return; // non va mai nel catch ed esce
            }
            Console.WriteLine($"Il numero inserito è {numero}");
        }
        catch (Exception e)
        {
            Console.WriteLine("Il numero non è valido");
            return;
        }
    }
}
```
</details>

### 64 - Gestione errori: gestire eccezione System.IO.IOException (accesso a file non esistente):
<details>
    <summary>codice</summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        try
        {
            string contenuto = File.ReadAllText("file.txt");    // il file deve essere nella stessa cartella del programma
            Console.WriteLine(contenuto);
        }
        catch (Exception e)
        {
            Console.WriteLine("Il file non esiste");
            return;
        }
    }
}
```
</details>

### 65 - Gestione errori: gestire eccezione System.IndexOutOfRangeException (tento di accedere ad un elemento di un array con indice non valido):
<details>
    <summary>codice</summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        int[] numeri = [1,2,3];
        try
        {
            Console.WriteLine(numeri[3]);
        }
        catch (Exception e)
        {
            Console.WriteLine("Indice array non valido");
            return;
        }
    }
}
```
</details>

### 66 - Gestione errori: gestire System.NullReferenceException (quando si tenta di accedere ad un oggetto null):
<details>
    <summary>codice</summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        string? nome = null;
        try
        {
            Console.WriteLine(nome.Length);
        }
        catch (Exception e)
        {
            Console.WriteLine("Il nome non è valido");
            return;
        }
    }
}
```
</details>

### 67 - Gestione errori: gestire System.OutOfMemoryException (si verifica quando non c'è abbastanza memoria disponibile):
<details>
    <summary>codice</summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        try
        {
            int[] numeri = new int[int.MaxValue]; //int.MaxValue è il max valore per un int (2.147.483.647)
        }
        catch (Exception e)
        {
            Console.WriteLine("Memoria insufficiente");
            return;
        }
    }
}
```
</details>

### 68 - Gestione errori: gestire System.ArgumentException (si verifica quando un argomento di un metodo non è valido):
<details>
    <summary>codice</summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        try
        {
           int numero = int.Parse("ciao"); // genera eccezione
        }
        catch (Exception e)
        {
            Console.WriteLine("Il numero non è valido");
            //Console.WriteLine(e.Message);
            return;
        }
    }
}
```
</details>

### 69 - Gestione errori: gestire eccezione System.IO.IOException con try-catch-finally (accesso a file non esistente):
<details>
    <summary>codice</summary>

```c#
class Program
{
    static void Main(string[] args)
    {
         try
        {
            string contenuto = File.ReadAllText("file.txt");
            Console.WriteLine(contenuto);
        }
        catch (Exception e)
        {
            Console.WriteLine("Il file non esiste");
            return;
        }
        finally
        {
            Console.WriteLine("Il file è chiuso");
        }
    }
}
```
</details>

### 70 - Gestione errori: 55 - Calcolatrice base con interi, chede prima i numeri:
<details>
    <summary>codice</summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        // semplice calcolatrice con quattro operatori e selettore switch
        int x, y, risultato = 0;
        string? input, outputString;

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

        PrimoInput: // ############################## inizio nuovo codice ###################################
            Console.WriteLine("Inserisci il primo numero");

            input = Console.ReadLine()!;

            // ************************************   vecchio codice  ***************************************
            // while (!(int.TryParse(input, out x))) // controllo sul primo numero inserito
            // {
            //     Console.WriteLine("Devi inserire un numero intero");
            //     Console.Write("Inserisci il primo numero: ");
            //     input = Console.ReadLine();
            // }
            // **********************************************************************************************

            // utilizzo gestione errori primo input
            try
            {
                x = int.Parse(input);
            }
            catch (Exception e)
            {
                if (input == "")
                {
                    Console.WriteLine("Attenzione!!! Non hai digitato alcun numero.");
                }
                else if (e.HResult == -2146233066) // ThrowOverflowException
                {
                    Console.WriteLine($"Hai inserito un numero oltre il range per il tipo intero.");
                }
                else if (e.HResult == -2146233033) // ThrowFormatException
                    Console.WriteLine($"Devi inserire un numero intero.");
                goto PrimoInput;
            }

        SecondoInput:
            Console.Write("Inserisci il secondo numero: ");
            input = Console.ReadLine()!;

            // ****************************  versione vecchia  *******************************************
            // while (!(int.TryParse(input, out y))) // controllo sul secondo numero inserito
            // {
            //     Console.WriteLine("Devi inserire un numero intero");
            //     Console.Write("Inserisci il secondo numero: ");
            //     input = Console.ReadLine();
            // }
            // *******************************************************************************************

            // utilizzo gestione errori secondo input
            try
            {
                y = int.Parse(input);
            }
            catch (Exception e)
            {

                if (input == "")
                {
                    Console.WriteLine("Attenzione!!! Non hai digitato alcun numero.");
                }
                else if (e.HResult == -2146233066) // ThrowOverflowException
                {
                    Console.WriteLine($"Hai inserito un numero oltre il range per il tipo intero.");
                }
                else if (e.HResult == -2146233033) // ThrowFormatException
                    Console.WriteLine($"Devi inserire un numero intero.");
                goto SecondoInput;
            }
            // #######################  fine nuovo codice  #################################################

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

                // #############################  inizio nuovo  #########################################

                // ************************************** versione vecchia  ******************************
                // while (y == 0)
                // {
                //     Console.WriteLine("Non puoi dividere per ZERO!");
                //     while (!(int.TryParse(input, out y)) || (int.Parse(input) == 0)) // controllo sul secondo numero inserito
                //     {
                //         Console.WriteLine("Devi inserire un numero intero");
                //         Console.Write("Inserisci il secondo numero: ");
                //         input = Console.ReadLine();
                //     }

                // }
                // risultato = x / y;
                // int resto = x % y;
                // outputString = "La divisione";
                // ************************************************************************************************
                    try
                    {
                        risultato = x / y;
                        int resto = x % y;
                        outputString = "La divisione";
                    }
                    #pragma warning disable
                    catch (Exception e)
                    #pragma warning restore
                    {
                        Console.WriteLine("Attenzione, non puoi eseguire una divisione per zero.");
                        goto SecondoInput;
                    }
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

### 71 - Gestione errori: 61 - Indovina il numero 'THE GAME':
<details>
    <summary> codice </summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        // programma che genera un numero tra 1 e N e chiede di indivinare il numero.
        // Ee sbaglio esce, se indovino mi avvisa con un output. Ho a disposizione 
        // X tentativi. N e X sono chiesti in input al giocatore mendiante selezione e input.
        // Visualizza un punteggio finale. Permette di avviare una
        // nuova partita e di accumulare i punti. Visualizza premio finale.
        // Suggerimenti: 
        // case 9,8,7,4,2,1          - il numero è (piu alto/basso). (bonus - 0.5)
        // case 5 (solo per m e d)   - il numero è (pari o dispari). (bonus - 1)
        // case 6 (solo per d)       - la somma delle cifre è.       (bonus - 2)
        // case 3 (solo per m e d)   - la prima cifra è.             (bonus - 3)

        // Punteggio: 
        //           moltiplicatore = 1.2 se facile, 1.6 se normale, 2.1 se difficile
        //           bonus = (3 facile, 6 medio, 10 difficile) - maxTentativi
        //           moltiplicatore = 1.2 (f), 1.6 (m), 2.1 (d)
        //           punteggio = bonus * moltiplicatore
        //           punteggioTotale += punteggio

        Random random = new();
        string input;
        int mioNumero, tentativi, maxTentativi = 0;
        int somma = 0, resto; // controlli per la somma tra le cifre
        bool continua = true; // controllo per la nuova partita
        bool indovinato; // contrtollo per numero sbagliato
        // per il punteggio e i premi
        double punteggio = 0, punteggioTotale = 0, moltiplicatore, bonus;
        int maxRand; // per il range di numeri random scelto dall'utente

        // premi in palio !!!
        Dictionary<int, string> premi = [];
        premi.Add(12, "Coniglietto");
        premi.Add(20, "Gattino");
        premi.Add(30, "Teddy");

        do
        {
            Console.Clear();

            // inserimento dell'input
            Console.WriteLine("Prova ad indovinare il numero segreto");
            Console.WriteLine($"Punteggio attuale: {punteggioTotale} punti");

            Console.WriteLine("\nScegli la difficoltà: ");
            Console.WriteLine("f - facile (numeri da 1 a 10)");
            Console.WriteLine("m - medio (numeri da 1 a 100)");
            Console.WriteLine("d - difficile (numeri da 1 a 1000)\n");

            input = Console.ReadLine()!;        // selezione opzione

        SelezionaOpzione:   // preparazione variabili del gioco
            switch (input)
            {
                case "f":
                InputF:
                    Console.WriteLine("Scegli il numero di tentativi (max 3).");
                    input = Console.ReadLine()!;

                    try     // gestione errore carattere inserito al posto di un int
                    {
                        maxTentativi = int.Parse(input);
                    }
                    catch
                    {
                        Console.WriteLine("Devi inserire un numero valido.");
                        goto InputF;
                    }

                    while (!(maxTentativi <= 3 && maxTentativi > 0))
                    {
                        Console.WriteLine("Puoi fare un massimo di 3 tentativi in modalità facile");
                        Console.WriteLine("Scegli il numero di tentativi ");
                        maxTentativi = int.Parse(Console.ReadLine()!);
                    }
                    maxRand = 10;
                    moltiplicatore = 1.2;
                    bonus = 3;
                    break;

                case "m":
                InputM:
                    Console.WriteLine("Scegli il numero di tentativi (max 6).");
                    input = Console.ReadLine()!;

                    try     // gestione errore carattere inserito al posto di un int
                    {
                        maxTentativi = int.Parse(input);
                    }
                    catch
                    {
                        Console.WriteLine("Devi inserire un numero valido.");
                        goto InputM;
                    }

                    while (!(maxTentativi <= 6 && maxTentativi > 0))
                    {
                        Console.WriteLine("Puoi fare un massimo di 6 tentativi in modalità normale");
                        Console.WriteLine("Scegli il numero di tentativi ");
                        maxTentativi = int.Parse(Console.ReadLine()!);
                    }
                    maxRand = 100;
                    moltiplicatore = 1.6;
                    bonus = 6;
                    break;

                case "d":
                InputD:
                    Console.WriteLine("Scegli il numero di tentativi (max 10).");
                    input = Console.ReadLine()!;

                    try     // gestione errore carattere inserito al posto di un int
                    {
                        maxTentativi = int.Parse(input);
                    }
                    catch
                    {
                        Console.WriteLine("Devi inserire un numero valido.");
                        goto InputD;
                    }

                    while (!(maxTentativi <= 10 && maxTentativi > 0))
                    {
                        Console.WriteLine("Puoi fare un massimo di 10 tentativi in modalità difficile");
                        Console.WriteLine("Scegli il numero di tentativi ");
                        maxTentativi = int.Parse(Console.ReadLine()!);
                    }
                    maxRand = 1000;
                    moltiplicatore = 2.1;
                    bonus = 10;
                    break;

                default:
                    Console.WriteLine("Selezione errata. Digita il tasto corretto");
                    input = Console.ReadLine()!;

                    goto SelezionaOpzione;
            }

            tentativi = maxTentativi;

            // parte il gioco
            Console.Clear();

            int x = random.Next(1, maxRand);    // genero numero casuale

            Console.WriteLine($"Inizia il gioco. Indovina il numero tra 1 e {maxRand}");
            Console.WriteLine($"Hai {tentativi} tentativi");
            indovinato = false;
            // Console.WriteLine($"numero segreto: {x}");      // #### debug ####

            while (!indovinato && tentativi > 0) // finche non indovino e ho ancora tentativi
            {
                // richiesta del numero in input
                input = Console.ReadLine()!;
                // verifica input utente 
                while (!(int.TryParse(input, out mioNumero)))
                {
                    Console.Write("Digita il numero correttamente: ");
                    input = Console.ReadLine()!;
                }

                if (mioNumero == x)
                {
                    for (int i = 0; i < 3; i++)     // ci pensa su!!!
                    {
                        Console.Write(". ");
                        Thread.Sleep(280);
                    }
                    if (tentativi == maxTentativi)
                    {
                        Console.WriteLine("\nChe fortuna!!!");  // se si indovina alla prima sei fortunato
                        indovinato = true;
                    }
                    else
                    {
                        Console.WriteLine($"\nComplimenti hai indovinato con {maxTentativi - tentativi + 1} tentativi!!!");
                        indovinato = true;
                    }

                    // assegno il punteggio partita in corso arrotondato alle 2 cifre per eccesso
                    punteggio = Math.Round(bonus * moltiplicatore, 2, MidpointRounding.ToEven);
                    Console.WriteLine($"\nHai guadagnato {punteggio} punti.");

                }
                else
                {

                    for (int i = 0; i < 3; i++)     // ci pensa su!!!
                    {
                        Console.Write(". ");
                        Thread.Sleep(280);
                    }

                    tentativi--;

                    // introduco i suggerimenti
                    switch (tentativi)
                    {
                        case 5:     // suggerimento pari o dispari al primo errore 
                            Console.WriteLine($"\nMi dispiace, hai ancora {tentativi} tentativi");
                            Console.Write("Suggerimento. Il numero segreto è ");

                            bonus--;    // aggiorno il bonus

                            if (x % 2 == 0)
                            {
                                Console.WriteLine("pari");
                            }
                            else
                            {
                                Console.WriteLine("dispari");
                            }
                            break;

                        case 6:     // suggerimento somma delle cifre del numero 
                            Console.WriteLine($"\nMi dispiace, hai ancora {tentativi} tentativi");

                            bonus -= 2; // aggiorno il bonus

                            resto = x;
                            while (resto > 0)
                            {
                                somma += resto % 10;
                                resto /= 10;
                            }

                            Console.Write($"La somma delle cifre è ");
                            Console.WriteLine($"{somma}");
                            break;

                        case 3:     // suggerimento prima cifra è
                            Console.WriteLine($"\nMi dispiace, hai ancora {tentativi} tentativi");

                            bonus -= 3; // aggiorno il bonus

                            int primaCifra = x / (maxRand / 10); // memorizza la prima cifra
                            Console.WriteLine($"La prima cifra del numero segreto è {primaCifra}");
                            break;

                        case 0:
                            Console.WriteLine($"\nHAI PERSO!\nIl numero era {x}");
                            punteggio = 0;
                            break;


                        default:
                            Console.WriteLine($"\nMi dispiace, hai ancora {tentativi} tentativi");

                            bonus -= 0.5;   // aggiorno il bonus

                            Console.Write("Suggerimento. Il numero segreto è ");

                            if (mioNumero < x)
                            {
                                Console.WriteLine("più alto!");
                            }
                            else
                            {
                                Console.WriteLine("più basso!");
                            }

                            break;
                    }
                }
            }
            punteggioTotale += punteggio;
            Console.WriteLine($"\nIl tuo punteggio attuale è {punteggioTotale}");
            Console.WriteLine($"\nLista premi: ");

            foreach (int valore in premi.Keys)
            {
                Console.WriteLine($"            {valore} - {premi[valore]}");

            }


            Console.WriteLine("\nVuoi continuare? s/n");
        InputContinua:    
            input = Console.ReadLine()!.ToLower();

            if (input == "n")
            {
                continua = false;
            }
            else if (input == "s")
            {
                continua = true;
            }
            else
            {
                Console.WriteLine("Premi 's' per continuare o 'n' per uscire!!!");
                goto InputContinua;
            }

        }
        while (continua);

        Console.WriteLine($"Hai accumulato {punteggioTotale} punti\n");

        Console.WriteLine("Hai vinto il premio seguente...");
        foreach (int valore in premi.Keys)
        {
            if (punteggioTotale < valore)
            {
                continue;
            }
            else
            {
                Console.WriteLine($"\n{premi[valore]}");
                return;
            }
        }

    }
}
```
</details>

### 72 - BetaTest: 61 - Indovina il numero 'THE GAME' :
<details>
    <summary> codice </summary>

```c#
class Test
{
    static void Main(string[] args)
    {
        // programma che genera un numero tra 1 e N e chiede di indivinare il numero.
        // Ee sbaglio esce, se indovino mi avvisa con un output. Ho a disposizione 
        // X tentativi. N e X sono chiesti in input al giocatore mendiante selezione e input.
        // Visualizza un punteggio finale. Permette di avviare una
        // nuova partita e di accumulare i punti. Visualizza premio finale.
        // Suggerimenti: 
        // case 9,8,7,4,2,1          - il numero è (piu alto/basso). (bonus - 0.5)
        // case 5 (solo per m e d)   - il numero è (pari o dispari). (bonus - 1)
        // case 6 (solo per d)       - la somma delle cifre è.       (bonus - 2)
        // case 3 (solo per m e d)   - la prima cifra è.             (bonus - 3)

        // Punteggio: 
        //           moltiplicatore = 1.2 se facile, 1.6 se normale, 2.1 se difficile
        //           bonus = (3 facile, 6 medio, 10 difficile) - maxTentativi
        //           moltiplicatore = 1.2 (f), 1.6 (m), 2.1 (d)
        //           punteggio = bonus * moltiplicatore
        //           punteggioTotale += punteggio

        Random random = new();
        string input;
        int mioNumero, tentativi, maxTentativi = 0;
        int somma = 0, resto; // controlli per la somma tra le cifre
        bool continua = true; // controllo per la nuova partita
        bool indovinato; // contrtollo per numero sbagliato
        // per il punteggio e i premi
        double punteggio = 0, punteggioTotale = 0, moltiplicatore, bonus;
        int maxRand; // per il range di numeri random scelto dall'utente

        // premi in palio !!!
        Dictionary<int, string> premi = [];
        premi.Add(12, "Coniglietto");
        premi.Add(20, "Gattino");
        premi.Add(30, "Teddy");

        do
        {
            Console.Clear();

            // inserimento dell'input
            Console.WriteLine("Prova ad indovinare il numero segreto");
            Console.WriteLine($"Punteggio attuale: {punteggioTotale} punti");

            Console.WriteLine("\nScegli la difficoltà: ");
            Console.WriteLine("f - facile (numeri da 1 a 10)");
            Console.WriteLine("m - medio (numeri da 1 a 100)");
            Console.WriteLine("d - difficile (numeri da 1 a 1000)\n");

            input = Console.ReadLine()!;        // selezione opzione

        SelezionaOpzione:   // preparazione variabili del gioco
            switch (input)
            {
                case "f":
                InputF:
                    Console.WriteLine("Scegli il numero di tentativi (max 3).");
                    input = Console.ReadLine()!;

                    try     // gestione errore carattere inserito al posto di un int
                    {
                        maxTentativi = int.Parse(input);
                    }
                    catch
                    {
                        Console.WriteLine("Devi inserire un numero valido.");
                        goto InputF;
                    }

                    while (!(maxTentativi <= 3 && maxTentativi > 0))
                    {
                        Console.WriteLine("Puoi fare un massimo di 3 tentativi in modalità facile");
                        goto InputF;
                    }
                    maxRand = 10;
                    moltiplicatore = 1.2;
                    bonus = 3;
                    break;

                case "m":
                InputM:
                    Console.WriteLine("Scegli il numero di tentativi (max 6).");
                    input = Console.ReadLine()!;

                    try     // gestione errore carattere inserito al posto di un int
                    {
                        maxTentativi = int.Parse(input);
                    }
                    catch
                    {
                        Console.WriteLine("Devi inserire un numero valido.");
                        goto InputM;
                    }

                    while (!(maxTentativi <= 6 && maxTentativi > 0))
                    {
                        Console.WriteLine("Puoi fare un massimo di 6 tentativi in modalità normale");
                        goto InputM;
                    }
                    maxRand = 100;
                    moltiplicatore = 1.6;
                    bonus = 6;
                    break;

                case "d":
                InputD:
                    Console.WriteLine("Scegli il numero di tentativi (max 10).");
                    input = Console.ReadLine()!;

                    try     // gestione errore carattere inserito al posto di un int
                    {
                        maxTentativi = int.Parse(input);
                    }
                    catch
                    {
                        Console.WriteLine("Devi inserire un numero valido.");
                        goto InputD;
                    }

                    while (!(maxTentativi <= 10 && maxTentativi > 0))
                    {
                        Console.WriteLine("Puoi fare un massimo di 10 tentativi in modalità difficile");
                        goto InputD;
                    }
                    maxRand = 1000;
                    moltiplicatore = 2.1;
                    bonus = 10;
                    break;

                default:
                    Console.WriteLine("Selezione errata. Digita il tasto corretto");
                    input = Console.ReadLine()!;

                    goto SelezionaOpzione;
            }

            tentativi = maxTentativi;

            // parte il gioco
            Console.Clear();

            int x = random.Next(1, maxRand);    // genero numero casuale

            Console.WriteLine($"Inizia il gioco. Indovina il numero tra 1 e {maxRand}");
            Console.WriteLine($"Hai {tentativi} tentativi");
            indovinato = false;
            // Console.WriteLine($"numero segreto: {x}");      // #### debug ####

            while (!indovinato && tentativi > 0) // finche non indovino e ho ancora tentativi
            {
                // richiesta del numero in input
                input = Console.ReadLine()!;
                // verifica input utente 
            DigitaNumero:
                while (!(int.TryParse(input, out mioNumero)))
                {
                    Console.Write("Digita il numero correttamente: ");
                    input = Console.ReadLine()!;
                }
                if (mioNumero > maxRand || mioNumero <= 0)
                {
                    Console.Write($"Inserisci un numero tra 1 e {maxRand}: ");
                    input = Console.ReadLine()!;
                    goto DigitaNumero;
                }

                if (mioNumero == x)
                {
                    for (int i = 0; i < 3; i++)     // ci pensa su!!!
                    {
                        Console.Write(". ");
                        Thread.Sleep(280);
                    }
                    if (tentativi == maxTentativi)
                    {
                        Console.WriteLine("\nChe fortuna!!!");  // se si indovina alla prima sei fortunato
                        indovinato = true;
                    }
                    else
                    {
                        Console.WriteLine($"\nComplimenti hai indovinato con {maxTentativi - tentativi + 1} tentativi!!!");
                        indovinato = true;
                    }

                    // assegno il punteggio partita in corso arrotondato alle 2 cifre per eccesso
                    punteggio = Math.Round(bonus * moltiplicatore, 2, MidpointRounding.ToEven);
                    Console.WriteLine($"\nHai guadagnato {punteggio} punti.");

                }
                else
                {

                    for (int i = 0; i < 3; i++)     // ci pensa su!!!
                    {
                        Console.Write(". ");
                        Thread.Sleep(280);
                    }

                    tentativi--;

                    // introduco i suggerimenti
                    switch (tentativi)
                    {
                        case 5:     // suggerimento pari o dispari al primo errore 
                            Console.WriteLine($"\nMi dispiace, hai ancora {tentativi} tentativi");
                            Console.Write("Suggerimento. Il numero segreto è ");

                            bonus--;    // aggiorno il bonus

                            if (x % 2 == 0)
                            {
                                Console.WriteLine("pari");
                            }
                            else
                            {
                                Console.WriteLine("dispari");
                            }
                            break;

                        case 6:     // suggerimento somma delle cifre del numero 
                            Console.WriteLine($"\nMi dispiace, hai ancora {tentativi} tentativi");

                            bonus -= 2; // aggiorno il bonus

                            resto = x;
                            while (resto > 0)
                            {
                                somma += resto % 10;
                                resto /= 10;
                            }

                            Console.Write($"La somma delle cifre è ");
                            Console.WriteLine($"{somma}");
                            break;

                        case 3:     // suggerimento prima cifra è
                            Console.WriteLine($"\nMi dispiace, hai ancora {tentativi} tentativi");

                            bonus -= 3; // aggiorno il bonus

                            int primaCifra = x / (maxRand / 10); // memorizza la prima cifra
                            Console.WriteLine($"La prima cifra del numero segreto è {primaCifra}");
                            break;

                        case 0:
                            Console.WriteLine($"\nHAI PERSO!\nIl numero era {x}");
                            punteggio = 0;
                            break;


                        default:
                            Console.WriteLine($"\nMi dispiace, hai ancora {tentativi} tentativi");

                            bonus -= 0.5;   // aggiorno il bonus

                            Console.Write("Suggerimento. Il numero segreto è ");

                            if (mioNumero < x)
                            {
                                Console.WriteLine("più alto!");
                            }
                            else
                            {
                                Console.WriteLine("più basso!");
                            }

                            break;
                    }
                }
            }
            punteggioTotale += punteggio;
            Console.WriteLine($"\nIl tuo punteggio attuale è {punteggioTotale}");
            Console.WriteLine($"\nLista premi: ");

            foreach (int valore in premi.Keys)
            {
                Console.WriteLine($"            {valore} - {premi[valore]}");

            }


            Console.WriteLine("\nVuoi continuare? s/n");
        InputContinua:
            input = Console.ReadLine()!.ToLower();

            if (input == "n")
            {
                continua = false;
            }
            else if (input == "s")
            {
                continua = true;
            }
            else
            {
                Console.WriteLine("Premi 's' per continuare o 'n' per uscire!!!");
                goto InputContinua;
            }

        }
        while (continua);

        Console.WriteLine($"Hai accumulato {punteggioTotale} punti\n");

        Console.WriteLine("Hai vinto il premio seguente...");
        foreach (int valore in premi.Keys)
        {
            if (punteggioTotale < valore)
            {
                continue;
            }
            else
            {
                Console.WriteLine($"\n{premi[valore]}");
                return;
            }
        }

    }
}
```
</details>

### 73 - File: legge un file.txt e stampa a video il suo contenuto riga per riga:
<details>
    <summary> codice </summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        // percorso del file con @
        string path = @"test.txt"; //  il file deve essere nella stessa cartella del programma
        string[] lines = File.ReadAllLines(path);
        foreach (string line in lines)
        {
            Console.WriteLine(line); // stampa la riga
        }
    }
}
```
</details>

### 74 - File: legge un file.txt ed effettua la copia in un altro array:
<details>
    <summary> codice </summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        // percorso del file con @
        string path = @"test.txt"; //  il file deve essere nella stessa cartella del programma
        string[] lines = File.ReadAllLines(path);
        string[] righe = new string[lines.Length];
                
        for (int i = 0; i < righe.Length; i++)
        {
            righe[i] = lines[i];
        }

        foreach (string riga in righe)
        {
            Console.WriteLine(riga);
        }
    }
}
```
oppure utilizzando il metodo 'Array.Copy()':

```c#
class Program
{
    static void Main(string[] args)
    {
       // percorso del file con @
        string path = @"test.txt"; //  il file deve essere nella stessa cartella del programma
        string[] lines = File.ReadAllLines(path);
        string[] righe = new string[lines.Length];
        
        Array.Copy(lines, righe, lines.Length);

        foreach (string riga in righe)
        {
            Console.WriteLine(riga);
        }
    }
}

```
</details>

### 75 - File: legge un file.txt e stampare a schermo solo i nomi che iniziano per 'a':
<details>
    <summary> codice </summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        // percorso del file con @
        string path = @"test.txt"; //  il file deve essere nella stessa cartella del programma
        string[] lines = File.ReadAllLines(path);

        foreach (string line in lines)
        {
            if (line.StartsWith("a"))
            {
                Console.WriteLine(line);
            }
                
        }
    }
}
```
</details>

### 76 - File: legge un file.txt e stampare a schermo solo i nomi che iniziano per 'a' anche se non ci sono:
<details>
    <summary> codice </summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        // percorso del file con @
        string path = @"test.txt"; //  il file deve essere nella stessa cartella del programma
        string[] lines = File.ReadAllLines(path);
        bool trovato = false;

        foreach (string line in lines)
        {
            if (line.StartsWith("a"))
            {
                Console.WriteLine(line);
                trovato = true;
            }    
        }
        if (!trovato)
        {
            Console.WriteLine("Nessun nome trovato");
        }
    }
}
```
</details>

### 77 - File: legge un file.txt e stampare a schermo solo i nomi che iniziano per 'a' con (Lambda):
<details>
    <summary> codice </summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        // percorso del file con @
        string path = @"test.txt"; //  il file deve essere nella stessa cartella del programma
        string[] lines = File.ReadAllLines(path);

        foreach (string line in lines)
        {
            if (line.StartsWith("a"))
            {
                Console.WriteLine(line);
            }
        }
        if (!lines.Any(line => line.StartsWith("a"))) // funzione lambda
        {
            Console.WriteLine("Nessun nome trovato");
        }
    }
}
```
</details>

### 78 - File: legge un file.txt e copia su un altro file.txt le parole che iniziano per 'a' con (Lambda):
<details>
    <summary> codice </summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        // percorso del file con @
        string path = @"test.txt"; //  il file deve essere nella stessa cartella del programma
        string[] lines = File.ReadAllLines(path);
        string[] nomi = new string[lines.Length];
                
        for (int i = 0; i < lines.Length; i++)
        {
            nomi[i] = lines[i];
        }

        string path2 = @"prova.txt";    // il file deve essere nella stessa cartella del programma
        File.Create(path2).Close();
        foreach (string nome in nomi)
        {
            if (nome.StartsWith("a"))
            {
                File.AppendAllText(path2, nome + "\n");
            }
        }

        if (!nomi.Any(nome => nome.StartsWith("a")))
        {
            File.AppendAllText(path2, "Nessun nome trovato");
        }
    }
}
```
</details>

### 79 - File: legge un file.txt e sorteggia un nome random:
<details>
    <summary> codice </summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        // percorso del file con @
        string path = @"test.txt"; //  il file deve essere nella stessa cartella del programma
        string[] nomi = File.ReadAllLines(path);

        Random random = new Random();

        int index = random.Next(nomi.Length);
        Console.WriteLine(nomi[index]);
        
    }
}
```
</details>

### 80 - File: legge un file.txt e sorteggia un nome random e lo salva in un altro file:
<details>
    <summary> codice </summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        // percorso del file con @
        string path = @"test.txt"; //  il file deve essere nella stessa cartella del programma
        string[] nomi = File.ReadAllLines(path);

        Random random = new Random();
        int index = random.Next(nomi.Length);
        Console.WriteLine(nomi[index]);
        // creazione secondo file
        string path2 = @"prova.txt";
        File.Create(path2).Close();
        File.AppendAllText(path2, nomi[index] + "\n");
    }
}
```
</details>
