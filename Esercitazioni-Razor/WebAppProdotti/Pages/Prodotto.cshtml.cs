using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppProdotti.Models;

namespace WebAppProdotti.Pages;

public class ProdottoModel : PageModel
{
    private readonly ILogger<ProdottoModel> _logger;    //non è necessario

    public ProdottoModel(ILogger<ProdottoModel> logger)
    {
        _logger = logger;
    }

    public IEnumerable<Prodotto>? Prodotti { get; set; } //creo oggetto di tipo lista
    public void OnGet()
    {
        Prodotti = new List<Prodotto>
        {
            new Prodotto {Nome = "Prodotto 1", Prezzo = 100},
            new Prodotto {Nome = "Prodotto 2", Prezzo = 200},
            new Prodotto {Nome = "Prodotto 3", Prezzo = 300}
        };
    }
}

