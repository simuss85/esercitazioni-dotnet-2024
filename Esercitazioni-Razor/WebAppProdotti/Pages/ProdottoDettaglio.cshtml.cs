using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WebAppProdotti.Models;

namespace WebAppProdotti.Pages;

public class ProdottoDettaglioModel : PageModel
{
    public required Prodotto Prodotto { get; set; }
    public required string jsonPath = "wwwroot/json/prodotti.json";
    public required IEnumerable<Prodotto> Prodotti { get; set; }

    private readonly ILogger<ProdottoDettaglioModel> _logger;

    public ProdottoDettaglioModel(ILogger<ProdottoDettaglioModel> logger)
    {
        _logger = logger;
    }

    public void OnGet(Prodotto prodotto)
    {
        Prodotto = prodotto;
        _logger.LogInformation($"nome: {prodotto.Nome}, prezzo: {prodotto.Prezzo}, dettaglio: {prodotto.Dettaglio}");

        // _logger.LogInformation($"***assegnamento***nome: {Prodotto.Nome}, prezzo: {Prodotto.Prezzo}, dettaglio: {Prodotto.Dettaglio}");

    }

    public void OnPost(Prodotto prodotto)
    {
        _logger.LogInformation("prodotto: {0} prezzo nuovo: {1} ", prodotto.Nome, prodotto.Prezzo);
        string jsonFile = System.IO.File.ReadAllText(jsonPath);
        Prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(jsonFile)!;
        foreach (var p in Prodotti)
        {
            if (p.Nome == prodotto.Nome)
            {
                p.Prezzo = prodotto.Prezzo;
            }
        }

        System.IO.File.WriteAllText(jsonPath, JsonConvert.SerializeObject(Prodotti));
    }
}

