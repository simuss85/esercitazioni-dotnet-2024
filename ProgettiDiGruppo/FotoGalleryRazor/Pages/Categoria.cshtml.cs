using FotoGalleryRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace FotoGalleryRazor.Pages;

public class CategoriaModel : PageModel
{
    public int NumeroPagine { get; set; }  //totale pagine per la paginazione
    public string? Categoria { get; set; } //categoria attuale
    public int? PageCategoria { get; set; }//pagina attuale
    public required IEnumerable<Immagine> Immagini { get; set; }

    public string jsonPath = @"wwwroot/json/immagini.json";

    #region  Logger
    private readonly ILogger<CategoriaModel> _logger;

    public CategoriaModel(ILogger<CategoriaModel> logger)
    {
        _logger = logger;
    }
    #endregion

    public void OnGet(int? pageCategoria, string? categoria)
    {
        //verifico che i dati vengono passati al get con un messaggio console
        _logger.LogInformation("Categoria: {0}, Numero pagina: {1}", categoria, pageCategoria);

        // carico il file categorie.json e seleziono solo la categoria passata al get
        var jsonFile = System.IO.File.ReadAllText(jsonPath);
        Immagini = JsonConvert.DeserializeObject<List<Immagine>>(jsonFile)!.Where(i => i.Categoria == categoria);

        //verifico se ci sono immagini per la categoria attuale
        if (!Immagini.Any())
        {
            RedirectToPage("/Error");
        }
        else
        {
            //assegno i valori passati al get agli attributi di classe
            Categoria = categoria;
            PageCategoria = pageCategoria;

            //calcolo il numero di pagine per la paginazione
            NumeroPagine = (int)Math.Ceiling((double)Immagini.Count() / 12);
            Immagini = Immagini.Skip(((pageCategoria ?? 1) - 1) * 12).Take(12);
        }

    }
}
