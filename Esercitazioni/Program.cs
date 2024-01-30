class Program
{
    static void Main(string[] args)
    {
        string path = @"./test.csv";
        string[] lines = File.ReadAllLines(path);
        string[][] nomi = new string[lines.Length][];
        
        //salvo ogni riga della matrice in un array in modo da poterlo manipolare in seguito
        for (int i = 0; i < lines.Length; i++)
        {
            nomi[i] = lines[i].Split(","); // inserisco in ogni riga gli elementi 
        }
        
        //stampa con il doppio ciclo righe colonne
        foreach (string[] nome in nomi)
        {
            string path2 = $"./{nome[0]}.csv";
            File.Create(path2).Close();
            for (int i = 1; i < nome.Length; i++)
            {
                File.AppendAllText(path2,$"{nome[i]}\n");
            }
        }
        File.Delete("nome.csv");
    }
}