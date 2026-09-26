namespace OpenObserverPingPongDemo;

public record PingPong
{
    public string Ping { get; init; } = "Ping";

    public string Pong()
        => "Pong";
}