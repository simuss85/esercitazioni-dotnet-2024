class ClasseStampa
{
    static void Stampa(List<int> listString)
    {
        Console.WriteLine("Funzione stampa lista di stringhe:");

        for (int i = 0; i < listString.Count; i++)
        {
            Console.Write(listString[i] + ", ");
        }

        Console.WriteLine("\n"); //  ritorno a capo


    }

    static void Stampa(string[] arrayString)
    {
        Console.WriteLine("Funzione stampa array di stringhe:");
        foreach (string elemento in arrayString)
        {
            Console.Write(elemento + ", ");
        }
    }
}