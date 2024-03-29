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
}