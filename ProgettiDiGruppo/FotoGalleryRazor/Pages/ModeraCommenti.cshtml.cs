using FotoGalleryRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace FotoGalleryRazor.Pages;

public class ModeraCommentiModel : PageModel
{
    public int NumeroPagine { get; set; }
    public int? PageModera { get; set; }
    public int ElementiPerPagina { get; set; }
    public required IEnumerable<Voto> Voti { get; set; }

    public string jsonPath2 = @"wwwroot/json/voti.json";

    #region  Logger
    private readonly ILogger<ModeraCommentiModel> _logger;

    public ModeraCommentiModel(ILogger<ModeraCommentiModel> logger)
    {
        _logger = logger;
    }
    #endregion

    public void OnGet(int? pageModera, List<int>? selezione)
    {
        ElementiPerPagina = 20;
        PageModera = pageModera;

        var jsonFile = System.IO.File.ReadAllText(jsonPath2);
        Voti = JsonConvert.DeserializeObject<List<Voto>>(jsonFile)!.OrderByDescending(i => i.Id);

        NumeroPagine = (int)Math.Ceiling((double)Voti.Count() / ElementiPerPagina);
        Voti = Voti.Skip(((pageModera ?? 1) - 1) * ElementiPerPagina).Take(ElementiPerPagina);
    }
}