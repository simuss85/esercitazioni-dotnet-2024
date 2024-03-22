using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FotoGalleryRazor.Models;
using Newtonsoft.Json;

namespace FotoGalleryRazor.Pages;

public class ImmagineModel : PageModel
{
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

    public void OnGet(int id)
    {
        var jsonFile = System.IO.File.ReadAllText(jsonPath);
        Immagine = JsonConvert.DeserializeObject<List<Immagine>>(jsonFile)!.First(i => i.Id == id);
        var jsonFile2 = System.IO.File.ReadAllText(jsonPath2);
        Voti = JsonConvert.DeserializeObject<List<Voto>>(jsonFile2)!;
    }
    public IActionResult OnPost(string? nome, int id, string? star5, string? star4, string? star3, string? star2, string? star1, string? commento)
    {
        _logger.LogInformation("Nome: {0}, Voto: {1}{2}{3}{4}{5}, Commento: {6}, IdImmagine: {7}", nome, star5, star4, star3, star2, star1, commento, id);
        var jsonFile2 = System.IO.File.ReadAllText(jsonPath2);
        var voti = JsonConvert.DeserializeObject<List<Voto>>(jsonFile2)!;
        int idUtente = voti.Count();
        idUtente++;
        double stelle = 0;
        if (star5 != null)
        {
            stelle = 5.0;
        }
        else if (star4 != null)
        {
            stelle = 4.0;
        }
        else if (star3 != null)
        {
            stelle = 3.0;
        }
        else if (star2 != null)
        {
            stelle = 2.0;
        }
        else if (star1 != null)
        {
            stelle = 1.0;
        }

        voti.Add(new Voto { Id = idUtente, Nome = nome, ImmagineId = id, Stelle = stelle, Data = DateTime.Today, Commento = commento, Visibile = true });
        System.IO.File.WriteAllText(jsonPath2, JsonConvert.SerializeObject(voti, Formatting.Indented));
        return Page();
    }
}