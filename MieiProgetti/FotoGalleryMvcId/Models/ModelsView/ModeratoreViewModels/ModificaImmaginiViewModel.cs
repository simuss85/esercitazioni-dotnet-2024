using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FotoGalleryMvcId.Models;

public class ModificaImmaginiViewModel : AggiungiImmaginiViewModel
{
    [HiddenInput]
    public int Id { get; set; }

    [Required(ErrorMessage = "Devi inserire un titolo")]
    [Display(Name = "Titolo ")]
    public override string? Titolo { get; set; }

    [Required(ErrorMessage = "Devi inserire un titolo")]
    [Display(Name = "Autore ")]
    public override string? Autore { get; set; }

    [BindProperty]  //la lista degli id selezionati per la modifica
    public List<int>? Selezione { get; set; }

    [BindProperty]  //la lista delle immagini da modificare
    public List<Immagine>? ImgMod { get; set; }

    //la lista di tutte le immagini per OnGet input Id
    public List<Immagine>? Immagini { get; set; }

    public ModificaImmaginiViewModel() : base()
    {
        Paths path = new();
        //memorizzo le immagini per la selezione degli Id input
        var jsonFileImm = System.IO.File.ReadAllText(path.PathImmagini);
        Immagini = JsonConvert.DeserializeObject<List<Immagine>>(jsonFileImm)!;
    }
}
