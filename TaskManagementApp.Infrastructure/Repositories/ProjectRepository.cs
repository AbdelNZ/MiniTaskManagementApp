using Microsoft.EntityFrameworkCore;
using TaskManagementApp.Application.Interfaces;
using TaskManagementApp.Domain.Entities;
using TaskManagementApp.Infrastructure.Persistence;

namespace TaskManagementApp.Infrastructure.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly AppDbContext _context;
    public ProjectRepository(AppDbContext context) => _context = context;

    public async Task<Project> AddAsync(Project project)
    {
        _context.Projects.Add(project);
        await _context.SaveChangesAsync();
        return project;
    }

    public async Task<Project?> GetByIdAsync(Guid id) =>
    await _context.Projects.Include(p => p.Tasks).FirstOrDefaultAsync(p => p.Id == id);

    public async Task<IEnumerable<Project>> GetAllAsync() =>
    await _context.Projects.Include(p => p.Tasks).ToListAsync();

    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
}