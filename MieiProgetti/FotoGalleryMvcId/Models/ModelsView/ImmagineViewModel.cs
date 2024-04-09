using Microsoft.AspNetCore.Mvc;

namespace FotoGalleryMvcId.Models;

public class ImmagineViewModel
{
    //attibuti per le view POST
    [BindProperty]
    [HiddenInput]
    public int Id { get; set; }

    [BindProperty]
    public double Stars { get; set; }

    [BindProperty]
    public string? Commento { get; set; }

    [BindProperty]
    [HiddenInput]
    public string? UrlBack { get; set; }

    [BindProperty]
    [HiddenInput]
    public string? NomeUtente { get; set; }

    //attibuti per le view GET
    public bool VotoAttivo { get; set; }
    public Immagine? Immagine { get; set; }
    public IEnumerable<Voto>? Voti { get; set; }
}