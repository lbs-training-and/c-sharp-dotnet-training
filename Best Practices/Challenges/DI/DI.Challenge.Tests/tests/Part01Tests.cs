using DI.Challenge.Services;
using FluentAssertions;
using Moq;

namespace DI.Challenge.Tests.tests
{
    public class Part01Tests
    {
        private Mock<SingletonService> _singletonServiceMock;
        private Part01 _part01;

        [SetUp]
        public void SetUp()
        {
            _singletonServiceMock = new Mock<SingletonService>();
            _part01 = new Part01(_singletonServiceMock.Object);
        }

        [Test]
        public void Execute_ShouldCallDoSingletonStuff()
        {
            // Act
            var result = _part01.Execute();

            // Assert
            result.Should().Be(SingletonService.SingletonCalled);
        }
    }
}
