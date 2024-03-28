using FotoGalleryRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace FotoGalleryRazor.Pages;

public class IndexModel : PageModel
{
    public int NumeroPagine { get; set; }
    public string? Categoria { get; set; }
    public int? PageIndex { get; set; }
    public required IEnumerable<Immagine> Immagini { get; set; }
    public required List<string> Categorie { get; set; }
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
        //log che visualizza la pagina selezionata
        _logger.LogInformation("Index - PageIndex: {0}", pageIndex);

        //per la gestione del frontend copio i valori attuali nelgli attributi di classe
        Categoria = categoria;
        PageIndex = pageIndex;

        var jsonFile = System.IO.File.ReadAllText(jsonPath);
        Immagini = JsonConvert.DeserializeObject<List<Immagine>>(jsonFile)!;

        var jsonFile3 = System.IO.File.ReadAllText(jsonPath3);
        Categorie = JsonConvert.DeserializeObject<List<string>>(jsonFile3)!;

        //elimino le categorie senza immagini
        Categorie.RemoveAll(c => Immagini.All(i => i.Categoria != c));

        //filtro le immagini per categoria
        if (!string.IsNullOrEmpty(Categoria))
        {
            Immagini = Immagini.Where(i => i.Categoria == categoria);
        }

        //calcolo numero pagine e paginazione
        NumeroPagine = (int)Math.Ceiling((double)Immagini.Count() / 12);
        Immagini = Immagini.Skip(((pageIndex ?? 1) - 1) * 12).Take(12);

    }
}
