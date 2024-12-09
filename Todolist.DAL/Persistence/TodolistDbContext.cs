using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todolist.DAL.Entities;
using Todolist.DAL.Enums;
using Task = Todolist.DAL.Entities.Task;
using TaskStatus = Todolist.DAL.Enums.TaskStatus;

namespace Todolist.DAL.Persistence
{
    public class TodolistDbContext : DbContext
    {
        public TodolistDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Task> Tasks { get; set; }

    }
}
