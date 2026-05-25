using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using TaskCore.IRepository;
using TaskInfastructure.ApplicationDBContext;

namespace TaskInfastructure.Repository
{
    public class UnitofWork : IUnitOfwork
    {
        private readonly TaskDBcontext _dbcontext;
        public ITasksRepo TaskRepo { get; set; }
        public ICetegoryRepo CategoryRepo { get; set; }
        public UnitofWork(TaskDBcontext dbcontext)
        {
            _dbcontext = dbcontext;
            TaskRepo = new TaskRepository(_dbcontext);
            CategoryRepo = new CategoryRepo(_dbcontext);    
        }

        public async Task SaveChangesAsync()
        {
            await _dbcontext.SaveChangesAsync();
        }
        public void Dispose()
        {
            _dbcontext.Dispose();
        }
    }
}
