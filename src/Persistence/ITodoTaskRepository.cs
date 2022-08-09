using Domain;

namespace Persistence;

public interface ITodoTaskRepository
{
    IQueryable<TodoTask> GetAll();
    TodoTask? GetById(Guid id);
    TodoTask Update(TodoTask entity);
    TodoTask Insert(TodoTask entity);
}
