class Program
{
    static void Main(string[] args)
    {
        System.Console.WriteLine("Inserisci il tuo nome");
        string? nome = Console.ReadLine();

        while (true)
        {
            Console.Clear();
            System.Console.WriteLine("Selezione un opzione:");
            System.Console.WriteLine("1 - saluto");
            System.Console.WriteLine("e - exit");

            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    System.Console.WriteLine($"Ciao {nome}");
                    break;

                case "e":
                    return;

                default:
                    System.Console.WriteLine($"Opzione {input} non valida. Riprova");
                    break;
            }

            System.Console.WriteLine("Premi un tasto per continuare...");
            Console.ReadKey();
            
        }

    }
}

