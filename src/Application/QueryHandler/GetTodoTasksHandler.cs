using Application.Query;
using Domain;
using Persistence;

namespace Application.QueryHandler;

public class GetTodoTasksHandler : IGetTodoTasksHandler
{
    private readonly ITodoTaskRepository _repository;

    public GetTodoTasksHandler(ITodoTaskRepository repository) =>
        _repository = repository;

    public IEnumerable<TodoTask> Execute() =>
        _repository.GetAll();
}
