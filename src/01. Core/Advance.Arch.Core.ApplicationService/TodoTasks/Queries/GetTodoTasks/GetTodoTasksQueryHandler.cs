using Advance.Arch.Core.Contracts.TodoTasks.Queries.GetTodoTasks;
using Advance.Arch.Core.Contracts.TodoTasks.QueryModels.Outputs;
using Advance.Arch.Core.Contracts.TodoTasks.Repositories;
using MediatR;

namespace Advance.Arch.Core.ApplicationService.TodoTasks.Queries.GetTodoTasks;

public class GetTodoTasksQueryHandler : IRequestHandler<GetTodoTasksQuery, IEnumerable<TodoTasksDto>>
{
    private readonly ITodoTaskQueryRepository _todoTaskQueryRepository;

    public GetTodoTasksQueryHandler(ITodoTaskQueryRepository todoTaskQueryRepository)
    {
        _todoTaskQueryRepository = todoTaskQueryRepository;
    }

    public async Task<IEnumerable<TodoTasksDto>> Handle(GetTodoTasksQuery request, CancellationToken cancellationToken)
    {
        var result = await _todoTaskQueryRepository.Select(request);
        return result;
    }
}