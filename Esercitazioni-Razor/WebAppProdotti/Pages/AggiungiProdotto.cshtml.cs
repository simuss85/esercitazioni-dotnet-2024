using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppProdotti.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace WebAppProdotti.Pages;

public class AggiungiProdottoModel : PageModel
{
    public required string jsonPath = "wwwroot/json/prodotti.json";

    #region Logger
    private readonly ILogger<AggiungiProdottoModel> _logger;

    public AggiungiProdottoModel(ILogger<AggiungiProdottoModel> logger)
    {
        _logger = logger;
    }
    #endregion

    public IActionResult OnPost(string nome, decimal prezzo, string dettaglio)
    {
        var jsonFile = System.IO.File.ReadAllText(jsonPath);
        var prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(jsonFile)!;
        prodotti.Add(new Prodotto { Nome = nome, Prezzo = prezzo, Dettaglio = dettaglio });
        //salva nel file json
        System.IO.File.WriteAllText(jsonPath, JsonConvert.SerializeObject(prodotti, Formatting.Indented));
        return RedirectToPage("Prodotti");
    }
}