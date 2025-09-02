using MediatR;
using TaskManagementApp.Application.DTOs;
using TaskManagementApp.Application.Interfaces;

namespace TaskManagementApp.Application.Commands;

public class CompleteTaskHandler : IRequestHandler<CompleteTaskCommand, TaskDto>
{
    private readonly ITaskRepository _taskRepository;
    public CompleteTaskHandler(ITaskRepository taskRepository) => _taskRepository = taskRepository;

    public async Task<TaskDto?> Handle(CompleteTaskCommand command, CancellationToken cancellationToken)
    {
        var task = await _taskRepository.GetByIdAsync(command.TaskId);
        if (task is null) return null;

        task.MarkAsComplete();
        await _taskRepository.SaveChangesAsync();
        return new TaskDto(task.Id, task.Title, task.Description, (int)task.Status);
    }
}