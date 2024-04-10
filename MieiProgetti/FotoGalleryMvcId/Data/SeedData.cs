using FotoGalleryMvcId.Models;
using Microsoft.AspNetCore.Identity;

//!!! classe che crea i ruoli nel dbContext 
public class SeedData
{
    public static async Task InitializeAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        //creazione dei ruoli se non esistono
        string[] roleNames = { "Admin", "Moderatore", "User" };

        foreach (var roleName in roleNames)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        //creazione dell'utente Admin se non esiste (personalizzare con i mio)
        if (await userManager.FindByEmailAsync("admin@admin.com") == null)
        {
            var adminUser = new AppUser
            {
                UserName = "admin@admin.com",
                Email = "admin@admin.com",
                Nome = "Admin",
                Cognome = "Admin",
                Eta = 18,
                Alias = "Admin",
                EmailConfirmed = true,
                Status = true,
                Ruoli = "Admin"

            };
            await userManager.CreateAsync(adminUser, "Admin123!");
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }
    }
}