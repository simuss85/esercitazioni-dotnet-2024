namespace FoodexpMvc.Views;

public class ListaSpesaView
{
    /// <summary>
    /// Visualizza opzioni sotto-meu "Lista della spesa"
    /// </summary>
    public static void MenuListaSpesa()
    {
        Console.WriteLine("Lista della spesa\n");
        Console.WriteLine("1. Visualizza lista");
        Console.WriteLine("2. Inserisci alimento");
        Console.WriteLine("3. Modifica alimento");
        Console.WriteLine("4. Elimina alimento");
        Console.WriteLine("r. torna al menu principale");
        Console.Write("\nseleziona opzione: ");
    }

    /// <summary>
    /// Stampa a schermo la lista degli alimenti in formato elenco numerato. <br/>
    /// Prevede l'inserimento di un messaggio come titolo per la sezione.
    /// </summary>
    /// <param name="listaSpesa">Lista degli alimenti</param>
    public static void VisualizzaLista(List<string> listaSpesa)
    {
        int conta = 1;  //gestisce l'elenco numerato
        Console.WriteLine("Lista della spesa");
        if (listaSpesa.Count == 0)
        {
            Console.WriteLine("\nElenco vuoto!!!");
        }
        else
        {
            foreach (var elemento in listaSpesa)
            {
                Console.WriteLine($"{conta} - {elemento}");
                conta++;
            }
        }

    }
}