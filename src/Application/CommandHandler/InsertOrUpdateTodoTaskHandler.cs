using Application.Command;
using Domain;
using Persistence;

namespace Application.CommandHandler;

public class InsertOrUpdateTodoTaskHandler : IInsertOrUpdateTodoTaskHandler
{
    private readonly ITodoTaskRepository _repository;

    public InsertOrUpdateTodoTaskHandler(ITodoTaskRepository repository)
    {
        _repository = repository;
    }

    public TodoTask Execute(TodoTask request)
    {
        if (request.Id != Guid.Empty)
        {
            var databaseItem = _repository.GetById(request.Id);
            if (databaseItem is null)
                throw new Exception("Todo task is not found");

            request.FinishedAt = request.IsFinished ? DateTime.UtcNow : null;
            _repository.Update(request);
        }
        else
        {
            request.FinishedAt = request.IsFinished ? DateTime.UtcNow : null;
            request.Id = Guid.NewGuid();
            request.CreatedAt = DateTime.UtcNow;
            _repository.Insert(request);
        }
        return request;
    }
}
