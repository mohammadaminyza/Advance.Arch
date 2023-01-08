using Advance.Arch.Core.Contracts.TodoTasks.Commands.CreateTodoTask;
using Advance.Arch.Core.Contracts.TodoTasks.Repositories;
using Advance.Arch.Core.Domain.Common.ValueObjects;
using Advance.Arch.Core.Domain.TodoTasks.Entities;
using MediatR;

namespace Advance.Arch.Core.ApplicationService.TodoTasks.Commands.CreateTodoTask;

public class CreateTodoTaskCommandHandler : IRequestHandler<CreateTodoTaskCommand, TodoTask>
{
    private readonly ITodoTaskCommandRepository _todoTaskCommandRepository;

    public CreateTodoTaskCommandHandler(ITodoTaskCommandRepository todoTaskCommandRepository)
    {
        _todoTaskCommandRepository = todoTaskCommandRepository;
    }

    public async Task<TodoTask> Handle(CreateTodoTaskCommand request, CancellationToken cancellationToken)
    {
        var entity = new TodoTask(Id.NewId(), request.Name, DateOnly.FromDateTime(request.DateTime), TimeOnly.FromDateTime(request.DateTime));

        await _todoTaskCommandRepository.InsertAsync(entity);
        await _todoTaskCommandRepository.CommitAsync();

        return entity;
    }
}