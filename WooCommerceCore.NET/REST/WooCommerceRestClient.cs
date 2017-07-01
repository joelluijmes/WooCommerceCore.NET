using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using WooCommerceCore.NET.Exceptions;

namespace WooCommerceCore.NET.REST
{
    public sealed class WooCommerceRestClient : IJsonRestClient
    {
        public WooCommerceRestClient(IJsonRestClient restClient)
        {
            RestClient = restClient;
        }

        public IJsonRestClient RestClient { get; }

        public async Task<JToken> DeleteJsonAsync(string url)
        {
            var response = await RestClient.DeleteJsonAsync(url);
            ValidateReponse(response);

            return response;
        }

        public async Task<JToken> GetJsonAsync(string url)
        {
            var response = await RestClient.GetJsonAsync(url);
            ValidateReponse(response);

            return response;
        }

        public async Task<JToken> PostJsonAsync<T>(string url, T postObject)
        {
            var response = await RestClient.PostJsonAsync(url, postObject);
            ValidateReponse(response);

            return response;
        }

        public async Task<JToken> PutJsonAsync<T>(string url, T postObject)
        {
            var response = await RestClient.PutJsonAsync(url, postObject);
            ValidateReponse(response);

            return response;
        }

        private static void ValidateReponse(JToken token, [CallerMemberName] string caller = null)
        {
            var code = token.SelectToken("$.code")?.ToString();
            var message = token.SelectToken("$.message")?.ToString();

            if (!string.IsNullOrEmpty(code) && !string.IsNullOrEmpty(message))
                throw new RestException(message, code, caller);
        }
    }
}
