using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.FeatureManagement;
using AdSetDesafio.Adapters.XLSX;
using AdSetDesafio.Domain.IoC;
using AdSetDesafio.Infrastructure.AutoMapper.IoC;
using AdSetDesafio.Infrastructure.Sql.IoC;
using System;
using System.IO;

namespace AdSetDesafio.Web.API
{
    public class Program
    {
        private static IHostEnvironment environment;
        private static IConfiguration configuration;

        public static void Main(string[] args)
        {
            using var host = CreateHostBuilder(args).Build();
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureAppConfiguration((hostingContext, configHost) =>
                {
                    environment = hostingContext.HostingEnvironment;
                    Console.WriteLine($"EnvironmentName: {environment.EnvironmentName}");
                    configHost.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                    configHost.AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true);
                    configHost.AddEnvironmentVariables();
                    configHost.AddCommandLine(args);
                    configuration = configHost.Build();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureServices((_, services) =>
                {
                    services.AddFeatureManagement();
                    services.AddDefaultMapper();
                    services.ConfigureServicesDomainApi();
                    services.ConfigureServicesSqlApi(configuration);
                    services.ConfigureServicesAdaptersXlsx();
                });
    }
}