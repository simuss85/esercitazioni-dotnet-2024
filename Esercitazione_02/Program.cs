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
        // case 9,8,7,4,2,1          - il numero è (piu alto/basso). (bonus - 0.5)
        // case 5 (solo per m e d)   - il numero è (pari o dispari). (bonus - 1)
        // case 6 (solo per d)       - la somma delle cifre è.       (bonus - 2)
        // case 3 (solo per m e d)   - la prima cifra è.             (bonus - 3)

        // Punteggio: 
        //           moltiplicatore = 1.2 se facile, 1.6 se normale, 2.1 se difficile
        //           bonus = (3 facile, 6 normale, 10 difficile) - maxTentativi
        //           punteggio = bonus * moltiplicatore
        //           punteggioTotale += punteggio

        Random random = new();
        string input;
        int mioNumero, tentativi, maxTentativi;
        int somma = 0, resto; // controlli per la somma tra le cifre
        bool continua = true; // controllo per la nuova partita
        bool indovinato; // contrtollo per numero sbagliato
        // per il punteggio e i premi
        double punteggio = 0, punteggioTotale = 0, moltiplicatore, bonus;
        int maxRand; // per il range di numeri random scelto dall'utente
        
        // premi in palio !!!
        Dictionary<int,string> premi = [];
        premi.Add(12,"Coniglietto");
        premi.Add(20,"Gattino");
        premi.Add(30,"Teddy");

        do
        {
            Console.Clear();

            // inserimento dell'input
            Console.WriteLine("Prova ad indovinare il numero segreto");
            Console.WriteLine($"Punteggio attuale: {punteggioTotale} punti");

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

                    while (!(maxTentativi <= 3 && maxTentativi > 0))
                    {
                        Console.WriteLine("Puoi fare un massimo di 3 tentativi in modalità facile");
                        Console.WriteLine("Scegli il numero di tentativi ");
                        maxTentativi = int.Parse(Console.ReadLine()!);
                    }
                    maxRand = 10;
                    moltiplicatore = 1.2;
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
                    moltiplicatore = 1.6;
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
                    moltiplicatore = 2.1;
                    bonus = 10;
                    break;

                default:
                    Console.WriteLine("Selezione errata. Digita il tasto corretto");
                    input = Console.ReadLine()!;

                    goto SelezionaOpzione;
            }

            tentativi = maxTentativi;

            // parte il gioco
            Console.Clear();

            int x = random.Next(1, maxRand);    // genero numero casuale

            Console.WriteLine($"Inizia il gioco. Indovina il numero tra 1 e {maxRand}");
            Console.WriteLine($"Hai {tentativi} tentativi");
            indovinato = false;
            // Console.WriteLine($"numero segreto: {x}");      // #### debug ####

            while (!indovinato && tentativi > 0) // finche non indovino e ho ancora tentativi
            {
                // richiesta del numero in input
                input = Console.ReadLine()!;
                // verifica input utente 
                while (!(int.TryParse(input, out mioNumero)))
                {
                    Console.Write("Digita il numero correttamente: ");
                    input = Console.ReadLine()!;
                }

                if (mioNumero == x)
                {
                    for (int i = 0; i < 3; i++)     // ci pensa su!!!
                    {
                        Console.Write(". ");
                        Thread.Sleep(280);
                    }
                    if (tentativi == maxTentativi)
                    {
                        Console.WriteLine("\nChe fortuna!!!");  // se si indovina alla prima sei fortunato
                        indovinato = true;
                    }
                    else
                    {
                        Console.WriteLine($"\nComplimenti hai indovinato con {maxTentativi - tentativi + 1} tentativi!!!");
                        indovinato = true;
                    }

                    // assegno il punteggio partita in corso arrotondato alle 2 cifre per eccesso
                    punteggio = Math.Round(bonus * moltiplicatore, 2, MidpointRounding.ToEven);
                    Console.WriteLine($"\nHai guadagnato {punteggio} punti.");

                }
                else
                {

                    for (int i = 0; i < 3; i++)     // ci pensa su!!!
                    {
                        Console.Write(". ");
                        Thread.Sleep(280);
                    }

                    tentativi--;

                    // introduco i suggerimenti
                    switch (tentativi)
                    {
                        case 5:     // suggerimento pari o dispari al primo errore 
                            Console.WriteLine($"\nMi dispiace, hai ancora {tentativi} tentativi");
                            Console.Write("Suggerimento. Il numero segreto è ");

                            bonus--;    // aggiorno il bonus

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
                            Console.WriteLine($"\nMi dispiace, hai ancora {tentativi} tentativi");

                            bonus -= 2; // aggiorno il bonus

                            resto = x;
                            while (resto > 0)
                            {
                                somma += resto % 10;
                                resto /= 10;
                            }

                            Console.Write($"La somma delle cifre è ");
                            Console.WriteLine($"{somma}");
                            break;

                        case 3:     // suggerimento prima cifra è
                            Console.WriteLine($"\nMi dispiace, hai ancora {tentativi} tentativi");

                            bonus -= 3; // aggiorno il bonus

                            int primaCifra = x / (maxRand / 10); // memorizza la prima cifra
                            Console.WriteLine($"La prima cifra del numero segreto è {primaCifra}");
                            break;

                        case 0:
                            Console.WriteLine($"\nHAI PERSO!\nIl numero era {x}");
                            punteggio = 0;
                            break;


                        default:
                            Console.WriteLine($"\nMi dispiace, hai ancora {tentativi} tentativi");

                            bonus -= 0.5;   // aggiorno il bonus

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
                }
            }
            punteggioTotale += punteggio;
            Console.WriteLine($"\nIl tuo punteggio attuale è {punteggioTotale}");
            Console.WriteLine($"\nLista premi: ");
            
            foreach (int valore in premi.Keys)
            {
                Console.WriteLine($"            {valore} - {premi[valore]}");
                
            }

            
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
        foreach (int valore in premi.Keys)
        {
            if (punteggioTotale < valore)
            {
                continue;
            }
            else
            {
                Console.WriteLine($"\n{premi[valore]}");
                return;
            }
        }

    }
}