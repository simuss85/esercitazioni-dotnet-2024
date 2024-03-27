using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FotoGalleryRazor.Pages;

[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
[IgnoreAntiforgeryToken]
public class ErrorModel : PageModel
{
    [BindProperty]
    public required string ReturnUrl { get; set; }
    public required string Message { get; set; }


    public IActionResult OnGet(string message, string returnUrl)
    {
        Message = message;
        ReturnUrl = returnUrl;
        return Page();
    }

    public IActionResult OnPost()
    {
        return Redirect(ReturnUrl);
    }
}

