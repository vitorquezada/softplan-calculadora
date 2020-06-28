using Api1.API;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace Api1.Testes.Integracao
{
    [Collection(nameof(Api1FixtureCollection))]
    public class TaxaTests
    {
        private readonly Api1Fixture<Startup> _integrationTestFixture;

        public TaxaTests(Api1Fixture<Startup> integrationTestFixture)
        {
            _integrationTestFixture = integrationTestFixture;
        }

        [Fact]
        public async Task GetTaxaJurosTest()
        {
            using var req = await _integrationTestFixture.Client.GetAsync("/taxaJuros");
            Assert.Equal(HttpStatusCode.OK, req.StatusCode);

            var resStream = await req.Content.ReadAsStreamAsync();
            var res = await JsonSerializer.DeserializeAsync<double>(resStream);

            Assert.Equal(0.01, res);
        }
    }
}
