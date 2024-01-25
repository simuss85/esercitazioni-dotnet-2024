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