using FluentResults;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todolist.DAL.Repositories.Interfaces;

namespace Todolist.BLL.MediatR.Task.Delete
{
    public class DeleteTaskHandler : IRequestHandler<DeleteTaskCommand, Result<Unit>>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly ILogger<DeleteTaskHandler> _logger;

        public DeleteTaskHandler(ITaskRepository taskRepository, ILogger<DeleteTaskHandler> logger)
        {
            _taskRepository = taskRepository;
            _logger = logger;
        }

        public async Task<Result<Unit>> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetByIdAsync(request.Id);

            if (task == null) {
                string errorMessage = "CannotFindTaskWithCorrespondingCategoryId";
                _logger.LogError(errorMessage, request);
                return Result.Fail(new Error(errorMessage));
            }

            _taskRepository.Delete(task);

            var resultIsSuccess = await _taskRepository.SaveChangesAsync() > 0;
            if (resultIsSuccess)
            {
                _logger.LogInformation("Deleted", request);
                return Result.Ok(Unit.Value);
            }
            else
            {
                string errorMessage = "FailedToDeleteFact";
                _logger.LogError(errorMessage, request);
                return Result.Fail(new Error(errorMessage));
            }
        }
    }
}
