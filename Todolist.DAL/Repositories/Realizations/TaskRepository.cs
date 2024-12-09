using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todolist.DAL.Persistence;
using Todolist.DAL.Repositories.Interfaces;
using Task = System.Threading.Tasks.Task;
using TaskType = Todolist.DAL.Entities.Task;

namespace Todolist.DAL.Repositories.Realizations
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TodolistDbContext _context;
        

        public TaskRepository(TodolistDbContext context)
        {
            _context = context;
        }

        public async Task<TaskType> CreateAsync(TaskType task)
        {
            var tmp = await _context.Tasks.AddAsync(task);
            return tmp.Entity;
        }

        public void Delete(TaskType task)
        {
            _context.Tasks.Remove(task);
        }

        public async Task<IEnumerable<TaskType>> GetAllAsync()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<TaskType> GetByIdAsync(int id)
        {
            return await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TaskType newTask)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(t=>t.Id == newTask.Id);
            task.Title = newTask.Title;
            task.Text = newTask.Text;
            task.TaskType = newTask.TaskType;
        }
    }
}
