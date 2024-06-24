using DI.Challenge.Services.Interfaces;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace DI.Challenge.Tests.tests
{
    internal class Part04Tests
    {
        private IServiceCollection services;

        [SetUp]
        public void SetUp()
        {
            services = new ServiceCollection();

            var hostBuilder = Part04.CreateHostBuilder(new string[0]);

            hostBuilder.ConfigureServices((context, serviceCollection) =>
            {
                foreach (var service in serviceCollection)
                {
                    services.Add(service);
                }
            });

            var host = hostBuilder.Build();
        }

        [Test]
        public void Should_Register_MultipleSingletonServices_With_Singleton_Lifetime()
        {
            var serviceDescriptors = services.Where(sd => sd.ServiceType == typeof(ISingletonService)).ToList();
            serviceDescriptors.Count.Should().Be(2);
            serviceDescriptors.All(sd => sd.Lifetime == ServiceLifetime.Singleton).Should().BeTrue();
        }
    }
}
