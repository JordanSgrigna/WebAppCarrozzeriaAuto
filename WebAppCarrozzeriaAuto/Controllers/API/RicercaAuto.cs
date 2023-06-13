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
        public IActionResult TrovaAuto(string marca, string modello, float prezzo, string alimentazione, int annoImmatricolazione, float kilometraggio, bool usata)
        {
            using (ConcessionarioContext db = new ConcessionarioContext())
            {
                List<Auto> auto = db.Auto
                                    .Include(a => a.MarcaAuto)
                                    .Include(a => a.TipoAuto)
                                    .Include(a => a.Specifiche)
                                    .ToList();

                if (!string.IsNullOrEmpty(marca))
                {
                    auto = auto.Where(a => a.MarcaAuto.Nome == marca).ToList();
                }

                if (!string.IsNullOrEmpty(modello))
                {
                    auto = auto.Where(a => a.NomeModello == modello).ToList();
                }

                if(prezzo > 0)
                {
                    auto = auto.Where(a => a.Prezzo == prezzo).ToList();
                }
            }

            return Ok();
        }
    }
}
