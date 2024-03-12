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
        Console.WriteLine("2. Inserisci categoria");
        Console.WriteLine("3. Modifica categoria");
        Console.WriteLine("r. torna al menu principale");
        Console.Write("\nseleziona opzione: ");
    }

    /// <summary>
    /// Stampa a schermo la lista delle categorie in formato elenco numerato (Categoria.Id).
    /// </summary>
    /// <param name="listaCategorie">Lista delle categorie</param>
    public static void VisualizzaCategorie(List<string> listaCategorie)
    {
        Console.WriteLine("Elenco categorie");
        if (listaCategorie.Count == 0)
        {
            Console.WriteLine("Elenco vuoto!!!");
        }
        else
        {
            foreach (var elemento in listaCategorie)
            {
                Console.WriteLine(elemento);
            }
        }
    }
}