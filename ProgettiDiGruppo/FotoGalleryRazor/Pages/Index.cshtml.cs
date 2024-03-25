using FotoGalleryRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace FotoGalleryRazor.Pages;

public class IndexModel : PageModel
{
    public required int NumeroPagine { get; set; }
    public required string? Categoria { get; set; }
    public required int? PageIndex { get; set; }
    public required IEnumerable<Immagine> Immagini { get; set; }
    public required IEnumerable<string> Categorie { get; set; }
    public string jsonPath = @"wwwroot/json/immagini.json";
    public string jsonPath3 = @"wwwroot/json/categorie.json";

    #region  Logger
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }
    #endregion

    public void OnGet(int? pageIndex, string? categoria)
    {

        var jsonFile = System.IO.File.ReadAllText(jsonPath);
        Immagini = JsonConvert.DeserializeObject<List<Immagine>>(jsonFile)!;

        var jsonFile3 = System.IO.File.ReadAllText(jsonPath3);
        Categorie = JsonConvert.DeserializeObject<List<string>>(jsonFile3)!;

        _logger.LogInformation("Index Numero pagina: {0}", pageIndex);

        //per la gestione del frontend mi copio i valori attuali nelgli attributi di classe
        Categoria = categoria;
        PageIndex = pageIndex;
        if (!string.IsNullOrEmpty(Categoria))
        {
            Immagini = Immagini.Where(i => i.Categoria == categoria);
        }

        NumeroPagine = (int)Math.Ceiling((double)Immagini.Count() / 12);
        Immagini = Immagini.Skip(((pageIndex ?? 1) - 1) * 12).Take(12);



    }
}
