using Advance.Arch.Core.Domain.TodoTasks.Entities;
using Microsoft.EntityFrameworkCore;

namespace Advance.Arch.Infra.Data.SqlCommands.Common;

public class ArchCommandDbContext : DbContext
{
    public ArchCommandDbContext(DbContextOptions<ArchCommandDbContext> options) : base(options)
    {
    }

    public DbSet<TodoTask> TodoTasks => Set<TodoTask>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        base.OnModelCreating(builder);
    }
}