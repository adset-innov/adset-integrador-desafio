using System;
using System.Configuration;

namespace AdSetDesafio.Infrastructure.Extensions
{
    public static class ExportExtensions
    {
        public static string GetTipoSelecao(int tipoSelecao)
        {
            var strTipoSelecao = string.Empty;

            switch (tipoSelecao)
            {
                case 0:
                    strTipoSelecao = "CSV";
                    break;
                default:
                    strTipoSelecao = "Excel";
                    break;
            }

            return strTipoSelecao;
        }
    }
}
