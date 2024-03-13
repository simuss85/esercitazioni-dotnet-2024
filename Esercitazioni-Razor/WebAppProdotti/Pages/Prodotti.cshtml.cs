using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppProdotti.Models;

namespace WebAppProdotti.Pages;

public class ProdottiModel : PageModel
{
    private readonly ILogger<ProdottiModel> _logger;    //non è necessario

    public ProdottiModel(ILogger<ProdottiModel> logger)
    {
        _logger = logger;
    }

    public required IEnumerable<Prodotto> Prodotti { get; set; } //creo oggetto di tipo lista
    public void OnGet()
    {
        Prodotti = new List<Prodotto>
        {
            new Prodotto {Nome = "Prodotto 1", Prezzo = 100, Dettaglio = "Descrizione prodotto 1"},
            new Prodotto {Nome = "Prodotto 2", Prezzo = 200, Dettaglio = "Descrizione prodotto 2"},
            new Prodotto {Nome = "Prodotto 3", Prezzo = 300, Dettaglio = "Descrizione prodotto 3"}
        };
    }
}

