using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FotoGalleryMvcId.Models;
using Newtonsoft.Json;

namespace FotoGalleryMvcId.Controllers;

public class ModeratoreController : Controller
{
    private readonly ILogger<ModeratoreController> _logger;

    public ModeratoreController(ILogger<ModeratoreController> logger)
    {
        _logger = logger;
    }
}