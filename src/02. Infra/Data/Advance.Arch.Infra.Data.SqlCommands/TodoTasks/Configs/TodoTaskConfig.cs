using Advance.Arch.Core.Domain.Common.ValueObjects;
using Advance.Arch.Core.Domain.TodoTasks.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Advance.Arch.Infra.Data.SqlCommands.TodoTasks.Configs;

public class TodoTaskConfig : IEntityTypeConfiguration<TodoTask>
{
    public void Configure(EntityTypeBuilder<TodoTask> builder)
    {
        builder.Property(t => t.Id)
            .HasConversion(c => c.Value, n => Id.FromGuid(n))
            .IsRequired();

        builder.Property(t => t.Name)
            .HasConversion(c => c.Value, n => Name.FromString(n))
            .IsRequired();

        builder.Property(t => t.Date)
            .HasConversion(d => d.ToDateTime(TimeOnly.MinValue), dt => DateOnly.FromDateTime(dt))
            .IsRequired();

        builder.Property(t => t.Time)
            .HasConversion(t => t.ToTimeSpan(), t => TimeOnly.FromTimeSpan(t))
            .IsRequired();

        builder.Property(t => t.State)
            .IsRequired();
    }
}