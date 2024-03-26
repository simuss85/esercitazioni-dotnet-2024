using FotoGalleryRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace FotoGalleryRazor.Pages;

public class ModificaImmagineModel : PageModel
{
    [BindProperty]
    public required List<int> Selezione { get; set; }
    [BindProperty]
    public required List<Immagine> ImmaginiModificate { get; set; }
    public required List<Immagine> Immagini { get; set; }
    public required IEnumerable<string> Categorie { get; set; }
    public string jsonPath = @"wwwroot/json/immagini.json";
    public string jsonPath3 = @"wwwroot/json/categorie.json";

    #region  Logger
    private readonly ILogger<ModificaImmagineModel> _logger;

    public ModificaImmagineModel(ILogger<ModificaImmagineModel> logger)
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

        var jsonFile = System.IO.File.ReadAllText(jsonPath);
        Immagini = JsonConvert.DeserializeObject<List<Immagine>>(jsonFile)!;

        // Verifica se la lista delle immagini modificate è vuota
        if (ImmaginiModificate != null && ImmaginiModificate.Any())
        {
            foreach (var immagineModificata in ImmaginiModificate)
            {
                _logger.LogInformation("ID: {0}", immagineModificata.Id);
                foreach (var i in Immagini)
                {
                    if (i.Id == immagineModificata.Id)
                    {
                        _logger.LogInformation("pre-Autore: {0}", i.Autore);
                        i.Autore = immagineModificata.Autore;
                        _logger.LogInformation("post-Autore: {0}", i.Autore);
                        i.Titolo = immagineModificata.Titolo;
                        i.Categoria = immagineModificata.Categoria;
                        i.Path = immagineModificata.Path;
                        break;
                    }
                }
            }
            System.IO.File.WriteAllText(jsonPath, JsonConvert.SerializeObject(Immagini, Formatting.Indented));
        }

        return RedirectToPage("/GestisciImmagini");
    }
}