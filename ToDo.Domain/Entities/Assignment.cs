using ToDo.Domain.Validator;

namespace ToDo.Domain.Entities;

public class Assignment : Base
{
    public string Description { get; set; }
    public int UserId { get; set; }
    public int? TodoListId { get; set; }
    public bool Conclued { get; set; }
    public DateTime? ConcluedAt { get; set; }
    public DateTime? DeadLine { get; set; }
    
    //Ef Relações
    public User User { get; set; }
    public TodoList TodoList { get; set; }

    //Validação
    public override bool Validate()
    {
        var validator = new AssignmentValidator();
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

    public void SetConclued()
    {
        Conclued = true;
        ConcluedAt = DateTime.Now;
    }
    
    public void SetUnconclued()
    {
        Conclued = false;
        ConcluedAt = null;
    }
}