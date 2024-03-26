using FotoGalleryRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace FotoGalleryRazor.Pages;

public class GestisciImmaginiModel : PageModel
{
    public int NumeroPagine { get; set; }
    public int? PageGestione { get; set; }
    public required IEnumerable<Immagine> Immagini { get; set; }
    public required IEnumerable<string> Categorie { get; set; }
    public string jsonPath = @"wwwroot/json/immagini.json";
    public string jsonPath3 = @"wwwroot/json/categorie.json";

    #region  Logger
    private readonly ILogger<GestisciImmaginiModel> _logger;

    public GestisciImmaginiModel(ILogger<GestisciImmaginiModel> logger)
    {
        _logger = logger;
    }
    #endregion

    public void OnGet(int? pageGestione, List<int>? selezione)
    {
        PageGestione = pageGestione;

        var jsonFile = System.IO.File.ReadAllText(jsonPath);
        Immagini = JsonConvert.DeserializeObject<List<Immagine>>(jsonFile)!.OrderByDescending(i => i.Id);

        var jsonFile3 = System.IO.File.ReadAllText(jsonPath3);
        Categorie = JsonConvert.DeserializeObject<List<string>>(jsonFile3)!;

        NumeroPagine = (int)Math.Ceiling((double)Immagini.Count() / 10);
        Immagini = Immagini.Skip(((pageGestione ?? 1) - 1) * 10).Take(10);
    }

}