using System;
using System.Collections.Generic;
using System.Text;
using TaskCore.Entity;

namespace TaskCore.IRepository
{
    public interface ITasksRepo : IRepository<Tasks>
    {
        Task<Tasks> GetAsync(int id);
        Task<Tasks> UpdateAsync(Tasks task, int id);
        Task<Tasks> DeleteAsync(int id);
        Task<bool> ExistsAsync(Tasks entity);
    }
}
