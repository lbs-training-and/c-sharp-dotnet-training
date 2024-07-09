using DI.Challenge.Interfaces;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace DI.Challenge.Tests.Tests;

public class Part02Tests
{
    [Test]
    public void SingletonServiceIsRegistered()
    {
        // Arrange
        
        var webApplicationFactory = new WebApplicationFactory<Program>();
        
        // Act
        
        var service1 = webApplicationFactory.Services.GetService<ISingletonService>();
        var service2 = webApplicationFactory.Services.GetService<ISingletonService>();
        
        // Assert

        service1.Should().NotBeNull().And.Be(service2);
    }
}