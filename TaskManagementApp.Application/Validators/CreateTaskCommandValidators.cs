using System.Data;
using FluentValidation;
using TaskManagementApp.Application.Commands;

namespace TaskManagementApp.Application.Validators;

public class CreateTaskCommandValidator : AbstractValidator<CreateTaskCommand>
{
    public CreateTaskCommandValidator()
    {
        RuleFor(x => x.Title)
        .NotEmpty().WithMessage("Title is required.")
        .MaximumLength(100).WithMessage("Title must not exceed 100 characters.");

        RuleFor(x => x.Description)
        .NotEmpty().WithMessage("Task Description is required.")
        .MaximumLength(500).WithMessage("Task Description must not exceed 500 characters.");

        RuleFor(x => x.ProjectId)
        .NotEmpty().WithMessage("ProjectId is required.");
    }
}