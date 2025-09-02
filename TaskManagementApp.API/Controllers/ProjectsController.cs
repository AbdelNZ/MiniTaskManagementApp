using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagementApp.Application.Commands;
using TaskManagementApp.Application.Queries;

namespace TaskManagementApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProjectsController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProjectCommand command)
    {
        var project = await _mediator.Send(command);
        return Ok(project);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var projects = await _mediator.Send(new GetProjectsQuery());
        return Ok(projects);
    }
}
