using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FotoGalleryRazorId.Models;
using Newtonsoft.Json;

namespace FotoGalleryRazorId.Pages;

public class ImmagineModel : PageModel
{
    [BindProperty]
    public int Id { get; set; }

    [BindProperty]
    public double Stars { get; set; }

    [BindProperty]
    public string? Commento { get; set; }

    [BindProperty]
    public string? UrlBack { get; set; }

    public required Immagine Immagine { get; set; }
    public required IEnumerable<Voto> Voti { get; set; }
    public string jsonPath = @"wwwroot/json/immagini.json";
    public string jsonPath2 = @"wwwroot/json/voti.json";

    #region Logger
    private readonly ILogger<ImmagineModel> _logger;

    public ImmagineModel(ILogger<ImmagineModel> logger)
    {
        _logger = logger;
    }
    #endregion

    public void OnGet(int id, string urlBack)
    {
        // memorizzo il valore passato dalla pagina precedente
        UrlBack = urlBack;

        //verifica log
        _logger.LogInformation("url back : {0}", urlBack);

        // seleziono da tutte le immagini quella attuale
        var jsonFile = System.IO.File.ReadAllText(jsonPath);
        Immagine = JsonConvert.DeserializeObject<List<Immagine>>(jsonFile)!.First(i => i.Id == id);

        //carico i voti per la view della card immagine
        var jsonFile2 = System.IO.File.ReadAllText(jsonPath2);
        Voti = JsonConvert.DeserializeObject<List<Voto>>(jsonFile2)!;

    }
    public IActionResult OnPost()
    {
        //validazione input anche se non necessaria in questo caso
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var jsonFile = System.IO.File.ReadAllText(jsonPath);
        var immagini = JsonConvert.DeserializeObject<List<Immagine>>(jsonFile)!;
        Immagine = immagini.First(i => i.Id == Id);

        var jsonFile2 = System.IO.File.ReadAllText(jsonPath2);
        var voti = JsonConvert.DeserializeObject<List<Voto>>(jsonFile2)!;
        Voti = voti;

        int idVoto = voti.Count();
        idVoto++;

        string nome = User.Identity?.Name!.Split("@")[0]!;

        //salvo il voto nel file voti.json
        voti.Add(new Voto { Id = idVoto, Nome = nome, ImmagineId = Id, Stelle = Stars, Data = DateTime.Today, Commento = Commento, Visibile = true, Moderato = false });
        System.IO.File.WriteAllText(jsonPath2, JsonConvert.SerializeObject(voti, Formatting.Indented));

        #region Modifica voto
        //recupero i dati del voto prima di aggiungere quello nuovo
        int numeroDiVoti = Immagine.NumeroVoti;
        double sommaVoti = Immagine.Voto * numeroDiVoti;

        //aggiorno con il nuovo voto
        numeroDiVoti++;
        sommaVoti += Stars;

        double votoAggiornato = Math.Round(sommaVoti / numeroDiVoti * 1.0, 1);

        //scansiono le immagini per caricare il nuovo voto
        foreach (var i in immagini)
        {
            if (i.Id == Id)
            {
                i.Voto = votoAggiornato;
                i.NumeroVoti = numeroDiVoti;
                break;
            }
        }
        System.IO.File.WriteAllText(jsonPath, JsonConvert.SerializeObject(immagini, Formatting.Indented));
        #endregion

        return Page();
    }
}