using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Shared.Features.Todos.Models;

namespace Shared.Features.Todos;

public static class TodoEndpoints
{
    static Todo[] sampleTodos = {
        new(1, "Walk the dog"),
        new(2, "Do the dishes", DateOnly.FromDateTime(DateTime.Now)),
        new(3, "Do the laundry", DateOnly.FromDateTime(DateTime.Now.AddDays(1))),
        new(4, "Clean the bathroom"),
        new(5, "Clean the car", DateOnly.FromDateTime(DateTime.Now.AddDays(2)))
    };

    public static RouteGroupBuilder MapTodoEndpoints(this RouteGroupBuilder group)
    {
        var todosApi = group.MapGroup("/todos");

        todosApi.MapGet("/", () => sampleTodos);

        todosApi.MapGet("/{id}", (int id) =>
            sampleTodos.FirstOrDefault(a => a.Id == id) is { } todo
                ? Results.Ok(todo)
                : Results.NotFound());

        return group;
    }
}
