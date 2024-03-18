using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppProdotti.Models;

namespace WebAppProdotti.Pages;

public class ProdottoDettaglioModel : PageModel
{
    public required Prodotto Prodotto { get; set; }


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
}

