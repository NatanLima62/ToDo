using FluentValidation;
using ToDo.Domain.Entities;

namespace ToDo.Domain.Validator;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(user => user)
            .NotEmpty()
            .WithMessage("O usuário não pode ser vazio")

            .NotNull()
            .WithMessage("O usuário não pode ser nulo");

        RuleFor(user => user.Name)
            .NotEmpty()
            .WithMessage("O nome do usuário não pode ser vazio")

            .NotNull()
            .WithMessage("O nome do usuário não pode ser nulo")

            .MinimumLength(3)
            .WithMessage("o nome do usuário deve ter no mínimo 3 caracteres")

            .MaximumLength(180)
            .WithMessage("o nome do usuário deve ter no máximo 180 caracteres");
        
        RuleFor(user => user.Password)
            .NotEmpty()
            .WithMessage("O password do usuário não pode ser vazio")

            .NotNull()
            .WithMessage("O password do usuário não pode ser nulo")

            .MinimumLength(8)
            .WithMessage("o password do usuário deve ter no mínimo 8 caracteres")

            .MaximumLength(255)
            .WithMessage("o password do usuário deve ter no máximo 80 caracteres");
        
        RuleFor(user => user.Email)
            .NotEmpty()
            .WithMessage("O email do usuário não pode ser vazio")

            .NotNull()
            .WithMessage("O email do usuário não pode ser nulo")

            .MinimumLength(11)
            .WithMessage("o email do usuário deve ter no mínimo 11 caracteres")

            .MaximumLength(180)
            .WithMessage("o email do usuário deve ter no máximo 180 caracteres")
            
            .Matches(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
            .WithMessage("O email do usuario deve ser válido");
    }
}