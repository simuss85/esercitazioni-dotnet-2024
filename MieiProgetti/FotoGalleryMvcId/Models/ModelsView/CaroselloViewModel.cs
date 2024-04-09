namespace FotoGalleryMvcId.Models;

public class CaroselloViewModel
{
    //path dei file json
    private const string IMM = @"wwwroot/json/immagini.json";
    public string PathImmagini { get; set; } = IMM;

    //attibuti per le view GET
    public string? Categoria { get; set; } //categoria attuale
    public IEnumerable<Immagine>? Immagini { get; set; }
}