using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppCarrozzeriaAuto.Database;
using WebAppCarrozzeriaAuto.Models;
using Microsoft.AspNetCore.Identity;

namespace WebAppCarrozzeriaAuto.Controllers.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AutoNumeroLikeUtenti : ControllerBase
    {
        [HttpPut("{id}")]
        public IActionResult ModificaNumeroLikeUtente(int id, [FromBody] Auto auto)
        {
            using (ConcessionarioContext db = new ConcessionarioContext())
            {
                Auto? autoNumeroDiLikeDaModificare = db.Auto.Where(auto => auto.Id == id).FirstOrDefault();
                if(autoNumeroDiLikeDaModificare != null)
                {
                    autoNumeroDiLikeDaModificare.NumeroLikeUtenti += 1;
                    db.SaveChanges();

                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
        }
    }
}
