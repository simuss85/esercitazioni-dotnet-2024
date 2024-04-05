using FotoGalleryRazorId.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace FotoGalleryRazorId.Pages;

//GET: /Reserved/User
[Authorize(Roles = "User, Admin")]
public class GestisciImmaginiModel : PageModel
{
    public int NumeroPagine { get; set; }
    public int? PageIndex { get; set; }
    public required IEnumerable<Immagine> Immagini { get; set; }
    public required IEnumerable<string> Categorie { get; set; }
    public string? Reverse { get; set; }    //gestisce filtri di ordinamento

    public string jsonPath = @"wwwroot/json/immagini.json";
    public string jsonPath3 = @"wwwroot/json/categorie.json";

    private readonly ILogger<GestisciImmaginiModel> _logger;
    public GestisciImmaginiModel(ILogger<GestisciImmaginiModel> logger)
    {
        _logger = logger;

        var jsonFile3 = System.IO.File.ReadAllText(jsonPath3);
        Categorie = JsonConvert.DeserializeObject<List<string>>(jsonFile3)!;
    }


    public void OnGet(int? pageIndex, string reverse = "idOff")
    {
        //log che visualizza la pagina selezionata
        _logger.LogInformation("GestisciImmagini - PageIndex: {0}", pageIndex);

        PageIndex = pageIndex;
        Reverse = reverse;

        var jsonFile = System.IO.File.ReadAllText(jsonPath);
        Immagini = JsonConvert.DeserializeObject<List<Immagine>>(jsonFile)!.OrderByDescending(i => i.Id);

        //gestione ordinameneto tabella
        switch (reverse)
        {
            case "idOff":
                Immagini = Immagini.OrderByDescending(i => i.Id);
                break;

            case "idOn":
                Immagini = Immagini.OrderBy(i => i.Id);
                break;

            case "dataOff":
                Immagini = Immagini.OrderByDescending(i => i.Data);
                break;

            case "dataOn":
                Immagini = Immagini.OrderBy(i => i.Data);
                break;

            case "autoreOff":
                Immagini = Immagini.OrderByDescending(i => i.Autore);
                break;

            case "autoreOn":
                Immagini = Immagini.OrderBy(i => i.Autore);
                break;

            case "titoloOff":
                Immagini = Immagini.OrderByDescending(i => i.Titolo);
                break;

            case "titoloOn":
                Immagini = Immagini.OrderBy(i => i.Titolo);
                break;

            default:
                Immagini = Immagini.OrderByDescending(v => v.Id);
                break;
        }

        //paginazione
        NumeroPagine = (int)Math.Ceiling((double)Immagini.Count() / 10);
        Immagini = Immagini.Skip(((pageIndex ?? 1) - 1) * 10).Take(10);
    }

}