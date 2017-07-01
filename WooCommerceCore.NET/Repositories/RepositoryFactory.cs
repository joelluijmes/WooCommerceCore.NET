using System;
using WooCommerceCore.NET.Entities;
using WooCommerceCore.NET.REST;

namespace WooCommerceCore.NET.Repositories
{
    public static class RepositoryFactory
    {
        public static TRepository Create<TEntity, TRepository>(IJsonRestClient restClient) 
            where TEntity : IEntity
            where TRepository : IRepository<TEntity>
        {
            var args = new object[] {restClient};
            return (TRepository) Activator.CreateInstance(typeof(TRepository), args);
        }
    }
}
