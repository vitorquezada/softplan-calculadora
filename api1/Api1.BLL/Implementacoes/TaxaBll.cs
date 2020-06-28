using Api1.BLL.Interfaces;
using Api1.DAL.Interfaces;
using System.Threading.Tasks;

namespace Api1.BLL.Implementacoes
{
    public class TaxaBll : ITaxaBll
    {
        private readonly ITaxaDal _taxaDal;

        public TaxaBll(ITaxaDal taxaDal)
        {
            _taxaDal = taxaDal;
        }

        public Task<decimal> ObterTaxaJuros()
        {
            return _taxaDal.ObterTaxaJuros();
        }
    }
}
