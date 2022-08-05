using FluentValidation;
using ToDo.Domain.Entities;

namespace ToDo.Domain.Validator;

public class AssignmentValidator : AbstractValidator<Assignment>
{
    public AssignmentValidator()
    {
        RuleFor(assignment => assignment)
            .NotEmpty()
            .WithMessage("A Task não pode ser vazio")

            .NotNull()
            .WithMessage("A Task não pode ser nulo");

        RuleFor(assignment => assignment.Description)
            .NotEmpty()
            .WithMessage("O nome da Task não pode ser vazio")

            .NotNull()
            .WithMessage("O nome da Task não pode ser nulo")

            .MinimumLength(3)
            .WithMessage("A descrição da Task deve ter no mínimo 3 caracteres")

            .MaximumLength(280)
            .WithMessage("A descrição da Task deve ter no máximo 280 caracteres");

        RuleFor(assignment => assignment.UserId)
            .NotEmpty()
            .WithMessage("O UserID da Task não pode ser vazio")

            .NotNull()
            .WithMessage("O UserID da Task não pode ser nulo");
    }
}