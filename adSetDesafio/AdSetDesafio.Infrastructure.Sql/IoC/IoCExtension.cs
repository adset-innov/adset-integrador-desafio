using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AdSetDesafio.Domain.Common.Repositories;
using AdSetDesafio.Infrastructure.DbContexts;
using AdSetDesafio.Infrastructure.Interfaces;
using AdSetDesafio.Infrastructure.Sql.DbContexts;
using AdSetDesafio.Infrastructure.Sql.DbContexts.Config;
using AdSetDesafio.Infrastructure.Sql.Repositories;
using AdSetDesafio.Infrastructure.UnitOfWork;

namespace AdSetDesafio.Infrastructure.Sql.IoC
{
    public static class IoCExtension
    {
        public static void ConfigureServicesSqlApi(this IServiceCollection services, IConfiguration configuration)
        {
            var config = new ConfigSQL();
            configuration.Bind("SqlServer", config);

            services.AddSingleton(config);
            
            services.AddTransient<IDbContext, SQLDbContext>();
            services.AddTransient<IUnitOfWork, SQLDbUnitOfWork>();
            services.AddTransient<IDbContextFactory, DbContextFactory>();
            services.AddTransient<IUnitOfWorkFactory, UnitOfWorkFactory>();

            services.AddScoped<IVeiculoRepository, VeiculoRepository>();
            services.AddScoped<IOpcionalRepository, OpcionalRepository>();
        }
    }
}