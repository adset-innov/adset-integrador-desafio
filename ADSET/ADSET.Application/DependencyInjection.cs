using ADSET.Application.Interfaces;
using ADSET.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ADSET.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddTransient<IFotoAppService, FotoAppService>();
            services.AddTransient<IMarcaAppService, MarcaAppService>();
            services.AddTransient<IOpcionalAppService, OpcionalAppService>();
            services.AddTransient<IVeiculoAppService, VeiculoAppService>();
            services.AddTransient<IPacoteAppService, PacoteAppService>();

            return services;
        }
    }
}
