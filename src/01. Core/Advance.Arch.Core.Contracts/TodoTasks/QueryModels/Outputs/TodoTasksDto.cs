using Advance.Arch.Core.Domain.TodoTasks.Enums;

namespace Advance.Arch.Core.Contracts.TodoTasks.QueryModels.Outputs;

public class TodoTasksDto
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required DateOnly Date { get; set; }
    public required TimeOnly Time { get; set; }
    public required TaskState State { get; set; }
}