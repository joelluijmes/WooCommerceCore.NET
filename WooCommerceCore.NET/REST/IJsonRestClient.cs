using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace WooCommerceCore.NET.REST
{
    public interface IJsonRestClient
    {
        Task<JToken> DeleteJsonAsync(string url);
        Task<JToken> GetJsonAsync(string url);
        Task<JToken> PostJsonAsync<T>(string url, T postObject);
        Task<JToken> PutJsonAsync<T>(string url, T postObject);
    }
}