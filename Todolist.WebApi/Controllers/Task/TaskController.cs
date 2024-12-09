using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todolist.DAL.Entities;
using Todolist.BLL.MediatR.Task.GetAll;
using TaskType = Todolist.DAL.Entities.Task;
using Todolist.BLL.MediatR.Task.GetById;
using Todolist.BLL.MediatR.Task.Create;
using Todolist.BLL.MediatR.Task.Update;
using Todolist.BLL.MediatR.Task.Delete;

namespace Todolist.WebApi.Controllers.Task
{
    public class TaskController : BaseApiController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TaskType>))]
        public async Task<IActionResult> GetAll()
        {
            return HandleResult(await Mediator.Send(new GetAllTasksQuery()));
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TaskType))]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return HandleResult(await Mediator.Send(new GetTaskByIdQuery(id))); 
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] TaskType task)
        {
            return HandleResult(await Mediator.Send(new CreateTaskCommand(task)));
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] TaskType task)
        {
            return HandleResult(await Mediator.Send(new UpdateTaskCommand(task)));
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return HandleResult(await Mediator.Send(new DeleteTaskCommand(id)));
        }
    }
}
