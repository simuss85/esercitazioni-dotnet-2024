using FotoGalleryMvcId.Models;
using Microsoft.AspNetCore.Mvc;

public class ImmagineViewModel
{
    [BindProperty]
    public int Id { get; set; }

    [BindProperty]
    public double Stars { get; set; }

    [BindProperty]
    public string? Commento { get; set; }

    [BindProperty]
    public string? UrlBack { get; set; }

    public string? NomeUtente { get; set; }
    public bool VotoAttivo { get; set; }
    public Immagine? Immagine { get; set; }
    public IEnumerable<Voto>? Voti { get; set; }
    public string jsonPath = @"wwwroot/json/immagini.json";
    public string jsonPath2 = @"wwwroot/json/voti.json";
}