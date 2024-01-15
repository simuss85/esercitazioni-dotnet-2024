class Program
{
    static void Main(string[] args)
    {
        System.Console.WriteLine("Trascina un file qui e premi invio:");
        string? filePath = Console.ReadLine().Trim('"'); // rimuove le virgolette

        try
        {
            string contenuto = File.ReadAllText(filePath);
            System.Console.WriteLine("Contenuto del file: ");
            System.Console.WriteLine(contenuto);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Si è verificato un errore: {ex.Message}");
            
        }
        
    }
}