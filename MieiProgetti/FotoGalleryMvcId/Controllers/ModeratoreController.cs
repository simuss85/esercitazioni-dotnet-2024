using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FotoGalleryMvcId.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using FotoGalleryMvcId.Data;

namespace FotoGalleryMvcId.Controllers;

[Authorize(Roles = "Admin, Moderatore")]
public class ModeratoreController : Controller
{
    //per la gestione dei file json
    private readonly Paths paths = new();

    //per la gestione del db
    private readonly ApplicationDbContext _db;

    //per la gestione dell'utente
    private readonly UserManager<AppUser> _userManager;
    private readonly ILogger<ModeratoreController> _logger;

    public ModeratoreController(ILogger<ModeratoreController> logger, UserManager<AppUser> userManager, ApplicationDbContext db)
    {
        _logger = logger;
        _userManager = userManager;
        _db = db;
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

        _logger.LogInformation("{0} - EliminaImmagine --> (Oggetti selezionati: {1})", DateTime.Now.ToString("T"), selezione);

        var jsonFileImm = System.IO.File.ReadAllText(paths.PathImmagini);
        model.Immagini = JsonConvert.DeserializeObject<List<Immagine>>(jsonFileImm)!;

        return View(model);
    }

    /// <summary>
    /// Azione che gestisce il form di eliminazione delleimmagine
    /// </summary>
    /// <param name="model">Il modello da caricare nella view dopo l'invio dei dati dal form</param>
    /// <returns>La vista gestisci immagini con il modello EliminaImmagineViewModel dopo l'eliminazione</returns>
    [HttpPost]
    public async Task<IActionResult> EliminaImmagine(EliminaImmagineViewModel model)
    {
        var jsonFileImm = System.IO.File.ReadAllText(paths.PathImmagini);
        model.Immagini = JsonConvert.DeserializeObject<List<Immagine>>(jsonFileImm)!;

        foreach (var id in model.Selezione!)
        {
            _logger.LogInformation("Selezione: {0}", id);
            model.Immagini.Remove(model.Immagini.First(i => i.Id == id));
        }
        System.IO.File.WriteAllText(paths.PathImmagini, JsonConvert.SerializeObject(model.Immagini, Formatting.Indented));

        //log immagine aggiunta correttamente 
        _logger.LogInformation("{0} - Elimina immagine --> (Immagini: {1})", DateTime.Now.ToString("T"), model.Selezione);

        #region db
        //carico i dati dell'utente attuale
        var user = await _userManager.GetUserAsync(User);

        //messaggio per immagini/immagine
        string messaggio = model.Selezione.Count > 1 ? "immagini eliminate" : "immagine eliminata";

        //creo oggetto log per il db
        Log log = new Log
        {
            DataOperazione = DateTime.Now,
            Alias = user!.Alias,
            Email = user.Email,
            Ruoli = user.Ruoli,
            OperazioneSvolta = $"Elimina immagini: {model.Selezione.Count} {messaggio}",
            Tipologia = true   //true = UserExperience; false = Administrative
        };
        //salvo nel db
        await _db.Logs.AddAsync(log);
        await _db.SaveChangesAsync();

        #endregion

        return RedirectToAction(nameof(GestisciImmagini));
    }

    [HttpGet]
    public IActionResult ModificaImmagini(List<int> selezione)
    {
        // creo il modello per gestire la view
        var model = new ModificaImmaginiViewModel
        {
            Selezione = selezione
        };

        _logger.LogInformation("{0} - Modifica immagine --> (Oggetti selezionati: {1})", DateTime.Now.ToString("T"), selezione);

        var jsonFileImm = System.IO.File.ReadAllText(paths.PathImmagini);
        model.Immagini = JsonConvert.DeserializeObject<List<Immagine>>(jsonFileImm)!;

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> ModificaImmagini(ModificaImmaginiViewModel model)
    {
        //assicura che i dati inviati siano validi, altrimenti ricarica la pagina
        if (!ModelState.IsValid)
        {
            //log errore selezione
            _logger.LogInformation("{0} - Errore validazione modulo (Errori: {1})", DateTime.Now.ToString("T"), ModelState.ErrorCount.ToString());
            return View(model);
        }
        else
        {
            _logger.LogInformation("{0} - Modifica Immegini --> (Avvio salvataggio dati)", DateTime.Now.ToString("T"));
            // Verifica se la lista delle immagini modificate è vuota
            if (model.ImgMod != null && model.ImgMod.Count != 0)
            {
                foreach (var img in model.ImgMod!)
                {
                    _logger.LogInformation("ID: {0}", img.Id);
                    foreach (var i in model.Immagini)
                    {
                        if (i.Id == img.Id)
                        {
                            i.Autore = img.Autore;
                            i.Titolo = img.Titolo;
                            i.Categoria = img.Categoria;
                            i.Path = img.Path;
                            break;
                        }
                    }
                }

                //salvo i dati aggiornati nel file immagini.json
                System.IO.File.WriteAllText(paths.PathImmagini, JsonConvert.SerializeObject(model.Immagini, Formatting.Indented));

                _logger.LogInformation("{0} - Modifica Immegini --> (Eseguito!!!)", DateTime.Now.ToString("T"));

                #region db
                //carico i dati dell'utente attuale
                var user = await _userManager.GetUserAsync(User);

                //messaggio per immagini/immagine
                string messaggio = model.ImgMod.Count > 1 ? "immagini modificate" : "immagine modificata";

                //creo oggetto log per il db
                Log log = new Log
                {
                    DataOperazione = DateTime.Now,
                    Alias = user!.Alias,
                    Email = user.Email,
                    Ruoli = user.Ruoli,
                    OperazioneSvolta = $"Modifica immagini: {model.ImgMod.Count} {messaggio}",
                    Tipologia = true   //true = UserExperience; false = Administrative
                };
                //salvo nel db
                await _db.Logs.AddAsync(log);
                await _db.SaveChangesAsync();

                #endregion

            }
            else
            {
                _logger.LogInformation("{0} - Modifica Immegini --> (Problema con Lista ImgMod!!!)", DateTime.Now.ToString("T"));
            }

            return RedirectToAction(nameof(GestisciImmagini));
        }
    }

    [HttpGet]
    public IActionResult ModeraCommenti(int pageIndex = 1, string reverse = "idOff")
    {
        //salvo url per il ritorno dalle immagini
        ViewBag.UrlBack = HttpContext.Request.Path + HttpContext.Request.QueryString;

        // creo il modello per gestire la view
        var model = new ModeraCommentiViewModel
        {
            ElementiPerPagina = 16,
            PageIndex = pageIndex,
            Reverse = reverse
        };

        var jsonFileVoti = System.IO.File.ReadAllText(paths.PathVoti);

        //seleziono solo i commenti che non sono vuoti ordinati per ultimo commento
        model.Voti = JsonConvert.DeserializeObject<List<Voto>>(jsonFileVoti)!.Where(v => !string.IsNullOrWhiteSpace(v.Commento));

        //gestione ordinameneto tabella
        switch (reverse)
        {
            case "idOff":
                model.Voti = model.Voti.OrderByDescending(v => v.Id);
                break;

            case "idOn":
                model.Voti = model.Voti.OrderBy(v => v.Id);
                break;

            case "idImmOff":
                model.Voti = model.Voti.OrderByDescending(v => v.ImmagineId);
                break;

            case "idImmOn":
                model.Voti = model.Voti.OrderBy(v => v.ImmagineId);
                break;

            case "dataOff":
                model.Voti = model.Voti.OrderByDescending(v => v.Data);
                break;

            case "dataOn":
                model.Voti = model.Voti.OrderBy(v => v.Data);
                break;

            case "utenteOff":
                model.Voti = model.Voti.OrderByDescending(v => v.Nome);
                break;

            case "utenteOn":
                model.Voti = model.Voti.OrderBy(v => v.Nome);
                break;

            case "commentoOff":
                model.Voti = model.Voti.OrderByDescending(v => v.Commento);
                break;

            case "commentoOn":
                model.Voti = model.Voti.OrderBy(v => v.Commento);
                break;

            default:
                model.Voti = model.Voti.OrderByDescending(v => v.Id);
                break;
        }

        //paginazione
        model.NumeroPagine = (int)Math.Ceiling((double)model.Voti.Count() / model.ElementiPerPagina);
        model.Voti = model.Voti.Skip((pageIndex - 1) * model.ElementiPerPagina).Take(model.ElementiPerPagina);

        _logger.LogInformation("{0} - ModeraCommenti --> (PageIndex: {1} - Reverse: {2})", DateTime.Now.ToString("T"), pageIndex, reverse);

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> ModeraCommenti(ModeraCommentiViewModel model)
    {
        //assicura che i dati inviati siano validi, altrimenti ricarica la pagina
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        else if (model.Selezione == null)
        {
            return RedirectToAction("ModeraCommenti", "Moderatore", new { pageIndex = model.PageIndex, reverse = model.Reverse });
        }
        else
        {
            // verifica log
            _logger.LogInformation("{0} - ModeraCommenti --> (Oggetti selezionati: {1})", DateTime.Now.ToString("T"), model.Selezione);

            //inizio la procedura di modifica del file voti.json
            var jsonFileVoti = System.IO.File.ReadAllText(paths.PathVoti);
            model.Voti = JsonConvert.DeserializeObject<List<Voto>>(jsonFileVoti)!;

            if (model.SubmitButton == "censura")
            {
                //verifica log
                _logger.LogInformation("{0} - ModeraCommenti --> (Opzione Censura)", DateTime.Now.ToString("T"));

                foreach (var id in model.Selezione!)   //per ogni checkbox (id del voto)
                {
                    foreach (var voto in model.Voti)  //cerco l'id e setto il voto a non visibile
                    {
                        if (voto.Id == id)
                        {
                            voto.Visibile = false;
                            voto.Moderato = true;
                            break;
                        }
                    }
                }
            }
            else if (model.SubmitButton == "approva")
            {
                //verifica log
                _logger.LogInformation("{0} - ModeraCommenti --> (Opzione Approva)", DateTime.Now.ToString("T"));

                foreach (var id in model.Selezione!)   //per ogni checkbox (id del voto)
                {
                    foreach (var voto in model.Voti)  //cerco l'id e setto il voto a non visibile
                    {
                        if (voto.Id == id)
                        {
                            voto.Moderato = true;
                            break;
                        }
                    }
                }
            }

            //salvo i dati aggiornati nel file voti.json
            System.IO.File.WriteAllText(paths.PathVoti, JsonConvert.SerializeObject(model.Voti, Formatting.Indented));

            #region db
            //carico i dati dell'utente attuale
            var user = await _userManager.GetUserAsync(User);

            //messaggio per commento/commenti
            string messaggio = model.Selezione!.Count > 1 ? "commenti" : "commento";
            string censura = model.Selezione!.Count > 1 ? "censurati" : "censurato";
            string approva = model.Selezione!.Count > 1 ? "approvati" : "approvato";
            string azione = model.SubmitButton == "censura" ? censura : approva;
            //creo oggetto log per il db
            Log log = new Log
            {
                DataOperazione = DateTime.Now,
                Alias = user!.Alias,
                Email = user.Email,
                Ruoli = user.Ruoli,
                OperazioneSvolta = $"Modera commenti: {model.Selezione.Count} {messaggio} {azione}",
                Tipologia = true   //true = UserExperience; false = Administrative
            };
            //salvo nel db
            await _db.Logs.AddAsync(log);
            await _db.SaveChangesAsync();

            #endregion

            return RedirectToAction("ModeraCommenti", "Moderatore", new { pageIndex = model.PageIndex, reverse = model.Reverse });

        }
    }
}
