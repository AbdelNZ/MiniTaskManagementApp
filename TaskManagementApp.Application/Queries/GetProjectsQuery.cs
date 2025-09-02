using MediatR;
using TaskManagementApp.Application.DTOs;

namespace TaskManagementApp.Application.Queries;

public record GetProjectsQuery() : IRequest<IEnumerable<ProjectDto>>;
