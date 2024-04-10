namespace FotoGalleryMvcId.Models;

public class CategorieViewModel
{
    //attibuti per le view GET
    public IEnumerable<Immagine>? Immagini { get; set; }
    public IEnumerable<string>? Categorie { get; set; }
}