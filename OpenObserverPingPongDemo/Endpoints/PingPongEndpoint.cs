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

    internal static IResult SendPingReturnPong(PingPong ping,
        [FromServices] ILoggerFactory loggerFactory)
    {
        ILogger
            logger = loggerFactory.CreateLogger("PingPongEndpoint"); // Due to static nature and Minimal API behavior

        try
        {
            var result = ping.Pong();

            logger.LogInformation(
                "PingPong request completed: {Ping} -> {Pong}",
                ping.Ping,
                result);

            logger.LogInformation(
                "Received ping request with message {Message}",
                ping.Ping);

            return Results.Ok(result);
        }
        catch (Exception ex)
        {
            return Results.BadRequest(ex.Message);
        }
    }
}