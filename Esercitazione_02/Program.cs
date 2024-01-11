class Program
{
    static void Main(string[] args)
    {
        int[] numeri = new int[3];
        numeri[0] = 10;
        numeri[1] = 20;
        numeri[2] = 20;
        numeri[3] = "30"; // elemento non di tipo numerico
        // array che non c'e'
        System.Console.WriteLine($"I numeri sono {numeri[0]}, {numeri[1]} e {numeri[3]}");
        System.Console.WriteLine($"I numeri sono {numeri[0]}, {numeri[1]} e {numeri[2]}");
    }
}