using Microsoft.AspNetCore.Mvc;

namespace FotoGalleryMvcId.Models;

public class CardUtenteViewModel
{
    public string? UrlBack { get; set; }
    public string? MenuRuoli { get; set; }    //gestisce i partial dei tasti utilizzando il valore Email per il confronto
    public AppUser? Utente { get; set; }
}