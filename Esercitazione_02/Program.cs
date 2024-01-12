class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, int> nomi = new Dictionary<string, int>()
        {
            {"Mario", 25},
            {"Luigi", 30},
            {"Giovanni", 35}
        };
        System.Console.WriteLine($"Le vostre età sono {nomi["Mario"]} {nomi["Luigi"]} e {nomi["Giovanni"]}");

    }
}