using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        // programma che genera un numero tra 1 e N e chiede di indivinare il numero.
        // Ee sbaglio esce, se indovino mi avvisa con un output. Ho a disposizione 
        // X tentativi. N e X sono chiesti in input al giocatore mendiante selezione e input.
        // Visualizza un punteggio finale. Permette di avviare una
        // nuova partita e di accumulare i punti. Visualizza premio finale.
        // Suggerimenti: 
        //               - il numero è (pari o dispari).
        //               - la somma delle cifre è.
        //               - il numero è (piu alto/basso).
        //               - la prima cifra è.

        Random random = new();
        string input;
        int mioNumero, tentativi, maxTentativi;
        int somma = 0, resto; // controlli per la somma tra le cifre
        bool continua = true; // controllo per la nuova partita
        bool indovinato = false; // contrtollo per numero sbagliato
        // per il punteggio e i premi
        double punteggio, punteggioTotale = 0, moltiplicatore;
        int bonus;
        int maxRand; // per il range di numeri random scelto dall'utente
        string[] premiF, premiM, premiD;


        do
        {
            Console.Clear();

            // inserimento dell'input
            Console.WriteLine("Prova ad indovinare il numero segreto");
            Thread.Sleep(300);
            Console.WriteLine("\nScegli la difficoltà: ");
            Console.WriteLine("f - facile (numeri da 1 a 10)");       // il punteggio è 1/3 dello standard
            Console.WriteLine("m - medio (numeri da 1 a 100)");       // il punteggio è standard
            Console.WriteLine("d - difficile (numeri da 1 a 1000)\n");  // il punteggio è 1,5 * standard

            input = Console.ReadLine()!;        // selezione opzione

        SelezionaOpzione:   // preparazione variabili del gioco
            switch (input)
            {
                case "f":

                    Console.WriteLine("Scegli il numero di tentativi (max 3).");
                    maxTentativi = int.Parse(Console.ReadLine()!);

                    while (!(maxTentativi < 4 && maxTentativi > 0))
                    {
                        Console.WriteLine("Puoi fare un massimo di 3 tentativi in modalità facile");
                        Console.WriteLine("Scegli il numero di tentativi ");
                        maxTentativi = int.Parse(Console.ReadLine()!);
                    }
                    maxRand = 10;
                    moltiplicatore = 0.3;
                    bonus = 3;
                    break;

                case "m":

                    Console.WriteLine("Scegli il numero di tentativi (max 6).");
                    maxTentativi = int.Parse(Console.ReadLine()!);

                    while (!(maxTentativi <= 6 && maxTentativi > 0))
                    {
                        Console.WriteLine("Puoi fare un massimo di 6 tentativi in modalità normale");
                        Console.WriteLine("Scegli il numero di tentativi ");
                        maxTentativi = int.Parse(Console.ReadLine()!);
                    }
                    maxRand = 100;
                    moltiplicatore = 1;
                    bonus = 6;
                    break;

                case "d":

                    Console.WriteLine("Scegli il numero di tentativi (max 10).");
                    maxTentativi = int.Parse(Console.ReadLine()!);

                    while (!(maxTentativi <= 10 && maxTentativi > 0))
                    {
                        Console.WriteLine("Puoi fare un massimo di 10 tentativi in modalità difficile");
                        Console.WriteLine("Scegli il numero di tentativi ");
                        maxTentativi = int.Parse(Console.ReadLine()!);
                    }
                    maxRand = 1000;
                    moltiplicatore = 1.5;
                    bonus = 10;
                    break;

                default:
                    Console.WriteLine("Selezione errata. Digita il tasto corretto");
                    input = Console.ReadLine()!;

                    goto SelezionaOpzione;
            }

            int x = random.Next(1, maxRand);
            tentativi = maxTentativi;

            // parte il gioco con gli aiuti
            Console.Clear();

            Console.WriteLine($"Inizia il gioco. Indovina il numero tra 1 e {maxRand}");
            input = Console.ReadLine()!;

            // verifica del numero inserito
            while (!(int.TryParse(input, out mioNumero)))
            {
                Console.Write("Digita il numero correttamente: ");
                input = Console.ReadLine()!;
            }

            while (!indovinato && tentativi != 1) //evito di farne uno in piu
            {
                Console.WriteLine($"numero segreto: {x}");      // #### debug ####
                if (mioNumero == x)
                {
                    if (tentativi == maxTentativi)
                    {
                        Console.WriteLine("\nChe fortuna!!!");  // se si indovina alla prima sei fortunato
                        punteggioTotale += bonus;
                        indovinato = true;
                    }
                    else
                    {
                        Console.WriteLine($"\nComplimenti hai indovinato con {tentativi} tentativi!!!");
                        punteggioTotale = moltiplicatore * tentativi;
                        indovinato = true;
                    }
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
                    case 10:     // suggerimento pari o dispari al primo errore 

                        Console.Write("Suggerimento. Il numero segreto è ");

                        if (x % 2 == 0)
                        {
                            Console.WriteLine("pari");
                        }
                        else
                        {
                            Console.WriteLine("dispari");
                        }
                        break;

                    case 6:     // suggerimento somma delle cifre del numero 

                        resto = x;
                        while (resto > 0)
                        {
                            somma += resto % 10;
                            resto /= 10;
                        }

                        Console.Write($"La somma delle cifre è ");
                        Console.WriteLine($"{somma}");
                        break;

                    case 4:     // suggerimento prima cifra è
                        int primaCifra = x / (maxRand / 10); // memorizza la prima cifra
                        Console.WriteLine($"La prima cifra del numero segreto è {primaCifra}");
                        break;

                    default:
                        Console.Write("Suggerimento. Il numero segreto è ");

                        if (mioNumero < x)
                        {
                            Console.WriteLine("più alto!");
                        }
                        else
                        {
                            Console.WriteLine("più basso!");
                        }

                        break;
                }

                input = Console.ReadLine()!;

                // verifica del numero inserito
                while (!(int.TryParse(input, out mioNumero)))
                {
                    Console.Write("Digita il numero correttamente: ");
                    input = Console.ReadLine()!;
                }
            }

            Console.WriteLine($"HAI PERSO!\nIl numero era {x}");
            Console.WriteLine($"\nIl tuo punteggio attuale è {punteggioTotale}");
            Console.WriteLine("\nVuoi continuare? s/n");
            input = Console.ReadLine()!;

            if (input == "n")
            {
                continua = false;
            }

        }
        while (continua);

        Console.WriteLine($"Hai accumulato {punteggioTotale} punti\n");
        Console.WriteLine("Hai vinto il premio seguente...");

    }
}