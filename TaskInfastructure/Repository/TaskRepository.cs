using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using TaskCore.Entity;
using TaskCore.IRepository;
using TaskInfastructure.ApplicationDBContext;

namespace TaskInfastructure.Repository
{
    public class TaskRepository:Repository<Tasks>, ITasksRepo    
    {
        private readonly TaskDBcontext _dbcontext;
        public TaskRepository(TaskDBcontext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<bool> ExistsAsync(Tasks entity)
        {
            var Result = await _dbcontext.Tasks.FirstOrDefaultAsync(c => c.Name == entity.Name);
            if (Result != null)
            {
                return true;
            }
            return false;
        }

        public async Task<Tasks> GetAsync(int id) 
        {
            return await _dbcontext.Tasks.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Tasks> UpdateAsync(Tasks task,int id)
        {
            var Result = await _dbcontext.Tasks.FirstOrDefaultAsync(x => x.Id == id);
            if (Result == null)
            {
                throw new NullReferenceException("Task not found");
            }

            Result.Name = task.Name;
            Result.TaskDate = task.TaskDate;
            Result.TaskDate = new DateOnly();
            Result.CategoryId = task.CategoryId;
            Result.TaskDescription = task.TaskDescription;

            _dbcontext.Tasks.Update(Result);
            return Result;
        }

        public async Task<Tasks> DeleteAsync(int id) 
        {
            var Result = await _dbcontext.Tasks.FirstOrDefaultAsync(x => x.Id == id);
            if (Result == null)
            {
                throw new NullReferenceException("Task not found");
            }

            _dbcontext.Tasks.Remove(Result);
            return Result;
        }
    }
}
