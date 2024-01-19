class Program
{
    static void Main(string[] args)
    {
        // programma che genera un numero tra 1 e 100 e chiede di indivinare il numero
        // se sbaglio esce, se indovino mi avvisa con un output. Ho a disposizione 
        // 10 tentativi. Invia suggerimenti per indovinare il numero (piu alto/basso).

        Random random = new();
        int x = random.Next(1, 100);
        int input, tentativi = 10;

        Console.Clear();

        Console.WriteLine("Prova ad indovinare il numero segreto");
        input = int.Parse(Console.ReadLine()!);

        while (tentativi != 1)
        {
            if (input == x)
            {
                if (tentativi == 10)
                {
                    Console.WriteLine("\nChe fortuna!!!");  // se si indovina alla prima sei fortunato
                }
                else
                {
                    Console.WriteLine("\nComplimenti hai indovinato!!!");
                }
                return;

            }
            tentativi--;
            Console.WriteLine($"\nMi dispiace, hai ancora {tentativi} tentativi");

            // introduco i suggerimenti
            Console.Write("Suggerimento. Il numero segreto è ");
            if (input < x)
            {
                Console.WriteLine("più alto!");
            }
            else
            {
                Console.WriteLine("più basso!");
            }
            Console.Write("\nInserisci: ");
            input = int.Parse(Console.ReadLine()!);
        }

        Console.WriteLine($"HAI PERSO!\nIl numero era {x}");
    }
}