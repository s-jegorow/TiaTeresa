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
    public class OrtController : Controller
    {
        private readonly TiaTeresaContext _context;

        public OrtController(TiaTeresaContext context)
        {
            _context = context;
        }

       
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ort.ToListAsync());
        }

       
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ort = await _context.Ort
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ort == null)
            {
                return NotFound();
            }

            ViewBag.Deutsch = ort?.BeschreibungDeutsch?.Split('|') ?? Array.Empty<string>();
            ViewBag.Spanisch = ort?.BeschreibungSpanisch?.Split('|') ?? Array.Empty<string>();

            return View(ort);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,BeschreibungSpanisch,BeschreibungDeutsch,URL,Bild,BildCopyright,lon,lat")] Ort ort)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ort);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ort);
        }

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ort = await _context.Ort.FindAsync(id);
            if (ort == null)
            {
                return NotFound();
            }
            return View(ort);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,BeschreibungSpanisch,BeschreibungDeutsch,URL,Bild,BildCopyright,lon,lat")] Ort ort)
        {
            if (id != ort.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ort);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrtExists(ort.Id))
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
            return View(ort);
        }

        // GET: Ort/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ort = await _context.Ort
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ort == null)
            {
                return NotFound();
            }

            return View(ort);
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ort = await _context.Ort.FindAsync(id);
            if (ort != null)
            {
                _context.Ort.Remove(ort);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrtExists(int id)
        {
            return _context.Ort.Any(e => e.Id == id);
        }
    }
}
