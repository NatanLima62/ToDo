using AutoMapper;
using ToDo.Core.Exeption;
using ToDo.Domain.Entities;
using ToDo.Infra.Interfaces;
using ToDo.Services.DTOs;
using ToDo.Services.Interfaces;

namespace ToDo.Services.Services;

public class TodoServices : ITodoService
{
    private readonly ITodoRepository _todoRepository;
    private readonly IMapper _mapper;

    public TodoServices(ITodoRepository todoRepository, IMapper mapper)
    {
        _todoRepository = todoRepository;
        _mapper = mapper;
    }

    public async Task<TodoDTO> Create(TodoDTO todoDto)
    {
        var todo = _mapper.Map<TodoList>(todoDto);
        todo.Validate();

        var todoCreated = await _todoRepository.Create(todo);

        return _mapper.Map<TodoDTO>(todoDto);
    }

    public async Task<List<TodoDTO>> GetAll()
    {
        var allTodos = await _todoRepository.GetAll();

        return _mapper.Map<List<TodoDTO>>(allTodos);
    }

    public async Task<TodoDTO> GetById(int id)
    {
        var todo = await _todoRepository.GetById(id);

        return _mapper.Map<TodoDTO>(todo);
    }

    public async Task<TodoDTO> Update(TodoDTO todoDto)
    {
        var todoExists = await _todoRepository.GetById(todoDto.Id);

        if (todoExists == null)
        {
            throw new DomainExeption("Não existe um todo com o id informado");
        }

        var todo = _mapper.Map<TodoList>(todoDto);
        todo.Validate();

        var todoUpdated = await _todoRepository.Update(todo);

        return _mapper.Map<TodoDTO>(todoDto);
    }

    public async Task Delete(int id)
    {
        await _todoRepository.Delete(id);
    }
}