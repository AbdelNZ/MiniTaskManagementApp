using TaskManagementApp.Domain.Entities;

namespace TaskManagementApp.Application.Interfaces;

public interface ITaskRepository
{
    Task<TaskItem> AddASync(TaskItem task);
    Task<TaskItem> GetByIdAsync(Guid id);
    Task<IEnumerable<TaskItem>> GetByProjectIdAsync(Guid projectId); 
    Task SaveChangesAsync();
}