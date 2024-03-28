using FotoGalleryRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace FotoGalleryRazor.Pages;

public class GestisciImmaginiModel : PageModel
{
    public int NumeroPagine { get; set; }
    public int? PageIndex { get; set; }
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

    public void OnGet(int? pageIndex)
    {
        //log che visualizza la pagina selezionata
        _logger.LogInformation("GestisciImmagini - PageIndex: {0}", pageIndex);

        PageIndex = pageIndex;

        var jsonFile = System.IO.File.ReadAllText(jsonPath);
        Immagini = JsonConvert.DeserializeObject<List<Immagine>>(jsonFile)!.OrderByDescending(i => i.Id);

        var jsonFile3 = System.IO.File.ReadAllText(jsonPath3);
        Categorie = JsonConvert.DeserializeObject<List<string>>(jsonFile3)!;

        NumeroPagine = (int)Math.Ceiling((double)Immagini.Count() / 10);
        Immagini = Immagini.Skip(((pageIndex ?? 1) - 1) * 10).Take(10);
    }

}