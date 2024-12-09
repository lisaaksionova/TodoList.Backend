using FluentResults;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todolist.DAL.Repositories.Interfaces;

namespace Todolist.BLL.MediatR.Task.Update
{
    public class UpdateTaskHandler : IRequestHandler<UpdateTaskCommand, Result<Unit>>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly ILogger<UpdateTaskHandler> _logger;

        public UpdateTaskHandler(ITaskRepository taskRepository, ILogger<UpdateTaskHandler> logger)
        {
            _taskRepository = taskRepository;
            _logger = logger;
        }

        public async Task<Result<Unit>> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetByIdAsync(request.Task.Id);
            if (task == null)
            {
                string errorMessage = "CannotConvertNullToTask";
                _logger.LogError(errorMessage, request);
                return Result.Fail(new Error(errorMessage));
            }

            await _taskRepository.UpdateAsync(request.Task);

            var resultIsSuccess = await _taskRepository.SaveChangesAsync() > 0;
            if (resultIsSuccess)
            {
                _logger.LogInformation("TaskUpdated", request.Task);
                return Result.Ok(Unit.Value); }
            else
            {
                Console.WriteLine(request.Task.Id + " " + request.Task.Title + " " + request.Task.Text + " " + request.Task.TaskType);
                string errorMessage = "FailedToUpdateTask";
                _logger.LogError(errorMessage, request);
                return Result.Fail(new Error(errorMessage));
            }
        }
    }
}
