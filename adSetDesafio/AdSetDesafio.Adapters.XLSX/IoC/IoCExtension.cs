using AdSetDesafio.Domain.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AdSetDesafio.Adapters.XLSX
{
    public static class IoCExtension
    {
        public static void ConfigureServicesAdaptersXlsx(this IServiceCollection services)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            services.AddScoped<IAdapterReader, XLSXReader>();
            services.AddScoped<IAdapterWriter, XLSXWriter>();
        }
    }
}