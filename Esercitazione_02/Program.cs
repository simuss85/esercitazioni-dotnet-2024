class Program
{
    static void Main(string[] args)
    {
        // programma che genera un numero tra 1 e 100 e chiede di indivinare il numero
        // se sbaglio esce, se indovino mi avvisa con un output. Ho a disposizione 
        // 10 tentativi

        Random random = new();
        int x = random.Next(1,5);
        int input, tentativi = 10;

        Console.Clear();
        
        Console.WriteLine("Prova ad indovinare il numero segreto");
        input = int.Parse(Console.ReadLine()!);

        while(tentativi != 1)
        {
            if (input == x)
            {
                Console.WriteLine("Che fortuna!!!");
                return;
            }
            tentativi--;
            Console.WriteLine($"Mi dispiace, hai ancora {tentativi} tentativi");
            input = int.Parse(Console.ReadLine()!);
        }

        Console.WriteLine($"HAI PERSO!\nIl numero era {x}");
        
    }
}