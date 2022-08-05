using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Entities;
using ToDo.Infra.Contexts;
using ToDo.Infra.Interfaces;

namespace ToDo.Infra.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : Base 
{
    private readonly TodoContext _context;

    public BaseRepository(TodoContext context)
    {
        _context = context;
    }
    
    public virtual async Task<T> Create(T obj)
    {
        _context.Add(obj);
        await _context.SaveChangesAsync();
        return obj;
    }

    public virtual async Task<List<T>> GetAll()
    {
        var obj = await _context.Set<T>()
            .AsNoTracking()
            .ToListAsync();

        return obj;
    }

    public virtual async Task<T> GetById(int id)
    {
        var obj = await _context.Set<T>()
            .AsNoTracking()
            .Where(x => x.Id == id)
            .ToListAsync();

        return obj.FirstOrDefault();
    }

    public virtual async Task<T> Update(T obj)
    {
        _context.Entry(obj).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return obj;
    }

    public virtual async Task<T> Delete(int id)
    {
        var obj = await GetById(id);

        if (obj != null)
        {
            _context.Remove(obj);
            await _context.SaveChangesAsync();
        }

        return obj;
    }
}