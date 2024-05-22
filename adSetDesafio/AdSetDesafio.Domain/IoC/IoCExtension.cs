using Microsoft.Extensions.DependencyInjection;
using AdSetDesafio.Domain.Handlers;
using AdSetDesafio.Domain.Services;
using AdSetDesafio.Domain.Services.Interfaces;

namespace AdSetDesafio.Domain.IoC
{
    public static class IoCExtension
    {
        public static void ConfigureServicesDomainApi(this IServiceCollection services)
        {

            //services.AddHttpClient();
            services.AddScoped<IVeiculoService, VeiculoService>();
            services.AddScoped<IFotoVeiculoService, FotoVeiculoService>();
            services.AddScoped<IOpcionalService, OpcionalService>();
        }
    }
}