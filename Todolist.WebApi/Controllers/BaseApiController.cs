using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Todolist.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        private IMediator? _mediator;

        protected IMediator Mediator => _mediator ??=
            HttpContext.RequestServices.GetService<IMediator>()!;

        protected ActionResult HandleResult<T>(Result<T> result)
        {

            if (result.IsSuccess)
            {
                if(result is Result<T>)
                {
                    return Ok(result.Value);
                }

                return (result.Value is null) ? NotFound("Not found") : Ok(result.Value);
            }

            return BadRequest("Something went wrong...");
        }
    }

   
}
