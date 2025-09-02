using MediatR;
using TaskManagementApp.Application.DTOs;

namespace TaskManagementApp.Application.Commands;

public record CreateTaskCommand(string Title, string Description, Guid ProjectId) : IRequest<TaskDto>;