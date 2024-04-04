using System.ComponentModel.DataAnnotations;

namespace FotoGalleryRazorId.Models;
/// <summary>
/// Classe di validazione input per l'aggiunta di un'immagine
/// </summary>
public class InputModel
{
    [Display(Name = "Titolo ")]
    public virtual string? Titolo { get; set; }

    [Display(Name = "Autore ")]
    public virtual string? Autore { get; set; }

    [Required(ErrorMessage = "Devi selezionare una categoria")]
    [Display(Name = "Categoria")]
    public string? Categoria { get; set; }

    [Required(ErrorMessage = "Devi inserire un link")]
    [Display(Name = "Link immagine")]
    public string? Path { get; set; }
}