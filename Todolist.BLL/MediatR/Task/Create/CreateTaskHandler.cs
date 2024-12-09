using FluentResults;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todolist.DAL.Repositories.Interfaces;

namespace Todolist.BLL.MediatR.Task.Create
{
    public class CreateTaskHandler : IRequestHandler<CreateTaskCommand, Result<Unit>>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly ILogger<CreateTaskHandler> _logger;

        public CreateTaskHandler(ITaskRepository taskRepository, ILogger<CreateTaskHandler> logger)
        {
            _taskRepository = taskRepository;
            _logger = logger;
        }

        public async Task<Result<Unit>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = request.Task;

            if (task == null)
            {
                string errorMessage = "CannotConvertNullToTask";
                _logger.LogError(errorMessage, request);
                return Result.Fail(new Error(errorMessage));
            }
            await _taskRepository.CreateAsync(task);

            var resultIsSuccess = await _taskRepository.SaveChangesAsync() > 0;
            if (resultIsSuccess)
            {
                _logger.LogInformation("TaskCreated", request.Task);
                return Result.Ok(Unit.Value); 
            }
            else
            {
                string errorMessage = "FailedToCreateTask";
                _logger.LogError(errorMessage, request);
                return Result.Fail(new Error(errorMessage));
            }
        }
    }
}
