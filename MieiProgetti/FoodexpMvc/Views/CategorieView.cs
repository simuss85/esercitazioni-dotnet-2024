namespace FoodexpMvc.Views;

public class CategorieView
{
    /// <summary>
    /// Visualizza opzioni sotto-menu "Gestione categorie"
    /// </summary>
    public static void MenuGestioneCategorie()
    {
        Console.WriteLine("Gestione categorie\n");
        Console.WriteLine("1. Visualizza categorie");
        Console.WriteLine("2. Modifica categoria");
        Console.WriteLine("3. Elimina categoria");
        Console.WriteLine("r. torna al menu principale");
        Console.WriteLine("\nseleziona opzione");
    }
}