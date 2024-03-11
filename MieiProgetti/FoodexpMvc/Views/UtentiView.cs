namespace FoodexpMvc.Views;

public class UtentiView
{
    /// <summary>
    /// Visualizza opzioni sotto-menu "Gestione utenti"
    /// </summary>
    public static void MenuGestioneUtenti()
    {
        Console.WriteLine("Gestione utenti\n");
        Console.WriteLine("1. Visualizza utenti");
        Console.WriteLine("2. Modifica nome e/o password");
        Console.WriteLine("3. Elimina account");
        Console.WriteLine("r. tona al menu principale");
        Console.WriteLine("\nseleziona opzione");
    }

    /// <summary>
    /// Stampa a schermo la lista degli utenti
    /// </summary>
    /// <param name="utenti"></param>
    public static void VisualizzaUtenti(List<string> utenti)
    {
        Console.WriteLine("Elenco utenti");
        foreach (var u in utenti)
        {
            Console.WriteLine(u);
        }
    }
}