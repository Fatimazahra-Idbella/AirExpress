// Controllers/VolController.cs
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using testprj.Models;

namespace testprj.Controllers;
public class VolController : Controller
{
    private static List<Vol> vols = new List<Vol>
    {
        new Vol { Id = 1, Destination = "Paris", Depart = "Lyon", DateDepart = DateTime.Now.AddDays(5), Prix = 150, PlacesDisponibles = 50 },
        new Vol { Id = 2, Destination = "New York", Depart = "Paris", DateDepart = DateTime.Now.AddDays(10), Prix = 500, PlacesDisponibles = 30 }
    };

    public IActionResult Index()
    {
        var vols = new List<Vol>
    {
        new Vol { Id = 1, Destination = "Paris", Depart = "Casablanca", DateDepart = DateTime.Now.AddDays(3), Prix = 1200, PlacesMax = 150 },
        new Vol { Id = 2, Destination = "New York", Depart = "Rabat", DateDepart = DateTime.Now.AddDays(5), Prix = 3500, PlacesMax = 200 },
        new Vol { Id = 3, Destination = "Dubai", Depart = "Marrakech", DateDepart = DateTime.Now.AddDays(2), Prix = 2800, PlacesMax = 180 }
    };
        return View(vols); // Passe les vols à la vue
    }

    public IActionResult Details(int id)
    {
        var vol = vols.FirstOrDefault(v => v.Id == id);
        return View(vol); // Affiche les détails d'un vol
    }
}