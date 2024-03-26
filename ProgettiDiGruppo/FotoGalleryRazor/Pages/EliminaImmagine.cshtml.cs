using FotoGalleryRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace FotoGalleryRazor.Pages;

public class EliminaImmagineModel : PageModel
{
    [BindProperty]
    public required List<int> Selezione { get; set; }   //lista di id da eliminare
    public required List<Immagine> Immagini { get; set; }
    public string jsonPath = @"wwwroot/json/immagini.json";

    #region  Logger
    private readonly ILogger<EliminaImmagineModel> _logger;

    public EliminaImmagineModel(ILogger<EliminaImmagineModel> logger)
    {
        _logger = logger;
    }
    #endregion

    public void OnGet(List<int> selezione)
    {
        Selezione = selezione;

        foreach (var id in Selezione)
        {
            _logger.LogInformation("Selezione: {0}", id);
        }
        var jsonFile = System.IO.File.ReadAllText(jsonPath);
        Immagini = JsonConvert.DeserializeObject<List<Immagine>>(jsonFile)!;
    }
    public IActionResult OnPost()
    {
        var jsonFile = System.IO.File.ReadAllText(jsonPath);
        Immagini = JsonConvert.DeserializeObject<List<Immagine>>(jsonFile)!;

        foreach (var id in Selezione)
        {
            _logger.LogInformation("Selezione: {0}", id);
            Immagini.Remove(Immagini.First(i => i.Id == id));
        }
        System.IO.File.WriteAllText(jsonPath, JsonConvert.SerializeObject(Immagini, Formatting.Indented));

        return RedirectToPage("/GestisciImmagini");
    }
}



