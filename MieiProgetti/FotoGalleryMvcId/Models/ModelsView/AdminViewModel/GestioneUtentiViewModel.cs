namespace FotoGalleryMvcId.Models;

public class GestioneUtentiViewModel
{
    public int NumeroPagine { get; set; }
    public int PageIndex { get; set; }
    public int ElementiPerPagina { get; set; }
    public int TotaleImmagini { get; set; }
    public string? Reverse { get; set; }    //gestisce filtri di ordinamento
    public string? MenuRuoli { get; set; }    //gestisce i partial dei tasti utilizzando il valore Email per il confronto
    public IEnumerable<AppUser>? Utenti { get; set; }

}