using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FotoGalleryRazor.Models;
using Newtonsoft.Json;

namespace FotoGalleryRazor.Pages;

public class ImmagineModel : PageModel
{
    [BindProperty]
    public string? Nome { get; set; }
    [BindProperty]
    public int Id { get; set; }
    [BindProperty]
    public int Stars { get; set; }
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

        _logger.LogInformation("url back : {0}", urlBack);
        var jsonFile = System.IO.File.ReadAllText(jsonPath);
        Immagine = JsonConvert.DeserializeObject<List<Immagine>>(jsonFile)!.First(i => i.Id == id);
        var jsonFile2 = System.IO.File.ReadAllText(jsonPath2);
        Voti = JsonConvert.DeserializeObject<List<Voto>>(jsonFile2)!;

    }
    public IActionResult OnPost()
    {
        //assicura che i dati inviati siano validi, altrimenti ricarica la pagina
        if (!ModelState.IsValid)
        {
            return Page();
        }

        // _logger.LogInformation("Nome: {0}, Voto: {1}{2}{3}{4}{5}, Commento: {6}, IdImmagine: {7}", Nome, Stars[0].ToString(), Stars[1].ToString(), Stars[2].ToString(), Stars[3].ToString(), Stars[4].ToString(), Commento, Id);
        var jsonFile = System.IO.File.ReadAllText(jsonPath);
        var immagini = JsonConvert.DeserializeObject<List<Immagine>>(jsonFile)!;
        Immagine = immagini.First(i => i.Id == Id);

        var jsonFile2 = System.IO.File.ReadAllText(jsonPath2);
        var voti = JsonConvert.DeserializeObject<List<Voto>>(jsonFile2)!;

        Voti = voti;

        int idVoto = voti.Count();
        idVoto++;
        double stelle = Stars;

        //salvo il voto nel file voti.json
        voti.Add(new Voto { Id = idVoto, Nome = Nome, ImmagineId = Id, Stelle = stelle, Data = DateTime.Today, Commento = Commento, Visibile = true });
        System.IO.File.WriteAllText(jsonPath2, JsonConvert.SerializeObject(voti, Formatting.Indented));

        //recupero i dati del voto prima di aggiungere quello nuovo
        int numeroDiVoti = Immagine.NumeroVoti;
        double sommaVoti = Immagine.Voto * numeroDiVoti;

        //aggiorno con il nuovo voto
        numeroDiVoti++;
        sommaVoti += stelle;

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

        return Page();
    }
}