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

        [HttpGet]
        public IActionResult ModifyAuto(int id)
        {
            using (ConcessionarioContext db = new ConcessionarioContext())
            {
                Auto? autoToModify = db.Auto.Where(auto => auto.Id == id).FirstOrDefault();
                if(autoToModify != null)
                {
                    return View("Update", autoToModify);
                } else
                {
                    return NotFound("L'auto che desideri modificare non è stata trovata.");
                }
            }
        }

        [HttpPost]
        public IActionResult ModifyAuto(int id,Auto modifiedAuto)
        {
            if(ModelState.IsValid)
            {
                return View("Update", modifiedAuto);
            }

            using (ConcessionarioContext db = new ConcessionarioContext())
            {
                Auto? autoToModify = db.Auto.Where(auto => auto.Id == id).FirstOrDefault();

                if(autoToModify != null)
                {
                    autoToModify.Descrizione = modifiedAuto.Descrizione;
                    autoToModify.AnnoImmatricolazione = modifiedAuto.AnnoImmatricolazione;
                    autoToModify.Colore = modifiedAuto.Colore;
                    autoToModify.UrlImmagine = modifiedAuto.UrlImmagine;
                    autoToModify.NumeroAutoNelConcessionario = modifiedAuto.NumeroAutoNelConcessionario;
                    autoToModify.NumeroLikeUtenti = modifiedAuto.NumeroLikeUtenti;
                    autoToModify.Prezzo = modifiedAuto.Prezzo;
                    autoToModify.AnnoProduzione = modifiedAuto.AnnoProduzione;
                    autoToModify.Usata = modifiedAuto.Usata;


                    db.SaveChanges();
                    return RedirectToAction("Index");
                } else
                {
                    return NotFound("L'auto che desideri modificare non è stata trovata.");
                }
            }

        }

        [HttpGet]
        public IActionResult ModifyMarca(int id)
        {
            using (ConcessionarioContext db = new ConcessionarioContext())
            {
                Marca? marcaToModify = db.Marche.Where(marca => marca.Id == id).FirstOrDefault();
                if (marcaToModify != null)
                {
                    return View("Update", marcaToModify);
                }
                else
                {
                    return NotFound("La marca che desideri modificare non è stata trovata.");
                }
            }
        }

        [HttpPost]
        public IActionResult ModifyMarca(int id, Marca modifiedMarca)
        {
            if (ModelState.IsValid)
            {
                return View("Update", modifiedMarca);
            }

            using (ConcessionarioContext db = new ConcessionarioContext())
            {
                Marca? marcaToModify = db.Marche.Where(marca => marca.Id == id).FirstOrDefault();

                if (marcaToModify != null)
                {
                    marcaToModify.Nome = modifiedMarca.Nome;
                    marcaToModify.PaeseOrigine = modifiedMarca.PaeseOrigine;

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound("La marca che desideri modificare non è stata trovata.");
                }
            }

        }

        [HttpGet]
        public IActionResult ModifyModello(int id)
        {
            using (ConcessionarioContext db = new ConcessionarioContext())
            {
                Modello? modelloToModify = db.Modelli.Where(modello => modello.Id == id).FirstOrDefault();
                if (modelloToModify != null)
                {
                    return View("Update", modelloToModify);
                }
                else
                {
                    return NotFound("Il modello che desideri modificare non è stata trovata.");
                }
            }
        }

        [HttpPost]
        public IActionResult ModifyModello(int id, Modello modifiedModello)
        {
            if (ModelState.IsValid)
            {
                return View("Update", modifiedModello);
            }

            using (ConcessionarioContext db = new ConcessionarioContext())
            {
                Marca? modelloToModify = db.Marche.Where(marca => marca.Id == id).FirstOrDefault();

                if (modelloToModify != null)
                {
                   

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound("Il modello che desideri modificare non è stata trovata.");
                }
            }

        }

    }
}
