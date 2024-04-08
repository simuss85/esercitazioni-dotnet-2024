using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FotoGalleryMvcId.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace FotoGalleryMvcId.Controllers;

[Authorize(Roles = "User")]
public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }


    public IActionResult Index(int? pageIndex, string? categoria)
    {

        //log che visualizza la pagina selezionata
        _logger.LogInformation("Index - PageIndex: {0}", pageIndex);

        // Inizializza gli attributi di classe nel modello
        var model = new IndexViewModel
        {
            PageIndex = pageIndex,
            Categoria = categoria
        };

        // Leggi il file JSON delle immagini
        var jsonFile = System.IO.File.ReadAllText(model.jsonPath);
        model.Immagini = JsonConvert.DeserializeObject<List<Immagine>>(jsonFile)!;

        // Leggi il file JSON delle categorie e riordina le categorie in ordine alfabetico
        var jsonFile3 = System.IO.File.ReadAllText(model.jsonPath3);
        model.Categorie = JsonConvert.DeserializeObject<List<string>>(jsonFile3)!.OrderBy(c => c).ToList();

        //elimino le categorie senza immagini
        model.Categorie.RemoveAll(c => model.Immagini.All(i => i.Categoria != c));

        //filtro le immagini per categoria
        if (!string.IsNullOrEmpty(model.Categoria))
        {
            model.Immagini = model.Immagini.Where(i => i.Categoria == categoria);
        }

        // Calcola il numero di pagine e la paginazione
        model.NumeroPagine = (int)Math.Ceiling((double)model.Immagini.Count() / 12);
        model.Immagini = model.Immagini.Skip(((pageIndex ?? 1) - 1) * 12).Take(12).ToList();

        return View(model);
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
