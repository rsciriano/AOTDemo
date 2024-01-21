using Shared.Features.Todos.Models;
using Shared.Features.Weather.Models;
using System.Text.Json.Serialization;

namespace Shared.Features;

[JsonSerializable(typeof(IEnumerable<WeatherForecast>))]
[JsonSerializable(typeof(Todo[]))]
public partial class AppJsonSerializerContext : JsonSerializerContext
{

}
