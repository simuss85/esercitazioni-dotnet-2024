using FoodexpRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodexpRazor.Pages;

public class DettaglioAlimentoModel : PageModel
{
    public readonly Database _db = new();
    public required Alimento Alimento { get; set; }

    #region Logger
    private readonly ILogger<DettaglioAlimentoModel> _logger;

    public DettaglioAlimentoModel(ILogger<DettaglioAlimentoModel> logger)
    {
        _logger = logger;
    }
    #endregion

    public void OnGet(int id)
    {
        _logger.LogInformation("Data: {0}", id);
        Alimento = _db.Alimenti.First(a => a.Id == id)!;

    }

}
