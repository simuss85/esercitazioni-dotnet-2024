using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FotoGalleryMvcId.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace FotoGalleryMvcId.Controllers;

[Authorize(Roles = "Admin, Moderatore")]
public class ModeratoreController : Controller
{
    //per la gestione dei file json
    private readonly Paths paths = new();

    //per la gestione dell'utente
    private readonly UserManager<AppUser> _userManager;
    private readonly ILogger<ModeratoreController> _logger;

    public ModeratoreController(ILogger<ModeratoreController> logger, UserManager<AppUser> userManager)
    {
        _logger = logger;
        _userManager = userManager;
    }

    /// <summary>
    /// Azione che crea la vista gestione immagine con una tabella con ordinamento variabile <br/>
    /// e tasti selezione checkbox e dropdown.
    /// </summary>
    /// <param name="pageIndex">Il numero attuale della pagina</param>
    /// <param name="reverse">Il valore per la gestione dell'ordinamento tabella</param>
    /// <returns>La vista gestione immagine con il modello ClassificaViewModel</returns>
    [HttpGet]
    public IActionResult GestisciImmagini(int pageIndex = 1, string reverse = "idOff")
    {
        //memorizzo UrlBack in un ViewBag
        ViewBag.UrlBack = HttpContext.Request.Path + HttpContext.Request.QueryString;

        // creo il modello per gestire la view
        var model = new GestisciImmaginiViewModel
        {
            PageIndex = pageIndex,
            Reverse = reverse
        };

        var jsonFileImm = System.IO.File.ReadAllText(paths.PathImmagini);
        model.Immagini = JsonConvert.DeserializeObject<List<Immagine>>(jsonFileImm)!.OrderByDescending(i => i.Id);

        //gestione ordinameneto tabella
        switch (reverse)
        {
            case "idOff":
                model.Immagini = model.Immagini.OrderByDescending(i => i.Id);
                break;

            case "idOn":
                model.Immagini = model.Immagini.OrderBy(i => i.Id);
                break;

            case "dataOff":
                model.Immagini = model.Immagini.OrderByDescending(i => i.Data);
                break;

            case "dataOn":
                model.Immagini = model.Immagini.OrderBy(i => i.Data);
                break;

            case "autoreOff":
                model.Immagini = model.Immagini.OrderByDescending(i => i.Autore);
                break;

            case "autoreOn":
                model.Immagini = model.Immagini.OrderBy(i => i.Autore);
                break;

            case "titoloOff":
                model.Immagini = model.Immagini.OrderByDescending(i => i.Titolo);
                break;

            case "titoloOn":
                model.Immagini = model.Immagini.OrderBy(i => i.Titolo);
                break;

            default:
                model.Immagini = model.Immagini.OrderByDescending(v => v.Id);
                break;
        }

        //paginazione
        model.NumeroPagine = (int)Math.Ceiling((double)model.Immagini.Count() / 10);
        model.Immagini = model.Immagini.Skip((pageIndex - 1) * 10).Take(10);

        _logger.LogInformation("{0} - GestioneImmagine --> (PageIndex: {1} - Reverse: {2})", DateTime.Now.ToString("T"), pageIndex, reverse);

        return View(model);
    }

    /// <summary>
    /// Azione che crea la vista elimina immagine con tasto elimina e annulla.
    /// </summary>
    /// <param name="selezione">La lista delle immagini selezionate per essere eliminate</param>
    /// <returns>La vista elimina immagine con il modello EliminaImmagineViewModel</returns>
    [HttpGet]
    public IActionResult EliminaImmagine(List<int> selezione)
    {
        // creo il modello per gestire la view
        var model = new EliminaImmagineViewModel
        {
            Selezione = selezione
        };

        _logger.LogInformation("{0} - Elimina immagine --> (Oggetti selezionati: {1})", DateTime.Now.ToString("T"), selezione);

        var jsonFileImm = System.IO.File.ReadAllText(paths.PathImmagini);
        model.Immagini = JsonConvert.DeserializeObject<List<Immagine>>(jsonFileImm)!;

        return View(model);
    }

    [HttpPost]
    public IActionResult EliminaImmagine(EliminaImmagineViewModel model)
    {
        var jsonFileImm = System.IO.File.ReadAllText(paths.PathImmagini);
        model.Immagini = JsonConvert.DeserializeObject<List<Immagine>>(jsonFileImm)!;

        foreach (var id in model.Selezione!)
        {
            _logger.LogInformation("Selezione: {0}", id);
            model.Immagini.Remove(model.Immagini.First(i => i.Id == id));
        }
        System.IO.File.WriteAllText(paths.PathImmagini, JsonConvert.SerializeObject(model.Immagini, Formatting.Indented));

        return RedirectToAction(nameof(GestisciImmagini));
    }
}