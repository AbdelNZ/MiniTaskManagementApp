namespace TaskManagementApp.Domain.Entities;

public class Project
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; private set; }

    public string Description { get; private set; }

    public List<TaskItem> Tasks { get; private set; } = new();

    private Project() { } // EF Core

    public Project(string name, string description)
    {
        Name = name;
        Description = description;
    }
}