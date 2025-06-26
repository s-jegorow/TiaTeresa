using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TiaTeresa.Models;

namespace TiaTeresa.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Sprichwort = "No hay mal que por bien no venga.";
            ViewBag.SprichwortÜbersetzung = "Kein Unglück, das nicht auch etwas Gutes bringt.";

            ViewBag.Vokabel = "el paraguas";
            ViewBag.VokabelÜbersetzung = "der Regenschirm";
            return View();
        
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
