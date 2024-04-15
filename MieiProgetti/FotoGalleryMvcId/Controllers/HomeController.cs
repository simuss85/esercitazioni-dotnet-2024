using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FotoGalleryMvcId.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity;

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
    /// Azione per la visualizzazione della pagina. Nel caso l'utente sia loggato in precedenza, viene reindirizzato <br/>
    /// alla route corrette.
    /// </summary>
    /// <param name="pageIndex">Indice della pagina selezionata.</param>
    /// <returns>La view principale a seconda dell'utente autenticato oppure no.</returns>
    public IActionResult Index()
    {
        if (User.Identity!.IsAuthenticated)
        {
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("GestioneUtenti", "Admin");
            }
            else if (User.IsInRole("Moderatore"))
            {
                return RedirectToAction("ModeraCommenti", "Moderatore");
            }
            else
            {
                return RedirectToAction("Immagini", "User");
            }

        }
        else
        {
            return View();
        }

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
