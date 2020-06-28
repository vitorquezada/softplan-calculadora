using Api2.DAL.Implementacoes;
using Api2.DAL.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Api2.DAL.Configuracoes
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
            services.AddScoped<ICalculosDal, CalculosDal>();
        }
    }
}
