using Api2.API;
using Microsoft.AspNetCore.WebUtilities;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace Api2.Testes.Integracao
{
    [Collection(nameof(Api2FixtureCollection))]
    public class CalculosTests : IClassFixture<Api2AppFactory<Startup>>
    {
        private readonly Api2Fixture<Startup> _integrationTestFixture;

        public CalculosTests(Api2Fixture<Startup> integrationTestFixture)
        {
            _integrationTestFixture = integrationTestFixture;
        }

        [Theory]
        [InlineData(null, null, 0)]
        [InlineData(null, 1, 0)]
        [InlineData(0, 1, 0)]
        [InlineData(100, 5, 105.10)]
        [InlineData(1000, 1, 1010)]
        [InlineData(50, 7, 53.60)]
        [InlineData(-100, 5, (-105.10))]
        public async Task GetCalcularJurosTest(double? valorinicial, int? meses, double valorEsperado)
        {
            var querystring = new Dictionary<string, string>();
            if (valorinicial.HasValue)
                querystring.Add("valorinicial", valorinicial.Value.ToString());
            if (meses.HasValue)
                querystring.Add("meses", meses.Value.ToString());

            var url = QueryHelpers.AddQueryString("/calculajuros", querystring);
            using var req = await _integrationTestFixture.Client.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, req.StatusCode);

            var resStream = await req.Content.ReadAsStreamAsync();
            var res = await JsonSerializer.DeserializeAsync<double>(resStream);

            Assert.Equal(valorEsperado, res);
        }
    }
}
