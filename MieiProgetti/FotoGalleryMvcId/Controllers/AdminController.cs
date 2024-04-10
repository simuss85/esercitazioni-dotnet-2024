using FotoGalleryMvcId.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FotoGalleryMvcId.Controllers;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    //per la gestione dei file json
    private readonly Paths paths = new();

    //per la gestione dell'utente
    private readonly UserManager<AppUser> _userManager;
    private readonly ILogger<AdminController> _logger;

    public AdminController(ILogger<AdminController> logger, UserManager<AppUser> userManager)
    {
        _logger = logger;
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> GestioneUtenti(int pageIndex = 1)
    {
        //memorizzo l'Utente attuale
        var user = await _userManager.GetUserAsync(User);

        if (user != null)
        {
            //creo un ViewBag per inviare l'Alias alla index
            ViewBag.Alias = user!.Alias;
        }

        //log che visualizza la pagina selezionata, user e orario
        _logger.LogInformation("{0} - GestioneUtenti --> (User: {1} - PageIndex: {2})", DateTime.Now.ToString("T"), user, pageIndex);

        return View();
    }
}