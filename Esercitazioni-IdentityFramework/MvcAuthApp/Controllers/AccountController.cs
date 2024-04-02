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

    // GET: /Account/AddToRoleAdmin
    public async Task<IActionResult> AddToRoleAdmin()
    {
        var user = await _userManager.FindByNameAsync(User.Identity!.Name!);
        await _userManager.AddToRoleAsync(user!, "Admin");
        return RedirectToAction("Index", "Home");
    }

    //GET: /Account/AddToRoleUser
    public async Task<IActionResult> AddToRoleUser()
    {
        var user = await _userManager.FindByNameAsync(User.Identity!.Name!);
        await _userManager.AddToRoleAsync(user!, "User");
        return RedirectToAction("Index", "Home");
    }

    //GET: /Account/GetRole
    public async Task<IActionResult> GetRole()
    {
        var user = await _userManager.FindByNameAsync(User.Identity!.Name!);
        var roles = await _userManager.GetRolesAsync(user!);
        return Content(string.Join(", ", roles));
    }

    //GET: /Account/RemoveFromRoleAdmin
    public async Task<IActionResult> RemoveFromRoleAdmin()
    {
        var user = await _userManager.FindByNameAsync(User.Identity!.Name!);
        await _userManager.RemoveFromRoleAsync(user!, "Admin");
        return RedirectToAction("Index", "Home");
    }

    //GET: /Account/RemoveFromRoleUser
    public async Task<IActionResult> RemoveFromRoleUser()
    {
        var user = await _userManager.FindByNameAsync(User.Identity!.Name!);
        await _userManager.RemoveFromRoleAsync(user!, "User");
        return RedirectToAction("Index", "Home");
    }

}