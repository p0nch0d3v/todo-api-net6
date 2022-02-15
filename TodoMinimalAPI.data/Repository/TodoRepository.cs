using Microsoft.EntityFrameworkCore;

namespace TodoMinimalAPI.Data;

public class TodoRepository : ITodoRepository
{
    protected readonly TodoDBContext _context;

    public TodoRepository(TodoDBContext context)
    {
        this._context = context;
    }

    public async Task<IEnumerable<Todo>> GetAllTodos()
    {
        var result = await _context.Set<Todo>().AsNoTracking().ToListAsync();
        return result;
    }

    public async Task<Todo> GetTodo(int id)
    {
        var todo = await _context.Set<Todo>().FirstOrDefaultAsync(t => t.Id.Equals(id));
        return todo;
    }

    public async Task AddTodo(Todo todo)
    {
        _context.Todos.Add(todo);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateTodo(Todo todo)
    {
        var todoToUpdate = await _context.Set<Todo>().FirstOrDefaultAsync(t => t.Id.Equals(todo.Id));
        todoToUpdate.Content = todo.Content;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteTodo(int id)
    {
        var todoToDelete = await _context.Set<Todo>().FirstOrDefaultAsync(t => t.Id.Equals(id));
        _context.Remove(todoToDelete);
        await _context.SaveChangesAsync();
    }
}
