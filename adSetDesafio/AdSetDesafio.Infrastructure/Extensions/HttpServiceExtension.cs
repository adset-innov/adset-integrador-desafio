using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace AdSetDesafio.Infrastructure.Extensions
{
    public static class HttpServiceExtension
    {
        public static void AddHeader(this HttpRequestMessage requestMessage, Dictionary<string, object> headers)
        {
            if (requestMessage == null)
                return;

            if (headers == null || headers.Count == 0)
                return;

            foreach (var header in headers)
                requestMessage.Headers.Add(header.Key, header.Value.ToString());
        }

        public static void AddBody(this HttpRequestMessage requestMessage, object body)
        {
            if (requestMessage == null)
                return;

            if (body == null)
                return;

            if (body is FormUrlEncodedContent formUrlEncodedContent)
                requestMessage.Content = formUrlEncodedContent;
            else
            {
                string content = JsonConvert.SerializeObject(body);
                requestMessage.Content = new StringContent(content, Encoding.UTF8, "application/json");
            }
        }
    }
}