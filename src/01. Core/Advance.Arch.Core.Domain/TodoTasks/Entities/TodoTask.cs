using Advance.Arch.Core.Domain.Tasks.Enums;

namespace Advance.Arch.Core.Domain.TodoTasks.Entities;

public class TodoTask
{
    #region Properties

    public int Id { get; set; }
    public string Name { get; set; }
    public TimeOnly Time { get; set; }
    public TaskState State { get; set; }

    #endregion

    #region Ctor

    public TodoTask(int id, string name, TimeOnly timeOnly, TaskState state)
    {
        Id = id;
        Name = name;
        Time = timeOnly;
        State = state;
    }

    #endregion

    #region Methods
    
    //Should Put Simple Business Logics Like Add Child Or ...

    #endregion
}