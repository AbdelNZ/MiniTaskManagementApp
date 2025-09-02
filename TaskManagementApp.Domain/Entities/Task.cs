using TaskManagementApp.Domain.ValueObjects;
namespace TaskManagementApp.Domain.Entities;

public class TaskItem
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Title { get; private set; }
    public string Description { get; private set; }
    public Task_Status Status { get; private set; } = Task_Status.Todo;

    public Guid ProjectId { get;  private set; }
    public Project Project { get; private set; }

    private TaskItem() { } // EF Core

    public TaskItem(string title, string description, Guid projectId)
    {
        Title = title;
        Description = description;
        ProjectId = projectId;
    }

    public void MarkAsComplete()
    {
        Status = Task_Status.Done;
        // Logic to mark the task as completed
    }

}