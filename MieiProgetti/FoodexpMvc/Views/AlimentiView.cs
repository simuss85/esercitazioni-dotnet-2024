namespace FoodexpMvc.Views;

public class AlimentiView
{
    /// <summary>
    /// Visualizza opzioni sotto-menu "Filtra alimenti"
    /// </summary>
    public static void MenuFiltraAlimenti()
    {
        Console.WriteLine("Filtra alimenti\n");
        Console.WriteLine("1. Visualizza tutti");
        Console.WriteLine("2. Visualizza scaduti");
        Console.WriteLine("3. Visualizza in scadenza");
        Console.WriteLine("4. Visualizza in esaurimento");
        Console.WriteLine("5. Ordina per nome");
        Console.WriteLine("6. Ordina per data di scadenza");
        Console.WriteLine("7. Ordina per data di inserimento");
        Console.WriteLine("8. Ordina per quantità");
        Console.WriteLine("9. Ordina per categoria");
        Console.WriteLine("r. torna al menu principale");
        Console.Write("\nseleziona opzione: ");
    }

    /// <summary>
    /// Visualizza opzioni sotto-meu "Gestione alimenti"
    /// </summary>
    public static void MenuGestioneAlimenti()
    {
        Console.WriteLine("Gestione alimenti\n");
        Console.WriteLine("1. Inserisci alimento");
        Console.WriteLine("2. Modifica alimento");
        Console.WriteLine("3. Elimina alimento");
        Console.WriteLine("r. torna al menu principale");
        Console.Write("\nseleziona opzione: ");
    }

    /// <summary>
    /// Stampa a schermo la lista degli alimenti in formato elenco numerato. <br/>
    /// Prevede l'inserimento di un messaggio come titolo per la sezione.
    /// </summary>
    /// <param name="listaAlimenti">Lista degli alimenti</param>
    /// <param name="titolo">Titolo della sezione corrente; vuoto di default</param>
    public static void VisualizzaAlimenti(List<string> listaAlimenti, string titolo = "")
    {
        int conta = 1;  //gestisce l'elenco numerato
        Console.WriteLine(titolo);
        if (listaAlimenti.Count == 0)
        {
            Console.WriteLine("Elenco vuoto!!!");
        }
        else
        {
            foreach (var elemento in listaAlimenti)
            {
                Console.WriteLine($"{conta} - {elemento}");
                conta++;
            }
        }

    }
}