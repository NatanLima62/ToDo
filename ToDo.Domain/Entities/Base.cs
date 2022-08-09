namespace ToDo.Domain.Entities;

public abstract class Base
{
    public int Id { get; set; }
    
    internal List<string> _erros;
    public virtual IReadOnlyCollection<string> Error => _erros;

    public abstract bool Validate();
}