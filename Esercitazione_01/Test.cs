class Test
{
    static void Main(string[] args)
    {
        try
        {
            F();
        }
        catch (Exception e)
        {
            Console.WriteLine("Errore!");
            e = new Exception("ERRORE");
            throw;
        }
    }

    static void F()
    {
        try
        {
            G();
        }
        catch (Exception e)
        {
            Console.WriteLine("PROVA G");
        }




    }

    static void G()
    {

        try
        {
            F();
        }
        catch (Exception e)
        {
            throw new Exception("PROVA G");
        }




    }
}