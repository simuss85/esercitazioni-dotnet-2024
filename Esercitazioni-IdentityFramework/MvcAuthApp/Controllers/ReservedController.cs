using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MvcAuthApp.Controllers;

public class ReservedController : Controller
{
    //GET: autorizzati Reserved/Index
    [Authorize]
    public IActionResult Index()
    {
        return View();
    }

    //GET: /Reserved/Admin
    [Authorize(Roles = "Admin")]
    public IActionResult Admin()
    {
        return View();
    }

    //GET: /Reserved/User
    [Authorize(Roles = "User")]
    public IActionResult Users()
    {
        return View();
    }
}