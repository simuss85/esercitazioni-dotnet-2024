namespace FotoGalleryMvcId.Models;

public class CaroselloViewModel
{
    //attibuti per le view GET
    public string? Categoria { get; set; } //categoria attuale
    public IEnumerable<Immagine>? Immagini { get; set; }
}