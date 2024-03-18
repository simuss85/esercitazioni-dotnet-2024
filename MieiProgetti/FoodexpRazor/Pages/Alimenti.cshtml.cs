using FoodexpRazor.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor;

namespace FoodexpRazor.Pages;

public class AlimentiModel : PageModel
{
    public required IEnumerable<Alimento> Alimenti { get; set; }
    public readonly Database _db = new();

    #region Logger
    private readonly ILogger<IndexModel> _logger;

    public AlimentiModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }
    #endregion

    public void OnGet(int? pageIndex)
    {
        _logger.LogInformation("Tabella alimenti");

        Alimenti = _db.Alimenti.ToList();
    }
}