using DI.Challenge.Interfaces;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;

namespace DI.Challenge.Tests.Tests;

public class Part05Tests
{
    [Test]
    public void SingletonConsumerServiceIsRegistered()
    {
        // Arrange
        
        var webApplicationFactory = new WebApplicationFactory<Program>();
        
        // Act
        
        var service1 = webApplicationFactory.Services.GetService<ISingletonConsumerService>();
        var service2 = webApplicationFactory.Services.GetService<ISingletonConsumerService>();
        
        // Assert

        service1.Should().NotBeNull().And.Be(service2);
    }
    
    [Test]
    public void SingletonConsumerService_ConsumesSingletonService()
    {
        // Arrange

        var work = new object();
        var mockSingletonService = new Mock<ISingletonService>();
        var webApplicationFactory = new WebApplicationFactory<Program>().WithWebHostBuilder(b =>
        {
            b.ConfigureServices(sc =>
            {
                sc.Replace(ServiceDescriptor.Singleton(mockSingletonService.Object));
            });
        });
        
        // Act

        var service = webApplicationFactory.Services.GetRequiredService<ISingletonConsumerService>();
        
        service.DoWork(work);
        
        // Assert

        mockSingletonService.Verify(s => s.DoSingletonStuff(work));
    }
}