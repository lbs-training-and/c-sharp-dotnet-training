using DI.Challenge.Interfaces;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;

namespace DI.Challenge.Tests.Tests;

public class Part07Tests
{
    [Test]
    public void SingletonConsumerServiceIsRegistered()
    {
        // Arrange

        var webApplicationFactory = new WebApplicationFactory<Program>();
        using var scope = webApplicationFactory.Services.CreateScope();

        // Act

        var service1 = scope.ServiceProvider.GetService<IOrderService>();
        var service2 = scope.ServiceProvider.GetService<IOrderService>();
        var service3 = webApplicationFactory.Services.GetService<IOrderService>();

        // Assert

        service1.Should().NotBeNull().And.Be(service2).And.NotBe(service3);
    }

    [Test]
    public void SingletonConsumerService_ConsumesSingletonService()
    {
        // Arrange

        var order = new Order();
        var mockNotificationServices = new List<Mock<INotificationService>> { new(), new(), new() };
        var webApplicationFactory = new WebApplicationFactory<Program>();

        webApplicationFactory.WithWebHostBuilder(b =>
        {
            b.ConfigureServices(sc =>
            {
                sc.RemoveAll<INotificationService>();

                foreach (var mock in mockNotificationServices)
                {
                    sc.AddSingleton(mock.Object);
                }
            });
        });

        // Act

        var service = webApplicationFactory.Services.GetRequiredService<IOrderService>();

        service.Dispatch(order);

        // Assert

        foreach (var mock in mockNotificationServices)
        {
            mock.Verify(s => s.SendDispatched(order));
        }
    }
}