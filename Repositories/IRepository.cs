using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using WooCommerceCore.NET.Models;

namespace WooCommerceCore.NET.Repositories
{
    internal interface IRepository<T>
        where T : IEntity
    {
        Task<IList<T>> ListEntitiesAsync();
        Task<T> CreateAsync(T entity);
        Task<T> Retrieve(int id);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
    }
}
