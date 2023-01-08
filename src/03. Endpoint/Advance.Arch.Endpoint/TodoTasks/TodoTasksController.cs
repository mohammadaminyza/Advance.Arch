using Advance.Arch.Core.Contracts.TodoTasks.Commands.CreateTodoTask;
using Advance.Arch.Core.Contracts.TodoTasks.Queries.GetTodoTasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Advance.Arch.Endpoint.TodoTasks;

[Route("api/[controller]")]
[ApiController]
public class TodoTasksController : ControllerBase
{
    private readonly IMediator _mediator;

    public TodoTasksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("get")]
    public async Task<IActionResult> GetTodoTasks([FromQuery] GetTodoTasksQuery query)
    {
        try
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
        }
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateTodoTask([FromBody] CreateTodoTaskCommand command)
    {
        try
        {
            await _mediator.Send(command);

            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
        }
    }
}