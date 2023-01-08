using Advance.Arch.Core.Contracts.TodoTasks.QueryModels.Outputs;
using Advance.Arch.Infra.Data.SqlQueries.Common.Models;
using AutoMapper;

namespace Advance.Arch.Infra.Tools.AutoMapper;

public class TodoTaskProfile : Profile
{
    public TodoTaskProfile()
    {
        CreateMap<TodoTask, TodoTasksDto>()
            .ForMember(td => td.Time,
                tm =>
                    tm.MapFrom(t => TimeOnly.FromTimeSpan(t.Time)))
            .ForMember(td => td.Date,
                tm =>
                    tm.MapFrom(t => DateOnly.FromDateTime(t.Date)));
    }
}