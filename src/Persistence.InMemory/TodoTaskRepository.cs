using Domain;

namespace Persistence.InMemory;

public class TodoTaskRepository : ITodoTaskRepository
{
    private readonly TodoAppContext _db;
    public TodoTaskRepository(TodoAppContext todoContext) => _db = todoContext;

    public IQueryable<TodoTask> GetAll() =>
        _db.TodoTasks;

    public TodoTask? GetById(Guid id) =>
        _db.TodoTasks.SingleOrDefault(q => q.Id == id);

    public TodoTask Insert(TodoTask entity)
    {
        _db.TodoTasks.Add(entity);
        _db.SaveChanges();
        return entity;
    }

    public TodoTask Update(TodoTask entity)
    {
        _db.Update(entity);
        _db.SaveChanges();
        return entity;
    }
}
