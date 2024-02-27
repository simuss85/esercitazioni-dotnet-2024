class Program
{
    static void Main(string[] args)
    {
        Player p1 = new();
        Player p2 = new();
        string path = @"save.csv";
        string[] file = File.ReadAllLines(path);
        Console.WriteLine("file csv letto...premi");
        Console.ReadKey();

        int count = 0;
        foreach (string riga in file)
        {
            if (count == 0)
            {
                p1.Carica(riga.Split(","));
                Console.WriteLine("scrittura p1...premi");
                Console.ReadKey();

            }
            else
            {
                p2.Carica(riga.Split(","));
                Console.WriteLine("scrittura p2...premi");
                Console.ReadKey();
            }
            count++;

        }

        Console.WriteLine("Stampa del giocatore 1...premi");
        Console.ReadKey();

        p1.Stampa();
        Console.WriteLine("Stampa del giocatore 2...premi");
        Console.ReadKey();

        p2.Stampa();


    }
}