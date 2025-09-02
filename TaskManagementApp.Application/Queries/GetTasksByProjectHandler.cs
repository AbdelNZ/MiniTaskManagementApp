using TaskManagementApp.Application.Interfaces;
using TaskManagementApp.Application.DTOs;
using MediatR;

namespace TaskManagementApp.Application.Queries;

public class GetTasksByProjectHandler : IRequestHandler<GetTasksByProjectQuery, IEnumerable<TaskDto>>
{
    private readonly ITaskRepository _taskRepository;

    public GetTasksByProjectHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<IEnumerable<TaskDto>> Handle(GetTasksByProjectQuery query, CancellationToken cancellationToken)
    {
        var tasks = await _taskRepository.GetByProjectIdAsync(query.ProjectId);

        return tasks.Select(t => new TaskDto(t.Id, t.Title, t.Description, (int)t.Status));
    }
}