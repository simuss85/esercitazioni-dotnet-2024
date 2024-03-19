using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WebAppProdotti.Models;

namespace WebAppPersone.Pages;

public class ModificaPersonaModel : PageModel
{
    public string jsonPath = $"wwwroot/json/persone.json";
    public required IEnumerable<Persona> Persone { get; set; }
    public int _id;

    #region Logger
    private readonly ILogger<ModificaPersonaModel> _logger;
    public ModificaPersonaModel(ILogger<ModificaPersonaModel> logger)
    {
        _logger = logger;
    }
    #endregion

    public void OnGet(int id)
    {
        _id = id;
        _logger.LogInformation("Id {0}", _id);
    }

    public void OnPost(string nome, string cognome, int eta)
    {
        _logger.LogInformation("Modifica nome: {0} cognome: {1} eta: {2}", nome, cognome, eta);
        var jsonFile = System.IO.File.ReadAllText(jsonPath);
        Persone = JsonConvert.DeserializeObject<List<Persona>>(jsonFile)!;
        foreach (var persona in Persone)
        {
            if (persona.Id == _id)
            {
                persona.Nome = nome;
                persona.Cognome = cognome;
                persona.Eta = eta;
                break;
            }
        }
        System.IO.File.WriteAllText(jsonPath, JsonConvert.SerializeObject(Persone));
    }
}