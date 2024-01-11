class Program
{
    static void Main(string[] args)
    {   
        // INPUT 
        int[] numeri = [1, 2, 3, 4, 5];

        string[] nomi = new string[] {"Mario", "Luigi", "Luca"};

        List<int> listaNumeri = new List<int> {1, 2, 3, 4, 5};

        List<string> listaNomi = new List<string> {"Mario", "Luigi", "Luca"};

        Stack<int> pilaNumeri = new Stack<int>(numeri);

        Queue<string> codaNomi = new Queue<string>(nomi);



        // OUTPUT 
        // stampa array di numeri con foreach
        System.Console.WriteLine($"Prova stampa array numeri:");

        foreach (int numero in numeri)
        {
            System.Console.Write(numero + ", ");
        }
        
        System.Console.WriteLine("\n"); //  ritorno a capo


        // stampa array di nomi con foreach
        System.Console.WriteLine($"Prova stampa array nomi:");

        foreach (string nome in nomi)
        {
            System.Console.Write(nome + ", ");
        }
        
        System.Console.WriteLine("\n"); //  ritorno a capo
        
        // stampa lista di numeri con for
        System.Console.WriteLine($"Prova stampa lista numeri:");

        for (int i = 0; i < listaNumeri.Count; i++)
        {
            System.Console.Write(listaNumeri[i] + ", ");
        }
        
        System.Console.WriteLine("\n"); //  ritorno a capo

        // aggiungo un nome nuovo alla lista
        listaNomi.Add("Veronica");

        stampa(listaNomi);
        stampa(nomi);

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