using DI.Challenge.Services.Interfaces;
using Moq;

namespace DI.Challenge.Tests.tests
{
    internal class Part05Tests
    {
        private Mock<ISingletonService> _serviceAMock;
        private Mock<ISingletonService> _serviceBMock;
        private Part05 _part05;

        [SetUp]
        public void SetUp()
        {
            _serviceAMock = new Mock<ISingletonService>();
            _serviceBMock = new Mock<ISingletonService>();
            var services = new List<ISingletonService> { _serviceAMock.Object, _serviceBMock.Object };

            _part05 = new Part05(services);
        }

        [Test]
        public void ExecuteAll_ShouldCallDoServiceStuffOnAllServices()
        {
            // Act
            _part05.ExecuteAll();

            // Assert
            _serviceAMock.Verify(x => x.DoSingletonStuff(), Times.Once);
            _serviceBMock.Verify(x => x.DoSingletonStuff(), Times.Once);
        }
    }
}
