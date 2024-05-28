using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Esame.Pages;

public class ConfermaModel : PageModel
{
    private readonly ILogger<ConfermaModel> _logger;

    public ConfermaModel(ILogger<ConfermaModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}