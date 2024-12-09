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

namespace Todolist.BLL.MediatR.Task.GetAll
{
    public class GetAllTasksHandler : IRequestHandler<GetAllTasksQuery, Result<IEnumerable<TaskType>>>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly ILogger<GetAllTasksHandler> _logger;

        public GetAllTasksHandler(ITaskRepository taskRepository, ILogger<GetAllTasksHandler> logger)
        {
            _taskRepository = taskRepository;
            _logger = logger;
        }

        public async Task<Result<IEnumerable<TaskType>>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _taskRepository.GetAllAsync();
            if (!tasks.Any())
            {
                string errorMessage = "CannotFindAnyTask";
                _logger.LogError(errorMessage, request);
                return Result.Fail(new Error(errorMessage));
            }
            return Result.Ok(tasks);    
        }
    }
}
