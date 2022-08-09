
The focus of this project was a simple implementation of **GraphQL** in AspNet Project.

![#](https://github.com/HenrySaldanha/AspNet.GraphQL/blob/main/images/insert.png?raw=true)

![#](https://github.com/HenrySaldanha/AspNet.GraphQL/blob/main/images/get_tasks.png?raw=true)

![#](https://github.com/HenrySaldanha/AspNet.GraphQL/blob/main/images/gettask.png?raw=true)

## Packages
    HotChocolate.AspNetCore
    Microsoft.EntityFrameworkCore.InMemory	

## Config
In the Program class, GraphQL, Query and Mutation were configured

	var builder = WebApplication.CreateBuilder(args);
	builder.Services
	    .AddDbContext<TodoAppContext>(option => option.UseInMemoryDatabase("TodoDatabase"));
	builder.Services
	    .AddGraphQLServer()
	    .AddMutationType<Mutations>()
	    .AddQueryType<Querys>();
	builder.Services
	    .AddScoped<ITodoTaskRepository, TodoTaskRepository>()
	    .AddScoped<IInsertOrUpdateTodoTaskHandler, InsertOrUpdateTodoTaskHandler>()
	    .AddScoped<IGetTodoTaskByIdHandler, GetTodoTaskByIdHandler>()
	    .AddScoped<IGetTodoTasksHandler, GetTodoTasksHandler>();

	var app = builder.Build();
	app.UseRouting()
	   .UseEndpoints(endpoints => endpoints.MapGraphQL());
	app.Run();

    
## Mutation Class

	public class Mutations
	{
	    public TodoTaskResponse InsertOrUpdate([Service] IInsertOrUpdateTodoTaskHandler handler, InsertOrUpdateTodoTaskRequest request)
	    {
	        var response = handler.Execute((TodoTask)request);

	        if (response is null) return null;

	        return (TodoTaskResponse)response;
	    }
	}


## Query Class

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

## Give a Star 
If you found this Implementation helpful or used it in your Projects, do give it a star. Thanks!

## This project was built with
* [.NET 6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
* [ChilliCream GraphQL](https://chillicream.com/)

## My contacts
* [LinkedIn](https://www.linkedin.com/in/henry-saldanha-3b930b98/)
