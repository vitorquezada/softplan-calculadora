using Api2.API;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net.Http;
using Xunit;

namespace Api2.Testes
{
    [CollectionDefinition(nameof(Api2FixtureCollection))]
    public class Api2FixtureCollection : ICollectionFixture<Api2Fixture<Startup>>
    {

    }

    public class Api2Fixture<TStartup> : IDisposable where TStartup : class
    {
        public readonly Api2AppFactory<TStartup> Factory;
        public readonly HttpClient Client;

        public Api2Fixture()
        {
            var clientOptions = new WebApplicationFactoryClientOptions()
            {
                HandleCookies = false,
                BaseAddress = new Uri("http://localhost"),
                AllowAutoRedirect = true,
                MaxAutomaticRedirections = 7
            };

            Factory = new Api2AppFactory<TStartup>();

            Client = Factory.CreateClient(clientOptions);
        }

        public void Dispose()
        {
            Client.Dispose();
            Factory.Dispose();
        }
    }
}
