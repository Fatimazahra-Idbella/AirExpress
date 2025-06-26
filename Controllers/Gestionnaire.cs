using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using testprj.Models;

namespace testprj.Controllers;

public class GestionnaireController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public GestionnaireController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Details()
    {
        return View();
    }
    public IActionResult Create()
    {
        return View();
    }

    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
