using FotoGalleryRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace FotoGalleryRazor.Pages;

public class IndexModel : PageModel
{
    public required int NumeroPagine { get; set; }
    public required IEnumerable<Immagine> Immagini { get; set; }
    public string jsonPath = @"wwwroot/json/immagini.json";

    #region  Logger
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }
    #endregion

    public void OnGet(int? pageIndex)
    {
        var jsonFile = System.IO.File.ReadAllText(jsonPath);
        Immagini = JsonConvert.DeserializeObject<List<Immagine>>(jsonFile)!;

        _logger.LogInformation("Index Numero pagina: {0}", pageIndex);

        NumeroPagine = (int)Math.Ceiling((double)Immagini.Count() / 12);

        Immagini = Immagini.Skip(((pageIndex ?? 1) - 1) * 12).Take(12);
    }
}
