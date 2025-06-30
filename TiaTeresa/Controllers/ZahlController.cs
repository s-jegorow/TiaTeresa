using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TiaTeresa.Models;

namespace TiaTeresa.Controllers
{
    public class ZahlController : Controller
    {
        private readonly TiaTeresaContext _context;

        public ZahlController(TiaTeresaContext context)
        {
            _context = context;
        }

        // GET: Zahl
        public async Task<IActionResult> Index()
        {
            return View(await _context.Zahl.ToListAsync());
        }

        // GET: Zahl/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zahl = await _context.Zahl
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zahl == null)
            {
                return NotFound();
            }

            return View(zahl);
        }

        // GET: Zahl/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zahl/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Wert,Spanisch,Audio")] Zahl zahl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zahl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zahl);
        }

        // GET: Zahl/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zahl = await _context.Zahl.FindAsync(id);
            if (zahl == null)
            {
                return NotFound();
            }
            return View(zahl);
        }

        // POST: Zahl/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Wert,Spanisch,Audio")] Zahl zahl)
        {
            if (id != zahl.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zahl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZahlExists(zahl.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(zahl);
        }

        // GET: Zahl/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zahl = await _context.Zahl
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zahl == null)
            {
                return NotFound();
            }

            return View(zahl);
        }

        // POST: Zahl/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zahl = await _context.Zahl.FindAsync(id);
            if (zahl != null)
            {
                _context.Zahl.Remove(zahl);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZahlExists(int id)
        {
            return _context.Zahl.Any(e => e.Id == id);
        }


        public IActionResult Trainer()
        {
            Random z = new Random();
            int randomIndex = z.Next(0, _context.Zahl.Count());

            Zahl zahl = _context.Zahl.ToList()[randomIndex];

            return View(zahl);
        }

        //Trainer Vergleich -> Ergebnis-String an View
        [HttpPost]
        public IActionResult Trainer(string eingabe, string fragedeutsch)
        {
            string ergebnis = null;


            if (eingabe != null && fragedeutsch.Equals(eingabe))
                ergebnis = "Korrekt!";
            else
            {
                ergebnis = $"Falsch! Die richtige Antwort wäre {fragedeutsch}";

            }


            return Content(ergebnis);
        }









    }
}
