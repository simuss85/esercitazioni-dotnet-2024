using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor;

namespace FoodexpRazor.Pages;

public class AlimentiModel : PageModel
{
    #region Logger
    private readonly ILogger<IndexModel> _logger;

    public AlimentiModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }
    #endregion

    public void OnGet()
    {

    }
}