using Advance.Arch.Core.Domain.Common.ValueObjects;
using Advance.Arch.Core.Domain.TodoTasks.Enums;

namespace Advance.Arch.Core.Domain.TodoTasks.Entities;

public class TodoTask
{
    #region Properties

    public Id Id { get; private set; }
    public Name Name { get; private set; }
    public DateOnly Date { get; private set; }
    public TimeOnly Time { get; private set; }
    public TaskState State { get; private set; }

    #endregion

    #region Ctor

    public TodoTask(Id id, Name name, DateOnly date, TimeOnly time)
    {
        Id = id;
        Name = name;
        Date = date;
        Time = time;
        State = TaskState.Active;

        //Add Event Or ...
    }

    #endregion

    #region Methods

    public void NextState()
    {
        switch (State)
        {
            case TaskState.Disable:
                ActiveTodoTask();
                break;

            case TaskState.Active:
                InProgressTodoTask();
                break;

            case TaskState.InProgress:
                DoneTodoTask();
                break;

            default:
                State = TaskState.Disable;
                break;
        }

    }

    private void ActiveTodoTask()
    {
        SetTaskState(TaskState.Active);
    }

    private void DisableTodoTask()
    {
        SetTaskState(TaskState.Disable);
    }

    private void InProgressTodoTask()
    {
        SetTaskState(TaskState.InProgress);
    }

    private void DoneTodoTask()
    {
        SetTaskState(TaskState.Done);
    }

    private void SetTaskState(TaskState taskState)
    {
        if (State == TaskState.Done)
            throw new Exception("Cloudn't Change Task When It's Done");

        State = taskState;
    }

    #endregion
}