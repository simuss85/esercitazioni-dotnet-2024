class Program
{
    static void Main(string[] args)
    {
        try
        {
           int numero = int.Parse("ciao"); // genera eccezione
        }
        catch (Exception e)
        {
            Console.WriteLine("Il numero non è valido");
            //Console.WriteLine(e.Message);
            return;
        }
    }
}