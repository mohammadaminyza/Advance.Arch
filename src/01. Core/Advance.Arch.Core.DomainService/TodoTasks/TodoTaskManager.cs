using Advance.Arch.Core.Domain.Tasks.Enums;
using Advance.Arch.Core.Domain.TodoTasks.Contracts;
using Advance.Arch.Core.Domain.TodoTasks.Entities;

namespace Advance.Arch.Core.DomainService.TodoTasks;

public class TodoTaskManager : ITodoTaskManager
{
    public void NextLevel(TodoTask todoTask)
    {
        switch (todoTask.State)
        {
            case TaskState.Disable:
                ActiveTodoTask(todoTask);
                break;

            case TaskState.Active:
                InProgressTodoTask(todoTask);
                break;

            case TaskState.InProgress:
                DoneTodoTask(todoTask);
                break;

            default:
                todoTask.State = TaskState.Disable;
                break;
        }

    }

    #region Methods

    private void ActiveTodoTask(TodoTask todoTask)
    {
        SetTaskState(todoTask, TaskState.Active);
    }

    private void DisableTodoTask(TodoTask todoTask)
    {
        SetTaskState(todoTask, TaskState.Disable);
    }

    private void InProgressTodoTask(TodoTask todoTask)
    {
        SetTaskState(todoTask, TaskState.InProgress);
    }

    private void DoneTodoTask(TodoTask todoTask)
    {
        SetTaskState(todoTask, TaskState.Done);
    }

    private void SetTaskState(TodoTask todoTask, TaskState taskState)
    {
        if (todoTask.State == TaskState.Done)
            throw new Exception("Cloudn't Change Task When It's Done");

        todoTask.State = taskState;
    }

    #endregion
}