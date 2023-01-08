using MediatR;

namespace Advance.Arch.Core.Contracts.TodoTasks.Commands.NextStateTodoTask;

public class NextStateTodoTaskCommand : IRequest
{
    public int Id { get; set; }
}