namespace FotoGalleryMvcId.Models;

public class GestisciImmaginiViewModel
{
    //attibuti per le view GET
    public int NumeroPagine { get; set; }
    public int PageIndex { get; set; }
    public IEnumerable<Immagine>? Immagini { get; set; }
    public IEnumerable<string>? Categorie { get; set; }
    public string? Reverse { get; set; }    //gestisce filtri di ordinamento
}