namespace TaskManagementApp.Application.DTOs;

public record TaskDto(Guid Id, string Title, string Description, int Status);
