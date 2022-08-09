using Api.Actions;
using Application.Command;
using Application.CommandHandler;
using Application.Query;
using Application.QueryHandler;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.InMemory;

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