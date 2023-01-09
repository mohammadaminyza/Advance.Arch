using Advance.Arch.Core.Contracts.Common.Utilities;
using Advance.Arch.Core.Contracts.TodoTasks.QueryModels.Inputs;
using Advance.Arch.Core.Contracts.TodoTasks.QueryModels.Outputs;
using Advance.Arch.Core.Contracts.TodoTasks.Repositories;
using Advance.Arch.Core.Domain.TodoTasks.Enums;
using Advance.Arch.Infra.Data.SqlQueries.Common;
using Advance.Arch.Infra.Data.SqlQueries.Common.Extensions;
using Advance.Arch.Infra.Data.SqlQueries.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace Advance.Arch.Infra.Data.SqlQueries.TodoTasks;

public class TodoTaskQueryRepository : BaseQueryRepository<ArchQueryDbContext>, ITodoTaskQueryRepository
{
    private readonly IObjectMapper _mapper;

    public TodoTaskQueryRepository(IObjectMapper mapper, ArchQueryDbContext dbContext) : base(dbContext)
    {
        _mapper = mapper;
    }

    public async Task<IEnumerable<TodoTasksDto>> Select(ITodoTasksDto filter)
    {
        #region Query

        var query = _dbContext.TodoTasks.AsQueryable();

        #endregion

        #region Filter

        query = query.WhereIf(filter.Name != null, t => t.Name == filter.Name);
        query = query.WhereIf(filter.DateTime != null, t => t.Date == filter.DateTime!.Value.Date && t.Time <= filter.DateTime!.Value.TimeOfDay);
        query = query.WhereIf(filter.State != null, t => (TaskState)t.State == filter.State!.Value);

        #endregion

        #region Result

        var result = await _mapper.MapTo<TodoTask, TodoTasksDto>(query).ToListAsync();

        #endregion

        return result;
    }
}