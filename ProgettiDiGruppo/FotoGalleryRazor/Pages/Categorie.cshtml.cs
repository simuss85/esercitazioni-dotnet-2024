using FotoGalleryRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace FotoGalleryRazor.Pages;

public class CategorieModel : PageModel
{
    public required IEnumerable<Immagine> Immagini { get; set; }
    public required IEnumerable<string> Categorie { get; set; }
    public string jsonPath = @"wwwroot/json/immagini.json";
    public string jsonPath3 = @"wwwroot/json/categorie.json";

    #region  Logger
    private readonly ILogger<CategorieModel> _logger;

    public CategorieModel(ILogger<CategorieModel> logger)
    {
        _logger = logger;
    }
    #endregion

    public void OnGet()
    {
        var jsonFile = System.IO.File.ReadAllText(jsonPath);
        Immagini = JsonConvert.DeserializeObject<List<Immagine>>(jsonFile)!;

        var jsonFile3 = System.IO.File.ReadAllText(jsonPath3);
        Categorie = JsonConvert.DeserializeObject<List<string>>(jsonFile3)!;


    }
}