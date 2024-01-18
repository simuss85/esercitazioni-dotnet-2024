
class Program
{
    // programma per le prove 
    static void Main(string[] args)
    {

        double a = double.Parse(Console.ReadLine()!.Replace(".",","));
        double b = double.Parse(Console.ReadLine()!.Replace(".",","));

        double r = a / b;

        Console.WriteLine($"{r}");
        // Console.WriteLine($"{CultureInfo.GetCultures()}");




    }
}
