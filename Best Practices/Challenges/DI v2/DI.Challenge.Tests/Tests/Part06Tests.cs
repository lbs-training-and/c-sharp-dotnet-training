using DI.Challenge.Interfaces;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;

namespace DI.Challenge.Tests.Tests;

public class Part06Tests
{
    [Test]
    public void ConsumerServiceIsRegistered()
    {
        // Arrange
        
        var webApplicationFactory = new WebApplicationFactory<Program>();
        using var scope = webApplicationFactory.Services.CreateScope();
        
        // Act
        
        var service1 = scope.ServiceProvider.GetService<IConsumerService>();
        var service2 = scope.ServiceProvider.GetService<IConsumerService>();
        
        // Assert

        service1.Should().NotBeNull().And.NotBe(service2);
    }
    
    [Test]
    public void ConsumerService_DependsOnServices()
    {
        // Arrange

        var work = new object();
        var mockSingletonService = new Mock<ISingletonService>();
        var mockScopedService = new Mock<IScopedService>();
        var mockTransientService = new Mock<ITransientService>();
        var webApplicationFactory = new WebApplicationFactory<Program>().WithWebHostBuilder(b =>
        {
            b.ConfigureServices(sc =>
            {
                sc.Replace(ServiceDescriptor.Singleton(mockSingletonService.Object));
                sc.Replace(ServiceDescriptor.Scoped(_ => mockScopedService.Object));
                sc.Replace(ServiceDescriptor.Transient(_ => mockTransientService.Object));
            });
        });
        
        using var scope = webApplicationFactory.Services.CreateScope();
        
        // Act

        var service = scope.ServiceProvider.GetRequiredService<IConsumerService>();
        
        service.DoWork(work);
        
        // Assert

        mockSingletonService.Verify(s => s.DoSingletonStuff(work));
        mockScopedService.Verify(s => s.DoScopedStuff(work));
        mockTransientService.Verify(s => s.DoTransientStuff(work));
    }
}