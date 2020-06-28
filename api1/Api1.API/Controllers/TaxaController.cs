using Api1.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api1.API.Controllers
{
    [ApiController]
    public class TaxaController : ControllerBase
    {
        private readonly ITaxaBll _taxaBll;

        public TaxaController(ITaxaBll taxaBll)
        {
            _taxaBll = taxaBll;
        }

        [HttpGet("taxaJuros")]
        public async Task<IActionResult> GetTaxaJuros()
        {
            return new JsonResult(await _taxaBll.ObterTaxaJuros());
        }
    }
}
