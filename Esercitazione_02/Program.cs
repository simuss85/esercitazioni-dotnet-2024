class Program
{
    // Gin & Fizz...v2
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Benvenuti a Fizz & Buzz!");

        List<int> fizzList = new();
        List<int> buzzList = new();
        List<int> fizzNbuzzList = new();

        do
        {
            Console.Clear();
            Console.WriteLine("Seleziona il metodo da usare:");
            Console.WriteLine("f - metodo for");
            Console.WriteLine("r - metodo Random");
            Console.WriteLine("v - visualizza liste");
            Console.WriteLine("e - exit");
            string? input = Console.ReadLine();

            Console.Clear();

            switch (input)
            {
                case "f":
                    Console.Write("Inserisci il valore massimo: ");
                    int max = Int32.Parse(Console.ReadLine() ?? string.Empty);

                    Console.Clear();

                    for (int i = 1; i < max; i++)
                    {
                        // Console.Write($"{i} ");        //### debug ###

                        if ((i % 3 == 0) && (i % 5 == 0)) // divisibile per 3 e 5
                        {
                            Console.Write($"{i} - ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Fizz & Buzz");
                            Console.ResetColor();

                            if (!(fizzNbuzzList.Contains(i)))
                            {
                                fizzNbuzzList.Add(i);
                            }
                            // fizzNbuzzList.Add(i);

                        }
                        else if (i % 3 == 0) // divisibile per 3
                        {
                            Console.Write($"{i} - ");
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine("Fizz");
                            Console.ResetColor();

                            if (!(fizzList.Contains(i)))
                            {
                                fizzList.Add(i);
                            }
                            // fizzList.Add(i);

                        }
                        else if (i % 5 == 0) // divisibile per 5
                        {
                            Console.Write($"{i} - ");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Buzz");
                            Console.ResetColor();

                            if (!(buzzList.Contains(i)))
                            {
                                buzzList.Add(i);
                            }
                            // buzzList.Add(i);
                        }
                        else                // non divisibile
                        {
                            Console.WriteLine($"{i}");
                        }
                        Thread.Sleep(100);

                    }
                    Console.WriteLine("Premi per continuare...");
                    Console.ReadKey();
                    break;

                case "r":
                    Console.Write("Inserici il numero di prove da verificare: ");
                    int prove = Int32.Parse(Console.ReadLine() ?? string.Empty);

                    Console.Clear();

                    Random random = new();
                    int count = 0;

                    while (count < prove)
                    {
                        int numero = random.Next(1, 1000);

                        if ((numero % 3 == 0) && (numero % 5 == 0)) // divisibile per 3 e 5
                        {
                            Console.Write($"{numero} - ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Fizz & Buzz");
                            Console.ResetColor();

                            if (!(fizzNbuzzList.Contains(numero)))
                            {
                                fizzNbuzzList.Add(numero);
                            }
                        }
                        else if (numero % 3 == 0) // divisibile per 3
                        {
                            Console.Write($"{numero} - ");
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine("Fizz");
                            Console.ResetColor();

                            if (!(fizzList.Contains(numero)))
                            {
                                fizzList.Add(numero);
                            }

                        }
                        else if (numero % 5 == 0) // divisibile per 5
                        {
                            Console.Write($"{numero} - ");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Buzz");
                            Console.ResetColor();

                            if (!(buzzList.Contains(numero)))
                            {
                                buzzList.Add(numero);
                            }

                        }
                        else                      // non divisibile
                        {
                            Console.WriteLine($"{numero}");  
                        }
                        Thread.Sleep(100);
                        count++;
                    }
                    break;

                case "v":
                    Console.WriteLine("Visualizzo le liste salvate");
                    // fizzNbuzz
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Fizz & Buzz:");
                    Console.ResetColor();
                    Console.Write(" [");
                    fizzList.Sort();

                    if (fizzNbuzzList.Count == 0)   // verifica lista vuota
                    {
                        Console.WriteLine("vuota]");
                    }

                    for (int i = 0; i < fizzNbuzzList.Count; i++)
                    {
                        if (i == fizzNbuzzList.Count - 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write($"{fizzNbuzzList[i]}");
                            Console.ResetColor();
                            Console.WriteLine("]");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write($"{fizzNbuzzList[i]}");
                            Console.ResetColor();
                            Console.Write(", ");

                        }
                    }
                    
                    // fizz 
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("Fizz:");
                    Console.ResetColor();
                    Console.Write(" [");
                    fizzList.Sort();

                    if (fizzList.Count == 0)   // verifica lista vuota
                    {
                        Console.WriteLine("vuota]");
                    }

                    for (int i = 0; i < fizzList.Count; i++)
                    {
                        if (i == fizzList.Count - 1)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write($"{fizzList[i]}");
                            Console.ResetColor();
                            Console.WriteLine("]");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write($"{fizzList[i]}");
                            Console.ResetColor();
                            Console.Write(", ");

                        }
                    }
                    
                    // buzz
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Buzz:");
                    Console.ResetColor();
                    Console.Write(" [");
                    buzzList.Sort();

                    if (buzzList.Count == 0)   // verifica lista vuota
                    {
                        Console.WriteLine("vuota]");
                    }
                    for (int i = 0; i < buzzList.Count; i++)
                    {
                        if (i == buzzList.Count - 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write($"{buzzList[i]}");
                            Console.ResetColor();
                            Console.WriteLine("]");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write($"{buzzList[i]}");
                            Console.ResetColor();
                            Console.Write(", ");

                        }
                    }

                    Console.WriteLine("Premi un tasto per continuare...");
                    Console.ReadKey();

                    break;

                case "e":
                    Console.WriteLine("Uscita...");
                    Thread.Sleep(300);
                    return;

                default:
                    Console.WriteLine("Selezione errata!");
                    break;
            }
        } while (true);
    }
}