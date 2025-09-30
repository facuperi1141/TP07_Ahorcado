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
        Juego juego = new Juego();
        HttpContext.Session.SetString("juego", Objeto.ObjectToString(juego));
        ViewBag.jugadores = juego.DevolverListaUsuarios();
        return View();
    }
    [HttpPost] public IActionResult Comenzar(string username, int dificultad)
    {
        Juego juego = Objeto.StringToObject<Juego>(HttpContext.Session.GetString("juego"));
        juego.InicializarJuego(username, dificultad);
        HttpContext.Session.SetString("juego", Objeto.ObjectToString(juego));
        ViewBag.username = username;
        ViewBag.palabra = juego.CargarPalabra(dificultad);
        return View();
    }
    [HttpPost]
    public IActionResult FinJuego(int intentos)
    {
        Juego juego = Objeto.StringToObject<Juego>(HttpContext.Session.GetString("Juego"));
        juego.Finjuego(intentos);
        HttpContext.Session.Clear();
        return View("Index");
    }
}
