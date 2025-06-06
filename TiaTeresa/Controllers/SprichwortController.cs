using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiaTeresa.Models;

namespace TiaTeresa.Controllers
{
    public class SprichwortController : Controller
    {
        private readonly TiaTeresaContext _context;

        public SprichwortController(TiaTeresaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Sprichwort.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var sprichwort = await _context.Sprichwort.FirstOrDefaultAsync(m => m.ID == id);
            if (sprichwort == null)
                return NotFound();

            return View(sprichwort);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Spanisch,Deutsch,BedeutungSpanisch,BedeutungDeutsch,Bilddatei")] Sprichwort sprichwort)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sprichwort);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sprichwort);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var sprichwort = await _context.Sprichwort.FindAsync(id);
            if (sprichwort == null)
                return NotFound();

            return View(sprichwort);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Spanisch,Deutsch,BedeutungSpanisch,BedeutungDeutsch,Bilddatei")] Sprichwort sprichwort)
        {
            if (id != sprichwort.ID)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sprichwort);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SprichwortExists(sprichwort.ID))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(sprichwort);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var sprichwort = await _context.Sprichwort.FirstOrDefaultAsync(m => m.ID == id);
            if (sprichwort == null)
                return NotFound();

            return View(sprichwort);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sprichwort = await _context.Sprichwort.FindAsync(id);
            if (sprichwort != null)
            {
                _context.Sprichwort.Remove(sprichwort);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool SprichwortExists(int id)
        {
            return _context.Sprichwort.Any(e => e.ID == id);
        }
    }
}
