using Advance.Arch.Core.Contracts.Utilities;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Linq.Expressions;

namespace Advance.Arch.Infra.Tools.AutoMapper.Common;

public class AutoMapperAdapter : IObjectMapper
{
    private readonly MapperConfiguration _mapperConfiguration;
    private readonly IMapper _mapper;

    public AutoMapperAdapter(params Profile[] profiles)
    {
        _mapperConfiguration = new MapperConfiguration(c =>
        {
            foreach (var profile in profiles)
            {
                c.AddProfile(profile);
            }
        });
        _mapper = _mapperConfiguration.CreateMapper();
    }

    public TDestination Map<TSource, TDestination>(TSource source)
    {
        return _mapper.Map<TDestination>(source);
    }

    public IQueryable<TDestination> MapTo<TSource, TDestination>(IQueryable source, params Expression<Func<TDestination, object>>[] membersToExpand)
    {
        return source.ProjectTo(_mapper.ConfigurationProvider, membersToExpand);
    }
}