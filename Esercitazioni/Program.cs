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