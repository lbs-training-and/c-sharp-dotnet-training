using DI.Challenge.Interfaces;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace DI.Challenge.Tests.Tests;

public class Part03Tests
{
    [Test]
    public void ScopedServiceIsRegistered()
    {
        // Arrange
        
        var webApplicationFactory = new WebApplicationFactory<Program>();
        using var scope = webApplicationFactory.Services.CreateScope();
        
        // Act
        
        var service1 = scope.ServiceProvider.GetService<IScopedService>();
        var service2 = scope.ServiceProvider.GetService<IScopedService>();
        var service3 = webApplicationFactory.Services.GetService<IScopedService>();
        
        // Assert

        service1.Should().NotBeNull().And.Be(service2).And.NotBe(service3);
    }
    
    [Test]
    public void TransientServiceIsRegistered()
    {
        // Arrange
        
        var webApplicationFactory = new WebApplicationFactory<Program>();
        
        // Act
        
        var service1 = webApplicationFactory.Services.GetService<ITransientService>();
        var service2 = webApplicationFactory.Services.GetService<ITransientService>();
        
        // Assert

        service1.Should().NotBeNull().And.NotBe(service2);
    }
}