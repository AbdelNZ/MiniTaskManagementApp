namespace TaskManagementApp.Domain.Events;

public class TaskCreatedEvent
{
    public Guid TaskId { get; }
    public DateTime CreatedAt { get; } = DateTime.UtcNow;

    public TaskCreatedEvent(Guid taskId)
    {
        TaskId = taskId;
    }
}