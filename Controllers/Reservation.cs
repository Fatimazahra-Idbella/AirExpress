using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using VotreApplication.Data;
using VotreApplication.Models;

namespace VotreApplication.Controllers
{
    public class ReservationController : Controller
    {
        private readonly AppDbContext _context;

        public ReservationController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Reservation/Create/5 (volId)
        public async Task<IActionResult> Create(int? volId)
        {
            if (volId == null)
            {
                return NotFound();
            }

            var vol = await _context.Vols.FindAsync(volId);
            if (vol == null || vol.PlacesMax <= 0)
            {
                return View("PlusDePlaces");
            }

            ViewBag.VolInfo = vol;
            return View(new Reservation { VolId = volId.Value });
        }

        // POST: Reservation/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VolId,ClientId,Classe")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                // Vérifier la disponibilité
                var vol = await _context.Vols
                    .Include(v => v.Reservations)
                    .FirstOrDefaultAsync(v => v.Id == reservation.VolId);

                if (vol == null || vol.Reservations.Count >= vol.PlacesMax)
                {
                    ModelState.AddModelError("", "Plus de places disponibles");
                    ViewBag.VolInfo = vol;
                    return View(reservation);
                }

                // Calculer le prix (exemple simplifié)
                reservation.PrixPaye = vol.Prix * (reservation.Classe == "Affaire" ? 1.5m : 1m);
                reservation.DateReservation = DateTime.Now;
                reservation.Confirmee = true;

                _context.Add(reservation);
                await _context.SaveChangesAsync();

                return RedirectToAction("Details", new { id = reservation.Id });
            }
            return View(reservation);
        }

        // GET: Reservation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations
                .Include(r => r.Vol)
                .Include(r => r.Client)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // GET: Reservation/Annuler/5

        public async Task<IActionResult> Annuler(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations
                .Include(r => r.Vol)
                .Include(r => r.Client)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // POST: Reservation/Annuler/5
        [HttpPost, ActionName("Annuler")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> AnnulerConfirmed(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation != null)
            {
                _context.Reservations.Remove(reservation);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Reservation/ParClient/5
        public async Task<IActionResult> ParClient(int clientId)
        {
            var reservations = await _context.Reservations
                .Where(r => r.ClientId == clientId)
                .Include(r => r.Vol)
                .ToListAsync();

            return View(reservations);
        }
        
         public IActionResult Index()
    {
        return View();
    }
    }
}