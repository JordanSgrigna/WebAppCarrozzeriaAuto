using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppCarrozzeriaAuto.Database;

namespace WebAppCarrozzeriaAuto.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class RicercaAuto : ControllerBase
    {
        public IActionResult TrovaAuto(string marca, string modello, float prezzo, string alimentazione, int annoImmatricolazione, float kilometraggio)
        {
            return Ok();
        }
    }
}
