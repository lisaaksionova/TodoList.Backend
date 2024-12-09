using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todolist.DAL.Entities;
using Task = System.Threading.Tasks.Task;
using TaskType = Todolist.DAL.Entities.Task;

namespace Todolist.DAL.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskType>> GetAllAsync();
        Task<TaskType> GetByIdAsync(int id);
        void Delete(TaskType task);
        Task<TaskType> CreateAsync(TaskType task);
        Task UpdateAsync(TaskType newTask);
        int SaveChanges();
        Task<int> SaveChangesAsync();


    }
}
