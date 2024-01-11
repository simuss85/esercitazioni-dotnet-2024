class Program
{

    static void Main(string[] args)
    {
        // esempio di array join
        string[] nomi = new string[] {"Alice", "Bob", "Charlie"};

        // unisce tutti gli elementi dell'array nomi in una singola stringa, separati da virgola e spazio
        string nomiConcatenati = String.Join(", ", nomi);

        System.Console.WriteLine($"Ciao {nomiConcatenati}");   
        
    }

    static void stampa(List<string> listString)
    {   
        System.Console.WriteLine("Funzione stampa lista di stringhe:");

        for(int i = 0; i < listString.Count; i++)
        {
            System.Console.Write(listString[i] + ", ");
        }

        System.Console.WriteLine("\n"); //  ritorno a capo


    }

    static void stampa(string[] arrayString)
    {
        System.Console.WriteLine("Funzione stampa arrai di stringhe:");
        foreach(string elemento in arrayString)
        {
            System.Console.Write(elemento + ", ");
        }
    }
}