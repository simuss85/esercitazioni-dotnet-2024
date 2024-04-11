using Microsoft.AspNetCore.Mvc;

namespace FotoGalleryMvcId.Models;

public class GestioneRuoliViewModel
{
    //POST
    [BindProperty]
    public string? Id { get; set; }

    [BindProperty]
    public List<string>? Ruoli { get; set; }
    [BindProperty]
    public string? UrlBack { get; set; }
}
