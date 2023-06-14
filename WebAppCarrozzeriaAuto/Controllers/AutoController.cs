using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.Arm;
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
                List<Auto> auto = db.Auto
                                  .Include(auto => auto.MarcaAuto)
                                  .Include(auto => auto.TipoAuto)
                                  .Include(auto => auto.Specifiche)
                                  .ToList();


                return View(auto);
            }
        }

        [HttpGet]
        public IActionResult DettagliMacchina(int id)
        {
            using(ConcessionarioContext db = new ConcessionarioContext())
            {
                Auto? autoDettagliata = db.Auto.Where(a => a.Id == id)
                                               .Include(m => m.MarcaAuto)
                                               .Include(t => t.TipoAuto)
                                               .Include(t => t.Specifiche)
                                               .FirstOrDefault();

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
        public IActionResult VenditaAuto(int id)
        {
            using (ConcessionarioContext db = new ConcessionarioContext())
            {
                Auto? autoDaVendere = db.Auto.Where(a => a.Id == id)
                                             .Include(m => m.MarcaAuto)
                                             .Include(a => a.TipoAuto)
                                             .FirstOrDefault();

                if(autoDaVendere == null)
                {
                    return NotFound();
                }
                else
                {
                    ModelloVenditaAutoUtente data = new ModelloVenditaAutoUtente();
                    VenditaAutoUtente venditaAuto = new VenditaAutoUtente();
                    data.Vendita = venditaAuto;
                    data.Auto = autoDaVendere;


                    return View(data);
                }
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
                using(ConcessionarioContext db = new ConcessionarioContext())
                {
                    data.Vendita.PrezzoTotale = data.Vendita.QuantitaAuto * data.Auto.Prezzo;
                    db.VenditeAuto.Add(data.Vendita);
                    Auto? autoDaVendere = db.Auto.Where(a => a.Id == id).FirstOrDefault();

                    if (autoDaVendere == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        autoDaVendere.NumeroAutoNelConcessionario -= data.Vendita.QuantitaAuto;
                        db.SaveChanges();
                        return RedirectToAction("Index", "Auto");
                    }
                }
            }
        }


    }


}
