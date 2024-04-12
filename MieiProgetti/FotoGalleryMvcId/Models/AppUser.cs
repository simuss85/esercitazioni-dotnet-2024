using Microsoft.AspNetCore.Identity;

namespace FotoGalleryMvcId.Models;

#nullable disable
public class AppUser : IdentityUser
{
    //aggiungo le proprietà per l'utente in fase di registrazione
    public DateTime DataRegistrazione { get; set; }
    public string Alias { get; set; }
    public string Nome { get; set; }
    public string Cognome { get; set; }
    public int Eta { get; set; }
    public bool Status { get; set; }
    public string Ruoli { get; set; }
}