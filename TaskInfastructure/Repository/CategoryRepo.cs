using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TaskCore.Entity;
using TaskCore.IRepository;
using TaskInfastructure.ApplicationDBContext;

namespace TaskInfastructure.Repository
{
    public class CategoryRepo : Repository<Taskcategory>,ICetegoryRepo
    {
        private readonly TaskDBcontext _dbcontext;
        public CategoryRepo(TaskDBcontext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<bool> ExistsAsync(Taskcategory entity)
        {
            var Result = await _dbcontext.Category.FirstOrDefaultAsync(c => c.Name == entity.Name);
            if (Result != null)
            {
                return true;
            }
            return false;
        }

        public async Task<Taskcategory> GetAsync(int id)
        {
            return await _dbcontext.Category.FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task<Taskcategory> UpdateAsync(Taskcategory category, int id)
        {
           var Result = await _dbcontext.Category.FirstOrDefaultAsync(c => c.Id == id);
           if (Result == null)
           {
              throw new NullReferenceException("Category not found");
           }
            Result.Name = category.Name;
            _dbcontext.Category.Update(Result);
            return Result;
        }
        public async Task<Taskcategory> DeleteAsync(int id)
        {
            var Result = await _dbcontext.Category.FirstOrDefaultAsync(c => c.Id == id);
            if (Result == null)
            {
                throw new NullReferenceException("Category not found");
            }
            _dbcontext.Category.Remove(Result);
            return Result;
        }

    }
}
