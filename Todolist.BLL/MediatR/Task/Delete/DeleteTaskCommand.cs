using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todolist.BLL.MediatR.Task.Delete
{
    public record DeleteTaskCommand(int Id) : IRequest<Result<Unit>>;
}
