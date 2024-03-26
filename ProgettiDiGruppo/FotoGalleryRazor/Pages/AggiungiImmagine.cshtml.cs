using FotoGalleryRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace FotoGalleryRazor.Pages;

public class AggiungiImmagineModel : PageModel
{
    [BindProperty]
    public required Immagine Immagine { get; set; }
    public required IEnumerable<string> Categorie { get; set; }

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

    public IActionResult OnPost()
    {
        //assicura che i dati inviati siano validi, altrimenti ricarica la pagina
        if (!ModelState.IsValid)
        {
            return Page();
        }
        _logger.LogInformation("Categoria: {0}", Immagine!.Categoria);

        var jsonFile = System.IO.File.ReadAllText(jsonPath);
        var immagini = JsonConvert.DeserializeObject<List<Immagine>>(jsonFile)!;

        int id = immagini.Max(i => i.Id);
        id++;

        if (string.IsNullOrEmpty(Immagine!.Autore))
        {
            Immagine.Autore = $"Autore {id}";
        }
        if (string.IsNullOrEmpty(Immagine.Titolo))
        {
            Immagine.Titolo = $"Titolo {id}";
        }

        Immagine.Id = id;
        Immagine.Data = DateTime.Today;

        immagini.Add(Immagine);

        System.IO.File.WriteAllText(jsonPath, JsonConvert.SerializeObject(immagini, Formatting.Indented));
        return RedirectToPage("/GestisciImmagini");
    }
}
