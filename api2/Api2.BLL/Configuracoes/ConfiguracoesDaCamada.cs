using Api2.BLL.Implementacoes;
using Api2.BLL.Interfaces;
using Api2.DAL.Configuracoes;
using Microsoft.Extensions.DependencyInjection;

namespace Api2.BLL.Configuracoes
{
    public static class ConfiguracoesDaCamada
    {
        public static IServiceCollection ConfigurarBll(this IServiceCollection services)
        {
            ConfigureInjecaoDependencia(services);
            services.ConfigurarDal();

            return services;
        }

        private static void ConfigureInjecaoDependencia(IServiceCollection services)
        {
            services.AddScoped<ICalculosBll, CalculosBll>();
        }
    }
}
