using Domain;

namespace Api.Models.Request;

public class InsertOrUpdateTodoTaskRequest
{
    public Guid? Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsFinished { get; set; }

    public static implicit operator TodoTask(InsertOrUpdateTodoTaskRequest request)
    {
        if (request is null)
            return null;

        return new TodoTask
        {
            Description = request.Description,
            IsFinished = request.IsFinished,
            Name = request.Name,
            Id = request.Id ?? Guid.Empty
        };
    }
}
