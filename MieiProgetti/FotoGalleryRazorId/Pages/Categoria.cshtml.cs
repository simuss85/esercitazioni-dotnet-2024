using FotoGalleryRazorId.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace FotoGalleryRazorId.Pages;

#nullable disable
//GET: /Reserved/User
[Authorize(Roles = "User")]
public class CategoriaModel : PageModel
{
    public string Categoria { get; set; } //categoria attuale
    public IEnumerable<Immagine> Immagini { get; set; }

    public string jsonPath = @"wwwroot/json/immagini.json";

    #region  Logger
    private readonly ILogger<CategoriaModel> _logger;

    public CategoriaModel(ILogger<CategoriaModel> logger)
    {
        _logger = logger;
    }
    #endregion

    public void OnGet(string categoria)
    {
        // carico il file categorie.json e seleziono solo la categoria passata al get
        var jsonFile = System.IO.File.ReadAllText(jsonPath);
        Immagini = JsonConvert.DeserializeObject<List<Immagine>>(jsonFile)!.Where(i => i.Categoria == categoria);
        Categoria = categoria;
    }
}
