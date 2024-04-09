namespace FotoGalleryMvcId.Models;

public class ImmaginiViewModel
{
    //path dei file json
    private const string CAT = @"wwwroot/json/categorie.json";
    private const string IMM = @"wwwroot/json/immagini.json";

    public int NumeroPagine { get; set; }
    public string? Categoria { get; set; }
    public int? PageIndex { get; set; }
    public IEnumerable<Immagine>? Immagini { get; set; }
    public List<string>? Categorie { get; set; }
    public string PathImmagini { get; set; } = IMM;
    public string PathCategorie { get; set; } = CAT;
}