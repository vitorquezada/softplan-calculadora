using Api2.DAL.Interfaces;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api2.DAL.Implementacoes
{
    public class CalculosDal : ICalculosDal
    {
        private readonly HttpClient _api1HttpClient;

        public CalculosDal(IHttpClientFactory httpClientFactoy)
        {
            _api1HttpClient = httpClientFactoy.CreateClient("api1");
        }

        public async Task<double?> ObterTaxaJuros()
        {
            const string pathTaxaJuros = "/taxaJuros";

            try
            {
                using var response = await _api1HttpClient.GetAsync(pathTaxaJuros);

                if (response.IsSuccessStatusCode)
                {
                    var resultadoStream = await response.Content.ReadAsStreamAsync();
                    var taxaJuros = await JsonSerializer.DeserializeAsync<double>(resultadoStream);

                    return taxaJuros;
                }

                return default;
            }
            catch (Exception ex)
            {
                throw new Exception($"A conexão não pôde ser feita com a API 1 ({pathTaxaJuros}). Verifique se a mesma está sendo executada. Mensagem: {ex.Message}", ex);
            }
        }
    }
}
