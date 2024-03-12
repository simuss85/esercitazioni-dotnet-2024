using FoodexpMvc.Views;

namespace FoodexpMvc.Controllers;
public class ValidaInput
{
    // public static string GetPassword()
    // {

    // }

    /// <summary>
    /// Verifica il corretto inserimento di input di tipo string non null o numerico.
    /// </summary>
    /// <param name="left">Parametro left del cursore prima del messaggio di errore</param>
    /// <param name="top">Parametro top del cursore prima del messaggio di errore</param>
    /// <returns></returns>
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

    /// <summary>
    /// Verifica il corretto inserimento di input di tipo data gg/mm/aaaa.
    /// </summary>
    /// <param name="left">Parametro left del cursore prima del messaggio di errore</param>
    /// <param name="top">Parametro top del cursore prima del messaggio di errore</param>
    /// <returns></returns>
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

    /// <summary>
    /// Verifica il corretto inserimento di input di tipo int per la quantita maggiore di zero.
    /// </summary>
    /// <param name="left">Parametro left del cursore prima del messaggio di errore</param>
    /// <param name="top">Parametro top del cursore prima del messaggio di errore</param>
    /// <returns></returns>
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

    /// <summary>
    /// Verifica il corretto inserimento di input di tipo int riferito a un elenco numerato.<br/>
    /// Valore intero maggiore di zero fino al maxElementi dell'elenco.<br/>
    /// NOTA! Se l'utente inserisce il carattere 'r' viene restituito -1.
    /// 
    /// </summary>
    /// <param name="totaleElenco">Il numero di elementi che compongono la selezione.</param>
    /// <param name="left">Parametro left del cursore prima del messaggio di errore</param>
    /// <param name="top">Parametro top del cursore prima del messaggio di errore</param>
    /// <param name="opzioneR">Opzione che permette anche la gestione dell'inserimento di 'r'</param>
    /// <returns>Un intero maggiore di zero e minore di totaleElenco; -1 se viene inserito 'r'</returns>
    public static int GetIntElenco(int totaleElenco, int left, int top, bool opzioneR = false)
    {
        string errore = "Devi inserire una quantita valida\r";
        int x = 0;
        string input = Console.ReadLine()!;

        if (opzioneR && input == "r")
        {
            x = -1;
        }
        else
        {
            //se non inserisco in numero oppure se supero il range dei numeri in elenco
            while (!int.TryParse(input, out x) || x < 0 || x > totaleElenco)
            {
                Console.Write(errore);
                View.PulisciRiga(errore.Length, left, top);
                input = Console.ReadLine()!;
            }
        }

        return x;
    }

    /// <summary>
    /// Verifica il corretto insrimento di input di tipo (s/n).
    /// </summary>
    /// <param name="left">Parametro left del cursore prima del messaggio di errore</param>
    /// <param name="top">Parametro top del cursore prima del messaggio di errore</param>
    /// <returns></returns>
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