using Advance.Arch.Core.Domain.TodoTasks.Entities;

namespace Advance.Arch.Core.Domain.TodoTasks.Contracts;

public interface ITodoTaskCommandRepository
{
    //Commands

    Task<TodoTask> Get(int id);
}