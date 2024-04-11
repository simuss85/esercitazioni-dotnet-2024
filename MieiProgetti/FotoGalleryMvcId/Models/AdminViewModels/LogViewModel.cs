namespace FotoGalleryMvcId.Models;

public class LogViewModel
{
    //attibuti per le view GET
    public IEnumerable<Log>? Logs { get; set; }
    public int NumeroPagine { get; set; }
    public int? PageIndex { get; set; }
    public int ElementiPerPagina { get; set; }
    public string? Reverse { get; set; }    //gestisce filtri di ordinamento
}