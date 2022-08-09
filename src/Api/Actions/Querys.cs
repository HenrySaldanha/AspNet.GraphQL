using Api.Models.Request;
using Api.Models.Response;
using Application.Query;
using HotChocolate;

namespace Api.Actions;

public class Querys
{
    public IEnumerable<TodoTaskResponse> GetTasks([Service] IGetTodoTasksHandler handler)
    {
        var tasks = handler.Execute();
        return tasks.Select(c => (TodoTaskResponse)c);
    }

    public TodoTaskResponse GetTask([Service] IGetTodoTaskByIdHandler handler, GetTodoTaskByIdRequest request)
    {
        var task = handler.Execute(request.Id);
        return (TodoTaskResponse)task;
    }
}
