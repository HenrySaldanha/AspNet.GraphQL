using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.InMemory;

public class TodoAppContext : DbContext
{
    public TodoAppContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<TodoTask> TodoTasks { get; set; }
}
