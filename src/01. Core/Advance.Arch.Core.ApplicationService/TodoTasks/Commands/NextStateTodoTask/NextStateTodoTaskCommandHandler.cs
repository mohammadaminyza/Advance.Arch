using Advance.Arch.Core.Contracts.TodoTasks.Commands.NextStateTodoTask;
using Advance.Arch.Core.Contracts.TodoTasks.Repositories;
using MediatR;

namespace Advance.Arch.Core.ApplicationService.TodoTasks.Commands.NextStateTodoTask;

public class NextStateTodoTaskCommandHandler : IRequestHandler<NextStateTodoTaskCommand>
{
    private readonly ITodoTaskCommandRepository _todoTaskCommandRepository;

    public NextStateTodoTaskCommandHandler(ITodoTaskCommandRepository todoTaskCommandRepository)
    {
        _todoTaskCommandRepository = todoTaskCommandRepository;
    }

    public async Task<Unit> Handle(NextStateTodoTaskCommand request, CancellationToken cancellationToken)
    {
        var entity = await _todoTaskCommandRepository.GetAsync(request.Id);
        entity.NextState();

        await _todoTaskCommandRepository.CommitAsync();

        return Unit.Value;
    }
}