using Api2.BLL.Configuracoes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Net.Http.Headers;

namespace Api2.API
{
    public class Startup
    {
        public const string ENVIRONMENT_TESTING = "Testing";

        private readonly bool _ehTestesAutomatizados;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _ehTestesAutomatizados = env.IsEnvironment(ENVIRONMENT_TESTING);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddHttpClient("api1", c =>
            {
                var urlApi1 = Configuration.GetSection("URL_API1").Value;
                if (string.IsNullOrWhiteSpace(urlApi1))
                    urlApi1 = Configuration.GetSection("UrlApi1").Value;

                c.BaseAddress = new Uri(urlApi1);
                c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });

            services.ConfigurarBll();

            if (!_ehTestesAutomatizados)
            {
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "API 2 - Softplan",
                        Description = "Uma API para calcular juros",
                        Contact = new OpenApiContact
                        {
                            Name = "Vitor Andrade",
                            Email = "vitorquezada@gmail.com",
                            Url = new Uri("https://github.com/vitorquezada")
                        }
                    });
                });
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (!_ehTestesAutomatizados)
            {
                app.UseStaticFiles();

                app.UseSwagger();

                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API 1 - Softplan - Vaga .NET");
                });
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
