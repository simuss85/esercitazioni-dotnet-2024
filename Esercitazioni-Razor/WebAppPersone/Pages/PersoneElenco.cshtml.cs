using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WebAppProdotti.Models;

namespace WebAppPersone.Pages;

public class PersoneElencoModel : PageModel
{
    public string jsonPath = $"wwwroot/json/persone.json";
    public required IEnumerable<Persona> Persone { get; set; }

    #region Logger
    private readonly ILogger<PersoneElencoModel> _logger;

    public PersoneElencoModel(ILogger<PersoneElencoModel> logger)
    {
        _logger = logger;
    }
    #endregion

    public void OnGet()
    {
        var jsonFile = System.IO.File.ReadAllText(jsonPath);
        Persone = JsonConvert.DeserializeObject<List<Persona>>(jsonFile)!;
    }
}

