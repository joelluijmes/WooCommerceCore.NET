using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WooCommerceCore.NET.REST
{
    public sealed class JsonRestClient : IDisposable, IJsonRestClient
    {
        private bool _disposed;

        public JsonRestClient(string baseUrl)
        {
            var httpClientHandler = new HttpClientHandler
            {
                UseCookies = true,
                CookieContainer = new CookieContainer(),
                AllowAutoRedirect = true
            };

            HttpClient = new HttpClient(httpClientHandler)
            {
                BaseAddress = new Uri(baseUrl)
            };
        }

        public JsonRestClient(string baseUrl, string username, string password) : this(baseUrl)
        {
            var basicToken = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}"));
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", basicToken);
        }

        private HttpClient HttpClient { get; }

        public void Dispose()
        {
            if (_disposed)
                throw new ObjectDisposedException("Object has already been disposed");

            HttpClient?.Dispose();
            _disposed = true;
        }

        public async Task<JToken> DeleteJsonAsync(string url)
        {
            var response = await HttpClient.DeleteAsync(url);
            var str = await response.Content.ReadAsStringAsync();

            return JToken.Parse(str);
        }

        public async Task<JToken> GetJsonAsync(string url)
        {
            var response = await HttpClient.GetAsync(url);
            var str = await response.Content.ReadAsStringAsync();

            return JToken.Parse(str);
        }

        public async Task<JToken> PostJsonAsync<T>(string url, T postObject)
        {
            var json = JsonConvert.SerializeObject(postObject);
            using (var content = new StringContent(json, Encoding.UTF8, "application/json"))
            {
                var response = await HttpClient.PostAsync(url, content);
                var str = await response.Content.ReadAsStringAsync();

                return JToken.Parse(str);
            }
        }

        public async Task<JToken> PutJsonAsync<T>(string url, T postObject)
        {
            var json = JsonConvert.SerializeObject(postObject);
            using (var content = new StringContent(json, Encoding.UTF8, "application/json"))
            {
                var response = await HttpClient.PutAsync(url, content);
                var str = await response.Content.ReadAsStringAsync();

                return JToken.Parse(str);
            }
        }
    }
}
