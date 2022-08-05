using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Entities;
using ToDo.Infra.Contexts;
using ToDo.Infra.Interfaces;

namespace ToDo.Infra.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    private readonly TodoContext _context;

    public UserRepository(TodoContext context) : base(context)
    {
        _context = context;
    }

    public virtual async Task<User> GetByEmail(string email)
    {
        var userEmail = await _context.Set<User>()
            .AsNoTracking()
            .Where(x => x.Email == email)
            .ToListAsync();
        
        return userEmail.FirstOrDefault();
    }
}