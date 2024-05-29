using ADSET.Domain.Interfaces;
using ADSET.Domain.Interfaces.ExternalServices;
using ADSET.Domain.Interfaces.Repositories;
using ADSET.Infra.Data;
using ADSET.Infra.ExternalServices;
using ADSET.Infra.Repositories;
using Amazon.S3;
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

            services.AddDefaultAWSOptions(configuration.GetAWSOptions());
            services.AddAWSService<IAmazonS3>();
            services.AddScoped<IAwsS3ExternalService, AwsS3ExternalService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IVeiculoRepository, VeiculoRepository>();
            services.AddScoped<IMarcaRepository, MarcaRepository>();
            services.AddScoped<IModeloRepository, ModeloRepository>();
            services.AddScoped<IFotoRepository, FotoRepository>();
            services.AddScoped<IOpcionalRepository, OpcionalRepository>();
            services.AddScoped<IPacoteRepository, PacoteRepository>();

            return services;
        }
    }
}
