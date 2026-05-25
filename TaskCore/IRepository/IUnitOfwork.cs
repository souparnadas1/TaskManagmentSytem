using System;
using System.Collections.Generic;
using System.Text;

namespace TaskCore.IRepository
{
    public interface IUnitOfwork : IDisposable
    {
        public ITasksRepo TaskRepo { get; set; }
        public ICetegoryRepo CategoryRepo { get; set; }
        Task SaveChangesAsync();
    }
}
