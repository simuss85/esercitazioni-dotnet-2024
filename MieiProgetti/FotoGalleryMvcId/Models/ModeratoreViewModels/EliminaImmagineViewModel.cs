using Microsoft.AspNetCore.Mvc;

namespace FotoGalleryMvcId.Models;

public class EliminaImmagineViewModel
{
    //attibuti per le view POST
    [BindProperty]
    public List<int>? Selezione { get; set; }   //lista di id da eliminare

    //attibuti per le view GET
    public List<Immagine>? Immagini { get; set; }
}