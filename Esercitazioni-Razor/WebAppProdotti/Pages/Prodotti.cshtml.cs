using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppProdotti.Models;

namespace WebAppProdotti.Pages;

public class ProdottiModel : PageModel
{
    public required int numeroPagine { get; set; }
    private readonly ILogger<ProdottiModel> _logger;

    public ProdottiModel(ILogger<ProdottiModel> logger)
    {
        _logger = logger;
    }

    public required IEnumerable<Prodotto> Prodotti { get; set; } //creo oggetto di tipo lista
    public void OnGet(decimal? minPrezzo, decimal? maxPrezzo, int? pageIndex)
    {
        //aggiungi un log
        _logger.LogInformation("Tabella prodotti");
        Prodotti = new List<Prodotto>
        {
            new Prodotto {Nome = "Prodotto 1", Prezzo = 100, Dettaglio = "Descrizione prodotto 1"},
            new Prodotto {Nome = "Prodotto 2", Prezzo = 200, Dettaglio = "Descrizione prodotto 2"},
            new Prodotto {Nome = "Prodotto 3", Prezzo = 300, Dettaglio = "Descrizione prodotto 3"},
            new Prodotto {Nome = "Prodotto 4", Prezzo = 400, Dettaglio = "Descrizione prodotto 4"},
            new Prodotto {Nome = "Prodotto 5", Prezzo = 500, Dettaglio = "Descrizione prodotto 5"},
            new Prodotto {Nome = "Prodotto 6", Prezzo = 600, Dettaglio = "Descrizione prodotto 6"},
            new Prodotto {Nome = "Prodotto 7", Prezzo = 700, Dettaglio = "Descrizione prodotto 7"},
            new Prodotto {Nome = "Prodotto 8", Prezzo = 800, Dettaglio = "Descrizione prodotto 8"},
            new Prodotto {Nome = "Prodotto 9", Prezzo = 900, Dettaglio = "Descrizione prodotto 9"},
            new Prodotto {Nome = "Prodotto 10", Prezzo = 100, Dettaglio = "Descrizione prodotto 10"},
            new Prodotto {Nome = "Prodotto 11", Prezzo = 200, Dettaglio = "Descrizione prodotto 11"},
            new Prodotto {Nome = "Prodotto 12", Prezzo = 300, Dettaglio = "Descrizione prodotto 12"},
            new Prodotto {Nome = "Prodotto 13", Prezzo = 300, Dettaglio = "Descrizione prodotto 13"},
            new Prodotto {Nome = "Prodotto 14", Prezzo = 400, Dettaglio = "Descrizione prodotto 14"},
            new Prodotto {Nome = "Prodotto 15", Prezzo = 500, Dettaglio = "Descrizione prodotto 15"},
            new Prodotto {Nome = "Prodotto 16", Prezzo = 600, Dettaglio = "Descrizione prodotto 16"},
            new Prodotto {Nome = "Prodotto 17", Prezzo = 100, Dettaglio = "Descrizione prodotto 17"},
            new Prodotto {Nome = "Prodotto 18", Prezzo = 200, Dettaglio = "Descrizione prodotto 18"},
            new Prodotto {Nome = "Prodotto 19", Prezzo = 300, Dettaglio = "Descrizione prodotto 19"},
            new Prodotto {Nome = "Prodotto 20", Prezzo = 300, Dettaglio = "Descrizione prodotto 20"},
            new Prodotto {Nome = "Prodotto 21", Prezzo = 400, Dettaglio = "Descrizione prodotto 21"},
            new Prodotto {Nome = "Prodotto 22", Prezzo = 500, Dettaglio = "Descrizione prodotto 22"},
            new Prodotto {Nome = "Prodotto 23", Prezzo = 600, Dettaglio = "Descrizione prodotto 23"},
            new Prodotto {Nome = "Prodotto 24", Prezzo = 100, Dettaglio = "Descrizione prodotto 24"},
            new Prodotto {Nome = "Prodotto 25", Prezzo = 200, Dettaglio = "Descrizione prodotto 25"},
            new Prodotto {Nome = "Prodotto 26", Prezzo = 300, Dettaglio = "Descrizione prodotto 26"},
            new Prodotto {Nome = "Prodotto 27", Prezzo = 300, Dettaglio = "Descrizione prodotto 27"},
            new Prodotto {Nome = "Prodotto 28", Prezzo = 400, Dettaglio = "Descrizione prodotto 28"},
            new Prodotto {Nome = "Prodotto 29", Prezzo = 500, Dettaglio = "Descrizione prodotto 29"},
        };
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

