using System.Threading;
using System.Threading.Tasks;
using Moq;
using Xunit;
using TaskManagementApp.Application.Commands;
using TaskManagementApp.Application.Interfaces;
using TaskManagementApp.Domain.Entities;

namespace TaskManagementApp.Tests;

public class CreateTaskHandlerTests
{
    [Fact]
    public async Task Handle_ShouldCreateTask()
    {
        var mockRepo = new Mock<ITaskRepository>();
        mockRepo.Setup(r => r.AddASync(It.IsAny<TaskItem>()))
        .ReturnsAsync((TaskItem t) => t);

        var handler = new CreateTaskHandler(mockRepo.Object);
        var command = new CreateTaskCommand("New Task", "Description", Guid.NewGuid());

        var result = await handler.Handle(command, CancellationToken.None);

        Assert.Equal("New Task", result.Title);
        Assert.Equal("Description", result.Description);
        mockRepo.Verify(r => r.AddASync(It.IsAny<TaskItem>()), Times.Once);
    }

}