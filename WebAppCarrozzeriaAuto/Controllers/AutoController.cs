using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppCarrozzeriaAuto.Database;
using WebAppCarrozzeriaAuto.Models;
using WebAppCarrozzeriaAuto.Models.ModelsPerViews;

namespace WebAppCarrozzeriaAuto.Controllers
{
    public class AutoController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            using(ConcessionarioContext db = new ConcessionarioContext())
            {
                List<Auto> auto = db.Auto.ToList();
                List<Tipo> tipi = db.Tipi.ToList();
                List<Marca> marche = db.Marche.ToList();
                List<Modello> modelli = db.Modelli.ToList();
                List<SpecificheTecniche> specifiche = db.SpecificheTecniche.ToList();


                return View();
            }
        }

        [HttpGet]
        public IActionResult DettagliMacchina(int id)
        {
            using(ConcessionarioContext db = new ConcessionarioContext())
            {
                Auto? autoDettagliata = db.Auto.Where(a => a.Id == id).Include(m => m.MarcaAuto).FirstOrDefault();
                if(autoDettagliata == null)
                {
                    return NotFound();
                }
                else
                {
                    return View("DettagliMacchina", autoDettagliata);
                }
            }
        }

        [HttpGet]
        [Authorize(Roles = "USER")]
        public IActionResult VenditaAuto(int id)
        {
            using (ConcessionarioContext db = new ConcessionarioContext())
            {
                Auto? autoDaVendere = db.Auto.Where(a => a.Id == id).Include(m => m.MarcaAuto).FirstOrDefault();

                if(autoDaVendere == null)
                {
                    return NotFound();
                }
                else
                {
                    VenditaAutoUtente venditaAuto = new VenditaAutoUtente();


                    return View();
                }
            }
        }
    }
}
