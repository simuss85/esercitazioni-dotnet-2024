public class Aiuti
{
    /// <summary>
    /// Suggerisce se il numero segreto è pari o dispari
    /// </summary>
    /// <param name="x">Il numero segreto random</param>
    /// <returns>Il valore da sottrarre al bonus</returns>
    public static int PariDispari(int x)
    {
        Console.Write("Suggerimento. Il numero segreto è ");

        if (x % 2 == 0)
        {
            Console.WriteLine("pari");
        }
        else
        {
            Console.WriteLine("dispari");
        }
        return 1;  //valore da sottrarre al bonus
    }

    /// <summary>
    /// Suggerisce la somma delle cifre del numero segreto
    /// </summary>
    /// <param name="x">Il numero segreto random</param>
    /// <returns>Il valore da sottrarre al bonus</returns>
    public static int SommaCifre(int x)
    {
        int somma = 0;
        int resto = x;

        while (resto > 0)
        {
            somma += resto % 10;
            resto /= 10;
        }

        Console.Write($"La somma delle cifre è ");
        Console.WriteLine($"{somma}");
        return 2;
    }

    /// <summary>
    /// Succerisce la prima cifra del numero segreto
    /// </summary>
    /// <param name="x">Il numero segreto random</param>
    /// <param name="maxRand">Il range per il calcolo del numero segreto scelto dall'utente</param>
    /// <returns>Il valore da sottrarre al bonus</returns>
    public static int PrimaCifra(int x, int maxRand)
    {
        int primaCifra = x / (maxRand / 10);
        Console.WriteLine($"La prima cifra del numero segreto è {primaCifra}");
        return 3;
    }

    /// <summary>
    /// Suggerisce se il numero segreto è piu alto o basso rispetto a quello scelto dall'utente
    /// </summary>
    /// <param name="x">Il numero segreto random</param>
    /// <param name="mioNumero">Il numero scelto dall'utente</param>
    /// <returns>Il valore da sottrarre al bonus</returns>
    public static double AltoBasso(int x, int mioNumero)
    {
        Console.Write("Suggerimento. Il numero segreto è ");

        if (mioNumero < x)
        {
            Console.WriteLine("più alto!");
        }
        else
        {
            Console.WriteLine("più basso!");
        }
        return 0.5;
    }
}