namespace ToDo.Services.DTOs;

public class AssignmentDTO
{
    public int Id { get; set; }
    public string Description { get; set; }
    public int UserId { get; set; }
    public int? TodoId { get; set; }
    public bool Conclued { get; set; }
    public DateTime? DeadLine { get; set; }
}