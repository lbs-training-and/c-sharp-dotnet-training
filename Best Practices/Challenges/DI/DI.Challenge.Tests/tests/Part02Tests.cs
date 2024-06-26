using DI.Challenge.Services.Interfaces;
using Moq;

namespace DI.Challenge.Tests.tests
{
    public class Part02Tests
    {
        private Mock<ISingletonService> _singletonServiceMock;
        private Part02 _part02;

        [SetUp]
        public void SetUp()
        {
            _singletonServiceMock = new Mock<ISingletonService>();
            _part02 = new Part02(_singletonServiceMock.Object);
        }

        [Test]
        public void Execute_ShouldCallDoSingletonStuff()
        {
            // Act
            var result = _part02.Execute();

            // Assert
            _singletonServiceMock.Verify(x => x.DoSingletonStuff(), Times.Once);
        }
    }
}
