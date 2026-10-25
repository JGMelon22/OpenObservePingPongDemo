using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Logging;
using OpenObserverPingPongDemo.Endpoints;

namespace OpenObserverPingPongDemo.API.UnitTests.Endpoints;

public class PingPongEndpointTests
{
    private ILoggerFactory _loggerFactory;

    [SetUp]
    public void SetUp()
    {
        _loggerFactory = NSubstitute.Substitute.For<ILoggerFactory>();
    }

    [Test]
    public void Should_Return_200OK_And_Pong_When_Api_IsHealthy()
    {
        // Arrange
        PingPong ping = new("Ping");

        // Act
        IResult response = PingPongEndpoint.SendPingReturnPong(ping, _loggerFactory);

        // Assert
        Assert.That(response, Is.TypeOf<Ok<string>>());

        Ok<string> result = (Ok<string>)response;

        Assert.That(result.Value, Is.EqualTo("Pong"));
    }

    [TearDown]
    public void TearDown()
    {
        _loggerFactory.Dispose();
    }
}