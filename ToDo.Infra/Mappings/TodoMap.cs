using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Entities;

namespace ToDo.Infra.Mappings;

public class TodoMap : IEntityTypeConfiguration<TodoList>
{
    public void Configure(EntityTypeBuilder<TodoList> builder)
    {
        builder.ToTable("todos");

        builder.HasKey(todo => todo.Id);

        builder.Property(todo => todo.Name)
            .IsRequired()
            .HasColumnType("VARCHAR(180)");

        builder.Property(todo => todo.UserId)
            .IsRequired()
            .HasColumnType("INTEGER");
    }
}