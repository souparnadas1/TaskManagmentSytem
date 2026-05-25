using System;
using System.Collections.Generic;
using System.Text;
using TaskCore.Entity;

namespace TaskCore.IRepository
{
    public interface ICetegoryRepo : IRepository<Taskcategory>
    {
        Task<Taskcategory> GetAsync(int id);
        Task<Taskcategory> UpdateAsync(Taskcategory category, int id);
        Task<Taskcategory> DeleteAsync(int id);
        Task<bool> ExistsAsync(Taskcategory entity);
    }
}
