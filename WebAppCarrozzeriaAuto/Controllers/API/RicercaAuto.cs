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
        public IActionResult TrovaAuto(string marca, string modello, float prezzo, string alimentazione, string tipo ,int annoImmatricolazione, float kilometraggio, bool usata)
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

                if(prezzo > 0)
                {
                    query = query.Where(a => a.Prezzo <= prezzo);
                }

                if (!string.IsNullOrEmpty(alimentazione))
                {
                    query = query.Where(a => a.Specifiche.Alimentazione == alimentazione);
                }

                if (!string.IsNullOrEmpty(tipo))
                {
                    query = query.Where(a => a.TipoAuto == tipo);
                }

                if (annoImmatricolazione > 0)
                {
                    query = query.Where(a => a.AnnoImmatricolazione == annoImmatricolazione);
                }

                if (usata)
                {
                    query = query.Where(a => a.Usata == true);
                }

                if (kilometraggio > 0)
                {
                    query = query.Where(a => a.Kilometraggio <= kilometraggio);
                }

                var risultati = query.ToList();
                return Ok(risultati);
            }

            
        }
    }
}
