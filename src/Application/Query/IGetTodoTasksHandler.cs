using Domain;

namespace Application.Query;

public interface IGetTodoTasksHandler
{
    IEnumerable<TodoTask> Execute();
}
