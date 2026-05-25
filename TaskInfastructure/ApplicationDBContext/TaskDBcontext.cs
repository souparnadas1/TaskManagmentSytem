using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TaskCore.Entity;

namespace TaskInfastructure.ApplicationDBContext
{
    public class TaskDBcontext : DbContext
    {
        public TaskDBcontext(DbContextOptions options) : base(options)
        {
            
        }

        public  DbSet<Taskcategory> Category { get; set; }
        public DbSet<Tasks> Tasks  { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tasks>()
                .HasOne(t => t.Category)          
                .WithMany(c => c.Tasks)       
                .HasForeignKey(t => t.CategoryId)  
                .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
