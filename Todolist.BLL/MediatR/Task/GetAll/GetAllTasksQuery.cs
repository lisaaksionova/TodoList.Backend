using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskType = Todolist.DAL.Entities.Task;

namespace Todolist.BLL.MediatR.Task.GetAll
{
    public record GetAllTasksQuery : IRequest<Result<IEnumerable<TaskType>>>;
}
