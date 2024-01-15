class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        System.Console.WriteLine("Seleziona l'opzione:");
        System.Console.WriteLine("1 - Nascondi il cursore");
        System.Console.WriteLine("2 - Mostra il cursore");
        System.Console.WriteLine("3 - Pulisci console");
        System.Console.WriteLine("4 - Emetti beep");
        System.Console.WriteLine("5 - Emetti beep prolungato");
        System.Console.WriteLine("6 - Imposta il titolo");
        System.Console.WriteLine("e - exit\n");

        while (true)
        {
            System.Console.WriteLine("Digita...");
            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.CursorVisible = false;
                    break;

                case "2":
                    Console.CursorVisible = true;
                    break;

                case "3":
                    Console.Clear();
                    break;

                case "4":
                    Console.Beep();
                    break;

                case "5":
                    System.Console.WriteLine("Inserisci la frequenza");
                    int freq = Int32.Parse(Console.ReadLine());

                    System.Console.WriteLine("Inserisci durata in ms");
                    int ms = Int32.Parse(Console.ReadLine());

                    Console.Beep(freq, ms);
                    break;

                case "6":
                    Console.Title = "La mia app";
                    break;

                case "e":
                    return;

                default:
                    System.Console.WriteLine("Opzione errata:");
                    break;

            }

        }

    }
}