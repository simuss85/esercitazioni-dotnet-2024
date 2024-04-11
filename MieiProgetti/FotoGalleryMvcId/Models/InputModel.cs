using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace FotoGalleryMvcId.Models;

public class InputModel
{
    //attibuti per le view POST
    [HiddenInput]
    public int Id { get; set; }

    [BindProperty]
    [Required(ErrorMessage = "Devi inserire un titolo")]
    [Display(Name = "Titolo ")]
    public string? Titolo { get; set; }

    [BindProperty]
    [Required(ErrorMessage = "Devi inserire un titolo")]
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
}