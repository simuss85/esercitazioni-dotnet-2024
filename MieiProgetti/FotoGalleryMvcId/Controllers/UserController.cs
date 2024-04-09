using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FotoGalleryMvcId.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace FotoGalleryMvcId.Controllers;

[Authorize(Roles = "User")]
public class UserController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger, UserManager<AppUser> userManager)
    {
        _logger = logger;
        _userManager = userManager;
    }

    /// <summary>
    /// Azione per la visualizzazione della home page che contiene tutte le immagini, il saluto all'utente <br/>
    /// o il titolo della categoria, i tasti per la scelta della categoria e il play per il carosello.
    /// </summary>
    /// <param name="pageIndex">Il numero attuale della pagina</param>
    /// <param name="categoria">La categoria attualmente selezionata</param>
    /// <returns>La vista con il modello ImmagineViewModel</returns>
    [HttpGet]
    public async Task<IActionResult> Immagini(int? pageIndex = 1, string? categoria = "")
    {
        //memorizzo UrlBack in un ViewBag
        ViewBag.UrlBack = HttpContext.Request.Path + HttpContext.Request.QueryString;

        //memorizzo l'Utente attuale
        var user = await _userManager.GetUserAsync(User);

        if (user != null)
        {
            //creo un ViewBag per inviare l'Alias alla index
            ViewBag.Alias = user!.Alias;
        }

        //log che visualizza la pagina selezionata, user e orario
        _logger.LogInformation("{0} - Immagini --> (User: {1} - PageIndex: {2})", DateTime.Now.ToString("T"), user, pageIndex);

        // Inizializza gli attributi di classe nel modello
        var model = new ImmaginiViewModel
        {
            PageIndex = pageIndex,
            Categoria = categoria
        };

        // Leggi il file JSON delle immagini
        var jsonFileImm = System.IO.File.ReadAllText(model.PathImmagini);
        model.Immagini = JsonConvert.DeserializeObject<List<Immagine>>(jsonFileImm)!;

        // Leggi il file JSON delle categorie e riordina le categorie in ordine alfabetico
        var jsonFileCat = System.IO.File.ReadAllText(model.PathCategorie);
        model.Categorie = JsonConvert.DeserializeObject<List<string>>(jsonFileCat)!.OrderBy(c => c).ToList();

        //elimino le categorie senza immagini
        model.Categorie.RemoveAll(c => model.Immagini.All(i => i.Categoria != c));

        //filtro le immagini per categoria
        if (!string.IsNullOrEmpty(model.Categoria))
        {
            model.Immagini = model.Immagini.Where(i => i.Categoria == categoria);
        }

        // Calcola il numero di pagine e la paginazione
        model.NumeroPagine = (int)Math.Ceiling((double)model.Immagini.Count() / 12);
        model.Immagini = model.Immagini.Skip(((pageIndex ?? 1) - 1) * 12).Take(12).ToList();

        return View(model);
    }

    /// <summary>
    /// Azione per la visualizzazione del dettaglio immagine che contiene la card immagine, i tasto <br/>
    /// i tasti per la scelta della categoria e il play per il carosello.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="urlBack"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> Immagine(int id, string urlBack)
    {
        //memorizzo l'Utente attuale
        var user = await _userManager.GetUserAsync(User);

        // Inizializza gli attributi di classe nel modello
        var model = new ImmagineViewModel
        {
            // memorizzo il valore passato dalla pagina precedente
            UrlBack = urlBack
        };



        // seleziono da tutte le immagini quella attuale
        var jsonFileImm = System.IO.File.ReadAllText(model.PathImmagini);
        model.Immagine = JsonConvert.DeserializeObject<List<Immagine>>(jsonFileImm)!.First(i => i.Id == id);

        //carico i voti per la view della card immagine
        var jsonFileVoti = System.IO.File.ReadAllText(model.PathVoti);
        model.Voti = JsonConvert.DeserializeObject<List<Voto>>(jsonFileVoti)!;

        if (user != null)
        {
            //memorizzo il nome utente attuale come email
            model.NomeUtente = user!.ToString();
        }

        //verifico se l'utente ha gia votato l'immagine
        if (model.Voti.FirstOrDefault(v => v.Nome == model.NomeUtente && v.ImmagineId == id) == null)
        {
            //log che visualizza la pagina selezionata, user, urlBack e orario
            _logger.LogInformation("{0} - Dettaglio Immagine --> (User: {1} - UrlBack: {2} - IdImmagine: {3} - Voto: Attivo!)", DateTime.Now.ToString("T"), user, urlBack, id);
            model.VotoAttivo = true;
        }
        else
        {
            _logger.LogInformation("{0} - Dettaglio Immagine --> (User: {1} - UrlBack: {2} - IdImmagine: {3} - Voto: Non Attivo!)", DateTime.Now.ToString("T"), user, urlBack, id);
            model.VotoAttivo = false;
        }

        return View(model);
    }



    // /// <summary>
    // /// Azione per la visualizzazione di una singola immagine.
    // /// </summary>
    // /// <param name="id">ID dell'immagine da visualizzare.</param>
    // /// <param name="urlBack">URL della pagina precedente.</param>
    // /// <returns>La vista Immagine con il modello ImmagineViewModel.</returns>
    // public IActionResult Immagine(int id, string urlBack)
    // {
    //     //memorizzo url per il ritorno
    //     ViewBag.Url = HttpContext.Request.Path + HttpContext.Request.QueryString;

    //     var model = new ImmagineViewModel
    //     {
    //         // memorizzo il valore passato dalla pagina precedente
    //         UrlBack = urlBack,

    //     };

    //     //verifica log
    //     _logger.LogInformation("url back : {0}", urlBack);

    //     // seleziono da tutte le immagini quella attuale
    //     var jsonFile = System.IO.File.ReadAllText(model.jsonPath);
    //     model.Immagine = JsonConvert.DeserializeObject<List<Immagine>>(jsonFile)!.First(i => i.Id == id);

    //     //carico i voti per la view della card immagine
    //     var jsonFile2 = System.IO.File.ReadAllText(model.jsonPath2);
    //     model.Voti = JsonConvert.DeserializeObject<List<Voto>>(jsonFile2)!;
    //     return View(model);
    // }

    // [HttpPost]
    // public IActionResult Immagine()
    // {
    //     var model = new ImmagineViewModel { };
    //     //validazione input anche se non necessaria in questo caso
    //     if (!ModelState.IsValid)
    //     {
    //         return View();
    //     }

    //     var jsonFile = System.IO.File.ReadAllText(model.jsonPath);
    //     var immagini = JsonConvert.DeserializeObject<List<Immagine>>(jsonFile)!;
    //     model.Immagine = immagini.First(i => i.Id == model.Id);

    //     var jsonFile2 = System.IO.File.ReadAllText(model.jsonPath2);
    //     var voti = JsonConvert.DeserializeObject<List<Voto>>(jsonFile2)!;
    //     model.Voti = voti;

    //     int idVoto = voti.Count();
    //     idVoto++;

    //     //carico il nome utente attuale (completo)
    //     model.NomeUtente = User.Identity?.Name!;

    //     //salvo il voto nel file voti.json
    //     voti.Add(new Voto { Id = idVoto, Nome = model.NomeUtente, ImmagineId = model.Id, Stelle = model.Stars, Data = DateTime.Today, Commento = model.Commento, Visibile = true, Moderato = false });
    //     System.IO.File.WriteAllText(model.jsonPath2, JsonConvert.SerializeObject(voti, Formatting.Indented));

    //     #region Modifica voto
    //     //recupero i dati del voto prima di aggiungere quello nuovo
    //     int numeroDiVoti = model.Immagine.NumeroVoti;
    //     double sommaVoti = model.Immagine.Voto * numeroDiVoti;

    //     //aggiorno con il nuovo voto
    //     numeroDiVoti++;
    //     sommaVoti += model.Stars;

    //     double votoAggiornato = Math.Round(sommaVoti / numeroDiVoti * 1.0, 1);

    //     //scansiono le immagini per caricare il nuovo voto
    //     foreach (var i in immagini)
    //     {
    //         if (i.Id == model.Id)
    //         {
    //             i.Voto = votoAggiornato;
    //             i.NumeroVoti = numeroDiVoti;
    //             break;
    //         }
    //     }
    //     System.IO.File.WriteAllText(model.jsonPath, JsonConvert.SerializeObject(immagini, Formatting.Indented));
    //     #endregion

    //     return View(model);
    // }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
