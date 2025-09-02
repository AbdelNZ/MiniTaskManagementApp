using Microsoft.EntityFrameworkCore;
using TaskManagementApp.Domain.Entities;

namespace TaskManagementApp.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<TaskItem> Tasks { get; set; }
    public DbSet<Project> Projects { get; set; } //project entity will be added later
}