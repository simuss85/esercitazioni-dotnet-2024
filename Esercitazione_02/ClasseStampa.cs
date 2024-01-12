class ClasseStampa
{
    static void stampa(List<int> listString)
    {
        System.Console.WriteLine("Funzione stampa lista di stringhe:");

        for (int i = 0; i < listString.Count; i++)
        {
            System.Console.Write(listString[i] + ", ");
        }

        System.Console.WriteLine("\n"); //  ritorno a capo


    }

    static void stampa(string[] arrayString)
    {
        System.Console.WriteLine("Funzione stampa arrai di stringhe:");
        foreach (string elemento in arrayString)
        {
            System.Console.Write(elemento + ", ");
        }
    }
}