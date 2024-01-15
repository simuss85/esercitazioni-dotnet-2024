class Program
{
    static void Main(string[] args)
    {
       Console.WriteLine("Premi 'Ctrl' + 'N' per temrinare...");

       // ciclo loop
       while (true)
       {
            // aspetta finche non viene premuto un tasto
            ConsoleKeyInfo keyInfo = Console.ReadKey(true); // ???

            // verifica se il tasto 'Ctrl' è tenuto premuto
            if ((keyInfo.Modifiers & ConsoleModifiers.Control) != 0)
            {
                // controlla se il tasto premuto è N
                if (keyInfo.Key == ConsoleKey.N)
                {
                    Console.WriteLine("Combinazione 'Ctrl' + 'N' rilevata...");
                    break;
                }
            }  
       }
    }
}