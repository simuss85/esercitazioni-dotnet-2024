using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FotoGalleryMvcId.Models;

public class AggiungiImmaginiViewModel
{
    //attibuti per le view POST
    [BindProperty]
    [Display(Name = "Titolo ")]
    public string? Titolo { get; set; }

    [BindProperty]
    [Display(Name = "Autore ")]
    public string? Autore { get; set; }

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
}
