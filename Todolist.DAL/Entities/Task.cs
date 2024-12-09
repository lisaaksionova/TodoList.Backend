using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todolist.DAL.Enums;
using TaskStatus = Todolist.DAL.Enums.TaskStatus;

namespace Todolist.DAL.Entities
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required")]
        [MaxLength(50)]
        public string Title { get; set; } = string.Empty;
        [MaxLength(100)]
        public string? Text { get; set; }
        public TaskStatus TaskType { get; set; }
    }
}
