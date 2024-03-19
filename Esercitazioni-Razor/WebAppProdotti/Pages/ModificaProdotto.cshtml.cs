using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppProdotti.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace WebAppProdotti.Pages;

public class ModificaProdottoModel : PageModel
{

    public required string jsonPath = "wwwroot/json/prodotti.json";
    public required Prodotto Prodotto { get; set; }

    #region Logger
    private readonly ILogger<ModificaProdottoModel> _logger;

    public ModificaProdottoModel(ILogger<ModificaProdottoModel> logger)
    {
        _logger = logger;
    }
    #endregion

    public void OnGet(string nome)
    {
        var jsonFile = System.IO.File.ReadAllText(jsonPath);
        var prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(jsonFile)!;
        Prodotto = prodotti.First(p => p.Nome == nome);
    }

    public IActionResult OnPost(string nome, decimal prezzo, string dettaglio)
    {
        var jsonFile = System.IO.File.ReadAllText(jsonPath);
        var prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(jsonFile)!;

        var prodotto = prodotti.First(p => p.Nome == nome);
        prodotto.Prezzo = prezzo;
        prodotto.Dettaglio = dettaglio;

        System.IO.File.WriteAllText(jsonPath, JsonConvert.SerializeObject(prodotti, Formatting.Indented));
        return RedirectToPage("Prodotti");
    }
}