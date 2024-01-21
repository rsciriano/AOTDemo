using System.Text.Json.Serialization;

namespace Shared.Features.Todos.Models;

public record Todo(int Id, string? Title, DateOnly? DueBy = null, bool IsComplete = false);

