using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TiaTeresa.Models;

namespace TiaTeresa.Controllers
{
    
    public class VokabelController : Controller
    {
        private readonly TiaTeresaContext _context;

        public VokabelController(TiaTeresaContext context)
        {
            _context = context;
        }

        // GET: Vokabel Index mit Pagination
        public async Task<IActionResult> Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = page ?? 1;

            var query = _context.Vokabel.AsNoTracking();

            var totalCount = await query.CountAsync();
            var vokabeln = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            ViewBag.CurrentPage = pageNumber;
            ViewBag.TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            return View(vokabeln);
        }



        #region CRUD aus Scaffold
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vokabel = await _context.Vokabel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vokabel == null)
            {
                return NotFound();
            }

            return View(vokabel);
        }

      
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Spanisch,Deutsch")] Vokabel vokabel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vokabel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vokabel);
        }

      
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vokabel = await _context.Vokabel.FindAsync(id);
            if (vokabel == null)
            {
                return NotFound();
            }
            return View(vokabel);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Spanisch,Deutsch")] Vokabel vokabel)
        {
            if (id != vokabel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vokabel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VokabelExists(vokabel.Id))
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
            return View(vokabel);
        }

       
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vokabel = await _context.Vokabel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vokabel == null)
            {
                return NotFound();
            }

            return View(vokabel);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vokabel = await _context.Vokabel.FindAsync(id);
            if (vokabel != null)
            {
                _context.Vokabel.Remove(vokabel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VokabelExists(int id)
        {
            return _context.Vokabel.Any(e => e.Id == id);
        }


        #endregion

        public  IActionResult Trainer()
        {
            Random z = new Random();
            int randomIndex = z.Next(0, _context.Vokabel.Count());
            
            Vokabel vokabel = _context.Vokabel.ToList()[randomIndex];

            return View(vokabel);
        }
        
        //Trainer Vergleich -> Ergebnis-String an View
        [HttpPost]
        public IActionResult Trainer(string eingabe, string fragedeutsch)
        {
            string ergebnis = null;


            if (eingabe != null && eingabe.Length >= 3 &&  fragedeutsch.ToLower().Contains(eingabe.ToLower()))
                ergebnis = "Korrekt!";
            else
            { 
                ergebnis = $"Falsch! Die richtige Antwort wäre {fragedeutsch}";
                
            }


            return Content(ergebnis);
        }
    }
}
