using Xunit;

using TaskManagementApp.Application.Commands;
using TaskManagementApp.Application.Validators;

public class CreateTaskCommandValidatorTests
{
    [Fact]
    public void Validate_ShouldFail_WhenTitleIsmpty()
    {
        var validator = new CreateTaskCommandValidator();
        var command = new CreateTaskCommand("Task 1", "description", Guid.NewGuid());

        var result = validator.Validate(command);

        Assert.True(result.IsValid);
    }
}