namespace FotoGalleryMvcId.Models;

public class GestioneUtentiViewModel
{
    public int NumeroPagine { get; set; }
    public int PageIndex { get; set; }
    public int ElementiPerPagina { get; set; }
    public int TotaleImmagini { get; set; }
    public string? Reverse { get; set; }    //gestisce filtri di ordinamento
    public bool MenuRuoli { get; set; }    //gestisce i partial dei tasti
    public IEnumerable<AppUser>? Utenti { get; set; }

}