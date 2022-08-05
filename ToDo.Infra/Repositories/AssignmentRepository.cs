using ToDo.Domain.Entities;
using ToDo.Infra.Contexts;
using ToDo.Infra.Interfaces;

namespace ToDo.Infra.Repositories;

public class AssignmentRepository : BaseRepository<Assignment>, IAssignmentRepository
{
    private readonly TodoContext _context;

    public AssignmentRepository(TodoContext context) : base(context)
    {
        _context = context;
    }
}