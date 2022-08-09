using Application.Query;
using Domain;
using Persistence;

namespace Application.QueryHandler;

public class GetTodoTaskByIdHandler : IGetTodoTaskByIdHandler
{
    private readonly ITodoTaskRepository _repository;

    public GetTodoTaskByIdHandler(ITodoTaskRepository repository) => 
        _repository = repository;

    public TodoTask? Execute(Guid id) => 
        _repository.GetById(id);
}
