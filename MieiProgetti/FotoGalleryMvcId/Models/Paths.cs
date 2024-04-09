namespace FotoGalleryMvcId.Models;

public class Paths
{
    //path dei file json
    private const string IMM = @"wwwroot/json/immagini.json";
    private const string VOT = @"wwwroot/json/voti.json";
    private const string CAT = @"wwwroot/json/categorie.json";
    public string PathVoti { get; set; } = VOT;
    public string PathCategorie { get; set; } = CAT;
    public string PathImmagini { get; set; } = IMM;
}