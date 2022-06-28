using Advance.Arch.Core.Domain.TodoTasks.Contracts;

namespace Advance.Arch.Core.ApplicationService.TodoTasks.Commands.NextLevelStateTodoTask;

public class NextLevelStateTodoTaskCommandHandler
{
    private readonly ITodoTaskCommandRepository _todoTaskCommandRepository;
    private readonly ITodoTaskManager _todoTaskManager;

    public NextLevelStateTodoTaskCommandHandler(ITodoTaskCommandRepository todoTaskCommandRepository, ITodoTaskManager todoTaskManager)
    {
        _todoTaskCommandRepository = todoTaskCommandRepository;
        _todoTaskManager = todoTaskManager;
    }

    public async Task Handle(NextLevelStateTodoTaskCommand request)
    {
        var entity = await _todoTaskCommandRepository.Get(request.Id);

        _todoTaskManager.NextLevel(entity);

        //Handle Use Case Like Creating Entity etc...

        //Done
    }
}