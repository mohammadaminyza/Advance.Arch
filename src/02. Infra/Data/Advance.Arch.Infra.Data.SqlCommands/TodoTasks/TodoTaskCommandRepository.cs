using Advance.Arch.Core.Contracts.TodoTasks.Repositories;
using Advance.Arch.Core.Domain.TodoTasks.Entities;
using Advance.Arch.Infra.Data.SqlCommands.Common;

namespace Advance.Arch.Infra.Data.SqlCommands.TodoTasks;

public class TodoTaskCommandRepository : BaseCommandRepository<TodoTask, ArchCommandDbContext>, ITodoTaskCommandRepository
{
    public TodoTaskCommandRepository(ArchCommandDbContext dbContext) : base(dbContext)
    {
    }
}