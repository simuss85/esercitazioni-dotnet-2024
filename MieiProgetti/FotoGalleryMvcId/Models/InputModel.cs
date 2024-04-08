using System.ComponentModel.DataAnnotations;

namespace FotoGalleryMvcId.Models;
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
    [Url(ErrorMessage = "Url non valido")]
    [RegularExpression(@".+\.(jpg|jpeg)(\?.+)?$", ErrorMessage = "L'URL deve contenere un'imagine .jpg o .jpeg")]
    public string? Path { get; set; }
}