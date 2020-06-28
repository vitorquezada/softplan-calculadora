using Api1.DAL.Implementacoes;
using Api1.DAL.Interfaces;
using System.Threading.Tasks;
using Xunit;

namespace Api1.Testes.Unidade
{
    public class TaxaDalTests
    {
        private readonly ITaxaDal _taxaDal;

        public TaxaDalTests()
        {
            _taxaDal = new TaxaDal();
        }

        [Fact]
        public async Task ObterTaxaJurosTest()
        {
            var taxaJuros = await _taxaDal.ObterTaxaJuros();
            Assert.Equal(0.01m, taxaJuros);
        }
    }
}