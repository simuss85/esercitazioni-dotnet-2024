
class Program
{
    // questo programma genera un numero casuale per sorteggiare un array:
    static void Main(string[] args)
    {
        string[] nomi = ["Mario", "Luigi", "Giovanni"];
        Random random = new Random();
        int i = 0;
        while (i < 10)
        {
            int indice = random.Next(0, nomi.Length);
            Console.WriteLine($"Il nome sorteggiato è {nomi[indice]}");
            i++;
        }

    }

}