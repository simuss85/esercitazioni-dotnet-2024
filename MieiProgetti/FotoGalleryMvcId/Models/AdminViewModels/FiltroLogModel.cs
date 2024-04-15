using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.DataProtection.XmlEncryption;

namespace FotoGalleryMvcId.Models;

public class FiltroLogModel
{
    //per i filtri di ricerca
    [Display(Name = "Id log")]
    public int Id { get; set; }

    [Display(Name = "Data Inizio")]
    [DataType(DataType.Date)]
    public DateTime DataInizio { get; set; } = new DateTime(2024, 4, 1);

    [Display(Name = "Data Fine")]
    [DataType(DataType.Date)]
    public DateTime DataFine { get; set; } = DateTime.Today;

    [Display(Name = "Alias utente")]
    public string? Alias { get; set; }

    [Display(Name = "Email utente")]
    public string? Email { get; set; }

    public List<string>? Ruoli { get; set; }

    [Display(Name = "Operazione effettuata")]
    public string? Operazione { get; set; }
    public bool? Tipologia { get; set; }
}