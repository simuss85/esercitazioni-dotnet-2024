class Program
{
    static void Main(string[] args)
    {
        Stampa("Ciao");
    }
    static void Stampa(string messaggio, int volte = 5)
    {
        for (int i = 0; i < volte; i++)
        {
            Console.WriteLine(messaggio);
        }
    }
}