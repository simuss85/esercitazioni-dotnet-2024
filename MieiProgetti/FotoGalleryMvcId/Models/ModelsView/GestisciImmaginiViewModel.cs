namespace FotoGalleryMvcId.Models;

public class GestisciImmaginiViewModel
{
    //path dei file json
    private const string IMM = @"wwwroot/json/immagini.json";
    private const string CAT = @"wwwroot/json/categorie.json";
    public string PathImmagini { get; set; } = IMM;
    public string PathCategorie { get; set; } = CAT;

    //attibuti per le view GET
    public int NumeroPagine { get; set; }
    public int PageIndex { get; set; }
    public IEnumerable<Immagine>? Immagini { get; set; }
    public IEnumerable<string>? Categorie { get; set; }
    public string? Reverse { get; set; }    //gestisce filtri di ordinamento
}