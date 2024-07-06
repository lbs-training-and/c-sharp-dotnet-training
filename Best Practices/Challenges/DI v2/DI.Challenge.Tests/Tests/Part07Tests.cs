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
    public void OrderServiceIsRegistered()
    {
        // Arrange

        var webApplicationFactory = new WebApplicationFactory<Program>();

        // Act

        var service1 = webApplicationFactory.Services.GetService<IOrderService>();
        var service2 = webApplicationFactory.Services.GetService<IOrderService>();

        // Assert

        service1.Should().NotBeNull().And.Be(service2);
    }

    [Test]
    public void OrderService_DependsOnNotificationServices()
    {
        // Arrange

        var order = new Order();
        var mockNotificationServices = new List<Mock<INotificationService>> { new(), new(), new() };
        var webApplicationFactory = new WebApplicationFactory<Program>().WithWebHostBuilder(b =>
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