using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace FotoGalleryMvcId.Models;

public class AggiungiImmaginiViewModel
{
    //attibuti per le view POST
    [BindProperty]
    [Display(Name = "Titolo ")]
    public virtual string? Titolo { get; set; }

    [BindProperty]
    [Display(Name = "Autore ")]
    public virtual string? Autore { get; set; }

    [BindProperty]
    [Required(ErrorMessage = "Devi selezionare una categoria")]
    [Display(Name = "Categoria")]
    public string? Categoria { get; set; }

    [BindProperty]
    [Required(ErrorMessage = "Devi inserire un link")]
    [Display(Name = "Link immagine")]
    [Url(ErrorMessage = "Url non valido")]
    [RegularExpression(@".+\.(jpg|jpeg)(\?.+)?$", ErrorMessage = "L'URL deve contenere un'imagine .jpg o .jpeg")]
    public string? Path { get; set; }

    //attibuti per le view GET
    public IList<SelectListItem> Categorie { get; set; } = []; // Inizializza la lista vuota

    //per la gestione dei messaggi a schermo
    public string? Messaggio { get; set; }
    public string? Colore { get; set; }

    //costruttore per generare il SelectListItem
    public AggiungiImmaginiViewModel()
    {
        Paths paths = new();
        // Leggi le categorie dal file JSON
        var jsonFileCat = System.IO.File.ReadAllText(paths.PathCategorie);
        // Se ho problemi con il file JSON...
        var categorie = JsonConvert.DeserializeObject<List<string>>(jsonFileCat) ?? new List<string>();

        // Costruisci oggetti SelectListItem e assegnali a Categorie
        foreach (var c in categorie)
        {
            Categorie.Add(new SelectListItem { Value = c, Text = c });
        }
    }
}
