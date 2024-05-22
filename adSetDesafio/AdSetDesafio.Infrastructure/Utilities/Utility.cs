using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Globalization;
using AdSetDesafio.Infrastructure.Extensions;

namespace AdSetDesafio.Infrastructure.Utilities
{
    public class Utility
    {
        public static string LocalizaErro(Exception ex)
        {
            if (ex.InnerException != null)
                return LocalizaErro(ex.InnerException);
            else
                return ex.Message;
        }

        public static IList<KeyValuePair<string, string>> ToKeyValue(object metaToken)
        {
            if (metaToken == null)
            {
                return null;
            }

            JToken token = metaToken as JToken;
            if (token == null)
            {
                return ToKeyValue(JObject.FromObject(metaToken));
            }

            if (token.HasValues)
            {
                var contentData = new List<KeyValuePair<string, string>>();
                foreach (var child in token.Children().ToList())
                {
                    var childContent = ToKeyValue(child);
                    if (childContent != null)
                    {
                        contentData = contentData.Concat(childContent).ToList();
                    }
                }

                return contentData;
            }

            var key = token.Path;

            if (key.IndexOf('[') > -1)
                key = key.Substring(0, key.IndexOf('['));

            var jValue = token as JValue;
            if (jValue?.Value == null)
            {
                return null;
            }

            var value = jValue?.Type == JTokenType.Date ?
                            jValue?.ToString("o", CultureInfo.InvariantCulture) :
                            jValue?.ToString(CultureInfo.InvariantCulture);

            return new Dictionary<string, string> { { key, value } }.ToList();
        }

        public static string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }

        public static IList<IEnumerable<T>> SplitList<T>(IList<T> items, int nSize = 30)
        {
            var list = new List<IEnumerable<T>>();

            for (int i = 0; i < items.Count; i += nSize)
                list.Add(items.Skip(i).Take(nSize));

            return list;
        }

        public static string VerificarDadoEditado(string dadoOld, string dadoNew, string nomeDado)
        {
            if (dadoOld != dadoNew)
                return $"{nomeDado} anterior: {dadoOld}; ";

            return string.Empty;
        }

        public static string VerificarDadoEditado(bool dadoOld, bool dadoNew, string nomeDado, string dadoTrue, string dadoFalse)
        {
            if (dadoOld != dadoNew)
                return $"{nomeDado} anterior: {(dadoOld ? dadoTrue : dadoFalse)}; ";

            return string.Empty;
        }

        public static string VerificarDadoEditado(bool? dadoOld, bool? dadoNew, string nomeDado, string dadoTrue, string dadoFalse)
        {
            if (dadoOld != dadoNew)
                return $"{nomeDado} anterior: {(!dadoOld.HasValue ? "" : dadoOld.Value ? dadoTrue : dadoFalse)}; ";

            return string.Empty;
        }

        public static string VerificarDadoEditado(DateTime? dadoOld, DateTime? dadoNew, string nomeDado)
        {
            if (dadoOld != dadoNew)
                return $"{nomeDado} anterior: {dadoOld?.ToString("dd/MM/yyyy")}; ";

            return string.Empty;
        }

        public static string VerificarDadoEditado(DateTime? dadoOld, DateTime? dadoNew, string nomeDado, string formato)
        {
            if (dadoOld != dadoNew)
                return $"{nomeDado} anterior: {dadoOld?.ToString(formato)}; ";

            return string.Empty;
        }

        public static string VerificarDadoEditado(decimal? dadoOld, decimal? dadoNew, string nomeDado)
        {
            if (dadoOld != dadoNew)
                return $"{nomeDado} anterior: {dadoOld?.ToString("N")}; ";

            return string.Empty;
        }

        public static string VerificarDadoListaEditado(IEnumerable<string> valuesOld, IEnumerable<string> valuesNew, string nomeDado)
        {
            var valuesOldIds = "";
            if (valuesOld.HasValue())
                valuesOldIds = string.Join(",", valuesOld.OrderBy(x => x));

            var valuesNewIds = "";
            if (valuesNew.HasValue())
                valuesNewIds = string.Join(",", valuesNew.OrderBy(x => x));

            if (valuesOldIds != valuesNewIds)
            {
                List<string> nomes = new();
                if (valuesOld.HasValue())
                    foreach (var item in valuesOld)
                        nomes.Add(item);

                return $"{nomeDado} anteriores: {string.Join(", ", nomes)}; ";
            }

            return string.Empty;
        }
    }
}