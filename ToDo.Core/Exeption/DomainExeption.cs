namespace ToDo.Core.Exeption;

public class DomainExeption : Exception
{
    internal List<string> _erros;

    public List<string> Errors => _erros;

    public DomainExeption() { }

    public DomainExeption(string message, List<string> erros) : base(message)
    {
        _erros = erros;
    }
    
    public DomainExeption(string message) : base(message)
    {
        
    }

    public DomainExeption(string message, Exception innerException) : base(message, innerException)
    {
        
    }
}