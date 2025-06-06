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
    public class GeschichteController : Controller
    {
        private readonly TiaTeresaContext _context;

        public GeschichteController(TiaTeresaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var alleGeschichten = _context.Geschichte.ToList();


            return View(alleGeschichten);
        }



      
        public async Task<IActionResult> Details(int? id)
        {


            if (id == null)
            {
                return NotFound();
            }

            var geschichte = await _context.Geschichte
                .FirstOrDefaultAsync(m => m.Id == id);
            if (geschichte == null)
            {
                return NotFound();
            }

            ViewBag.Deutsch = geschichte?.Deutsch?.Split('|') ?? Array.Empty<string>();
            ViewBag.Spanisch = geschichte?.Spanisch?.Split('|') ?? Array.Empty<string>();

            return View(geschichte);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

   
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TitelSpanisch,TitelDeutsch,Spanisch,Deutsch,Niveau,Bild,Audio")] Geschichte geschichte)
        {
            if (ModelState.IsValid)
            {
                _context.Add(geschichte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(geschichte);
        }

    
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var geschichte = await _context.Geschichte.FindAsync(id);
            if (geschichte == null)
            {
                return NotFound();
            }
            return View(geschichte);
        }


        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TitelSpanisch,TitelDeutsch,Spanisch,Deutsch,Niveau,Bild,Audio")] Geschichte geschichte)
        {
            if (id != geschichte.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(geschichte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GeschichteExists(geschichte.Id))
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
            return View(geschichte);
        }


        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var geschichte = await _context.Geschichte
                .FirstOrDefaultAsync(m => m.Id == id);
            if (geschichte == null)
            {
                return NotFound();
            }

            return View(geschichte);
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var geschichte = await _context.Geschichte.FindAsync(id);
            if (geschichte != null)
            {
                _context.Geschichte.Remove(geschichte);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GeschichteExists(int id)
        {
            return _context.Geschichte.Any(e => e.Id == id);
        }
    }
}