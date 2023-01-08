using Advance.Arch.Core.Domain.TodoTasks.Entities;
using MediatR;

namespace Advance.Arch.Core.Contracts.TodoTasks.Commands.CreateTodoTask;

public class CreateTodoTaskCommand : IRequest<TodoTask>
{
    public required string Name { get; set; }
    public DateTime DateTime { get; set; }
}