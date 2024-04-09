using Microsoft.AspNetCore.Mvc;

namespace FotoGalleryMvcId.Models;

public class ImmagineViewModel
{
    //path dei file json
    private const string VOT = @"wwwroot/json/voti.json";
    private const string IMM = @"wwwroot/json/immagini.json";
    public string PathVoti { get; set; } = VOT;
    public string PathImmagini { get; set; } = IMM;

    //attibuti per le view POST
    [BindProperty]
    public int Id { get; set; }

    [BindProperty]
    public double Stars { get; set; }

    [BindProperty]
    public string? Commento { get; set; }

    [BindProperty]
    public string? UrlBack { get; set; }

    //attibuti per le view GET
    public string? NomeUtente { get; set; }
    public bool VotoAttivo { get; set; }
    public Immagine? Immagine { get; set; }
    public IEnumerable<Voto>? Voti { get; set; }


}