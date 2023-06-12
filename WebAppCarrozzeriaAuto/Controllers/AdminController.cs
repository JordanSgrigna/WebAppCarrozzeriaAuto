﻿using Microsoft.AspNetCore.Authorization;
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

                return View();
            }
        }

        [HttpGet]
        public IActionResult CreateAuto()
        {
            using (ConcessionarioContext db = new ConcessionarioContext())
            {
                List<Tipo> tipi = db.Tipi.ToList();
                List<Marca> marche = db.Marche.ToList();

                ModelloMacchinaComplesso modelloPerView = new ModelloMacchinaComplesso();
                modelloPerView.Auto = new Auto();
                modelloPerView.Specifiche = new SpecificheTecniche();
                modelloPerView.Tipo = tipi;
                modelloPerView.Marca = marche;

                return View(modelloPerView);

            }
        }

        [HttpGet]
        public IActionResult CreateModello()
        {
            using(ConcessionarioContext db = new ConcessionarioContext())
            {
                List<Marca> marche = db.Marche.ToList();
                return View(marche);
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
        public IActionResult AcquistaMacchina(int id)
        {
            using (ConcessionarioContext db = new ConcessionarioContext())
            {
                Auto? autoDaAcquistare = db.Auto
                            .Where(auto => auto.Id == id)
                            .Include(auto => auto.MarcaAuto)
                            //.Include(auto => auto.ModelloAuto)
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
                    SpecificheTecniche? specifiche = db.SpecificheTecniche.FirstOrDefault();
                    if (specifiche != null)
                    {
                        data.Tipo = tipi;
                        data.Marca = marche;
                        data.Specifiche = specifiche;

                        return View(data);
                    }
                    else return NotFound();
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

        [HttpGet]
        public IActionResult ModifyAuto(int id)
        {
            using (ConcessionarioContext db = new ConcessionarioContext())
            {
                Auto? autoToModify = db.Auto.Where(auto => auto.Id == id)
                                    .Include(auto => auto.MarcaAuto)
                                    .FirstOrDefault();

                if (autoToModify != null)
                {
                    return View("Update", autoToModify);
                }
                else
                {
                    return NotFound("L'auto che desideri modificare non è stata trovata.");
                }
            }
        }

        [HttpPost]
        public IActionResult ModifyAuto(int id, ModelloMacchinaComplesso modifiedAuto)
        {
            if (!ModelState.IsValid)
            {
                using(ConcessionarioContext db = new ConcessionarioContext())
                {
                    List<Tipo> tipi = db.Tipi.ToList();
                    List<Marca> marche = db.Marche.ToList();
                    SpecificheTecniche? specifiche = db.SpecificheTecniche.FirstOrDefault();
                    if (specifiche != null)
                    {
                        modifiedAuto.Tipo = tipi;
                        modifiedAuto.Marca = marche;
                        modifiedAuto.Specifiche = specifiche;

                        return View(modifiedAuto);
                    }
                    else return NotFound();
                }

            }

            using (ConcessionarioContext db = new ConcessionarioContext())
            {
                Auto? autoToModify = db.Auto.Where(auto => auto.Id == id).Include(auto => auto.MarcaAuto)
                                        .FirstOrDefault();

                if (autoToModify != null)
                {

                    autoToModify.Descrizione = modifiedAuto.Auto.Descrizione;
                    autoToModify.AnnoImmatricolazione = modifiedAuto.Auto.AnnoImmatricolazione;
                    autoToModify.Colore = modifiedAuto.Auto.Colore;
                    autoToModify.UrlImmagine = modifiedAuto.Auto.UrlImmagine;
                    autoToModify.NumeroAutoNelConcessionario = modifiedAuto.Auto.NumeroAutoNelConcessionario;
                    autoToModify.NumeroLikeUtenti = modifiedAuto.Auto.NumeroLikeUtenti;
                    autoToModify.Prezzo = modifiedAuto.Auto.Prezzo;

                    autoToModify.Usata = modifiedAuto.Auto.Usata;

                    autoToModify.MarcaAuto = modifiedAuto.Auto.MarcaAuto;



                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
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
        public IActionResult ModifySpecificheTecniche(int id)
        {
            using (ConcessionarioContext db = new ConcessionarioContext())
            {
                SpecificheTecniche? specificheTecnicheToModify = db.SpecificheTecniche.Where(specificheTecniche => specificheTecniche.Id == id).FirstOrDefault();
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

        [HttpPost]
        public IActionResult ModifySpecificheTecniche(int id, SpecificheTecniche modifiedSpecificheTecniche)
        {
            if (ModelState.IsValid)
            {
                return View("Update", modifiedSpecificheTecniche);
            }

            using (ConcessionarioContext db = new ConcessionarioContext())
            {
                SpecificheTecniche? specificheTecnicheToModify = db.SpecificheTecniche.Where(specificheTecniche => specificheTecniche.Id == id).FirstOrDefault();

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

    }
}
