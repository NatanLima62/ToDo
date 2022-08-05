using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Entities;
using ToDo.Infra.Mappings;

namespace ToDo.Infra.Contexts;

public class TodoContext : DbContext
{
    public TodoContext()
    { }
    public TodoContext(DbContextOptions<TodoContext> options) : base(options)
    { }
    
    public DbSet<User> Users { get; set; }
    public DbSet<TodoList> TodoLists { get; set; }
    public DbSet<Assignment> Assignments { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS01;Database=dbToDoList;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserMap());
        modelBuilder.ApplyConfiguration(new TodoMap());
        modelBuilder.ApplyConfiguration(new AssignmentMap());
    }
}