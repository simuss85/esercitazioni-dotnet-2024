class Program
{
    static void Main(string[] args)
    {
        int a = 10;
        // int b = 20;
        switch (a)
        {
            case 10:
                System.Console.WriteLine($"{a} e' uguale a 10");
                break;
            case 20:
                System.Console.WriteLine($"{a} e' uguale a 20");
                break;
            default:
                System.Console.WriteLine($"{a} non e' uguale a 10 o 20");
                break;
        }

    }
}