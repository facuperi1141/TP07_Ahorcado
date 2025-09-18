using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP07_Ahorcado.Models;

namespace TP07_Ahorcado.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
}
