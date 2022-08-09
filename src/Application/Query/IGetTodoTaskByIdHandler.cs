using Domain;

namespace Application.Query;

public interface IGetTodoTaskByIdHandler
{
    TodoTask? Execute(Guid id);
}
