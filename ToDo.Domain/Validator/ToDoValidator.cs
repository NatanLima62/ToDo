using FluentValidation;
using ToDo.Domain.Entities;

namespace ToDo.Domain.Validator;

public class ToDoValidator : AbstractValidator<TodoList>
{
    public ToDoValidator()
    {
        RuleFor(todoList => todoList)
            .NotEmpty()
            .WithMessage("O ToDo não pode ser vazio")

            .NotNull()
            .WithMessage("O ToDo não pode ser nulo");

        RuleFor(todoList => todoList.Name)
            .NotEmpty()
            .WithMessage("O nome do ToDo não pode ser vazio")

            .NotNull()
            .WithMessage("O nome do ToDo não pode ser nulo")

            .MinimumLength(3)
            .WithMessage("o nome do ToDo deve ter no mínimo 3 caracteres")

            .MaximumLength(180)
            .WithMessage("o nome do ToDo deve ter no máximo 180 caracteres");
        
        RuleFor(todoList => todoList.UserId)
            .NotEmpty()
            .WithMessage("O UserId do ToDo não pode ser vazio")

            .NotNull()
            .WithMessage("O UserId do ToDo não pode ser nulo");
    }
}