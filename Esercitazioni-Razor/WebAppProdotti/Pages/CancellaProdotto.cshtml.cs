using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppProdotti.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace WebAppProdotti.Pages;

public class CancellaProdottoModel : PageModel
{
    public required string jsonPath = "wwwroot/json/prodotti.json";
    public required Prodotto Prodotto { get; set; }

    #region Logger
    private readonly ILogger<CancellaProdottoModel> _logger;

    public CancellaProdottoModel(ILogger<CancellaProdottoModel> logger)
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

    public IActionResult OnPost(string nome)
    {
        var jsonFile = System.IO.File.ReadAllText(jsonPath);
        var prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(jsonFile)!;

        prodotti.Remove(prodotti.First(p => p.Nome == nome));
        System.IO.File.WriteAllText(jsonPath, JsonConvert.SerializeObject(prodotti, Formatting.Indented));
        return RedirectToPage("Prodotti");
    }
}