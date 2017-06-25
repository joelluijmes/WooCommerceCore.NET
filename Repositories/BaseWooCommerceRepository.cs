using System.Collections.Generic;
using System.Threading.Tasks;
using WooCommerceCore.NET.Models;

namespace WooCommerceCore.NET.Repositories
{
    public abstract class BaseWooCommerceRepository<T> : IRepository<T>
        where T : IEntity
    {
        private readonly string _api;
        protected JsonRestClient JsonClient { get; }

        public async Task<IList<T>> ListEntitiesAsync()
        {
            var response = await JsonClient.GetJsonAsync(_api);
            return response.ToObject<IList<T>>();
        }

        public async Task<T> CreateAsync(T entity)
        {
            var response = await JsonClient.PostJsonAsync(_api, entity);
            return response.ToObject<T>();
        }

        public async Task<T> Retrieve(int id)
        {
            var response = await JsonClient.GetJsonAsync($"{_api}/{id}");
            return response.ToObject<T>();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var response = await JsonClient.PutJsonAsync($"{_api}/{entity.Id}", entity);
            return response.ToObject<T>();
        }

        public async Task<T> DeleteAsync(T entity)
        {
            var response = await JsonClient.DeleteJsonAsync($"{_api}/{entity.Id}");
            return response.ToObject<T>();
        }

        protected BaseWooCommerceRepository(JsonRestClient jsonClient, string api)
        {
            _api = api;
            JsonClient = jsonClient;
        }
    }
}
