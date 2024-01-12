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

### 27 - Dichiarare un dizionario di sttinghe:

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