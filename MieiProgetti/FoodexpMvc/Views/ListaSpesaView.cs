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
}