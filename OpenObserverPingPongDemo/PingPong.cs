namespace OpenObserverPingPongDemo;

public record PingPong(string? Ping = null)
{
    public string Ping { get; } = string.IsNullOrEmpty(Ping) ? "Ping" : Ping;

    public string Pong()
        => "Pong";
}