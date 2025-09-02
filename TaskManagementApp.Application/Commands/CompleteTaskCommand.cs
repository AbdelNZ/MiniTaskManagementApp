using MediatR;
using TaskManagementApp.Application.DTOs;

namespace TaskManagementApp.Application.Commands;

public record CompleteTaskCommand(Guid TaskId) :IRequest<TaskDto>;