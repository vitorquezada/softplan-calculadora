using Api1.API;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net.Http;
using Xunit;

namespace Api1.Testes
{
    [CollectionDefinition(nameof(Api1FixtureCollection))]
    public class Api1FixtureCollection : ICollectionFixture<Api1Fixture<Startup>>
    {

    }

    public class Api1Fixture<TStartup> : IDisposable where TStartup : class
    {
        public readonly Api1AppFactory<TStartup> Factory;
        public HttpClient Client;

        public Api1Fixture()
        {
            var clientOptions = new WebApplicationFactoryClientOptions()
            {
                HandleCookies = false,
                BaseAddress = new Uri("http://localhost"),
                AllowAutoRedirect = true,
                MaxAutomaticRedirections = 7
            };

            Factory = new Api1AppFactory<TStartup>();
            Client = Factory.CreateClient(clientOptions);
        }

        public void Dispose()
        {
            Client.Dispose();
            Factory.Dispose();
        }
    }
}
