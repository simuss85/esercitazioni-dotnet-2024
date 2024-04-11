using Microsoft.AspNetCore.Mvc;

namespace FotoGalleryMvcId.Models;

public class ModeraCommentiViewModel
{
    //attibuti per le view POST
    [BindProperty]
    public List<int>? Selezione { get; set; }

    [BindProperty]
    public string? SubmitButton { get; set; }

    [BindProperty]
    public IEnumerable<Voto>? Voti { get; set; }

    [BindProperty]
    public string? UrlBack { get; set; }

    //attibuti per le view GET
    public int NumeroPagine { get; set; }
    public int? PageIndex { get; set; }
    public int ElementiPerPagina { get; set; }
    public string? Reverse { get; set; }    //gestisce filtri di ordinamento

}