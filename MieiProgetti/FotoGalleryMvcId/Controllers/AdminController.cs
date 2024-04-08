using FotoGalleryMvcId.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FotoGalleryMvcId.Controllers;

public class AdminController : Controller
{
    // private readonly UserManager<AppUser> _userManager;

    // public AdminController(UserManager<AppUser> userManager)
    // {
    //     _userManager = userManager;
    // }

    //GET: /Account/AddToRoleAdmin
    // public async Task<IActionResult> AddToRoleModeratore()
    // {
    //     var user = await _userManager.FindByNameAsync(User.Identity!.Name!);
    //     await _userManager.AddToRoleAsync(user!, "Moderatore");
    //     return RedirectToAction("Index", "Pages");
    // }

    // //GET: /Account/AddToRoleUser
    // public async Task<IActionResult> AddToRoleUser()
    // {
    //     var user = await _userManager.FindByNameAsync(User.Identity!.Name!);
    //     await _userManager.AddToRoleAsync(user!, "User");
    //     return RedirectToAction("Index", "Pages");
    // }
}