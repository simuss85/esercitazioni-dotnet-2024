using FotoGalleryMvcId.Data;
using FotoGalleryMvcId.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;

namespace FotoGalleryMvcId.Controllers;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    //per la gestione dei file json
    private readonly Paths paths = new();
    //per la gestione del database
    private readonly ApplicationDbContext _db;
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly ILogger<AdminController> _logger;

    public AdminController(ILogger<AdminController> logger, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext db)
    {
        _logger = logger;
        _userManager = userManager;
        _roleManager = roleManager;
        _db = db;
    }

    /// <summary>
    /// Azione che crea la vista per la gestione degli utenti con una tabella con ordinamento variabile <br/>
    /// link per il dettaglio utenti, tasti per gestione status, ruoli e elimina utente.
    /// </summary>
    /// <param name="pageIndex">Il numero attuale della pagina</param>
    /// <param name="reverse">Il valore per la gestione dell'ordinamento tabella</param>
    /// <returns>La vista gestione utenti con il modello GestioneUtentiViewModel</returns>
    [HttpGet]
    public async Task<IActionResult> GestioneUtenti(int pageIndex = 1, string reverse = "idOff", string menuRuoli = "")
    {
        //memorizzo UrlBack in un ViewBag
        ViewBag.UrlBack = HttpContext.Request.Path;

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
            MenuRuoli = menuRuoli
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
    /// <returns>La vista gestione utenti con il modello GestioneUtentiViewModel dopo la modifica dello status</returns>
    public async Task<IActionResult> GestisciStatus(string id, string urlBack)
    {
        _logger.LogInformation("{0} - GestisciStatus --> (IdUtente: {1} - UrlBack: {2})", DateTime.Now.ToString("T"), id, urlBack);

        //carico i dati dell'utente attuale
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        user.Status = !user.Status;
        await _userManager.UpdateAsync(user);

        #region db

        //messaggio per status
        string status = user.Status == false ? "Bloccato" : "Attivato";
        //creo oggetto log per il db
        Log log = new Log
        {
            DataOperazione = DateTime.Now,
            Alias = user!.Alias,
            Email = user.Email,
            Ruoli = user.Ruoli,
            OperazioneSvolta = $"Status modificato: utente {status}",
            Tipologia = true   //true = UserExperience; false = Administrative
        };
        //salvo nel db
        await _db.Logs.AddAsync(log);
        await _db.SaveChangesAsync();

        #endregion

        // Controlla se l'URL contiene la stringa della pagina "GestioneUtenti"
        if (urlBack.Contains("GestioneUtenti"))
        {
            return RedirectToAction(nameof(GestioneUtenti));
        }
        else
        {

            return RedirectToAction(nameof(CardUtente), new { id = user.Id });
        }

    }

    public async Task<IActionResult> MenuRuoli(string id, string urlBack)
    {
        _logger.LogInformation("{0} - MenuRuoli --> (IdUtente: {1} - UrlBack: {2})", DateTime.Now.ToString("T"), id, urlBack);

        //passo il valore per la partial

        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        // Controlla se l'URL contiene la stringa della pagina "CardUtente"
        if (urlBack.Contains("GestioneUtenti"))
        {
            return RedirectToAction(nameof(GestioneUtenti), new { menuRuoli = user.Email });
        }
        else
        {

            return RedirectToAction(nameof(CardUtente), new { id = user.Id, menuRuoli = user.Email });
        }
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

            #region db
            //creo oggetto log per il db
            Log log = new Log
            {
                DataOperazione = DateTime.Now,
                Alias = user!.Alias,
                Email = user.Email,
                Ruoli = user.Ruoli,
                OperazioneSvolta = $"Utente eliminato: utente {user.Email}",
                Tipologia = true   //true = UserExperience; false = Administrative
            };
            //salvo nel db
            await _db.Logs.AddAsync(log);
            await _db.SaveChangesAsync();

            #endregion

            return RedirectToAction(nameof(GestioneUtenti));
        }

        return RedirectToAction(nameof(GestioneUtenti));
    }


    /// <summary>
    /// Azione che permette di visualizzare la card dei dettagli utente.
    /// </summary>
    /// <param name="id">Il codice identificativo dell'utente da modificare</param>
    /// <param name="urlBack">Gestisce il tasto di ritorno</param>
    /// <returns>La vista card utente con il modello CardUtentiViewModel</returns>
    [HttpGet]
    public async Task<IActionResult> CardUtente(string id, string menuRuoli = "")
    {
        //memorizzo UrlBack in un ViewBag
        ViewBag.UrlBack = HttpContext.Request.Path;

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
            MenuRuoli = menuRuoli
        };

        //log che visualizza la pagina selezionata, user, urlBack e orario
        _logger.LogInformation("{0} - Card Utente --> (UserId: {1})", DateTime.Now.ToString("T"), id);
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> GestioneRuoli(GestioneRuoliViewModel model)
    {
        // Trova l'utente
        var user = await _userManager.FindByIdAsync(model.Id!);
        if (user == null)
        {
            // Se l'utente non esiste, ritorna una vista di errore o reindirizza a una pagina di errore
            return NotFound("Utente non trovato");
        }
        //memorizzo i ruoli attuali dell'utente (oppure utilizzo la proprietà Ruoli)
        var ruoliUtente = await _userManager.GetRolesAsync(user);

        //gestione della lista vuota per il log
        int numeroRuoliScelti = 0;

        if (model.Ruoli != null)    //se la lista non è vuota eseguo le operazioni
        {
            //per il log
            numeroRuoliScelti = model.Ruoli.Count;

            //assegno i ruoli della lista e verifico che l'operazione vada a buon fine
            var conferma = await _userManager.AddToRolesAsync(user, model.Ruoli.Except(ruoliUtente));

            if (!conferma.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Impossibile aggiungere i ruoli selezionati all'utente.");
                return View(model);
            }
            {
                user.Ruoli = "";

                //assegno anche alla proprietà Ruoli
                user.Ruoli = string.Join(" ,", model.Ruoli);
            }

            //elimino ruoli dall'utente
            conferma = await _userManager.RemoveFromRolesAsync(user, ruoliUtente.Except(model.Ruoli));

            if (!conferma.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Impossibile rimuovere i ruoli selezionati dall'utente.");
                return View(model);
            }

        }
        else    //elimino tutti i ruoli (blocco l'utente)
        {
            user.Ruoli = "-----";
            var blocca = await _userManager.RemoveFromRolesAsync(user, ruoliUtente);

            if (!blocca.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Impossibile rimuovere i ruoli selezionati dall'utente.");
                return View(model);
            }
        }

        //Aggiorno i ruoli nel campo Ruoli
        var ruoliAggiornati = await _userManager.GetRolesAsync(user);


        //log che visualizza la pagina selezionata, user id, urlBack e orario
        _logger.LogInformation("{0} - Gestione Ruoli --> (User: {1} - UrlBack: {2} - NumeroRuoliScelti: {3} - (PRE)Ruoli Utente: {4} - (POST)Ruoli Utente: {5})", DateTime.Now.ToString("T"), user.Alias, model.UrlBack, numeroRuoliScelti, ruoliUtente, ruoliAggiornati);

        #region db

        //messaggio per status
        string ruoliPre = string.Join(" ,", ruoliUtente);
        string ruoliPost = ruoliAggiornati.Count > 0 ? string.Join(" ,", ruoliAggiornati) : "-----";
        //creo oggetto log per il db
        Log log = new Log
        {
            DataOperazione = DateTime.Now,
            Alias = user!.Alias,
            Email = user.Email,
            Ruoli = user.Ruoli,
            OperazioneSvolta = $"Ruoli modificati: da {ruoliPre} a {ruoliPost}",
            Tipologia = false   //true = UserExperience; false = Administrative
        };
        //salvo nel db
        await _db.Logs.AddAsync(log);
        await _db.SaveChangesAsync();

        #endregion

        // Controlla se l'URL contiene la stringa della pagina "CardUtente"
        if (model.UrlBack!.Contains("GestioneUtenti"))
        {
            return RedirectToAction(nameof(GestioneUtenti), new { menuRuoli = "" });
        }
        else
        {

            return RedirectToAction(nameof(CardUtente), new { id = model.Id, menuRuoli = "" });
        }
    }

    [HttpGet]
    public async Task<IActionResult> Log(int pageIndex = 1, string reverse = "idOff")
    {
        // creo il modello per gestire la view
        var model = new LogViewModel
        {
            ElementiPerPagina = 15,
            PageIndex = pageIndex,
            Reverse = reverse,
            Logs = await _db.Logs.ToListAsync()
        };

        _logger.LogInformation("{0} - Logs --> (PageIndex: {1} - Reverse: {2})", DateTime.Now.ToString("T"), pageIndex, reverse);

        // //gestione ordinameneto tabella
        switch (reverse)
        {
            case "idOff":
                model.Logs = model.Logs.OrderByDescending(u => u.Id);
                break;

            case "idOn":
                model.Logs = model.Logs.OrderBy(u => u.Id);
                break;

            case "dataOff":
                model.Logs = model.Logs.OrderByDescending(u => u.DataOperazione);
                break;

            case "dataOn":
                model.Logs = model.Logs.OrderBy(u => u.DataOperazione);
                break;

            case "aliasOff":
                model.Logs = model.Logs.OrderByDescending(u => u.Alias);
                break;

            case "aliasOn":
                model.Logs = model.Logs.OrderBy(u => u.Alias);
                break;

            case "emailOff":
                model.Logs = model.Logs.OrderByDescending(u => u.Email);
                break;

            case "emailOn":
                model.Logs = model.Logs.OrderBy(u => u.Email);
                break;

            case "ruoloOff":
                model.Logs = model.Logs.OrderByDescending(u => u.Ruoli);
                break;

            case "ruoloOn":
                model.Logs = model.Logs.OrderBy(u => u.Ruoli);
                break;

            case "operazioneOff":
                model.Logs = model.Logs.OrderByDescending(u => u.OperazioneSvolta);
                break;

            case "operazioneOn":
                model.Logs = model.Logs.OrderBy(u => u.OperazioneSvolta);
                break;

            case "tipologiaOff":
                model.Logs = model.Logs.OrderByDescending(u => u.Tipologia);
                break;

            case "tipologiaOn":
                model.Logs = model.Logs.OrderBy(u => u.Tipologia);
                break;

            default:
                model.Logs = model.Logs.OrderByDescending(u => u.Id);
                break;
        }

        //paginazione dei logs
        model.NumeroPagine = (int)Math.Ceiling((double)model.Logs.Count() / model.ElementiPerPagina);
        model.Logs = model.Logs.Skip((pageIndex - 1) * model.ElementiPerPagina).Take(model.ElementiPerPagina);

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> EliminaLog(LogViewModel model)
    {
        _logger.LogInformation("{0} - EliminaLog --> (IdLog: {1})", DateTime.Now.ToString("T"), model.IdLog);
        //assicura che i dati inviati siano validi, altrimenti ricarica la pagina
        if (!ModelState.IsValid)
        {
            return RedirectToAction("Log", "Admin", new { pageIndex = model.PageIndex, reverse = model.Reverse });
        }
        else
        {
            //scansiono la tagbella dei logs
            foreach (var log in _db.Logs)
            {
                if (log.Id == model.IdLog)
                {
                    _db.Logs.Remove(log);
                    break;
                }
            }
            await _db.SaveChangesAsync();
            return RedirectToAction("Log", "Admin", new { pageIndex = model.PageIndex, reverse = model.Reverse });
        }
    }
}

