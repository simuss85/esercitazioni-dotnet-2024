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
    public IActionResult Index()
    {
        return View();
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
