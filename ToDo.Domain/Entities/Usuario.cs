using ToDo.Domain.Validator;

namespace ToDo.Domain.Entities;

public class User : Base
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    
    //Ef relações
    public List<TodoList> TodoLists { get; set; } = new();
    public List<Assignment> Assignments { get; set; } = new();
    
    //validação
    public override bool Validate()
    {
        var validator = new UserValidator();
        var validation = validator.Validate(this);

        if (!validation.IsValid)
        {
            foreach (var error in validation.Errors)
            {
                _erros.Add(error.ErrorMessage);
            }

            throw new Exception("Alguns campos estão inválidos por favor corrija-os");
        }

        return true;
    }
}