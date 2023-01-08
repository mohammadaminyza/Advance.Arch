using Advance.Arch.Core.Contracts.Common;
using Advance.Arch.Core.Domain.TodoTasks.Entities;

namespace Advance.Arch.Core.Contracts.TodoTasks.Repositories;

public interface ITodoTaskCommandRepository : ICommandRepository<TodoTask>
{
}