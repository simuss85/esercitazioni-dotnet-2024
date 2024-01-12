class Program
{
    static void Main(string[] args)
    {
        List<string> nomi = new List<string>();
        nomi.Add("Mario");
        nomi.Add("Luigi");
        nomi.Add("Giovanni");

        foreach (string nome in nomi)
        {
            System.Console.WriteLine($"Ciao {nome}");
        }
     
    }
}