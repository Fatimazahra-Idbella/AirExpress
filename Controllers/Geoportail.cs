using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using testprj.Models;

namespace testprj.Controllers;

public class GeoportailController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public GeoportailController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
