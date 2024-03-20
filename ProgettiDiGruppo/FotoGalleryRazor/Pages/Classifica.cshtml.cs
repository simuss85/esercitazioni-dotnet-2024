using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FotoGalleryRazor.Models;
using Newtonsoft.Json;

namespace FotoGalleryRazor.Pages;

public class ClassificaModel : PageModel
{
    public required IEnumerable<Immagine> Immagini { get; set; }
    public string jsonPath = @"wwwroot/json/immagini.json";

    #region Logger
    private readonly ILogger<ClassificaModel> _logger;

    public ClassificaModel(ILogger<ClassificaModel> logger)
    {
        _logger = logger;
    }
    #endregion

    public void OnGet()
    {
        var jsonFile = System.IO.File.ReadAllText(jsonPath);
        Immagini = JsonConvert.DeserializeObject<List<Immagine>>(jsonFile)!;
    }
}

