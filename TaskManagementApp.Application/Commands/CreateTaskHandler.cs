using MediatR;
using TaskManagementApp.Application.DTOs;
using TaskManagementApp.Application.Interfaces;
using TaskManagementApp.Domain.Entities;

namespace TaskManagementApp.Application.Commands;


public class CreateTaskHandler : IRequestHandler<CreateTaskCommand, TaskDto>
{
    private readonly ITaskRepository _taskRepository;

    public CreateTaskHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<TaskDto> Handle(CreateTaskCommand command, CancellationToken cancellationToken)
    {
        var task = new TaskItem(command.Title, command.Description, command.ProjectId);
        await _taskRepository.AddASync(task);
        return new TaskDto(task.Id, task.Title, task.Description, (int)task.Status);
    }
}