using Api2.BLL.Implementacoes;
using Api2.BLL.Interfaces;
using Api2.DAL.Interfaces;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Api2.Testes.Unidade
{
    public class CalculosBllTests
    {
        private readonly ICalculosBll _calculosBll;

        public CalculosBllTests()
        {
            var calculosDalMock = new Mock<ICalculosDal>();

            calculosDalMock
                .Setup(x => x.ObterTaxaJuros())
                .ReturnsAsync(0.01);

            _calculosBll = new CalculosBll(calculosDalMock.Object);
        }

        [Theory]
        [InlineData(100, 5, 105.10)]
        [InlineData(1000, 1, 1010)]
        [InlineData(50, 7, 53.60)]
        [InlineData(-100, 5, (-105.10))]
        public async Task CalcularJurosTest(double valorInicial, int meses, double resultadoEsperado)
        {
            var valorFinal = await _calculosBll.CalcularJuros(valorInicial, meses);

            Assert.Equal(resultadoEsperado, valorFinal);
        }
    }
}