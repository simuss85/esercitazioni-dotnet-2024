class Test
{
    static void Main(string[] args)
    {
        try
        {
           StackOverflow();
        }
        catch (StackOverflowException e)
        {
            Console.WriteLine($"{e.InnerException}");
            throw new StackOverflowException("MIO MESSAGGIO");
        }
    }

    static void StackOverflow()
    {
        StackOverflow();
    }

    public void Errore()
    {

    }
}