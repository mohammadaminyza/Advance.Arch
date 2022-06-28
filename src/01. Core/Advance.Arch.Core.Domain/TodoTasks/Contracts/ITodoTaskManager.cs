using Advance.Arch.Core.Domain.TodoTasks.Entities;

namespace Advance.Arch.Core.Domain.TodoTasks.Contracts;

//DomainService
public interface ITodoTaskManager
{
    void NextLevel(TodoTask todoTask);
}