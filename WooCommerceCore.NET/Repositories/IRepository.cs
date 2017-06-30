﻿using System.Collections.Generic;
using System.Threading.Tasks;
using WooCommerceCore.NET.Models;

namespace WooCommerceCore.NET.Repositories
{
    internal interface IRepository<T>
        where T : IEntity
    {
        Task<T> CreateAsync(T entity);
        Task<T> DeleteAsync(T entity);
        Task<IList<T>> ListAsync();
        Task<T> RetrieveAsync(int id);
        Task<T> UpdateAsync(T entity);
    }
}
