using Microsoft.AspNetCore.Mvc;

namespace WebAppCarrozzeriaAuto.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult PannelloAdmin()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {

        }
    }
}
