using Api1.DAL.Implementacoes;
using Api1.DAL.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Api1.DAL.Configuracoes
{
    public static class ConfiguracoesDaCamada
    {
        public static IServiceCollection ConfigurarDal(this IServiceCollection services)
        {
            ConfigurarInjecaoDependencia(services);

            return services;
        }

        private static void ConfigurarInjecaoDependencia(IServiceCollection services)
        {
            services.AddScoped<ITaxaDal, TaxaDal>();
        }
    }
}
