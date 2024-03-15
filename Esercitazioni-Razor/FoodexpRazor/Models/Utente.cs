namespace FoodexpRazor.Models;
public class Utente
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Password { get; set; }

    public List<ListaSpesa>? ListeSpesa { get; set; }     //riferimento uno a molti tab-listaSpesa
}
