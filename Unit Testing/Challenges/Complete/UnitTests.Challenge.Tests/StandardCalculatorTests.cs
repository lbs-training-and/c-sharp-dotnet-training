using FluentAssertions;
using Moq;
using UnitTests.Challenge.Interfaces;

namespace UnitTests.Challenge.Tests;

[TestFixture]
public class StandardCalculatorTests
{
    [Test]
    public void CanAdd()
    {
        // Arrange

        const decimal seed = 2;
        const decimal right = 8;
        const decimal expected = 10;

        var screenMock = new Mock<IScreen>();
        var mathHandlerMock = new Mock<IMathHandler>();

        var calculator = new StandardCalculator(mathHandlerMock.Object, screenMock.Object, seed);

        mathHandlerMock.Setup(h => h.Add(seed, right)).Returns(expected);

        // Act

        var total = calculator.Add(right);

        // Assert
        
        total.Should().Be(expected).And.Be(calculator.Total);
        
        screenMock.Verify(s => s.Display(expected), Times.Once);
    }
    
    [Test]
    public void CanSubtract()
    {
        // Arrange
        
        const decimal seed = 1.2m;
        const decimal right = 11.5m;
        const decimal expected = -10.3m;

        var screenMock = new Mock<IScreen>();
        var mathHandlerMock = new Mock<IMathHandler>();

        var calculator = new StandardCalculator(mathHandlerMock.Object, screenMock.Object, seed);

        mathHandlerMock.Setup(h => h.Subtract(seed, right)).Returns(expected);

        // Act

        var total = calculator.Subtract(right);

        // Assert
        
        total.Should().Be(expected).And.Be(calculator.Total);
        
        screenMock.Verify(s => s.Display(expected), Times.Once);
    }
    
    [Test]
    public void CanMultiply()
    {
        // Arrange
        
        const decimal seed = 2;
        const decimal right = 11.52m;
        const decimal expected = 23.04m;
        
        var screenMock = new Mock<IScreen>();
        var mathHandlerMock = new Mock<IMathHandler>();

        var calculator = new StandardCalculator(mathHandlerMock.Object, screenMock.Object, seed);

        mathHandlerMock.Setup(h => h.Multiply(seed, right)).Returns(expected);

        // Act

        var total = calculator.Multiply(right);

        // Assert
        
        total.Should().Be(expected).And.Be(calculator.Total);
        
        screenMock.Verify(s => s.Display(expected), Times.Once);
    }
    
    [Test]
    public void CanDivide()
    {
        // Arrange
        
        const decimal seed = 5.5m;
        const decimal right = 2m;
        const decimal expected = 2.75m;

        var screenMock = new Mock<IScreen>();
        var mathHandlerMock = new Mock<IMathHandler>();

        var calculator = new StandardCalculator(mathHandlerMock.Object, screenMock.Object, seed);

        mathHandlerMock.Setup(h => h.Divide(seed, right)).Returns(expected);

        // Act

        var total = calculator.Divide(right);

        // Assert
        
        total.Should().Be(expected).And.Be(calculator.Total);
        
        screenMock.Verify(s => s.Display(expected), Times.Once);
    }
}