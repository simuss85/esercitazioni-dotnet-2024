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

    // static void stampa(string[] arrayString)
    // {
    //     System.Console.WriteLine("Funzione stampa arrai di stringhe:");
    //     foreach(string elemento in arrayString)
    //     {
    //         System.Console.Write(elemento + ", ");
    //     }
    // }
}