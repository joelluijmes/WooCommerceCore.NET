using System;
using System.Collections.Generic;
using System.Linq;
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
            const int batchsize = 100;

            var totalEntities = new List<T>();

            for (var i = 1;; ++i)
            {
                var response = await JsonClient.GetJsonAsync($"{_api}?per_page={batchsize}&page={i}");
                if (response == null)
                    return null;

                var batch = response.ToObject<IList<T>>();
                totalEntities.AddRange(batch);

                if (!batch.Any() || batch.Count < batchsize)
                    break;
            }

            return totalEntities;
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
            var response = await JsonClient.DeleteJsonAsync($"{_api}/{entity.Id}?force=1");
            return response.ToObject<T>();
        }

        protected BaseWooCommerceRepository(JsonRestClient jsonClient, string api)
        {
            _api = api;
            JsonClient = jsonClient;
        }
    }
}
