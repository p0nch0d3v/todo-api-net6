namespace TodoMinimalAPI.Data;
public interface ITodoRepository
{   
    Task<IEnumerable<Todo>> GetAllTodos();
}