using System;
using System.Collections.Generic;
using System.Text;
using TaskCore.Entity;
using TaskCore.IRepository;

namespace TaskInfastructure.Services
{
    public class CategoryService
    {
        private readonly IUnitOfwork _unitOfwork;
        public CategoryService(IUnitOfwork unitOfwork)
        {
            _unitOfwork = unitOfwork;
        }

        public async Task<Taskcategory> AddCategory(Taskcategory category)
        {
            var exist = await _unitOfwork.CategoryRepo.ExistsAsync(category);
            if (exist)
            {
                throw new Exception("Category already exists");
            }
            await _unitOfwork.CategoryRepo.AddAsync(category);
            await _unitOfwork.SaveChangesAsync();
            return category;
        }
        public async Task<IEnumerable<Taskcategory>> getAllAsync()
        {
            return await _unitOfwork.CategoryRepo.GetAllAsync(p=>p.categoryName);
        }
        public async Task<Taskcategory> GetByIdAsync(int id)
        {
            return await _unitOfwork.CategoryRepo.GetAsync(id);
        }
        public async Task<Taskcategory> UpdateAsync(Taskcategory category, int id)
        {
            var exist = await _unitOfwork.CategoryRepo.ExistsAsync(category);
            if (exist)
            {
                throw new Exception("Category already exists");
            }
            var result = await _unitOfwork.CategoryRepo.UpdateAsync(category,id);
            await _unitOfwork.SaveChangesAsync();
            return result;
        }
        public async Task<Taskcategory> DeleteAsync(int id)
        {
            var result = await _unitOfwork.CategoryRepo.DeleteAsync(id);
            await _unitOfwork.SaveChangesAsync();
            return result;
        }
    }
}
