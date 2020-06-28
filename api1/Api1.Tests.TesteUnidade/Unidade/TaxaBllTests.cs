using Api1.BLL.Implementacoes;
using Api1.BLL.Interfaces;
using Api1.DAL.Interfaces;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Api1.Testes.Unidade
{
    public class TaxaBllTests
    {
        private readonly ITaxaBll _taxaBll;

        public TaxaBllTests()
        {
            var taxaDalMock = new Mock<ITaxaDal>();
            taxaDalMock
                .Setup(x => x.ObterTaxaJuros())
                .ReturnsAsync(() => 0.01m);

            _taxaBll = new TaxaBll(taxaDalMock.Object);
        }

        [Fact()]
        public async Task ObterTaxaJurosTest()
        {
            var taxaJuros = await _taxaBll.ObterTaxaJuros();
            Assert.Equal(0.01m, taxaJuros);
        }
    }
}