using Microsoft.AspNetCore.Mvc;

namespace OpenObserverPingPongDemo.Endpoints;

public static class PingPongEndpoint
{
    public static void MapPingPongEndpoint(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/")
            .WithTags("PingPong");

        group.MapPost("", SendPingReturnPong);
    }

    private static IResult SendPingReturnPong(PingPong ping,
        [FromServices] ILoggerFactory loggerFactory)
    {
        ILogger logger = loggerFactory.CreateLogger("PingPongEndpoint"); // Due to static nature and Minimal API behavior

        logger.LogInformation(
            "Received ping request with message {Message}",
            ping.Ping);

        var result = ping.Pong();

        logger.LogInformation(
            "PingPong request completed: {Ping} -> {Pong}",
            ping.Ping,
            result);

        return Results.Ok(result);
    }
}