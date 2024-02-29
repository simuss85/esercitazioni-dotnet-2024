
using System.Runtime.CompilerServices;

public class Game
{
    public void Gioca()
    {
        GestisciTxt.CreaTxt();
        VerificaInput vi = new();
        string nome;
        string input;
        int maxTentativi = 0;

        //input nome utente
        do
        {
            Console.Clear();

            Console.WriteLine("Inserisci il tuo nome");
            nome = Console.ReadLine()!;
            vi.MaxNome(nome);
        }
        while (!vi.Valido);

        Player p = new(nome);

        //verifica del file txt, ricerca giocatore se presente lo carica
        GestisciTxt.InizializzaTxt(p);

        SalutaGiocatore(p);
        Console.Clear();

        //input di selezione difficolta
        do
        {
            MenuDifficoltà();
            input = Console.ReadLine()!;
            vi.Stringa(input);

            switch (input)
            {
                case "f":   //facile - max 3 tentativi
                    //do
                    {
                        Console.WriteLine("Scegli il numero di tentativi (max 3).");
                        input = Console.ReadLine()!;
                        vi.Numero(input);
                    }


                    if (vi.Valido)
                    {
                        maxTentativi = int.Parse(input);
                        while (!(maxTentativi <= 3 && maxTentativi > 0))
                        {
                            Console.WriteLine("Puoi fare un massimo di 3 tentativi in modalità facile");
                        }
                    }

                    break;

                case "m":   //medio - max 6 tentativi
                    Console.WriteLine("Scegli il numero di tentativi (max 6).");
                    input = Console.ReadLine()!;
                    break;

                case "d":   //difficile - max 10 tentativi
                    Console.WriteLine("Scegli il numero di tentativi (max 10).");
                    input = Console.ReadLine()!;
                    break;

                default:
                    Console.WriteLine("Selezione errata. Digita il tasto corretto");
                    vi.Valido = false;
                    break;
            }

        }
        while (!vi.Valido);


    }

    /// <summary>
    /// Menu iniziale di selezione difficoltà
    /// </summary>
    private void MenuDifficoltà()
    {
        Console.WriteLine("\nScegli la difficoltà: ");
        Console.WriteLine("f - facile (numeri da 1 a 10)");
        Console.WriteLine("m - medio (numeri da 1 a 100)");
        Console.WriteLine("d - difficile (numeri da 1 a 1000)\n");
    }

    /// <summary>
    /// Messaggio di saluto variabile per il giocatore attuale. <br/>
    /// - nuovo giocatore: "Benvenuto nome-giocatore" <br/>
    /// - vecchio giocatore: "Bentornato nome-giocatore"
    /// </summary>
    /// <param name="p">Oggetto Player giocatore attuale</param>
    private void SalutaGiocatore(Player p)
    {
        Console.WriteLine($"{p.Saluto} {p.Nome}");
        Thread.Sleep(1000);
        Console.WriteLine("Prova ad indovinare il numero segreto");
        Thread.Sleep(700);
        Console.WriteLine($"Punteggio attuale: {p.Punteggio} punti");
        Thread.Sleep(700);
        Console.WriteLine("premi un tasto...");
        Console.ReadKey();
    }


    //avvia il gioco

    //menu selezione difficolta

    //selezione difficilta

    //menu selezione aiuti

    //selezione aiuti

    //avvio turno

    //inserimento numero giocatore

    //controllo numero

    //verifica vincita

    //continui o esci

    //risultato e premio
}