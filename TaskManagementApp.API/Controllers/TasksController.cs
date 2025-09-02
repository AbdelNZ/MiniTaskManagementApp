using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagementApp.Application.Commands;
using TaskManagementApp.Application.Queries;
using TaskManagementApp.Domain.Entities;


namespace TaskManagementApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly IMediator _mediator;

    public TasksController(IMediator mediator) => _mediator = mediator;

    [HttpPost("Create new task")]
    public async Task<IActionResult> CreateTask([FromBody] CreateTaskCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpGet("project/{projectId}")]
    public async Task<IActionResult> GetTasksByProject(Guid projectId)
    {
        var tasks = await _mediator.Send(new GetTasksByProjectQuery(projectId));
        return Ok(tasks);
    }

    [HttpPut("{taskId}/complete")]
    public async Task<IActionResult> CompleteTask(Guid taskId)
    {
        var task = await _mediator.Send(new CompleteTaskCommand(taskId));
        if (task == null) return NotFound();
        return Ok(task);
    }
}
