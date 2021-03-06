﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WooCommerceCore.NET.Entities;
using WooCommerceCore.NET.REST;

namespace WooCommerceCore.NET.Repositories
{
    public abstract class BaseWooCommerceRepository<T> : IRepository<T>
        where T : IEntity
    {
        private readonly string _api;

        protected BaseWooCommerceRepository(IJsonRestClient jsonClient, string api)
        {
            _api = api;
            JsonClient = jsonClient;
        }

        protected IJsonRestClient JsonClient { get; }

        public async Task<IList<T>> ListAsync()
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
            return response == null
                ? default(T)
                : response.ToObject<T>();
        }

        public async Task<T> RetrieveAsync(int id)
        {
            var response = await JsonClient.GetJsonAsync($"{_api}/{id}");
            return response == null
                ? default(T)
                : response.ToObject<T>();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var response = await JsonClient.PutJsonAsync($"{_api}/{entity.Id}", entity);
            return response == null
                ? default(T)
                : response.ToObject<T>();
        }

        public async Task<T> DeleteAsync(T entity)
        {
            var response = await JsonClient.DeleteJsonAsync($"{_api}/{entity.Id}?force=1");
            return response == null
                ? default(T)
                : response.ToObject<T>();
        }
    }
}
