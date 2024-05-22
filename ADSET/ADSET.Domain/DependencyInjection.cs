using ADSET.Domain.Interfaces.Services;
using ADSET.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ADSET.Domain
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddScoped<IFotoService, FotoService>();
            services.AddScoped<IVeiculoService, VeiculoService>();
            services.AddScoped<IOpcionalService, OpcionalService>();
            services.AddScoped<IMarcaService, MarcaService>();
            services.AddScoped<IModeloService, ModeloService>();

            return services;
        }
    }
}
