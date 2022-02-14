using Microsoft.EntityFrameworkCore;

namespace TodoMinimalAPI.Data;
public class TodoDBContext : DbContext
{
    public DbContextOptions<TodoDBContext> Context { get; }

    public TodoDBContext(DbContextOptions<TodoDBContext> options) : base(options)
    {
    }

    public DbSet<Todo> Todos { get; set; }
}