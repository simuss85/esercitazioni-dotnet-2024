namespace FotoGalleryMvcId.Models;

public class ClassificaViewModel
{
    //path dei file json
    private const string IMM = @"wwwroot/json/immagini.json";
    public string PathImmagini { get; set; } = IMM;

    //attibuti per le view GET
    public int NumeroPagine { get; set; }
    public int? PageIndex { get; set; }
    public int ElementiPerPagina { get; set; }
    public int TotaleImmagini { get; set; }
    public string? Reverse { get; set; }    //gestisce filtri di ordinamento
    public IEnumerable<Immagine>? Immagini { get; set; }
}