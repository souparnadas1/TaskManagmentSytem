using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TaskCore.Entity;
using TaskCore.IRepository;
using TaskInfastructure.ApplicationDBContext;

namespace TaskInfastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly TaskDBcontext _context;
        private readonly DbSet<T> _dbSet;
        public Repository(TaskDBcontext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task<bool> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return true;
        }

        public async Task<IEnumerable<T>> GetAllAsync(
            params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;

            foreach (var include in includes)
                query = query.Include(include);

            return await query.ToListAsync();
        }

    }
}
