using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FotoGalleryMvcId.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace FotoGalleryMvcId.Controllers;

[Authorize(Roles = "Moderatore")]
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
}