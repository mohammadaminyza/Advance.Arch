using Advance.Arch.Infra.Data.SqlQueries.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace Advance.Arch.Infra.Data.SqlQueries.Common;

public class ArchQueryDbContext : BaseQueryDbContext
{
    public ArchQueryDbContext(DbContextOptions<ArchQueryDbContext> options) : base(options)
    {
    }

    public virtual DbSet<TodoTask> TodoTasks => Set<TodoTask>();
}