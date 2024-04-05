using System.ComponentModel.DataAnnotations;
using FotoGalleryRazorId.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace FotoGalleryRazorId.Pages;

//GET: /Reserved/Admin
[Authorize(Roles = "Admin")]
public class ModificaImmagineModel : PageModel
{
    [BindProperty]  //la lista degli id selezionati per la modifica
    public required List<int> Selezione { get; set; }

    [BindProperty]  //la lista delle immagini da modificare
    public required List<InputModelMod> ImgMod { get; set; }

    //la lista di tutte le immagini per OnGet input Id
    public required List<Immagine> Immagini { get; set; }

    //elenco delle categorie disponibili
    public IList<SelectListItem> Categorie { get; set; } = []; // Inizializza la lista vuota

    public string jsonPath = @"wwwroot/json/immagini.json";
    public string jsonPath3 = @"wwwroot/json/categorie.json";

    private readonly ILogger<ModificaImmagineModel> _logger;

    public ModificaImmagineModel(ILogger<ModificaImmagineModel> logger)
    {
        _logger = logger;

        // Leggi le categorie dal file JSON
        var jsonFile3 = System.IO.File.ReadAllText(jsonPath3);
        // Se ho problemi con il file JSON...
        var categorie = JsonConvert.DeserializeObject<List<string>>(jsonFile3) ?? new List<string>();

        // Costruisci oggetti SelectListItem e assegnali a Categorie
        foreach (var c in categorie)
        {
            Categorie.Add(new SelectListItem { Value = c, Text = c });
        }

        //memorizzo le immagini per la selezione degli Id input
        var jsonFile = System.IO.File.ReadAllText(jsonPath);
        Immagini = JsonConvert.DeserializeObject<List<Immagine>>(jsonFile)!;
    }

    public void OnGet(List<int> selezione)
    {
        Selezione = selezione;

        //log selezione 
        foreach (var id in Selezione)
        {
            _logger.LogInformation("Selezione: {0}", id);
        }
    }

    public IActionResult OnPost()
    {
        //assicura che i dati inviati siano validi, altrimenti ricarica la pagina
        if (!ModelState.IsValid)
        {
            //log errore selezione
            _logger.LogInformation("Errore validazione modulo - " + DateTime.Now.ToString("T"));
            return Page();
        }

        // Verifica se la lista delle immagini modificate è vuota
        if (ImgMod != null && ImgMod.Any())
        {
            foreach (var img in ImgMod)
            {
                _logger.LogInformation("ID: {0}", img.Id);
                foreach (var i in Immagini)
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
            System.IO.File.WriteAllText(jsonPath, JsonConvert.SerializeObject(Immagini, Formatting.Indented));
        }

        return RedirectToPage("/GestisciImmagini");
    }

    public class InputModelMod : InputModel
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "Devi inserire un titolo")]
        [Display(Name = "Titolo ")]
        public override string? Titolo { get; set; }

        [Required(ErrorMessage = "Devi inserire un titolo")]
        [Display(Name = "Autore ")]
        public override string? Autore { get; set; }

    }

}