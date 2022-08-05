using ToDo.Services.DTOs;

namespace ToDo.Services.Interfaces;

public interface IAssignmentService
{
    Task<AssignmentDTO> Create(AssignmentDTO assignmentDto);
    Task<List<AssignmentDTO>> GetAll();
    Task<AssignmentDTO> GetById(int id);
    Task<AssignmentDTO> Update(AssignmentDTO assignmentDto);
    Task Delete(int id);
}