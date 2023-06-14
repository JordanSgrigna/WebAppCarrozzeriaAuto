using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using WebAppCarrozzeriaAuto.Database;
using WebAppCarrozzeriaAuto.Models;

namespace WebAppCarrozzeriaAuto.Controllers
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
            using(ConcessionarioContext db = new ConcessionarioContext())
            {
                List<Auto> autoOrdinatePerLike = db.Auto.OrderByDescending(a => a.NumeroLikeUtenti).ToList();
                return View(autoOrdinatePerLike);
            }

        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contattaci()
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