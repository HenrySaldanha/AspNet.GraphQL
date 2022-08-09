using Api.Models.Request;
using Api.Models.Response;
using Application.Command;
using Domain;
using HotChocolate;

namespace Api.Actions;

public class Mutations
{
    public TodoTaskResponse InsertOrUpdate([Service] IInsertOrUpdateTodoTaskHandler handler, InsertOrUpdateTodoTaskRequest request)
    {
        var response = handler.Execute((TodoTask)request);

        if (response is null) return null;

        return (TodoTaskResponse)response;
    }
}
