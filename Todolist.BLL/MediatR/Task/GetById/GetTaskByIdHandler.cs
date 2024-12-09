using FluentResults;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todolist.DAL.Repositories.Interfaces;
using TaskType = Todolist.DAL.Entities.Task;

namespace Todolist.BLL.MediatR.Task.GetById
{
    public class GetTaskByIdHandler : IRequestHandler<GetTaskByIdQuery, Result<TaskType>>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly ILogger<GetTaskByIdHandler> _logger;

        public GetTaskByIdHandler(ITaskRepository taskRepository, ILogger<GetTaskByIdHandler> logger)
        {
            _taskRepository = taskRepository;
            _logger = logger;
        }

        public async Task<Result<TaskType>> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetByIdAsync(request.Id);
            if (task == null)
            {
                string errorMessage = "CannotFindTaskWithCorrespondingId";
                _logger.LogError(errorMessage, request);
                return Result.Fail(new Error(errorMessage));
            }

            return Result.Ok(task);
        }
    }
}
