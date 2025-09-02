using TaskManagementApp.Domain.Entities;
namespace TaskManagementApp.Application.Interfaces;

public interface IProjectRepository
{
    Task<Project> AddAsync(Project project);
    Task<Project?> GetByIdAsync(Guid id);
    Task<IEnumerable<Project>> GetAllAsync();

    Task SaveChangesAsync();
}