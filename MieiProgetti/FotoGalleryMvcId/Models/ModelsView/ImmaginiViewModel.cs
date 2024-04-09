namespace FotoGalleryMvcId.Models;

public class ImmaginiViewModel
{
    //path dei file json
    private const string IMM = @"wwwroot/json/immagini.json";
    private const string CAT = @"wwwroot/json/categorie.json";
    public string PathImmagini { get; set; } = IMM;
    public string PathCategorie { get; set; } = CAT;

    //attibuti per le view GET
    public int NumeroPagine { get; set; }
    public string? Categoria { get; set; }
    public int? PageIndex { get; set; }
    public IEnumerable<Immagine>? Immagini { get; set; }
    public List<string>? Categorie { get; set; }

}