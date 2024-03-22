using FotoGalleryRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace FotoGalleryRazor.Pages;

public class AggiungiImmagineModel : PageModel
{

    public required List<string> Categorie { get; set; }
    public required Immagine Immagine { get; set; }
    public string jsonPath = @"wwwroot/json/immagini.json";
    public string jsonPath3 = @"wwwroot/json/categorie.json";
    #region  Logger
    private readonly ILogger<AggiungiImmagineModel> _logger;

    public AggiungiImmagineModel(ILogger<AggiungiImmagineModel> logger)
    {
        _logger = logger;
    }
    #endregion

    public void OnGet()
    {
        var jsonFile3 = System.IO.File.ReadAllText(jsonPath3);
        Categorie = JsonConvert.DeserializeObject<List<string>>(jsonFile3)!;
    }
    public IActionResult OnPost(string? autore, string? titolo, string path, string categoria)
    {
        var jsonFile = System.IO.File.ReadAllText(jsonPath);
        var immagini = JsonConvert.DeserializeObject<List<Immagine>>(jsonFile)!;


        int id = immagini.Max(i => i.Id);
        id++;
        if (autore == null)
        {
            autore = $"Autore {id}";
        }

        if (titolo == null)
        {
            titolo = $"Titolo {id}";
        }

        immagini.Add(new Immagine { Id = id, Path = path, Titolo = titolo, Voto = 0, NumeroVoti = 0, Autore = autore, Data = DateTime.Today });
        System.IO.File.WriteAllText(jsonPath, JsonConvert.SerializeObject(immagini, Formatting.Indented));
        return Page();
    }
}
