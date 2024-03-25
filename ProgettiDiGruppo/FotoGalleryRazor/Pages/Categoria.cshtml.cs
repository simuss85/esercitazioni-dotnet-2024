using FotoGalleryRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace FotoGalleryRazor.Pages;

public class CategoriaModel : PageModel
{
    public required int NumeroPagine { get; set; }
    public required string? Categoria { get; set; }
    public required int? PageCategoria { get; set; }
    public required IEnumerable<Immagine> Immagini { get; set; }

    public string jsonPath = @"wwwroot/json/immagini.json";


    #region  Logger
    private readonly ILogger<CategoriaModel> _logger;

    public CategoriaModel(ILogger<CategoriaModel> logger)
    {
        _logger = logger;
    }
    #endregion

    public void OnGet(int? pageCategoria, string? categoria)
    {
        var jsonFile = System.IO.File.ReadAllText(jsonPath);
        Immagini = JsonConvert.DeserializeObject<List<Immagine>>(jsonFile)!.Where(i => i.Categoria == categoria);

        _logger.LogInformation("Categoria: {0}, Numero pagina: {1}", categoria, pageCategoria);

        Categoria = categoria;
        PageCategoria = pageCategoria;

        NumeroPagine = (int)Math.Ceiling((double)Immagini.Count() / 12);
        Immagini = Immagini.Skip(((pageCategoria ?? 1) - 1) * 12).Take(12);

    }
}
