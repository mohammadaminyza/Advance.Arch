using Advance.Arch.Core.Contracts.Common;

namespace Advance.Arch.Infra.Data.SqlQueries.Common;

public class BaseQueryRepository<TDbContext> : IQueryRepository
    where TDbContext : BaseQueryDbContext
{
    protected readonly TDbContext _dbContext;

    public BaseQueryRepository(TDbContext dbContext)
    {
        _dbContext = dbContext;
    }
}