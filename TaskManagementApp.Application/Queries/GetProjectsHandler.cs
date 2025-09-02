using MediatR;
using TaskManagementApp.Application.DTOs;
using TaskManagementApp.Application.Interfaces;
using TaskManagementApp.Domain.Entities;


namespace TaskManagementApp.Application.Queries;

public class GetProjectsHandler : IRequestHandler<GetProjectsQuery, IEnumerable<ProjectDto>>
{
    private readonly IProjectRepository _projectRepository;
    public GetProjectsHandler(IProjectRepository projectRepository) => _projectRepository = projectRepository;

    public async Task<IEnumerable<ProjectDto>> Handle(GetProjectsQuery query, CancellationToken cancellationToken)
    {
        var projects = await _projectRepository.GetAllAsync();
        return projects.Select(p => new ProjectDto(
            p.Id,
            p.Name,
            p.Description,
            p.Tasks.Select(t => new TaskDto(t.Id, t.Title, t.Description, (int)t.Status)).ToList()
        ));
    }
}