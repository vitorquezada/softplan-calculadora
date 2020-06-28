using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api2.API.Controllers
{
    [ApiController]
    public class CodigoController : ControllerBase
    {
        public CodigoController()
        {

        }

        [HttpGet("showmethecode")]
        public IActionResult GetUrlCodigo()
        {
            return new JsonResult("https://github.com/vitorquezada/softplan-calculadora");
        }
    }
}
