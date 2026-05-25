using System;
using System.Collections.Generic;
using System.Text;
using TaskCore.Entity;
using TaskCore.IRepository;

namespace TaskInfastructure.Services
{
    public class TaskService
    {
        private readonly IUnitOfwork _unitOfwork;
        public TaskService(IUnitOfwork unitOfwork)
        {
            _unitOfwork = unitOfwork;
        }

        public async Task<Tasks> AddTasks(Tasks Task)
        {
            var exist = await _unitOfwork.TaskRepo.ExistsAsync(Task);
            if (exist)
            {
                throw new Exception("Category already exists");
            }
            await _unitOfwork.TaskRepo.AddAsync(Task);
            await _unitOfwork.SaveChangesAsync();
            return Task;
        }
        public async Task<IEnumerable<Tasks>> getAllAsync(Tasks Task)
        {
            return await _unitOfwork.TaskRepo.GetAllAsync();
        }
        public async Task<Tasks> GetByIdAsync(int id)
        {
            return await _unitOfwork.TaskRepo.GetAsync(id);
        }
        public async Task<Tasks> UpdateAsync(Tasks Task, int id)
        {
            var exist = await _unitOfwork.TaskRepo.ExistsAsync(Task);
            if (exist)
            {
                throw new Exception("Category already exists");
            }
            var result = await _unitOfwork.TaskRepo.UpdateAsync(Task, id);
            return result;
        }
        public async Task<Tasks> DeleteAsync(int id)
        {
            var result = await _unitOfwork.TaskRepo.DeleteAsync(id);
            return result;
        }
    }
}
