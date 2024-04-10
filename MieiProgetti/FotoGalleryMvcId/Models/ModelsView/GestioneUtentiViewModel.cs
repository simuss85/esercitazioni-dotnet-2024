namespace FotoGalleryMvcId.Models;

public class GestioneUtentiViewModel
{
    public int NumeroPagine { get; set; }
    public int PageIndex { get; set; }
    public int ElementiPerPagina { get; set; }
    public int TotaleImmagini { get; set; }
    public string? Reverse { get; set; }    //gestisce filtri di ordinamento
    public IEnumerable<AppUser>? Utenti { get; set; }

}