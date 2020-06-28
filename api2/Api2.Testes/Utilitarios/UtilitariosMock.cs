using Moq;
using Moq.Protected;
using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Api2.Testes.Utilitarios
{
    public static class UtilitariosMock
    {
        public static Mock<HttpMessageHandler> CriarMockHttpMessageHandle(HttpStatusCode statusCodeRetorno = HttpStatusCode.OK, object conteudoRetorno = null)
        {
            var httpClientMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            httpClientMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = statusCodeRetorno,
                    Content = new StringContent(JsonSerializer.Serialize(conteudoRetorno))
                });

            return httpClientMock;
        }
    }
}
