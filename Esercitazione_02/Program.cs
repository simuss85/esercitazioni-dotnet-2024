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
        int x = random.Next(1, 1000);
        int input, tentativi = 10;
        int sleep; // per il Thread.Sleep random
        int primaCifra = 0, somma, resto;

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
                    Console.WriteLine("\nComplimenti hai indovinato!!!");
                }
                return;

            }
            tentativi--;

            for (int i = 0; i < 3; i++)     // ci pensa su!!!
            {
                Console.Write(". ");
                Thread.Sleep(200);
            }

            Console.WriteLine($"\nMi dispiace, hai ancora {tentativi} tentativi");
            // introduco i suggerimenti


            switch (tentativi)
            {
                case 9:     // suggerimento pari o dispari al primo errore 

                    Console.Write("Suggerimento. Il numero segreto è ");
                    sleep = random.Next(1, 7);
                    Thread.Sleep(sleep);               // ci pensa su!!!

                    if (x % 2 == 0)
                    {
                        Console.WriteLine("pari");
                    }
                    else
                    {
                        Console.WriteLine("dispari");
                    }
                    break;

                case 8:     // suggerimento somma delle cifre del numero 
                    somma = x;
                    resto = 0;
                    string risp = "La somma delle cifre è ";

                    if (x < 10)
                    {   
                        risp += x.ToString();
                    }
                    else if (x < 100)
                    {
                        primaCifra = x / 10;
                        somma = primaCifra;
                        resto = x % 10; // rimane 1 cifra
                        somma += resto;
                        risp += somma.ToString();
                    }
                    else
                    {
                        primaCifra = x / 100;
                        somma = primaCifra;
                        resto = x % 100; // rimangono 2 cifre
                        somma += resto / 10;
                        resto %= 10;    // rimane 1 cifra
                        somma += resto;
                        risp += somma.ToString();
                    }

                    Console.Write(risp);
                    sleep = random.Next(1, 7);
                    Thread.Sleep(sleep);               // ci pensa su!!!
                    break;

                case 7:               // suggerimento se piu alto o piu basso
                case 6:               // per tre volte
                case 5:               // di fila 
                case 3:               // e per il 
                case 2:               // resto dei
                case 1:               // tentativi rimasti

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