using TaskManagementApp.Domain.Entities;

namespace TaskManagementApp.Application.DTOs;

public record ProjectDto(Guid Id, string Name, string Description, List<TaskDto> Tasks);

