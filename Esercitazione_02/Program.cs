class Program
{
    static void Main(string[] args)
    {
       System.Console.WriteLine("Premi 'N' per temrinare...");

       // ciclo loop
       while (true)
       {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.N)
            {
                break; // esce dal ciclo se viene premuto N
            }  
       }
    }
}