using FoodexpRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodexpRazor.Pages;

public class DettaglioAlimentoModel : PageModel
{
    public required Alimento Alimento { get; set; }
    #region Logger
    private readonly ILogger<DettaglioAlimentoModel> _logger;

    public DettaglioAlimentoModel(ILogger<DettaglioAlimentoModel> logger)
    {
        _logger = logger;
    }
    #endregion

    public void OnGet(Alimento alimento)
    {
        Alimento = alimento;

    }

}
