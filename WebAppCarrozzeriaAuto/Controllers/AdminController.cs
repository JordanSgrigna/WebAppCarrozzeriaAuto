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


        [HttpGet]
        public IActionResult ListaMacchineAdmin()
        {
            using (ConcessionarioContext db = new ConcessionarioContext())
            {
                List<Auto> auto = db.Auto.ToList();

                return View(auto);
            }
        }

        [HttpGet]
        public IActionResult CreateAuto()
        {
            using (ConcessionarioContext db = new ConcessionarioContext())
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult CreateSpecificheTecniche(int id)
        {
            SpecificheTecniche specifiche = new SpecificheTecniche();
            specifiche.AutoId = id;
            return View();
        }



        [HttpGet]
        public IActionResult ModifyAuto(int id)
        {
            using (ConcessionarioContext db = new ConcessionarioContext())
            {
                Auto? autoToModify = db.Auto.Where(auto => auto.Id == id).FirstOrDefault();
                if (autoToModify != null)
                {
                    return View(autoToModify);
                }
                else
                {
                    return NotFound($"La macchina con id {id} non è stata trovata");
                }
            }
        }


        [HttpGet]
        public IActionResult ModifySpecificheTecniche(int id)
        {
            using (ConcessionarioContext db = new ConcessionarioContext())
            {
                SpecificheTecniche? specificheTecnicheToModify = db.SpecificheTecniche.Where(specificheTecniche => specificheTecniche.AutoId == id).FirstOrDefault();
                if (specificheTecnicheToModify != null)
                {
                    return View(specificheTecnicheToModify);
                }
                else
                {
                    return NotFound("Le specifiche tecniche che desideri modificare non sono state trovate.");
                }
            }
        }


        [HttpGet]
        public IActionResult AcquistoAutoPresenteNelConcessionario(int id)
        {
            using (ConcessionarioContext db = new ConcessionarioContext())
            {
                Auto? autoDaAcquistare = db.Auto.Where(auto => auto.Id == id).FirstOrDefault();

                if (autoDaAcquistare != null)
                {

                    return View(autoDaAcquistare);
                }
                else
                {
                    return NotFound();
                }

            }
        }


        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAuto(Auto data)
        {
            if (!ModelState.IsValid)
            {                
                 return View(data);               
            }
            else
            {
                using (ConcessionarioContext db = new ConcessionarioContext())
                {
                    db.Auto.Add(data);
                    db.SaveChanges();
                    return RedirectToAction("ListaMacchineAdmin", "Admin");
                }
            }
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            using (ConcessionarioContext db = new ConcessionarioContext())
            {
                Auto? autoDaEliminare = db.Auto.Where(auto => auto.Id == id).FirstOrDefault();

                if (autoDaEliminare != null)
                {
                    db.Auto.Remove(autoDaEliminare);
                    db.SaveChanges();
                    return RedirectToAction("ListaMacchineAdmin", "Admin");

                }
                else return NotFound();
            }
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ModifyAuto(int id, Auto data)
        {
            if (!ModelState.IsValid)
            {
                using (ConcessionarioContext db = new ConcessionarioContext())
                {

                    return View(data);
                }
            }
            else
            {
                using (ConcessionarioContext db = new ConcessionarioContext())
                {
                    Auto? autoDaModificare = db.Auto.Where(auto => auto.Id == id).FirstOrDefault();
                    if (autoDaModificare != null)
                    {
                        autoDaModificare.NomeModello = data.NomeModello;
                        autoDaModificare.Descrizione = data.Descrizione;
                        autoDaModificare.Usata = data.Usata;
                        autoDaModificare.UrlImmagine = data.UrlImmagine;
                        autoDaModificare.Colore = data.Colore;
                        autoDaModificare.AnnoInizioProduzione = data.AnnoInizioProduzione;
                        autoDaModificare.AnnoFineProduzione = data.AnnoFineProduzione;
                        autoDaModificare.AnnoImmatricolazione = data.AnnoImmatricolazione;
                        autoDaModificare.NumeroAutoNelConcessionario = data.NumeroAutoNelConcessionario;
                        autoDaModificare.MarcaAuto = data.MarcaAuto;
                        autoDaModificare.TipoAuto = data.TipoAuto;

                        db.SaveChanges();
                        return RedirectToAction("ListaMacchineAdmin", "Admin");

                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateSpecificheTecniche(SpecificheTecniche data)
        {
            if (!ModelState.IsValid)
            {
                return View(data);
            }
            else
            {
                using (ConcessionarioContext db = new ConcessionarioContext())
                { 
                    db.SpecificheTecniche.Add(data);
                    db.SaveChanges();
                    return View("ListaMacchineAdmin", "Admin");
                }
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ModifySpecificheTecniche(int id, SpecificheTecniche modifiedSpecificheTecniche)
        {
            if (ModelState.IsValid)
            {
                return View("ModifySpecificheTecniche", modifiedSpecificheTecniche);
            }

            using (ConcessionarioContext db = new ConcessionarioContext())
            {
                SpecificheTecniche? specificheTecnicheToModify = db.SpecificheTecniche.Where(specificheTecniche => specificheTecniche.AutoId == id).FirstOrDefault();

                if (specificheTecnicheToModify != null)
                {
                    specificheTecnicheToModify.Alimentazione = modifiedSpecificheTecniche.Alimentazione;
                    specificheTecnicheToModify.Potenza = modifiedSpecificheTecniche.Potenza;
                    specificheTecnicheToModify.Cambio = modifiedSpecificheTecniche.Cambio;
                    specificheTecnicheToModify.Trazione = modifiedSpecificheTecniche.Trazione;
                    specificheTecnicheToModify.ClasseEmissioni = modifiedSpecificheTecniche.ClasseEmissioni;
                    specificheTecnicheToModify.ConsumoUrbano = modifiedSpecificheTecniche.ConsumoUrbano;
                    specificheTecnicheToModify.ConsumoExtraUrbano = modifiedSpecificheTecniche.ConsumoUrbano;
                    specificheTecnicheToModify.ConsumoMisto = modifiedSpecificheTecniche.ConsumoMisto;

                    db.SaveChanges();
                    return RedirectToAction("ListaMacchineAdmin", "Admin");
                }
                else
                {
                    return NotFound("Le specifiche tecniche che desideri modificare non sono state trovate.");
                }
            }

        }
      

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AcquistoAutoPresenteNelConcessionario(int id, ModelloAcquisizioneAutoPresente data)
        {
            if (!ModelState.IsValid)
            {
                return View(data);
            }
            else
            {
                using (ConcessionarioContext db = new ConcessionarioContext())
                {
                    data.AcquistoAuto.PrezzoTotale = data.AcquistoAuto.PrezzoUnitarioMacchina * data.AcquistoAuto.NumeroMacchineAcquistate;
                    db.AcquisizioniAuto.Add(data.AcquistoAuto);

                    Auto? AutoModificaNumero = db.Auto.Where(auto => auto.Id == id).FirstOrDefault();
                    if (AutoModificaNumero != null)
                    {
                        AutoModificaNumero.NumeroAutoNelConcessionario += data.AcquistoAuto.NumeroMacchineAcquistate;
                        db.SaveChanges();

                        return RedirectToAction("ListaMacchineAdmin", "Admin");
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
        }

    }
}
