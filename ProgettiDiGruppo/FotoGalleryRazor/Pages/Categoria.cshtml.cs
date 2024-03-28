using FotoGalleryRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace FotoGalleryRazor.Pages;

public class CategoriaModel : PageModel
{
    public string? Categoria { get; set; } //categoria attuale
    public required IEnumerable<Immagine> Immagini { get; set; }

    public string jsonPath = @"wwwroot/json/immagini.json";

    #region  Logger
    private readonly ILogger<CategoriaModel> _logger;

    public CategoriaModel(ILogger<CategoriaModel> logger)
    {
        _logger = logger;
    }
    #endregion

    public void OnGet(string? categoria)
    {
        // carico il file categorie.json e seleziono solo la categoria passata al get
        var jsonFile = System.IO.File.ReadAllText(jsonPath);
        Immagini = JsonConvert.DeserializeObject<List<Immagine>>(jsonFile)!.Where(i => i.Categoria == categoria);
        Categoria = categoria;
    }
}
