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