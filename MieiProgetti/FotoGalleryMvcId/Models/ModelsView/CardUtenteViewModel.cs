using Microsoft.AspNetCore.Mvc;

namespace FotoGalleryMvcId.Models;

public class CardUtenteViewModel
{
    public string? UrlBack { get; set; }
    public bool MenuRuoli { get; set; }    //gestisce i partial dei tasti
    public AppUser? Utente { get; set; }
}