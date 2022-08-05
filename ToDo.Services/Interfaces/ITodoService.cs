using ToDo.Services.DTOs;

namespace ToDo.Services.Interfaces;

public interface ITodoService
{
    Task<TodoDTO> Create(TodoDTO todoDto);
    Task<List<TodoDTO>> GetAll();
    Task<TodoDTO> GetById(int id);
    Task<TodoDTO> Update(TodoDTO todoDto);
    Task Delete(int id);
}