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
}
