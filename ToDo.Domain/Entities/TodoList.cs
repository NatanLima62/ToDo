using ToDo.Domain.Validator;

namespace ToDo.Domain.Entities;

public class TodoList : Base
{
    public string Name { get; set; }
    public int UserId { get; set; }
    
    //Ef relaçoes
    public User User { get; set; }
    public List<Assignment> Assignments { get; set; } = new();

    //Validação
    public override bool Validate()
    {
        var validator = new ToDoValidator();
        var validation = validator.Validate(this);

        if (!validation.IsValid)
        {
            foreach (var error in validation.Errors)
            {
                _erros.Add(error.ErrorMessage);
            }
        }

        return true;
    }
}