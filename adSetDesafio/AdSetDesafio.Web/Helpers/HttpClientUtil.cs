using System;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Reflection;
using System.Linq;
using AdSetDesafio.Infrastructure.Extensions;

namespace AdSetDesafio.Web.Helpers
{
    internal class HttpClientUtil<T> : IDisposable
        where T : class
    {
        private HttpClient _client = new();
        public static readonly TimeSpan Timeout30Minutos = new TimeSpan(0, 30, 0);

        public HttpClientUtil(string url, bool longTimeout = false)
        {
            _client.BaseAddress = new Uri(url);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (longTimeout)
                _client.Timeout = new(0, 30, 0);
            else
                _client.Timeout = new(0, 1, 0);
        }

        public async Task<T> Get(string url)
        {
            T retorno = null;

            using (var response = await _client.GetAsync(url))
            {
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                    retorno = await response.Content.ReadAsAsync<T>();
            }

            return retorno;
        }

        private async Task<T> PostModel(string url, object obj)
        {
            T retorno = null;
            var json = JsonConvert.SerializeObject(obj);

            using (var content = new StringContent(json, Encoding.UTF8, "application/json"))
            using (var response = await _client.PostAsync(url, content))
            {
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                    retorno = await response.Content.ReadAsAsync<T>();
            }

            return retorno;
        }

        public async Task<T> Post(string url, IFormFile file)
        {
            T retorno = null;
            var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

            using (var content = new MultipartFormDataContent())
            {
                content.Add(new StreamContent(file.OpenReadStream())
                {
                    Headers = { ContentLength = file.Length, ContentType = new MediaTypeHeaderValue(file.ContentType) }
                }, "File", fileName);

                using (var response = await _client.PostAsync(url, content))
                {
                    response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                        retorno = await response.Content.ReadAsAsync<T>();
                }
            }

            return retorno;
        }

        public async Task<T> Post(string url, object model = null)
        {

            PropertyInfo[] properties = (model is not null ? model.GetType().GetProperties() : null);

            if (properties is not null && properties.Where(x => x.PropertyType.Name == nameof(IFormFile)).HasValue())
            {
                T retorno = null;

                using (MultipartFormDataContent content = new())
                {
                    foreach (var property in properties)
                    {
                        if (property.PropertyType.Name != nameof(IFormFile))
                        {
                            content.Add(new StringContent((property.GetValue(model) ?? String.Empty).ToString()), property.Name);
                        } else
                        {
                            IFormFile file = (IFormFile)property.GetValue(model);
                            if (file is not null) { 
                                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                                content.Add(new StreamContent(file.OpenReadStream())
                                {
                                    Headers = { ContentLength = file.Length, ContentType = new MediaTypeHeaderValue(file.ContentType) }
                                }, "File", fileName);
                            }
                        }
                    }
                    using var response = await _client.PostAsync(url, content);
                    response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                        retorno = await response.Content.ReadAsAsync<T>();
                }

                return retorno;
            }
            else return await PostModel(url, model);

        }

        public async Task<T> Put(string url, object obj = null)
        {
            T retorno = null;
            var json = JsonConvert.SerializeObject(obj);

            using (var content = new StringContent(json, Encoding.UTF8, "application/json"))
            using (var response = await _client.PutAsync(url, content))
            {
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                    retorno = await response.Content.ReadAsAsync<T>();
            }

            return retorno;
        }

        public async Task<T> Patch(string url, object obj = null)
        {
            T retorno = null;
            var json = JsonConvert.SerializeObject(obj);

            using (var content = new StringContent(json, Encoding.UTF8, "application/json"))
            using (var response = await _client.PatchAsync(url, content))
            {
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                    retorno = await response.Content.ReadAsAsync<T>();
            }

            return retorno;
        }

        public async Task<T> Delete(string url)
        {
            T retorno = null;

            using (var response = await _client.DeleteAsync(url))
            {
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                    retorno = await response.Content.ReadAsAsync<T>();
            }

            return retorno;
        }

        public void SetLongTimeout()
        {
            _client.Timeout = Timeout30Minutos;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                if (_client != null)
                {
                    _client.Dispose();
                    _client = null;
                }
        }
    }
}