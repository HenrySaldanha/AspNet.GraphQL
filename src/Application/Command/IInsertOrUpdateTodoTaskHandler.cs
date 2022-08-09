using Domain;

namespace Application.Command;

public interface IInsertOrUpdateTodoTaskHandler
{
    TodoTask Execute(TodoTask request);
}
