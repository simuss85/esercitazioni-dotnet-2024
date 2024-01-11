class Program
{
    static void Main(string[] args)
    {   
        // utilizziamo il diamond invece di parentesi quadre
        List<int> numeri = new List<int>();
        numeri.Add(10); // aggiungo elemento con metodo add
        numeri.Add(20);
        numeri.Add(30);

        System.Console.WriteLine($"Ciao {numeri[0]}, {numeri[1]} e {numeri[2]}");
    }
}