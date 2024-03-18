using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppProdotti.Models;
using Newtonsoft.Json;

namespace WebAppProdotti.Pages;

public class ProdottiModel : PageModel
{
    public required int numeroPagine { get; set; }
    public required string jsonPath = "wwwroot/json/prodotti.json";
    public required IEnumerable<Prodotto> Prodotti { get; set; }

    #region Logger
    private readonly ILogger<ProdottiModel> _logger;

    public ProdottiModel(ILogger<ProdottiModel> logger)
    {
        _logger = logger;
    }
    #endregion


    public void OnGet(decimal? minPrezzo, decimal? maxPrezzo, int? pageIndex)
    {
        //aggiungi un log
        _logger.LogInformation("Tabella prodotti");

        string jsonFile = System.IO.File.ReadAllText(jsonPath);

        Prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(jsonFile)!;

        if (minPrezzo.HasValue)
        {
            Prodotti = Prodotti.Where(p => p.Prezzo >= minPrezzo);
            //aggiungi un log
            _logger.LogInformation("minPrezzo: {minPrezzo}", minPrezzo);
        }
        if (maxPrezzo.HasValue)
        {
            Prodotti = Prodotti.Where(p => p.Prezzo <= maxPrezzo);
            _logger.LogInformation("maxPrezzo: {maxPrezzo}", maxPrezzo);
        }

        //aggiungi un log
        _logger.LogInformation("pageIndex: {pageIndex}", pageIndex);

        numeroPagine = (int)Math.Ceiling((double)Prodotti.Count() / 6);

        Prodotti = Prodotti.Skip(((pageIndex ?? 1) - 1) * 6).Take(6);
    }
}

