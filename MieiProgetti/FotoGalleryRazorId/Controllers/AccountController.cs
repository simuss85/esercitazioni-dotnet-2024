using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FotoGalleryRazorId.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;

    public AccountController(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    //GET: /Account/AddToRoleAdmin
    public async Task<IActionResult> AddToRoleAdmin()
    {
        var user = await _userManager.FindByNameAsync(User.Identity!.Name!);
        await _userManager.AddToRoleAsync(user!, "Admin");
        return RedirectToAction("Index", "Pages");
    }

    //GET: /Account/AddToRoleUser
    public async Task<IActionResult> AddToRoleUser()
    {
        var user = await _userManager.FindByNameAsync(User.Identity!.Name!);
        await _userManager.AddToRoleAsync(user!, "User");
        return RedirectToAction("Index", "Pages");
    }
}