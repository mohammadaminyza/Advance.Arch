using Advance.Arch.Core.Contracts.Common;
using Advance.Arch.Core.Contracts.TodoTasks.QueryModels.Inputs;
using Advance.Arch.Core.Contracts.TodoTasks.QueryModels.Outputs;

namespace Advance.Arch.Core.Contracts.TodoTasks.Repositories;

public interface ITodoTaskQueryRepository : IQueryRepository
{
    Task<IEnumerable<TodoTasksDto>> Select(ITodoTasksDto filter);
}
