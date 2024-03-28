using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FotoGalleryRazor.Models;
using Newtonsoft.Json;

namespace FotoGalleryRazor.Pages;

public class ClassificaModel : PageModel
{
    public int NumeroPagine { get; set; }
    public int? PageIndex { get; set; }
    public int ElementiPerPagina { get; set; }
    public bool Reverse { get; set; }
    public int TotaleImmagini { get; set; }
    public required IEnumerable<Immagine> Immagini { get; set; }
    public string jsonPath = @"wwwroot/json/immagini.json";

    #region Logger
    private readonly ILogger<ClassificaModel> _logger;

    public ClassificaModel(ILogger<ClassificaModel> logger)
    {
        _logger = logger;
    }
    #endregion

    public void OnGet(int? pageIndex, bool reverse)
    {
        //log che visualizza la pagina selezionata
        _logger.LogInformation("Classifica - PageIndex: {0}", pageIndex);

        ElementiPerPagina = 10;
        PageIndex = pageIndex;
        Reverse = reverse;

        _logger.LogInformation("Classifica - Numero Pagina: {0}, Reverse {1}", PageIndex, reverse);
        var jsonFile = System.IO.File.ReadAllText(jsonPath);
        Immagini = JsonConvert.DeserializeObject<List<Immagine>>(jsonFile)!.OrderByDescending(i => i.Voto);
        TotaleImmagini = Immagini.Count();
        _logger.LogInformation("Totale immagini: {0}", TotaleImmagini);
        if (reverse)
        {
            Immagini = Immagini.Reverse();
        }



        NumeroPagine = (int)Math.Ceiling((double)Immagini.Count() / ElementiPerPagina);
        Immagini = Immagini.Skip(((pageIndex ?? 1) - 1) * ElementiPerPagina).Take(ElementiPerPagina);
    }
}

