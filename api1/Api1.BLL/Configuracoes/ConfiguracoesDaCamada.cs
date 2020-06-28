using Api1.BLL.Implementacoes;
using Api1.BLL.Interfaces;
using Api1.DAL.Configuracoes;
using Microsoft.Extensions.DependencyInjection;

namespace Api1.BLL.Configuracoes
{
    public static class ConfiguracoesDaCamada
    {
        public static IServiceCollection ConfigurarBll(this IServiceCollection services)
        {
            ConfigurarInjecaoDependencia(services);

            services.ConfigurarDal();

            return services;
        }

        private static void ConfigurarInjecaoDependencia(IServiceCollection services)
        {
            services.AddScoped<ITaxaBll, TaxaBll>();
        }
    }
}
