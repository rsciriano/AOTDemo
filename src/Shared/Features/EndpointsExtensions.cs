using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Shared.Features.Todos;
using Shared.Features.Weather;

namespace Shared.Features
{
    public static class EndpointsExtensions
    {
        public static RouteGroupBuilder MapEndpoints(this IEndpointRouteBuilder endpoints)
        {
            var group = endpoints.MapGroup("/");

            group.MapWeatherEndpoints();
            group.MapTodoEndpoints();

            return group;
        }
    }
}
