using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Shared.Features.Weather.Models;

namespace Shared.Features.Weather;

internal static class WeatherEndpoints
{
    static string[] _summaries =
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };


    internal static RouteGroupBuilder MapWeatherEndpoints(this RouteGroupBuilder group)
    {
        group.MapGet("/weatherforecast", GetWeatherForecast)
            .WithName("WeatherForecast")
            .WithTags("Weather");

        return group;
    }

    static IEnumerable<WeatherForecast> GetWeatherForecast()
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                        new WeatherForecast
                        (
                            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                            Random.Shared.Next(-20, 55),
                            _summaries[Random.Shared.Next(_summaries.Length)]
                        ))
                        .ToArray();
        return forecast;
    }
}
