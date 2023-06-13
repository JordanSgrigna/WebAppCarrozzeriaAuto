using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.Arm;
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
                List<Auto> auto = db.Auto
                                  .Include(auto => auto.MarcaAuto)
                                  .Include(auto => auto.TipoAuto)
                                  .Include(auto => auto.Specifiche)
                                  .ToList();

                List<Marca> marche = db.Marche.ToList();
                List<Tipo> tipi = db.Tipi.ToList();

                ModelloMacchinaComplesso modelloPerView = new ModelloMacchinaComplesso();
                modelloPerView.Auto = auto;
                modelloPerView.Marche = marche;
                modelloPerView.Tipi = tipi;

                return View(modelloPerView);
            }
        }

        [HttpGet]
        public IActionResult CreateAuto()
        {
            using (ConcessionarioContext db = new ConcessionarioContext())
            {
                List<Marca> marche = db.Marche.ToList();
                List<Tipo> tipi = db.Tipi.ToList();
                ModelloMacchinaCreateUpdate modelloPerView = new ModelloMacchinaCreateUpdate();
                modelloPerView.Auto = new Auto();
                modelloPerView.Tipi = tipi;
                modelloPerView.Marche = marche;

                return View(modelloPerView);
            }
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
        public IActionResult ModifyAuto(int id)
        {
            using (ConcessionarioContext db = new ConcessionarioContext())
            {
                Auto? autoToModify = db.Auto.Where(auto => auto.Id == id).FirstOrDefault();
                if(autoToModify != null)
                {
                    List<Marca> marche = db.Marche.ToList();
                    List<Tipo> tipi = db.Tipi.ToList();

                    ModelloMacchinaCreateUpdate modelView = new ModelloMacchinaCreateUpdate();
                    modelView.Tipi = tipi;
                    modelView.Marche = marche;

                    return View(modelView);

                }
                else
                {
                    return NotFound($"La macchina con id {id} non è stata trovata");
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

        [HttpGet]
        public IActionResult ModifySpecificheTecniche(int id)
        {
            using (ConcessionarioContext db = new ConcessionarioContext())
            {
                SpecificheTecniche? specificheTecnicheToModify = db.SpecificheTecniche.Where(specificheTecniche => specificheTecniche.AutoId == id).FirstOrDefault();
                if (specificheTecnicheToModify != null)
                {
                    return View("Update", specificheTecnicheToModify);
                }
                else
                {
                    return NotFound("Le specifiche tecniche che desideri modificare non sono state trovate.");
                }
            }
        }

        [HttpGet]
        public IActionResult ModifyTipo(int id)
        {
            using (ConcessionarioContext db = new ConcessionarioContext())
            {
                Tipo? tipoToModify = db.Tipi.Where(tipo => tipo.Id == id).FirstOrDefault();
                if (tipoToModify != null)
                {
                    return View("Update", tipoToModify);
                }
                else
                {
                    return NotFound("Il tipo che desideri modificare non è stato trovato.");
                }
            }
        }

        [HttpGet]
        public IActionResult AcquistoAutoPresenteNelConcessionario(int id)
        {
            using (ConcessionarioContext db = new ConcessionarioContext())
            {
                Auto? autoDaAcquistare = db.Auto.Where(auto => auto.Id == id)
                                                .Include(auto => auto.MarcaAuto)
                                                .Include(auto => auto.TipoAuto)
                                                .FirstOrDefault();

                if (autoDaAcquistare != null)
                {
                    ModelloAcquisizioneAutoPresente modelPerView = new ModelloAcquisizioneAutoPresente();
                    modelPerView.Auto = autoDaAcquistare;
                    modelPerView.AcquistoAuto = new AcquistoAuto();

                    return View(modelPerView);
                }
                else
                {
                    return NotFound();
                }

            }
        }

        [HttpGet]
        public IActionResult AcquistoAutoNuova()
        {
            using (ConcessionarioContext db = new ConcessionarioContext())
            {
                List<Marca> marche = db.Marche.ToList();
                List<Tipo> tipi = db.Tipi.ToList();

                ModelloAcquisizioneAutoNuova modelPerView = new ModelloAcquisizioneAutoNuova();
                modelPerView.Auto = new Auto();
                modelPerView.AcquistoAuto = new AcquistoAuto();
                modelPerView.Marche = marche;
                modelPerView.Tipi = tipi;

                return View(modelPerView);
            }

        }


        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAuto(ModelloMacchinaCreateUpdate data)
        {
            if (!ModelState.IsValid)
            {
                using (ConcessionarioContext db = new ConcessionarioContext())
                {
                    List<Marca> marche = db.Marche.ToList();
                    List<Tipo> tipi = db.Tipi.ToList();

                    data.Tipi = tipi;
                    data.Marche = marche;

                    return View(data);
                }
            }
            else
            {
                using (ConcessionarioContext db = new ConcessionarioContext())
                {
                    db.Auto.Add(data.Auto);
                    db.SaveChanges();
                    return RedirectToAction("ListaMacchineAdmin", "Admin");
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
                    return RedirectToAction("ListaMacchineAdmin", "Admin");
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
                    return RedirectToAction("ListaMacchineAdmin", "Admin");
                }
            }
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            using (ConcessionarioContext db = new ConcessionarioContext())
            {
                Auto? autoDaEliminare = db.Auto.Where(auto => auto.Id == id).FirstOrDefault();
                SpecificheTecniche? specificheTecnicheDaEliminare = db.SpecificheTecniche.Where(specifiche => specifiche.AutoId == id).FirstOrDefault();

                if (autoDaEliminare != null && specificheTecnicheDaEliminare != null)
                {
                    db.Auto.Remove(autoDaEliminare);
                    db.SpecificheTecniche.Remove(specificheTecnicheDaEliminare);
                    db.SaveChanges();
                    return RedirectToAction("ListaMacchineAdmin", "Admin");

                }
                else return NotFound();
            }
        }



        [HttpPost]
        public IActionResult ModifyAuto(int id, ModelloMacchinaCreateUpdate data)
        {
            if (!ModelState.IsValid)
            {
                using (ConcessionarioContext db = new ConcessionarioContext())
                {
                    List<Marca> marche = db.Marche.ToList();
                    List<Tipo> tipi = db.Tipi.ToList();

                    data.Marche = marche;
                    data.Tipi = tipi;

                    return View(data);
                }
            }
            else
            {
                using (ConcessionarioContext db = new ConcessionarioContext())
                {
                    Auto? autoDaModificare = db.Auto.Where(auto => auto.Id == id).FirstOrDefault();
                    if(autoDaModificare != null)
                    {
                        autoDaModificare.NomeModello = data.Auto.NomeModello;
                        autoDaModificare.Descrizione = data.Auto.Descrizione;
                        autoDaModificare.Usata = data.Auto.Usata;
                        autoDaModificare.UrlImmagine = data.Auto.UrlImmagine;
                        autoDaModificare.Colore = data.Auto.Colore;
                        autoDaModificare.AnnoInizioProduzione = data.Auto.AnnoInizioProduzione;
                        autoDaModificare.AnnoFineProduzione = data.Auto.AnnoFineProduzione;
                        autoDaModificare.AnnoImmatricolazione = data.Auto.AnnoImmatricolazione;
                        autoDaModificare.NumeroAutoNelConcessionario = data.Auto.NumeroAutoNelConcessionario;
                        autoDaModificare.MarcaAuto.Id = data.Auto.MarcaAuto.Id;
                        autoDaModificare.TipoAuto.Id = data.Auto.TipoAuto.Id;

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

        [HttpPost]
        public IActionResult ModifySpecificheTecniche(int id, SpecificheTecniche modifiedSpecificheTecniche)
        {
            if (ModelState.IsValid)
            {
                return View("Update", modifiedSpecificheTecniche);
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
                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound("Le specifiche tecniche che desideri modificare non sono state trovate.");
                }
            }

        }



        [HttpPost]
        public IActionResult ModifyTipo(int id, Tipo modifiedTipo)
        {
            if (ModelState.IsValid)
            {
                return View("Update", modifiedTipo);
            }

            using (ConcessionarioContext db = new ConcessionarioContext())
            {
                Tipo? tipoToModify = db.Tipi.Where(tipo => tipo.Id == id).FirstOrDefault();

                if (tipoToModify != null)
                {
                    tipoToModify.Nome = modifiedTipo.Nome;

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound("Il tipo che desideri modificare non è stato trovato.");
                }
            }

        }

        [HttpPost]
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
                    db.AcquisizioniAuto.Add(data.AcquistoAuto);

                    Auto? AutoModificaNumero = db.Auto.Where(auto => auto.Id == id).FirstOrDefault();
                    if(AutoModificaNumero != null)
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

        [HttpPost]
        public IActionResult AcquistoAutoNuova(ModelloAcquisizioneAutoNuova data)
        {
            if (!ModelState.IsValid)
            {
                using (ConcessionarioContext db = new ConcessionarioContext())
                {
                    List<Marca> marche = db.Marche.ToList();
                    List<Tipo> tipi = db.Tipi.ToList();

                    data.Tipi = tipi;
                    data.Marche = marche;

                    return View(data);
                }
            }
            else
            {
                using (ConcessionarioContext db = new ConcessionarioContext())
                {
                    data.Auto.NumeroAutoNelConcessionario = data.AcquistoAuto.NumeroMacchineAcquistate;

                    db.AcquisizioniAuto.Add(data.AcquistoAuto);
                    db.Auto.Add(data.Auto);
                    db.SaveChanges();
                    return RedirectToAction("ListaMacchineAdmin", "Admin");
                }
            }
        }

    }
}
