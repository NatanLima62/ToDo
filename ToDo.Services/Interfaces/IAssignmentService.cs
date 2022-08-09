using ToDo.Services.DTOs;

namespace ToDo.Services.Interfaces;

public interface IAssignmentService
{
    Task<AssignmentDTO> Create(AssignmentDTO assignmentDto);
    Task<List<AssignmentDTO>> GetAll();
    Task<AssignmentDTO> GetById(int id);
    Task<AssignmentDTO> Update(AssignmentDTO assignmentDto);
    Task MarkAsDone(int id);
    Task MarkAsUndone(int id);
    Task Delete(int id);
}