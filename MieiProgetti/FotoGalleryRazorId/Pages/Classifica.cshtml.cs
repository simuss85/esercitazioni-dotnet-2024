using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FotoGalleryRazorId.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace FotoGalleryRazorId.Pages;

//GET: /Reserved/User
[Authorize(Roles = "User")]
public class ClassificaModel : PageModel
{
    public int NumeroPagine { get; set; }
    public int? PageIndex { get; set; }
    public int ElementiPerPagina { get; set; }
    public int TotaleImmagini { get; set; }
    public string? Reverse { get; set; }    //gestisce filtri di ordinamento
    public required IEnumerable<Immagine> Immagini { get; set; }
    public string jsonPath = @"wwwroot/json/immagini.json";

    private readonly ILogger<ClassificaModel> _logger;
    public ClassificaModel(ILogger<ClassificaModel> logger)
    {
        _logger = logger;
    }

    public void OnGet(int? pageIndex, string reverse = "votoOff")
    {
        //log che visualizza la pagina selezionata
        _logger.LogInformation("Classifica - PageIndex: {0}", pageIndex);

        ElementiPerPagina = 10;
        PageIndex = pageIndex;
        Reverse = reverse;

        _logger.LogInformation("Classifica - Numero Pagina: {0}, Reverse: {1}", PageIndex, reverse);
        var jsonFile = System.IO.File.ReadAllText(jsonPath);
        Immagini = JsonConvert.DeserializeObject<List<Immagine>>(jsonFile)!;

        TotaleImmagini = Immagini.Count();
        _logger.LogInformation("Totale immagini: {0}", TotaleImmagini);

        //gestione ordinameneto tabella
        switch (reverse)
        {
            case "votoOff":
                Immagini = Immagini.OrderByDescending(i => i.Voto);
                break;

            case "votoOn":
                Immagini = Immagini.OrderBy(i => i.Voto);
                break;

            case "dataOff":
                Immagini = Immagini.OrderByDescending(i => i.Data);
                break;

            case "dataOn":
                Immagini = Immagini.OrderBy(i => i.Data);
                break;

            case "titoloOff":
                Immagini = Immagini.OrderByDescending(i => i.Titolo);
                break;

            case "titoloOn":
                Immagini = Immagini.OrderBy(i => i.Titolo);
                break;

            case "autoreOff":
                Immagini = Immagini.OrderByDescending(i => i.Autore);
                break;

            case "autoreOn":
                Immagini = Immagini.OrderBy(i => i.Autore);
                break;

            default:
                Immagini = Immagini.OrderByDescending(i => i.Voto);
                break;
        }

        //paginazione 
        NumeroPagine = (int)Math.Ceiling((double)Immagini.Count() / ElementiPerPagina);
        Immagini = Immagini.Skip(((pageIndex ?? 1) - 1) * ElementiPerPagina).Take(ElementiPerPagina);
    }
}

