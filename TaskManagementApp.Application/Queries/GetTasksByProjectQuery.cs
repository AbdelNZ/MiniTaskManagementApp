using MediatR;
using TaskManagementApp.Application.DTOs;

namespace TaskManagementApp.Application.Queries;

public record GetTasksByProjectQuery(Guid ProjectId) : IRequest<IEnumerable<TaskDto>>;