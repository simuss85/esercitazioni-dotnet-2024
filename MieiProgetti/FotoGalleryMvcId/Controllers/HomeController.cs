using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FotoGalleryMvcId.Models;
using Newtonsoft.Json;

namespace FotoGalleryMvcId.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// GET: Utenti non registrati
    /// </summary>
    /// <param name="pageIndex">La pagina attuale attiva</param>
    /// <returns>Home/Index</returns>
    public IActionResult Index(int? pageIndex)
    {

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


    public IActionResult Immagine(int id, string urlBack)
    {
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

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
