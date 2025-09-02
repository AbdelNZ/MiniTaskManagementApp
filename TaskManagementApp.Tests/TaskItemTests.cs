using TaskManagementApp.Domain.Entities;
using TaskManagementApp.Domain.ValueObjects;


namespace TaskManagementApp.Tests;

public class TaskItemTests
{
    [Fact]
    public void MarkAsComplete_ShouldSetIsCompletedToTrue()
    {
        var project = new Project("Test Project", "Test Description");
        var task = new TaskItem("Test Task", "Test Description", project.Id);

        task.MarkAsComplete();

        Assert.Equal(Task_Status.Done, task.Status);
    }

    [Fact]
    public void Constructor_ShouldAssignPropertiesCorrectly()
    {
        var project = new Project("Test Project", "Test Description");
        var task = new TaskItem("Test Task", "Test Description", project.Id);

        Assert.Equal("Test Task", task.Title);
        Assert.Equal("Test Description", task.Description);
        Assert.Equal(project.Id, task.ProjectId);
        Assert.Equal(Task_Status.Todo, task.Status);
    }
}