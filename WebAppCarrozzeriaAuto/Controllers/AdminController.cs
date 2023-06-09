using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppCarrozzeriaAuto.Database;
using WebAppCarrozzeriaAuto.Models;
using WebAppCarrozzeriaAuto.Models.ModelsPerViews;

namespace WebAppCarrozzeriaAuto.Controllers
{
    public class AdminController : Controller
    {
        //GET
        [HttpGet]
        public IActionResult PannelloAdmin()
        {
            return View();
        }

        public IActionResult ListaMacchineAdmin()
        {
            using (ConcessionarioContext db = new ConcessionarioContext())
            {
                List<Auto> auto = db.Auto
                            .Include(auto => auto.MarcaAuto)
                            .Include(auto => auto.ModelloAuto)
                            .Include(auto => auto.TipoAuto)
                            .ToList();

                return View(auto);
            }
        }

        [HttpGet]
        public IActionResult CreateAuto()
        {
            using (ConcessionarioContext db = new ConcessionarioContext())
            {
                List<Tipo> tipi = db.Tipi.ToList();
                List<Marca> marche = db.Marche.ToList();
                List<Modello> modelli = db.Modelli.ToList();

                ModelloMacchinaComplesso modelloPerView = new ModelloMacchinaComplesso();
                modelloPerView.Auto = new Auto();
                modelloPerView.Specifiche = new SpecificheTecniche();
                modelloPerView.Modello = modelli;
                modelloPerView.Tipo = tipi;
                modelloPerView.Marca = marche;

                return View(modelloPerView);

            }
        }

        [HttpGet]
        public IActionResult CreateModello()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateMarca()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateTipo()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AcquistaMacchina(int id)
        {
            using (ConcessionarioContext db = new ConcessionarioContext())
            {
                Auto? autoDaAcquistare = db.Auto
                            .Where(auto => auto.Id == id)
                            .Include(auto => auto.MarcaAuto)
                            .Include(auto => auto.ModelloAuto)
                            .Include(auto => auto.TipoAuto)
                            .FirstOrDefault();

                if (autoDaAcquistare != null)
                {
                    ModelloAcquisizioneAuto modelloAcquisizioneAuto = new ModelloAcquisizioneAuto();

                    modelloAcquisizioneAuto.Auto = autoDaAcquistare;
                    modelloAcquisizioneAuto.AcquistoAuto = new AcquistoAuto();

                    return View(modelloAcquisizioneAuto);
                }
                else
                {
                    return NotFound();
                }
            }
        }

        //POST
        [HttpPost]
        public IActionResult CreateAuto(ModelloMacchinaComplesso data)
        {
            if (!ModelState.IsValid)
            {
                using (ConcessionarioContext db = new ConcessionarioContext())
                {
                    List<Tipo> tipi = db.Tipi.ToList();
                    List<Marca> marche = db.Marche.ToList();
                    List<Modello> modelli = db.Modelli.ToList();

                    data.Tipo = tipi;
                    data.Marca = marche;
                    data.Modello = modelli;

                    return View(data);
                }
            }
            else
            {
                using (ConcessionarioContext db = new ConcessionarioContext())
                {
                    db.Auto.Add(data.Auto);
                    db.SaveChanges();

                    return RedirectToAction("Index", "Auto");
                }
            }
        }

        [HttpPost]
        public IActionResult CreateTipo(Tipo tipo)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateTipo", tipo);
            }
            else
            {
                using (ConcessionarioContext db = new ConcessionarioContext())
                {
                    db.Tipi.Add(tipo);
                    db.SaveChanges();
                    return RedirectToAction("PannelloAdmin", "Admin");
                }
            }
        }

        [HttpPost]
        public IActionResult CreateModello(Modello modello)
        {
            using (ConcessionarioContext db = new ConcessionarioContext())
            {
                if (!ModelState.IsValid)
                {
                    return View("CreateAuto", modello);
                }
                else
                {
                    db.Modelli.Add(modello);
                    db.SaveChanges();
                    return RedirectToAction("PannelloAdmin", "Admin");

                }
            }
        }

        [HttpPost]
        public IActionResult CreateMarca(Marca marca)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateAuto", marca);
            }
            else
            {
                using (ConcessionarioContext db = new ConcessionarioContext())
                {
                    db.Marche.Add(marca);
                    db.SaveChanges();
                    return RedirectToAction("PannelloAdmin", "Admin");
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AcquisisciMacchina(ModelloAcquisizioneAuto data)
        {
            if (!ModelState.IsValid)
            {
                return View(data.AcquistoAuto);
            }
            else
            {
                using (ConcessionarioContext db = new ConcessionarioContext())
                {
                    db.AcquisizioniAuto.Add(data.AcquistoAuto);
                    db.SaveChanges();

                    return RedirectToAction("PannelloAdmin");
                }
            }

        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            using (ConcessionarioContext db = new ConcessionarioContext())
            {
                Auto? autoDaEliminare = db.Auto.Where(auto => auto.Id == id).FirstOrDefault();
                if (autoDaEliminare != null)
                {
                    db.Auto.Remove(autoDaEliminare);
                    db.SaveChanges();
                    return RedirectToAction("PannelloAdmin");

                }
                else return NotFound();
            }
        }

    }
}
