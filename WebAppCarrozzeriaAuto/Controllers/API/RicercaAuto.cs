using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppCarrozzeriaAuto.Database;
using WebAppCarrozzeriaAuto.Models;

namespace WebAppCarrozzeriaAuto.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class RicercaAuto : ControllerBase
    {
        [HttpGet]
        public IActionResult TrovaAuto(string marca, string modello, string alimentazione, string tipo ,int annoImmatricolazione, float kilometraggio, string usata)
        {
            using (ConcessionarioContext db = new ConcessionarioContext())
            {

                var query = db.Auto.Include(a => a.Specifiche).AsQueryable();

                if (!string.IsNullOrEmpty(marca))
                {
                    query = query.Where(a => a.MarcaAuto == marca);
                }

                if (!string.IsNullOrEmpty(modello))
                {
                    query = query.Where(a => a.NomeModello == modello);
                }

                if (!string.IsNullOrEmpty(alimentazione))
                {
                    query = query.Where(a => a.Specifiche.Alimentazione == alimentazione);
                }

                if (!string.IsNullOrEmpty(tipo))
                {
                    query = query.Where(a => a.TipoAuto == tipo);
                }

                if (annoImmatricolazione >= 0)
                {
                    query = query.Where(a => a.AnnoImmatricolazione == annoImmatricolazione);
                }

                if (!string.IsNullOrEmpty(usata))
                {
                    bool isUsata = usata.ToLower() == "true";
                    query = query.Where(a => a.Usata == true);
                }

                if (kilometraggio >= 0)
                {
                    query = query.Where(a => a.Kilometraggio <= kilometraggio);
                }

                var risultati = query.ToList();
                return Ok(risultati);

            }

            
        }
    }
}
