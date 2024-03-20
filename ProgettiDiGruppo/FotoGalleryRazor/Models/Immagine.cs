namespace FotoGalleryRazor.Models;

public class Immagine
{
    public int Id { get; set; }
    public string? Path { get; set; }
    public string? Titolo { get; set; }
    public decimal Voto { get; set; }
    public string? Autore { get; set; }
    public DateTime Data { get; set; }
}
