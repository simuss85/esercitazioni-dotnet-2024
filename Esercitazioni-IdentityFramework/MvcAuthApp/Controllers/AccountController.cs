using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MvcAuthApp.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;

    public AccountController(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    // GET: /Account/AddToRole
    public async Task<IActionResult> AddToRole()
    {
        var user = await _userManager.FindByNameAsync(User.Identity!.Name!);
        await _userManager.AddToRoleAsync(user!, "Admin");
        return RedirectToAction("Index", "Home");
    }

    //GET: /Account/GetRole
    public async Task<IActionResult> GetRole()
    {
        var user = await _userManager.FindByNameAsync(User.Identity!.Name!);
        var roles = await _userManager.GetRolesAsync(user!);
        return Content(string.Join(", ", roles));
    }
}