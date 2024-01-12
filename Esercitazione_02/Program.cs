class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, int> eta = new ()
        {
            {"Mario", 25},
            {"Luigi", 30},
            {"Giovanni", 35}
        };

        foreach (string nome in eta.Keys)
        {
            System.Console.WriteLine($"Ciao {nome} hai {eta[$"{nome}"]} anni");
        }

    }
}