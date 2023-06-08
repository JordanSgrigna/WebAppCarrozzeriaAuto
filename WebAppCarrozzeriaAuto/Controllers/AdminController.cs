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
        public IActionResult PannelloAdmin()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN")]
        public IActionResult CreateAuto()
        {
            using (ConcessionarioContext db  = new ConcessionarioContext())
            {
                List<Tipo> tipi = db.Tipi.ToList();
                List<Marca> marche = db.Marche.ToList();
                List<Modello> modelli = db.Modelli.ToList();

                ModelloMacchinaComplesso modelloPerView = new ModelloMacchinaComplesso();
                modelloPerView.Auto = new Auto();
                modelloPerView.Modello = modelli;
                modelloPerView.Tipo = tipi;
                modelloPerView.Marca = marche;

                return View(modelloPerView);

            }
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public IActionResult CreateAuto(ModelloMacchinaComplesso data)
        {
            if (!ModelState.IsValid)
            {
                using(ConcessionarioContext db =new ConcessionarioContext())
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
                return View("CreateAuto", tipo);
            }
            else
            {
                using (ConcessionarioContext db = new ConcessionarioContext())
                {
                    db.Tipi.Add(tipo);
                    db.SaveChanges();
                    return RedirectToAction("CreateAuto", "Admin");
                }
            }
        }

        [HttpPost]
        public IActionResult CreateModello (Modello modello)
        {
            using (ConcessionarioContext db = new ConcessionarioContext())
            {
                //PRENDO LA LISTA DEI TIPI DA ASSOCIARE AL MODELLO
                List<Tipo> tipi = db.Tipi.ToList();

                if (!ModelState.IsValid)
                {
                    return View("CreateAuto", modello);
                }
                else
                {
                    db.Modelli.Add(modello);
                    db.SaveChanges();
                    return RedirectToAction("CreateAuto", "Admin");

                }
            }
        }

        [HttpPost]
        public IActionResult CreateMarca (Marca marca)
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
                    return RedirectToAction("CreateAuto", "Admin");
                }
            }
        }

        [HttpGet]
        public IActionResult AcquisisciMacchina()
        {
            using(ConcessionarioContext db = new ConcessionarioContext())
            {
                List<Auto> auto = db.Auto.ToList();
                List<Tipo> tipi = db.Tipi.ToList();
                List<Marca> marche = db.Marche.ToList();
                List<Modello> modelli = db.Modelli.ToList();

                ModelloAcquisizioneAuto modelloAcquisizioneAuto = new ModelloAcquisizioneAuto();

                modelloAcquisizioneAuto.Auto = auto;
                modelloAcquisizioneAuto.Marca = marche;
                modelloAcquisizioneAuto.Modello = modelli;
                modelloAcquisizioneAuto.Tipo = tipi;
                modelloAcquisizioneAuto.AcquisizioneAuto = new AcquisizioneAuto();

                return View(modelloAcquisizioneAuto);
            }
        }

    }
}
