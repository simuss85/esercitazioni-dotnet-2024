using FotoGalleryMvcId.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;

namespace FotoGalleryMvcId.Controllers;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    //per la gestione dei file json
    private readonly Paths paths = new();

    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly ILogger<AdminController> _logger;

    public AdminController(ILogger<AdminController> logger, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _logger = logger;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    /// <summary>
    /// Azione che crea la vista per la gestione degli utenti con una tabella con ordinamento variabile <br/>
    /// link per il dettaglio utenti, tasti per gestione status, ruoli e elimina utente.
    /// </summary>
    /// <param name="pageIndex">Il numero attuale della pagina</param>
    /// <param name="reverse">Il valore per la gestione dell'ordinamento tabella</param>
    /// <returns>La vista gestione utenti con il modello GestioneUtentiViewModel</returns>
    [HttpGet]
    public async Task<IActionResult> GestioneUtenti(int pageIndex = 1, string reverse = "idOff", string partial = "tutti")
    {
        //memorizzo UrlBack in un ViewBag
        ViewBag.UrlBack = HttpContext.Request.Path + HttpContext.Request.QueryString;

        //seleziono l'utene attuale
        var user = await _userManager.GetUserAsync(User);

        //creo il modello per gestire la view
        var model = new GestioneUtentiViewModel
        {
            //genero la lista degli utenti del sistema
            Utenti = await _userManager.Users.ToListAsync(),
            ElementiPerPagina = 10,
            PageIndex = pageIndex,
            Reverse = reverse,
            Partial = partial
        };

        //rimuovo l'utente attuale dalla lista
        if (user != null)
        {
            model.Utenti = model.Utenti.Where(u => u.Id != user.Id).ToList();
        }


        //log che visualizza la pagina selezionata, user e orario
        _logger.LogInformation("{0} - GestioneUtenti --> (PageIndex: {1} - Reverse: {2})", DateTime.Now.ToString("T"), pageIndex, reverse);

        //gestione ordinameneto tabella
        switch (reverse)
        {
            case "idOff":
                model.Utenti = model.Utenti.OrderByDescending(u => u.Id);
                break;

            case "idOn":
                model.Utenti = model.Utenti.OrderBy(u => u.Id);
                break;

            case "aliasOff":
                model.Utenti = model.Utenti.OrderByDescending(u => u.Alias);
                break;

            case "aliasOn":
                model.Utenti = model.Utenti.OrderBy(u => u.Alias);
                break;

            case "ruoloOff":
                model.Utenti = model.Utenti.OrderByDescending(u => u.Ruoli);
                break;

            case "ruoloOn":
                model.Utenti = model.Utenti.OrderBy(u => u.Ruoli);
                break;

            case "emailOff":
                model.Utenti = model.Utenti.OrderByDescending(u => u.Email);
                break;

            case "emailOn":
                model.Utenti = model.Utenti.OrderBy(u => u.Email);
                break;

            case "statusOff":
                model.Utenti = model.Utenti.OrderByDescending(u => u.Status);
                break;

            case "statusOn":
                model.Utenti = model.Utenti.OrderBy(u => u.Status);
                break;

            default:
                model.Utenti = model.Utenti.OrderByDescending(u => u.Id);
                break;
        }

        // //paginazione 
        model.NumeroPagine = (int)Math.Ceiling((double)model.Utenti.Count() / model.ElementiPerPagina);
        model.Utenti = model.Utenti.Skip((pageIndex - 1) * model.ElementiPerPagina).Take(model.ElementiPerPagina);

        return View(model);
    }

    /// <summary>
    /// Azione che permette di modificare lo status di ogni utente.
    /// </summary>
    /// <param name="id">Il codice identificativo dell'utente da modificare</param>
    /// <param name="cardBack">Se true invia la richiesta alla view CardUtente</param>
    /// <returns>La vista gestione utenti con il modello GestioneUtentiViewModel dopo la modifica dello status</returns>
    public async Task<IActionResult> GestisciStatus(string id, bool cardBack = false)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        user.Status = !user.Status;
        await _userManager.UpdateAsync(user);

        //reindirizza alla pagina corretta
        if (cardBack == true)
        {
            return RedirectToAction(nameof(CardUtente), new { id = user.Id });
        }
        else
        {
            return RedirectToAction(nameof(GestioneUtenti));
        }

    }

    public async Task<IActionResult> GestisciRuoli(string id, bool modifica)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        if (modifica)
        {

        }

        return RedirectToAction();
    }


    /// <summary>
    /// (PRE) Azione per l'eliminazione di un utente
    /// </summary>
    /// <param name="id">Il codice identificativo dell'utente da modificare</param>
    /// <returns>La vista gestione utenti con il modello GestioneUtentiViewModel</returns>
    public async Task<IActionResult> EliminaUtente(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
        {
            return NotFound("Utente non trovato");
        }

        return View(user);
    }

    /// <summary>
    /// (POST) Azione per l'eliminazione di un utente
    /// </summary>
    /// <param name="id">Il codice identificativo dell'utente da modificare</param>
    /// <param name="conferma">Valore true di conferma per l'eliminiazione utente</param>
    /// <returns>La vista gestione utenti con il modello GestioneUtentiViewModel dopo l'eliminazione dell'utente</returns>
    [HttpPost]
    public async Task<IActionResult> EliminaUtente(string id, bool conferma)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        if (conferma)
        {
            await _userManager.DeleteAsync(user);
            return RedirectToAction(nameof(GestioneUtenti));
        }

        return RedirectToAction(nameof(GestioneUtenti));
    }


    /// <summary>
    /// Azione che permette di visualizzare la card dei dettagli utente.
    /// </summary>
    /// <param name="id">Il codice identificativo dell'utente da modificare</param>
    /// <param name="urlBack"></param>
    /// <returns>La vista card utente con il modello CardUtentiViewModel</returns>
    [HttpGet]
    public async Task<IActionResult> CardUtente(string id, string urlBack = "")
    {
        // Trova l'utente
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
        {
            // Se l'utente non esiste, ritorna una vista di errore o reindirizza a una pagina di errore
            return NotFound("Utente non trovato");
        }

        // Passa l'utente al modello
        var model = new CardUtenteViewModel
        {
            Utente = user,
            UrlBack = urlBack
        };

        //log che visualizza la pagina selezionata, user, urlBack e orario
        _logger.LogInformation("{0} - Dettaglio Immagine --> (UserId: {1} - UrlBack: {2})", DateTime.Now.ToString("T"), id, urlBack);
        return View(model);
    }



}