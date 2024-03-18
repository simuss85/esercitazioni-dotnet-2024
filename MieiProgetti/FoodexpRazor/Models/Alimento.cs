namespace FoodexpRazor.Models;

public class Alimento
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public int Quantita { get; set; }
    public DateTime DataScadenza { get; set; }
    public DateTime DataInserimento { get; set; }
    //chiave esterna
    public int CategoriaId { get; set; }
    public Categoria? Categoria { get; set; } //riferimento molti a uno tab-categoria
    public string? Info { get; set; }
    public string? Immagine { get; set; }

}