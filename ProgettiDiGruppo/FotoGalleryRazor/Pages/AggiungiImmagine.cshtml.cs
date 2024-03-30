using System.ComponentModel.DataAnnotations;
using FotoGalleryRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace FotoGalleryRazor.Pages;

public class AggiungiImmagineModel : PageModel
{
    [BindProperty]
    public required InputModel Input { get; set; }
    public IEnumerable<SelectListItem> Categorie { get; set; } = new List<SelectListItem>();

    private readonly string jsonPath = @"wwwroot/json/immagini.json";
    private readonly string jsonPath3 = @"wwwroot/json/categorie.json";
    //logger
    private readonly ILogger<AggiungiImmagineModel> _logger;

    public AggiungiImmagineModel(ILogger<AggiungiImmagineModel> logger)
    {
        _logger = logger;

        //spostandolo nel costruttore, si crea l'oggetto Categorie nel modo corretto
        var jsonFile3 = System.IO.File.ReadAllText(jsonPath3);
        //se ho problemi con il file json...
        var categorie = JsonConvert.DeserializeObject<List<string>>(jsonFile3) ?? new List<string> { "Nessuna categoria" };

        foreach (var c in categorie)
        {
            Categorie = Categorie.Append(new SelectListItem { Value = c, Text = c });
        }
    }


    public IActionResult OnPost()
    {
        //assicura che i dati inviati siano validi, altrimenti ricarica la pagina
        if (!ModelState.IsValid)
        {
            _logger.LogInformation("Errore validazione modulo - " + DateTime.Now.ToString("T"));
            return Page();
        }

        _logger.LogInformation("Categoria: {0}", Input!.Categoria);

        var jsonFile = System.IO.File.ReadAllText(jsonPath);
        var immagini = JsonConvert.DeserializeObject<List<Immagine>>(jsonFile)!;

        int id = immagini.Max(i => i.Id);
        id++;

        if (string.IsNullOrEmpty(Input!.Autore))
        {
            Input.Autore = $"Autore {id}";
        }
        if (string.IsNullOrEmpty(Input.Titolo))
        {
            Input.Titolo = $"Titolo {id}";
        }
        Immagine img = new()
        {
            Id = id,
            Path = Input.Path,
            Titolo = Input.Titolo,
            Voto = 0,
            NumeroVoti = 0,
            Autore = Input.Autore,
            Data = DateTime.Now,
            Categoria = Input.Categoria

        };

        immagini.Add(img);

        System.IO.File.WriteAllText(jsonPath, JsonConvert.SerializeObject(immagini, Formatting.Indented));
        return RedirectToPage("/GestisciImmagini");
    }

    public class InputModel
    {
        [Display(Name = "Titolo ")]
        public string? Titolo { get; set; }
        [Display(Name = "Autore ")]
        public string? Autore { get; set; }
        [Required(ErrorMessage = "Devi selezionare una categoria")]
        [Display(Name = "Categoria")]
        public string? Categoria { get; set; }
        [Required(ErrorMessage = "Devi inserire un link")]
        [Display(Name = "Link immagine")]
        public string? Path { get; set; }
    }
}

