
class Program
{
    // questo programma genera 10 numeri casuali e ne calcola la somma
    static void Main(string[] args)
    {
        Random random = new Random();           // Generatore di numeri casuali
        int somma = 0;
        for (int i = 0; i < 10; i++)
        {
            int numero = random.Next(1,10);     // Genera un numero casuale tra 1 e 10 si dice che l'intervallo è [1,11)
            somma += numero;
            Console.WriteLine($"Il numero casuale è {numero}"); // interpolazione di stringhe
        }
        Console.WriteLine($"La somma è {somma}");    
    }

}