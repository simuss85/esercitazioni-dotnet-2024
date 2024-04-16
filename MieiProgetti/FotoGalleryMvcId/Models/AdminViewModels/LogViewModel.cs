using Microsoft.AspNetCore.Mvc;

namespace FotoGalleryMvcId.Models;

public class LogViewModel
{
    //attributi per le view POST
    [BindProperty]
    public int IdLog { get; set; }

    //per i filtri
    [BindProperty]
    public FiltroLogModel? Filtro { get; set; }

    [BindProperty]
    [HiddenInput]
    public string? UrlBack { get; set; }


    //attibuti per le view GET
    public IEnumerable<Log>? Logs { get; set; }
    public int NumeroPagine { get; set; }
    public int PageIndex { get; set; }
    public int ElementiPerPagina { get; set; }
    public string? Reverse { get; set; }    //gestisce filtri di ordinamento



}
