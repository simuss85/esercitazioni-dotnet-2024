class Program
{
    static void Main(string[] args)
    {
        int timeoutInSeconds = 5;
        Console.WriteLine($"Inserisci input entro {timeoutInSeconds} secondi:");

        bool inputReceived = false;
        string? input = "";

        DateTime endTime = DateTime.Now.AddSeconds(timeoutInSeconds);

        while (DateTime.Now < endTime)
        {
            if (Console.KeyAvailable)
            {
                input = Console.ReadLine();
                inputReceived = true;
                break;
            }
            // Thread.Sleep(400);
            // System.Console.WriteLine($"{DateTime.Now}");
        }

        if (inputReceived)
        {
            Console.WriteLine($"Hai inserito: {input}");
            
        }
        else
        {
            System.Console.WriteLine("Tempo scaduto!");
        }
        

    }
}