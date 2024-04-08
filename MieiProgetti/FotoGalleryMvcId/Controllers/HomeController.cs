using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FotoGalleryMvcId.Models;
using Newtonsoft.Json;

namespace FotoGalleryMvcId.Controllers;

/// <summary>
/// Controller principale utenti non registrati.
/// </summary>
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    /// <summary>
    /// Costruttore del controller HomeController.
    /// </summary>
    /// <param name="logger">Logger per la registrazione di informazioni, avvisi, errori, ecc.</param>
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Azione per la visualizzazione della pagina principale con l'elenco delle immagini.
    /// </summary>
    /// <param name="pageIndex">Indice della pagina selezionata.</param>
    /// <returns>La vista Index con il modello IndexViewModel.</returns>
    public IActionResult Index(int? pageIndex = 1)
    {
        //memorizzo url per il ritorno
        string url = HttpContext.Request.Path + HttpContext.Request.QueryString;
        ViewBag.Url = url;

        //log che visualizza la pagina selezionata
        _logger.LogInformation("Index - PageIndex: {0}", pageIndex);

        // Inizializza gli attributi di classe nel modello
        var model = new IndexViewModel
        {
            PageIndex = pageIndex,
        };

        // Leggi il file JSON delle immagini
        var jsonFile = System.IO.File.ReadAllText(model.jsonPath);
        model.Immagini = JsonConvert.DeserializeObject<List<Immagine>>(jsonFile) ?? new List<Immagine>();

        // Leggi il file JSON delle categorie
        var jsonFile3 = System.IO.File.ReadAllText(model.jsonPath3);
        model.Categorie = JsonConvert.DeserializeObject<List<string>>(jsonFile3) ?? new List<string>();

        // Calcola il numero di pagine e la paginazione
        model.NumeroPagine = (int)Math.Ceiling((double)model.Immagini.Count() / 12);
        model.Immagini = model.Immagini.Skip(((pageIndex ?? 1) - 1) * 12).Take(12).ToList();

        return View(model);
    }

    /// <summary>
    /// Azione per la visualizzazione di una singola immagine.
    /// </summary>
    /// <param name="id">ID dell'immagine da visualizzare.</param>
    /// <param name="urlBack">URL della pagina precedente.</param>
    /// <returns>La vista Immagine con il modello ImmagineViewModel.</returns>
    public IActionResult Immagine(int id, string urlBack)
    {
        //memorizzo url per il ritorno
        ViewBag.Url = HttpContext.Request.Path + HttpContext.Request.QueryString;

        var model = new ImmagineViewModel
        {
            // memorizzo il valore passato dalla pagina precedente
            UrlBack = urlBack,

        };

        //verifica log
        _logger.LogInformation("url back : {0}", urlBack);

        // seleziono da tutte le immagini quella attuale
        var jsonFile = System.IO.File.ReadAllText(model.jsonPath);
        model.Immagine = JsonConvert.DeserializeObject<List<Immagine>>(jsonFile)!.First(i => i.Id == id);

        //carico i voti per la view della card immagine
        var jsonFile2 = System.IO.File.ReadAllText(model.jsonPath2);
        model.Voti = JsonConvert.DeserializeObject<List<Voto>>(jsonFile2)!;
        return View(model);
    }

    // <summary>
    /// Azione per la gestione degli errori.
    /// </summary>
    /// <returns>La vista Error con il modello ErrorViewModel.</returns>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
