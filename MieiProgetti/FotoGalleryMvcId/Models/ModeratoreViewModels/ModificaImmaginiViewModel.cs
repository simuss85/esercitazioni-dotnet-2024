using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace FotoGalleryMvcId.Models;

public class ModificaImmaginiViewModel
{
    //attibuti per le view POST
    [BindProperty]
    public List<InputModel>? ImgMod { get; set; }

    [BindProperty]  //la lista degli id selezionati per la modifica
    public List<int>? Selezione { get; set; }

    //attibuti per le view GET
    public IList<SelectListItem> Categorie { get; set; } = []; // Inizializza la lista vuota

    //la lista di tutte le immagini per OnGet input Id
    public List<Immagine> Immagini { get; set; }

    //costruttore per generare il SelectListItem e La lista immagini
    public ModificaImmaginiViewModel()
    {
        Paths paths = new();
        // Leggi le categorie dal file JSON
        var jsonFileCat = System.IO.File.ReadAllText(paths.PathCategorie);
        // Se ho problemi con il file JSON...
        var categorie = JsonConvert.DeserializeObject<List<string>>(jsonFileCat) ?? new List<string>();

        // Costruisci oggetti SelectListItem e assegnali a Categorie
        foreach (var c in categorie)
        {
            Categorie.Add(new SelectListItem { Value = c, Text = c });
        }

        //memorizzo le immagini per la selezione degli Id input
        var jsonFileImm = System.IO.File.ReadAllText(paths.PathImmagini);
        Immagini = JsonConvert.DeserializeObject<List<Immagine>>(jsonFileImm)!;
    }
}
