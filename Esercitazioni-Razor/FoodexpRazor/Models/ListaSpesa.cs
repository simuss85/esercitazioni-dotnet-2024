namespace FoodexpRazor.Models;
public class ListaSpesa
{
    public int Id { get; set; }
    public string? Alimento { get; set; }
    public int Quantita { get; set; }
    //chiavi estene
    public int CategoriaId { get; set; }
    public Categoria? Categoria { get; set; } //riferimento molti a uno tab-utenti
    public int UtenteId { get; set; }
    public Utente? Utente { get; set; }   //riferimento molti a uno tab-categorie
}
