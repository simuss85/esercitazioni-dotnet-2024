using FotoGalleryMvcId.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FotoGalleryMvcId.Controllers;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    //per la gestione dei file json
    private readonly Paths paths = new();

    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly ILogger<AdminController> _logger;

    public AdminController(ILogger<AdminController> logger, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _logger = logger;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    [HttpGet]
    public async Task<IActionResult> GestioneUtenti(int pageIndex = 1)
    {
        //creo il modello per gestire la view
        var model = new GestioneUtentiViewModel
        {
            //genero la lista degli utenti del sistema
            Utenti = await _userManager.Users.ToListAsync(),
            PageIndex = pageIndex
        };

        //log che visualizza la pagina selezionata, user e orario
        _logger.LogInformation("{0} - GestioneUtenti --> (PageIndex: {1})", DateTime.Now.ToString("T"), pageIndex);

        return View(model);
    }
}