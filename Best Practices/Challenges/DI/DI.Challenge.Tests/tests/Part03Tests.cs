using DI.Challenge.Services.Interfaces;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace DI.Challenge.Tests.tests
{
    internal class Part03Tests
    {
        private IServiceCollection services;

        [SetUp]
        public void SetUp()
        {
            services = new ServiceCollection();

            var hostBuilder = Part03.CreateHostBuilder(new string[0]);

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
        public void Should_Register_SingletonService_With_Singleton_Lifetime()
        {
            var serviceDescriptor = services.FirstOrDefault(sd => sd.ServiceType == typeof(ISingletonService));
            serviceDescriptor.Should().NotBeNull();
            serviceDescriptor!.Lifetime.Should().Be(ServiceLifetime.Singleton);
        }

        [Test]
        public void Should_Register_ScopedService_With_Scoped_Lifetime()
        {
            var serviceDescriptor = services.FirstOrDefault(sd => sd.ServiceType == typeof(IScopedService));
            serviceDescriptor.Should().NotBeNull();
            serviceDescriptor!.Lifetime.Should().Be(ServiceLifetime.Scoped);
        }

        [Test]
        public void Should_Register_TransientService_With_Transient_Lifetime()
        {
            var serviceDescriptor = services.FirstOrDefault(sd => sd.ServiceType == typeof(ITransientService));
            serviceDescriptor.Should().NotBeNull();
            serviceDescriptor!.Lifetime.Should().Be(ServiceLifetime.Transient);
        }
    }
}
