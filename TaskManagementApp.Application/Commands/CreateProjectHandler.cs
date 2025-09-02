using MediatR;
using TaskManagementApp.Application.DTOs;
using TaskManagementApp.Application.Interfaces;
using TaskManagementApp.Domain.Entities;


namespace TaskManagementApp.Application.Commands;

public class CreateProjectHandler : IRequestHandler<CreateProjectCommand, ProjectDto>
{
    private readonly IProjectRepository _projectRepository;

    public CreateProjectHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<ProjectDto> Handle(CreateProjectCommand command, CancellationToken cancellationToken)
    {
        var project = new Project(command.Name, command.Description);
        await _projectRepository.AddAsync(project);
        return new ProjectDto(project.Id, project.Name, project.Description, new());
    }
}