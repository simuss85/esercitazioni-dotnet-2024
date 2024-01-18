class Program
{
    static void Main(string[] args)
    {
        // programma che genera un numero tra 1 e 100 e chiede di indivinare il numero
        // se sbaglio esce, se indovino mi avvisa con un output

        Random random = new();
        int x = random.Next(1,100);
        int input;

        Console.WriteLine("Prova ad indovinare il numero segreto");
        input = int.Parse(Console.ReadLine()!);

        if (input == x)
        {
            Console.WriteLine("Che fortuna!!!");
        }
        else
        {
            Console.WriteLine($"Mi dispiace, il numero segreto era {x}");
        }
    }
}