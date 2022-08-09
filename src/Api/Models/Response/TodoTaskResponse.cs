using Domain;

namespace Api.Models.Response;

public class TodoTaskResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsFinished { get; set; }
    public DateTime? FinishedAt { get; set; }
    public DateTime CreatedAt { get; set; }

    public static implicit operator TodoTaskResponse(TodoTask todo)
    {
        if (todo is null)
            return null;

        return new TodoTaskResponse
        {
            Description = todo.Description,
            IsFinished = todo.IsFinished,
            Name = todo.Name,
            Id = todo.Id,
            CreatedAt = todo.CreatedAt,
            FinishedAt = todo.FinishedAt
        };
    }
}
