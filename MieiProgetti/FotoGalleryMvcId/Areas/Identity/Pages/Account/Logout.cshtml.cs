// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using FotoGalleryMvcId.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using FotoGalleryMvcId.Data;

namespace FotoGalleryMvcId.Areas.Identity.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ILogger<LogoutModel> _logger;

        public LogoutModel(UserManager<AppUser> userManager, ApplicationDbContext db, SignInManager<AppUser> signInManager, ILogger<LogoutModel> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
            _db = db;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");

            #region db
            var user = await _userManager.GetUserAsync(User);

            //creo oggetto log per il db
            Log log = new Log
            {
                DataOperazione = DateTime.Now,
                Alias = user.Alias,
                Email = user.Email,
                Ruoli = user.Ruoli,
                OperazioneSvolta = "Logout",
                Tipologia = false   //true = UserExperience; false = Administrative
            };
            //salvo nel db
            await _db.Logs.AddAsync(log);
            await _db.SaveChangesAsync();

            #endregion

            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                // This needs to be a redirect so that the browser performs a new
                // request and the identity for the user gets updated.
                return RedirectToPage();
            }
        }
    }
}
