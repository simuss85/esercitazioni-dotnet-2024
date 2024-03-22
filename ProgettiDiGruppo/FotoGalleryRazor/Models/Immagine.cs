namespace FotoGalleryRazor.Models;

public class Immagine
{
    public int Id { get; set; }
    public string? Path { get; set; }
    public string? Titolo { get; set; }
    public double Voto { get; set; }
    public int NumeroVoti { get; set; }
    public string? Autore { get; set; }
    public DateTime Data { get; set; }
    public string? Categoria { get; set; }
}
