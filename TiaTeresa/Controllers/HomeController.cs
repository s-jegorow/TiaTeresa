using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiaTeresa.Models;
using Microsoft.AspNetCore.Authorization;


namespace TiaTeresa.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TiaTeresaContext _context;


        public HomeController(ILogger<HomeController> logger, TiaTeresaContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {

            int seed = DateTime.Today.GetHashCode();
            Random z = new Random(seed);

            int randomIndex = z.Next(0, _context.Sprichwort.Count());
            var tagessprichwort = _context.Sprichwort.ToList()[randomIndex];

            ViewBag.Sprichwort = tagessprichwort.Spanisch;
            ViewBag.Sprichwortuebersetzung = tagessprichwort.Deutsch;



            Random z2 = new Random(seed);
            int randomIndexvokabel = z2.Next(0, _context.Vokabel.Count());
            var tagesvokabel = _context.Vokabel.ToList()[randomIndexvokabel];


            ViewBag.Vokabel = tagesvokabel.Spanisch;
            ViewBag.Vokabeluebersetzung = tagesvokabel.Deutsch;
            return View();

        }


        public IActionResult TiaTeresaProfil()
        {
            return View();
        }


        public IActionResult Impressum()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
