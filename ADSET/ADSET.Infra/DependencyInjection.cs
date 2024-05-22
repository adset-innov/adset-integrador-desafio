using ADSET.Domain.Interfaces;
using ADSET.Domain.Interfaces.Repositories;
using ADSET.Infra.Data;
using ADSET.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ADSET.Infra
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastrucuture(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SqlContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IVeiculoRepository, VeiculoRepository>();
            services.AddScoped<IMarcaRepository, MarcaRepository>();
            services.AddScoped<IModeloRepository, ModeloRepository>();
            services.AddScoped<IFotoRepository, FotoRepository>();
            services.AddScoped<IOpcionalRepository, OpcionalRepository>();

            return services;
        }
    }
}
