using Microsoft.AspNetCore.Mvc;

namespace FotoGalleryMvcId.Models;

public class CardUtenteViewModel
{
    public string? UrlBack { get; set; }
    public AppUser? Utente { get; set; }
}