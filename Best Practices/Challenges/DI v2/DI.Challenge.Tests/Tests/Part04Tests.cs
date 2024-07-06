using DI.Challenge.Interfaces;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace DI.Challenge.Tests.Tests;

public class Part04Tests
{
    [Test]
    public void NotificationServicesAreRegistered()
    {
        // Arrange
        
        var webApplicationFactory = new WebApplicationFactory<Program>();
        
        // Act

        var services1 = webApplicationFactory.Services.GetServices<IEnumerable<INotificationService>>();
        var services2 = webApplicationFactory.Services.GetServices<IEnumerable<INotificationService>>();
        
        // Assert

        services1.Should().NotBeNull().And.HaveCount(3).And.OnlyHaveUniqueItems().And.BeEquivalentTo(services2);
    }
}