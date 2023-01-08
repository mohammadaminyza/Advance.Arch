using System.Linq.Expressions;

namespace Advance.Arch.Core.Contracts.Utilities;

public interface IObjectMapper
{
    TDestination Map<TSource, TDestination>(TSource source);
    IQueryable<TDestination> MapTo<TSource, TDestination>(IQueryable source,
        params Expression<Func<TDestination, object>>[] membersToExpand);
}