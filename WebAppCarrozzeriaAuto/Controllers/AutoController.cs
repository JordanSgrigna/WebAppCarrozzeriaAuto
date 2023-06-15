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
            using (ConcessionarioContext db = new ConcessionarioContext())
            {
                List<Auto> auto = db.Auto
                                  .Include(auto => auto.Specifiche)
                                  .ToList();


                return View(auto);
            }
        }

        [HttpGet]
        public IActionResult DettagliMacchina(int id)
        {
            using (ConcessionarioContext db = new ConcessionarioContext())
            {
                Auto? autoDettagliata = db.Auto.Where(a => a.Id == id)
                                               .Include(t => t.Specifiche)
                                               .FirstOrDefault();

                if (autoDettagliata == null)
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
        public IActionResult TrovaMarcaOModello(string input)
        {
            using (ConcessionarioContext db = new ConcessionarioContext())
            {
                List<Auto>? autoTrovate = db.Auto.Where(a => a.MarcaAuto.Contains(input) || a.NomeModello.Contains(input)).ToList();
                return View("Index", autoTrovate);
            }
        }

        [HttpGet]
        public IActionResult VenditaAuto()
        {
            using (ConcessionarioContext db = new ConcessionarioContext())
            {
                List<Auto>? autoDaVendere = db.Auto.ToList();
                ModelloVenditaAutoUtente data = new ModelloVenditaAutoUtente();

                data.Auto = autoDaVendere;
                data.Vendita = new VenditaAutoUtente();
                


                return View(data);

            }
        }

        //POST

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult VenditaAuto(int id, ModelloVenditaAutoUtente data)
        {
            if (!ModelState.IsValid)
            {
                return View(data);
            }
            else
            {
                using (ConcessionarioContext db = new ConcessionarioContext())
                {

                    Auto? autoDaVendere = db.Auto.Where(a => a.Id == id).FirstOrDefault();

                    if (autoDaVendere == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        data.Vendita.PrezzoTotale = data.Vendita.QuantitaAuto * autoDaVendere.Prezzo;
                        db.VenditeAuto.Add(data.Vendita);
                        autoDaVendere.NumeroAutoNelConcessionario -= data.Vendita.QuantitaAuto;
                        db.SaveChanges();
                        return RedirectToAction("Index", "Auto");
                    }
                }
            }
        }


    }


}
