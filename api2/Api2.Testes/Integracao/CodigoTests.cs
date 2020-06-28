using Api2.API;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace Api2.Testes.Integracao
{
    [Collection(nameof(Api2FixtureCollection))]
    public class CodigoTests
    {
        private readonly Api2Fixture<Startup> _integrationTestsFixture;

        public CodigoTests(Api2Fixture<Startup> integrationTestsFixture)
        {
            _integrationTestsFixture = integrationTestsFixture;
        }

        [Fact]
        public async Task GetUrlCodigoTest()
        {
            var url = "showmethecode";
            using var res = await _integrationTestsFixture.Client.GetAsync(url);
            Assert.True(res.IsSuccessStatusCode);

            using var resStream = await res.Content.ReadAsStreamAsync();
            var resString = await JsonSerializer.DeserializeAsync<string>(resStream);
            Assert.Equal("https://github.com/vitorquezada/softplan-calculadora", resString);
        }
    }
}
