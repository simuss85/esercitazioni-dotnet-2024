class Program
{
    static void Main(string[] args)
    {
        Dado d1 = new();
        Dado d2 = new();

        int n1 = d1.Lancia();
        int n2 = d2.Lancia();

        Console.WriteLine($"Dado 1: {n1}");
        Console.WriteLine($"Dado 2: {n2}");
    }
}