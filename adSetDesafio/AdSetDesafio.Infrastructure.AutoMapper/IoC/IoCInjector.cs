using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using AdSetDesafio.Infrastructure.AutoMapper.AutoMapper;

namespace AdSetDesafio.Infrastructure.AutoMapper.IoC
{
    public static class IoCInjector
    {
        public static void AddDefaultMapper(this IServiceCollection services)
        {
            services.AddSingleton((sp) => {
                var config = new MapperConfiguration(cfg =>
                     cfg.AddProfile(new DefaultApiProfile())
                 );
                config.AssertConfigurationIsValid();
                return config.CreateMapper();
            });
        }
    }
}