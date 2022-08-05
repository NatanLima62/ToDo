using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Entities;

namespace ToDo.Infra.Mappings;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.HasKey(user => user.Id);

        builder.Property(user => user.Name)
            .IsRequired()
            .HasColumnType("VARCHAR(180)");

        builder.Property(user => user.Password)
            .IsRequired()
            .HasColumnType("VARCHAR(255)");

        builder.Property(user => user.Email)
            .IsRequired()
            .HasColumnType("VARCHAR(180)");

        builder
            .HasMany(user => user.TodoLists)
            .WithOne(todoList => todoList.User)
            .HasForeignKey(todoList => todoList.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasMany(user => user.Assignments)
            .WithOne(assignment => assignment.User)
            .OnDelete(DeleteBehavior.Restrict);
    }
}