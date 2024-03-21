namespace FotoGalleryRazor.Models;

public class Utente
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public int ImmagineId { get; set; }
    public double Voto { get; set; }
    public DateTime Data { get; set; }
    public string? Commento { get; set; }
    public bool Visibile { get; set; }

}
