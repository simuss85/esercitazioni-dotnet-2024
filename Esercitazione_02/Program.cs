class Program
{
    static void Main(string[] args)
    {
        int a = 10;
        int b = 20;
        if (a > b) // la condizione da verificare si scrive tra parentesi
        {
            System.Console.WriteLine($"{a} e' maggiore di {b}");
        }
        else
        {
            System.Console.WriteLine($"{a} e' minore di {b}");
        }
        
    }
}