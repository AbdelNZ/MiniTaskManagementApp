using Microsoft.EntityFrameworkCore;
using TaskManagementApp.Application.Interfaces;
using TaskManagementApp.Domain.Entities;
using TaskManagementApp.Infrastructure.Persistence;

namespace TaskManagementApp.Infrastructure.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly AppDbContext _context;
    public TaskRepository(AppDbContext context) => _context = context;

    public async Task<TaskItem> AddASync(TaskItem task)
    {
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
        return task;
    }

    public async Task<TaskItem?> GetByIdAsync(Guid id) =>
        await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);

    public async Task<IEnumerable<TaskItem>> GetByProjectIdAsync(Guid projectId) =>
        await _context.Tasks.Where(t => t.ProjectId == projectId).ToListAsync();

    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
}
