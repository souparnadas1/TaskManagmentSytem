using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TaskCore.Entity;

namespace TaskCore.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
        Task<bool> AddAsync(T entity);
    }
}
