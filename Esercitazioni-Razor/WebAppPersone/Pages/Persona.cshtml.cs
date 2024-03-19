using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WebAppProdotti.Models;

namespace WebAppPersone.Pages;

public class PersonaModel : PageModel
{
    public string jsonPath = $"wwwroot/json/persone.json";
    public required Persona Persona { get; set; }

    #region Logger
    private readonly ILogger<PersonaModel> _logger;
    public PersonaModel(ILogger<PersonaModel> logger)
    {
        _logger = logger;
    }
    #endregion

    public void OnGet(int id)
    {
        var jsonFile = System.IO.File.ReadAllText(jsonPath);
        Persona = JsonConvert.DeserializeObject<List<Persona>>(jsonFile)!.First(p => p.Id == id);
    }
}