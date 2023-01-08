using Advance.Arch.Core.Contracts.Common;
using Advance.Arch.Core.Contracts.Utilities;
using Advance.Arch.Infra.Tools.AutoMapper.Common;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyModel;
using System.Reflection;

namespace Advance.Arch.Endpoint;

public static class HostingExtensions
{
    public static IServiceCollection AddCommonService(this IServiceCollection services)
    {
        var assemblies = GetAssemblies("Advance.Arch");

        services.AddMediator(assemblies)
            .AddRepositories(assemblies)
            .AddAutoMapper(assemblies);

        return services;
    }

    public static IServiceCollection AddMediator(this IServiceCollection services,
        IEnumerable<Assembly> assemblies)
    {
        services.AddTransient<ServiceFactory>(p => p.GetService);
        services.AddTransient<IMediator, Mediator>();

        services.AddWithTransientLifetime(assemblies, typeof(IRequestHandler<>), typeof(IRequestHandler<,>));

        return services;
    }

    private static IServiceCollection AddAutoMapper(this IServiceCollection services,
        IEnumerable<Assembly> assemblies)
    {
        var profileTypes = assemblies
            .SelectMany(x => x.DefinedTypes)
            .Where(type => typeof(Profile).IsAssignableFrom(type)).ToList();
        var profiles = new List<Profile>();
        foreach (var profileType in profileTypes)
        {
            if (Activator.CreateInstance(profileType) is Profile profile)
                profiles.Add(profile);
        }

        services.AddSingleton<IObjectMapper>(s => new AutoMapperAdapter(profiles.ToArray()));

        return services;
    }
    private static IServiceCollection AddRepositories(this IServiceCollection services,
        IEnumerable<Assembly> assemblies)
    {
        services.AddWithTransientLifetime(assemblies, typeof(ICommandRepository<>), typeof(IQueryRepository));

        return services;
    }

    private static List<Assembly> GetAssemblies(params string[] assmblyName)
    {

        var assemblies = new List<Assembly>();
        var dependencies = DependencyContext.Default.RuntimeLibraries;
        foreach (var library in dependencies)
        {
            if (IsCandidateCompilationLibrary(library, assmblyName))
            {
                var assembly = Assembly.Load(new AssemblyName(library.Name));
                assemblies.Add(assembly);
            }
        }
        return assemblies;
    }

    private static bool IsCandidateCompilationLibrary(RuntimeLibrary compilationLibrary, string[] assmblyName)
    {
        return assmblyName.Any(d => compilationLibrary.Name.Contains(d))
               || compilationLibrary.Dependencies.Any(d => assmblyName.Any(c => d.Name.Contains(c)));
    }
}