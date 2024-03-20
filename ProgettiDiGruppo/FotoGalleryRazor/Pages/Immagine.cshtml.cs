using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FotoGalleryRazor.Models;
using Newtonsoft.Json;

namespace FotoGalleryRazor.Pages;

public class ImmagineModel : PageModel
{
    public required Immagine Immagine { get; set; }
    public string jsonPath = @"wwwroot/json/immagini.json";

    #region Logger
    private readonly ILogger<ImmagineModel> _logger;

    public ImmagineModel(ILogger<ImmagineModel> logger)
    {
        _logger = logger;
    }
    #endregion

    public void OnGet(int id)
    {
        var jsonFile = System.IO.File.ReadAllText(jsonPath);
        Immagine = JsonConvert.DeserializeObject<List<Immagine>>(jsonFile)!.First(i => i.Id == id);
    }
}