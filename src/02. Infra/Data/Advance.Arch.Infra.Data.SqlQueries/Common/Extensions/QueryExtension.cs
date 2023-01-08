using System.Linq.Expressions;

namespace Advance.Arch.Infra.Data.SqlQueries.Common.Extensions;

public static class QueryExtension
{
    public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition, Expression<Func<T, bool>> expression)
    {
        if (condition)
            query = query.Where(expression);

        return query;
    }
}