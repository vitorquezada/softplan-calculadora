using Api2.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Api2.API.Controllers
{
    [ApiController]
    public class CalculosController : ControllerBase
    {
        private readonly ICalculosBll _calculosBll;

        public CalculosController(ICalculosBll calculosBll)
        {
            _calculosBll = calculosBll;
        }

        [HttpGet("calculajuros")]
        public async Task<IActionResult> GetCalcularJuros(double? valorinicial, int? meses)
        {
            try
            {
                var valorFinal = await _calculosBll.CalcularJuros(valorinicial.GetValueOrDefault(), meses.GetValueOrDefault());
                return new JsonResult(valorFinal);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
