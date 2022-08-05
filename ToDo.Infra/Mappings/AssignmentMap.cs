using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Entities;

namespace ToDo.Infra.Mappings;

public class AssignmentMap : IEntityTypeConfiguration<Assignment>
{
    public void Configure(EntityTypeBuilder<Assignment> builder)
    {
        builder.ToTable("tasks");

        builder.HasKey(assignment => assignment.Id);

        builder.Property(assignment => assignment.Description)
            .IsRequired()
            .HasColumnType("VARCHAR(280)");

        builder.Property(assignment => assignment.Conclued)
            .HasDefaultValue(false)
            .HasColumnType("TINYINT");

        builder.Property(assignment => assignment.DeadLine)
            .IsRequired(false)
            .HasColumnType("DATETIME");

        builder.Property(assignment => assignment.ConcluedAt)
            .IsRequired(false)
            .ValueGeneratedOnUpdate()
            .HasColumnType("DATETIME");

        builder.Property(assignment => assignment.CreateAt)
            .ValueGeneratedOnAdd()
            .HasColumnType("DATETIME");
        
        builder.Property(assignment => assignment.UpdateAt)
            .ValueGeneratedOnAdd()
            .HasColumnType("DATETIME");
    }
}