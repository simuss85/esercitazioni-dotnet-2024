class Program
{
    static void Main(string[] args)
    {
        // programma che genera un numero tra 1 e 1000 e chiede di indivinare il numero
        // se sbaglio esce, se indovino mi avvisa con un output. Ho a disposizione 
        // 10 tentativi. 
        // Suggerimenti: 
        //               - il numero è (pari o dispari).
        //               - la somma delle cifre è.
        //               - il numero è (piu alto/basso).
        //               - la prima cifra è.

        Random random = new();
        int maxRand = 1000;
        int x = random.Next(1, maxRand);
        int input, tentativi = 10;
        int sleep; // per il Thread.Sleep random
        int primaCifra = x / (maxRand/10); // memorizza la prima cifra
        int somma = 0, resto; // controlli per la somma tra le cifre

        Console.Clear();

        Console.WriteLine("Prova ad indovinare il numero segreto");
        input = int.Parse(Console.ReadLine()!);

        while (tentativi != 1)
        {   
            Console.WriteLine($"numero segreto: {x}");      // #### debug ####
            if (input == x)
            {
                if (tentativi == 10)
                {
                    Console.WriteLine("\nChe fortuna!!!");  // se si indovina alla prima sei fortunato
                }
                else
                {
                    Console.WriteLine($"\nComplimenti hai indovinato con {10-tentativi} tentativi!!!");
                }
                return;

            }
            tentativi--;

            for (int i = 0; i < 3; i++)     // ci pensa su!!!
            {
                Console.Write(". ");
                Thread.Sleep(280);
            }

            Console.WriteLine($"\nMi dispiace, hai ancora {tentativi} tentativi");
            // introduco i suggerimenti


            switch (tentativi)
            {
                case 9:     // suggerimento pari o dispari al primo errore 

                    Console.Write("Suggerimento. Il numero segreto è ");
                    sleep = random.Next(1, 5);
                    Thread.Sleep(sleep*500);               // ci pensa su!!!

                    if (x % 2 == 0)
                    {
                        Console.WriteLine("pari");
                    }
                    else
                    {
                        Console.WriteLine("dispari");
                    }
                    break;

                case 5:     // suggerimento somma delle cifre del numero 

                    resto = x;
                    while (resto > 0)
                    {
                        somma += resto % 10;
                        resto /= 10;
                    }

                    Console.Write($"La somma delle cifre è ");
                    sleep = random.Next(1, 5);
                    Thread.Sleep(sleep*500);               // ci pensa su!!!
                    Console.WriteLine($"{somma}");
                    break;

                case 8:               // suggerimento se piu alto o piu basso
                case 7:               // per tre volte
                case 6:               // di fila 
                case 3:               // e per il 
                case 2:               // resto dei
                case 1:               // tentativi rimasti
                    
                    Console.Write("Suggerimento. Il numero segreto è ");
                    sleep = random.Next(1, 5);
                    Thread.Sleep(sleep*500);               // ci pensa su!!!

                    if (input < x)
                    {
                        Console.WriteLine("più alto!");
                    }
                    else
                    {
                        Console.WriteLine("più basso!");
                    }
                    
                    break;

                case 4:     // suggerimento prima cifra è
                    Console.WriteLine($"La prima cifra del numero segreto è {primaCifra}");
                    break;

                default:
                    Console.WriteLine("Errore imprevisto!!!");
                    return;
            }

            // richiesta input in caso di errore
            Console.Write("\nInserisci: ");
            input = int.Parse(Console.ReadLine()!);
        }
        Console.WriteLine($"HAI PERSO!\nIl numero era {x}");
    }
}