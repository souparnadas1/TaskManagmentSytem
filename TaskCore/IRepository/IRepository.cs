using System;
using System.Collections.Generic;
using System.Text;
using TaskCore.Entity;

namespace TaskCore.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<bool> AddAsync(T entity);
    }
}
