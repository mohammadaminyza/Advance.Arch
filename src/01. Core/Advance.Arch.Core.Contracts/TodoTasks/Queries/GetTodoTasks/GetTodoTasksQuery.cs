using Advance.Arch.Core.Contracts.TodoTasks.QueryModels.Inputs;
using Advance.Arch.Core.Contracts.TodoTasks.QueryModels.Outputs;
using Advance.Arch.Core.Domain.TodoTasks.Enums;
using MediatR;

namespace Advance.Arch.Core.Contracts.TodoTasks.Queries.GetTodoTasks;

public class GetTodoTasksQuery : IRequest<IEnumerable<TodoTasksDto>>, ITodoTasksDto
{
    public string? Name { get; set; }
    public DateTime? DateTime { get; set; }
    public TaskState? State { get; set; }
}