namespace OpenObserverPingPongDemo.Endpoints;

public static class PingPongEndpoint
{
    public static void MapPingPongEndpoint(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/")
            .WithTags("PingPong");

        group.MapPost("", SendPingReturnPong);
    }

    private static IResult SendPingReturnPong(PingPong ping)
    {
        var result = ping.Pong();

        return Results.Ok(result);
    }
}