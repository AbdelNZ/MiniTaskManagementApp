using Moq;
using TaskManagementApp.Application.Queries;
using TaskManagementApp.Application.Interfaces;
using TaskManagementApp.Domain.Entities;

public class GetProjectsQueryHandlerTests
{
    [Fact]
    public async Task Handle_ShouldReturnProjects_WhenProjectsExist()
    {
        var mockRepo = new Mock<IProjectRepository>();
        mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<Project>
        {
            new Project("Test Project 1", "Description 1"),
            new Project("Test Project 2", "Description 2")
        });
        var handler = new GetProjectsHandler(mockRepo.Object);

        var result = await handler.Handle(new GetProjectsQuery(), CancellationToken.None);

        Assert.NotNull(result);
        Assert.Collection(result,
        p => Assert.Equal("Test Project 1", p.Name),
        p => Assert.Equal("Test Project 2", p.Name)
        );
    }
}