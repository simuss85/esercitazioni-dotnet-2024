namespace FotoGalleryMvcId.Models;

public class ImmaginiViewModel
{
    //attibuti per le view GET
    public int NumeroPagine { get; set; }
    public string? Categoria { get; set; }
    public int PageIndex { get; set; }
    public IEnumerable<Immagine>? Immagini { get; set; }
    public List<string>? Categorie { get; set; }
}