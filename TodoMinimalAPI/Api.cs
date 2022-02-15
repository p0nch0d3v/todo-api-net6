using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TodoMinimalAPI.Data;

namespace TodoMinimalAPI;

public static class Api
{
    public static void ConfigureAPI(this WebApplication app)
    {
        // All API endpoint mapping
        app.MapGet("/Todos", GetTodos);
        app.MapGet("/Todos/{id}", GetTodo);
        app.MapPost("/Todos", InserTodo);
        app.MapPut("/Todos", UpdateTodo);
        app.MapDelete("/Todos", DeleteTodo);
    }

    private static async Task<IResult> GetTodos(ITodoRepository repository)
    {
        try
        {
            return Results.Ok(await repository.GetAllTodos());
        }
        catch (System.Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> GetTodo(int id, ITodoRepository repository)
    {
        try
        {
            Todo todo = await repository.GetTodo(id);
            if (todo == null) return Results.NotFound();
            return Results.Ok(todo);
        }
        catch (System.Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> InserTodo(Todo todo, ITodoRepository repository)
    {
        try
        {
            await repository.AddTodo(todo);
            return Results.Ok(true);
        }
        catch (System.Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> UpdateTodo(Todo todo, ITodoRepository repository)
    {
        try
        {
            await repository.UpdateTodo(todo);
            return Results.Ok(true);
        }
        catch (System.Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> DeleteTodo(int id, ITodoRepository repository)
    {
        try
        {
            await repository.DeleteTodo(id);
            return Results.Ok(true);
        }
        catch (System.Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}