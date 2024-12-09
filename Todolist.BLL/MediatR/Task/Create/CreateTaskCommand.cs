using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskType = Todolist.DAL.Entities.Task;

namespace Todolist.BLL.MediatR.Task.Create
{
    public record CreateTaskCommand(TaskType Task) : IRequest<Result<Unit>>;
}
