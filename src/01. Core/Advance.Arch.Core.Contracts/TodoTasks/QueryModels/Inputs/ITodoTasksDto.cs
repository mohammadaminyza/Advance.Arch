using Advance.Arch.Core.Domain.TodoTasks.Enums;

namespace Advance.Arch.Core.Contracts.TodoTasks.QueryModels.Inputs;

public interface ITodoTasksDto
{
    public string? Name { get; set; }
    public DateTime? DateTime { get; set; }
    public TaskState? State { get; set; }
}