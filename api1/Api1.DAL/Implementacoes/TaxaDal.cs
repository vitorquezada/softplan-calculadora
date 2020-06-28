using Api1.DAL.Interfaces;
using System.Threading.Tasks;

namespace Api1.DAL.Implementacoes
{
    public class TaxaDal : ITaxaDal
    {
        public Task<decimal> ObterTaxaJuros()
        {
            return Task.FromResult(0.01m);
        }
    }
}
