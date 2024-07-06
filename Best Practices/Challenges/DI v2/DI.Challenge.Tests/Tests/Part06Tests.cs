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
    public void SingletonConsumerServiceIsRegistered()
    {
        // Arrange
        
        var webApplicationFactory = new WebApplicationFactory<Program>();
        
        // Act
        
        var service1 = webApplicationFactory.Services.GetService<IConsumerService>();
        var service2 = webApplicationFactory.Services.GetService<IConsumerService>();
        
        // Assert

        service1.Should().NotBeNull().And.NotBe(service2);
    }
    
    [Test]
    public void SingletonConsumerService_ConsumesSingletonService()
    {
        // Arrange

        var work = new object();
        var mockSingletonService = new Mock<ISingletonService>();
        var mockScopedService = new Mock<IScopedService>();
        var mockTransientService = new Mock<ITransientService>();
        var webApplicationFactory = new WebApplicationFactory<Program>();

        webApplicationFactory.WithWebHostBuilder(b =>
        {
            b.ConfigureServices(sc =>
            {
                sc.Replace(ServiceDescriptor.Singleton(mockSingletonService.Object));
                sc.Replace(ServiceDescriptor.Singleton(mockScopedService.Object));
                sc.Replace(ServiceDescriptor.Singleton(mockTransientService.Object));
            });
        });
        
        // Act

        var service = webApplicationFactory.Services.GetRequiredService<ISingletonConsumerService>();
        
        service.DoWork(work);
        
        // Assert

        mockSingletonService.Verify(s => s.DoSingletonStuff(work));
        mockScopedService.Verify(s => s.DoScopedStuff(work));
        mockTransientService.Verify(s => s.DoTransientStuff(work));
    }
}