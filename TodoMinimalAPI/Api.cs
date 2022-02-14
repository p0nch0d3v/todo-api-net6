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
        // app.MapGet("/Todos", GetTodos);
        // app.MapGet("/Todos/{id}", GetTodo);
        // app.MapPost("Todos", InserTodo);
    }

    // private static async Task<IResult> GetTodos()
    // {
    //     try
    //     {
    //         return Results.Ok(true);
    //     }
    //     catch (System.Exception ex) 
    //     {
    //         return Results.Problem(ex.Message);
    //     }
    // }
    // private static async Task<IResult> GetTodo(int id)
    // {
    //     try
    //     {
    //         return Results.Ok(true);
    //     }
    //     catch (System.Exception ex)
    //     {
    //         return Results.Problem(ex.Message);
    //     }
    // }

    // private static async Task<IResult> InserTodo(Todo todo)
    // {
    //     try
    //     {
    //          return Results.Ok(true);
    //     }
    //     catch (System.Exception ex)
    //     {
    //         return Results.Problem(ex.Message);
    //     }
    // }
}