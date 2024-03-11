using FoodexpMvc.Views;

namespace FoodexpMvc.Controllers;
public class ValidaInput
{
    // public static string GetPassword()
    // {

    // }

    public static string GetString(int left, int top)
    {
        string errore = "Devi inserire un nome valido\r";
        string input = Console.ReadLine()!;
        while (input == "" || int.TryParse(input, out int x))
        {
            Console.Write(errore);
            View.PulisciRiga(errore.Length, left, top);
            input = Console.ReadLine()!;
        }
        return input;
    }

    public static DateTime GetData(int left, int top)
    {
        bool corretto = false;
        string input;
        string erroreScaduto = "alimento gia scaduto\r";
        string erroreFormato = "formato data errato\r";
        string[] data = new string[3];
        DateTime oggettoData = new();
        var annoInCorso = DateTime.Today.Year;    //memorizzo l' anno in corso
        var meseInCorso = DateTime.Today.Month;
        var oggi = DateTime.Today.Day;

        while (!corretto)
        {
            input = Console.ReadLine()!;

            try
            {
                data = input.Split("/");
                //converto in valore numerico per facilitare i controlli
                int anno = int.Parse(data[2]);
                int mese = int.Parse(data[1]);
                int giorno = int.Parse(data[0]);
                // Console.WriteLine("anno: " + anno); //DEBUG
                // Console.WriteLine("mese: " + mese); //DEBUG
                // Console.WriteLine("giorno: " + giorno); //DEBUG
                // Console.ReadKey();                      //DEBUG


                if (anno < annoInCorso) //anno precedente quindi scaduto
                {
                    if (anno < 2000)
                    {
                        throw new Exception();
                    }

                    Console.Write(erroreScaduto);
                    View.PulisciRiga(erroreScaduto.Length, left, top);
                    continue;
                }
                else if (anno >= annoInCorso)      //anno attuale verifico mese e giorno
                {
                    if (mese > 13 || mese < 1)  //mese errato
                    {
                        throw new Exception();
                    }
                    if (giorno > 31 || giorno < 1)  //giorno errato
                    {
                        throw new Exception();
                    }

                    if (anno == annoInCorso && mese < meseInCorso) //anno in  corso ma scaduto
                    {
                        Console.Write(erroreScaduto);
                        View.PulisciRiga(erroreScaduto.Length, left, top);
                        continue;
                    }
                    else if (anno == annoInCorso && mese == meseInCorso)   //anno in corso e mese in corso
                    {
                        if (giorno < oggi)  //scaduto
                        {
                            Console.Write(erroreScaduto);
                            View.PulisciRiga(erroreScaduto.Length, left, top);
                            continue;
                        }
                    }
                }

                //inserisco i valori per la data
                oggettoData = new DateTime(anno, mese, giorno);


            }
            catch (Exception)
            {
                Console.Write(erroreFormato);
                View.PulisciRiga(erroreScaduto.Length, left, top);
                continue;
            }
            corretto = true;
        }
        return oggettoData;
    }

    public static int GetQuantita(int left, int top)
    {
        string errore = "Devi inserire una quantita valida\r";
        int x = 0;
        while (!int.TryParse(Console.ReadLine()!, out x) || x <= 0)
        {
            Console.Write(errore);
            View.PulisciRiga(errore.Length, left, top);
        }
        return x;
    }

    public static int GetIntElenco(int totaleElenco, int left, int top)
    {
        string errore = "Devi inserire una quantita valida\r";
        int x = 0;
        //se non inserisco in numero oppure se supero il range dei numeri in elenco
        while (!int.TryParse(Console.ReadLine()!, out x) || x <= 0 || x > totaleElenco)
        {
            Console.Write(errore);
            View.PulisciRiga(errore.Length, left, top);
        }
        return x;
    }

    public static string GetSiNo(int left, int top)
    {
        string errore = "Selezione errata\r";
        string input = "";
        bool corretto = false;
        while (!corretto)
        {
            input = Console.ReadLine()!.ToLower();
            if (input == "s" || input == "n")
            {
                corretto = true;
            }
            else
            {
                Console.Write(errore);
                View.PulisciRiga(errore.Length, left, top);
            }
        }
        return input;
    }
}