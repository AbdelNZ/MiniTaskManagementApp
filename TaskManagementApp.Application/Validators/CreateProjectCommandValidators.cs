using FluentValidation;

using TaskManagementApp.Application.Commands;

namespace TaskManagementApp.Application.Validators;

public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
{
    public CreateProjectCommandValidator()
    {
        RuleFor(x => x.Name)
        .NotEmpty().WithMessage("Project Name is required.")
            .MaximumLength(100);

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Project Description is required.")
            .MaximumLength(500);
    }
}