using Api2.DAL.Implementacoes;
using Api2.DAL.Interfaces;
using Api2.Testes.Utilitarios;
using Moq;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Api2.Testes.Unidade
{
    public class CalculosDalTests
    {
        private const double _TAXA_JUROS_MOCK = 0.01;

        private readonly ICalculosDal _calculosDal;

        public CalculosDalTests()
        {
            var api1HttpClientMock = UtilitariosMock.CriarMockHttpMessageHandle(conteudoRetorno: _TAXA_JUROS_MOCK);

            var httpClientFactoryMock = new Mock<IHttpClientFactory>();
            httpClientFactoryMock
                .Setup(x => x.CreateClient(It.IsAny<string>()))
                .Returns(new HttpClient(api1HttpClientMock.Object) { BaseAddress = new Uri("http://fake") });

            _calculosDal = new CalculosDal(httpClientFactoryMock.Object);
        }

        [Fact]
        public async Task CalcularJurosTest()
        {
            var taxaJuros = await _calculosDal.ObterTaxaJuros();
            Assert.Equal(_TAXA_JUROS_MOCK, taxaJuros);
        }
    }
}