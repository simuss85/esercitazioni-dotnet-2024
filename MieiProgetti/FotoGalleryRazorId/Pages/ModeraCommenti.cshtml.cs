using FotoGalleryRazorId.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace FotoGalleryRazorId.Pages;

//GET: /Reserved/User
[Authorize(Roles = "Admin")]
public class ModeraCommentiModel : PageModel
{
    [BindProperty]
    public required List<int> Selezione { get; set; }
    [BindProperty]
    public required string SubmitButton { get; set; }
    [BindProperty]
    public required IEnumerable<Voto> Voti { get; set; }
    [BindProperty]
    public required string UrlBack { get; set; }
    public int NumeroPagine { get; set; }
    public int? PageIndex { get; set; }
    public int ElementiPerPagina { get; set; }


    public string jsonPath2 = @"wwwroot/json/voti.json";

    #region  Logger
    private readonly ILogger<ModeraCommentiModel> _logger;

    public ModeraCommentiModel(ILogger<ModeraCommentiModel> logger)
    {
        _logger = logger;
    }
    #endregion

    public void OnGet(int? pageIndex)
    {
        //log che visualizza la pagina selezionata
        _logger.LogInformation("ModeraCommento - PageIndex: {0}", pageIndex);

        ElementiPerPagina = 20;
        PageIndex = pageIndex;

        var jsonFile = System.IO.File.ReadAllText(jsonPath2);

        //seleziono solo i commenti che non sono vuoti ordinati per ultimo commento
        Voti = JsonConvert.DeserializeObject<List<Voto>>(jsonFile)!.Where(v => !string.IsNullOrWhiteSpace(v.Commento)).OrderByDescending(i => i.Id);

        NumeroPagine = (int)Math.Ceiling((double)Voti.Count() / ElementiPerPagina);
        Voti = Voti.Skip(((pageIndex ?? 1) - 1) * ElementiPerPagina).Take(ElementiPerPagina);
    }

    public IActionResult OnPost()
    {
        //assicura che i dati inviati siano validi, altrimenti ricarica la pagina
        if (!ModelState.IsValid)
        {
            return Page();
        }

        // verifica log
        foreach (var id in Selezione)
        {
            _logger.LogInformation("POST - Selezione: {0}", id);
        }

        //inizio la procedura di modifica del file voti.json
        var jsonFile = System.IO.File.ReadAllText(jsonPath2);
        Voti = JsonConvert.DeserializeObject<List<Voto>>(jsonFile)!;

        if (SubmitButton == "censura")
        {
            //verifica log
            _logger.LogInformation("Censura");

            foreach (var id in Selezione)   //per ogni checkbox (id del voto)
            {
                foreach (var voto in Voti)  //cerco l'id e setto il voto a non visibile
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
        else if (SubmitButton == "approva")
        {
            //verifica log
            _logger.LogInformation("approva");

            foreach (var id in Selezione)   //per ogni checkbox (id del voto)
            {
                foreach (var voto in Voti)  //cerco l'id e setto il voto a non visibile
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
        System.IO.File.WriteAllText(jsonPath2, JsonConvert.SerializeObject(Voti, Formatting.Indented));

        //verifica log
        _logger.LogInformation("POST - url back : {0}", UrlBack);

        return Redirect(UrlBack);
    }
}