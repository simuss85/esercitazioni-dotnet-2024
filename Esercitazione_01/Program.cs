using System.Globalization;

class Program
{
    // programma per le prove 
    static void Main(string[] args)
    {

        double a = double.Parse(Console.ReadLine()!.Replace(".",","));
        double b = double.Parse(Console.ReadLine()!.Replace(".",","));

        double r = a / b;

        // r = Math.Sqrt(r);

        // Console.WriteLine(String.Format(CultureInfo.InvariantCulture,"{0:0.00}", r));
        Console.WriteLine(r.ToString("0.0000"));
        Console.WriteLine($"{r}");

        Math.
        



    }
}
