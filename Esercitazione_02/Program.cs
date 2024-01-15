class Program
{
    static void Main(string[] args)
    {   
        Console.Clear();
        System.Console.WriteLine("Inserisci un comando speciale ('cmd:info', 'cmd:exit')");

        while (true)
        {

            string? input = Console.ReadLine();

            if (input.StartsWith("cmd:"))
            {
                string comando = input.Substring(4);

                switch (comando)
                {
                    case "info":
                        System.Console.WriteLine("Comando 'info' riconosciuto. Ecco le informazioni...");
                        break;

                    case "exit":
                        System.Console.WriteLine("Comando 'exit' riconosciuto. Uscita in corso...");
                        return;
                    
                    default:
                        System.Console.WriteLine($"Comando '{comando}' non riconosciuto.");
                        break;
                }
            }
            else
            {
                System.Console.WriteLine("Input non valido. Inserisci un comando valido");
            }

            System.Console.WriteLine("\nInserisci un altro comando");
            
        }
    }
}