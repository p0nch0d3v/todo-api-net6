namespace TodoMinimalAPI.Data;

public interface ITodoRepository
{
    Task<IEnumerable<Todo>> GetAllTodos();
    Task<Todo> GetTodo(int id);
    Task AddTodo(Todo todo);
    Task UpdateTodo(Todo todo);
    Task DeleteTodo(int id);
}