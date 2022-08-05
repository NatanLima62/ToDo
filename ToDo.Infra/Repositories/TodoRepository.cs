using ToDo.Domain.Entities;
using ToDo.Infra.Contexts;
using ToDo.Infra.Interfaces;

namespace ToDo.Infra.Repositories;

public class TodoRepository : BaseRepository<TodoList>, ITodoRepository
{
    private readonly TodoContext _context;

    public TodoRepository(TodoContext context) : base(context)
    {
        _context = context;
    }
}