using FluentAssertions;

namespace UnitTests.Challenge.Tests;

public class ParameterisedBasicCalculatorTests
{
    [Test]
    [TestCase(0, 10.5, 10.5)]
    [TestCase(-1.2, 11.5, 10.3)]
    public void CanAdd(decimal seed, decimal right, decimal expected)
    {
        // Arrange

        var calculator = new BasicCalculator(seed);

        // Act

        var total = calculator.Add(right);

        // Assert

        total.Should().Be(expected).And.Be(calculator.Total);
    }
    
    [Test]
    [TestCase(0, 10.5, -10.5)]
    [TestCase(-1.2, -11.5, 10.3)]
    public void CanSubtract(decimal seed, decimal right, decimal expected)
    {
        // Arrange

        var calculator = new BasicCalculator(seed);

        // Act

        var total = calculator.Subtract(right);

        // Assert

        total.Should().Be(expected).And.Be(calculator.Total);
    }
    
    [Test]
    [TestCase(0, 10.5, 0)]
    [TestCase(2, 11.52, 23.04)]
    [TestCase(2, -11.52, -23.04)]
    public void CanMultiply(decimal seed, decimal right, decimal expected)
    {
        // Arrange

        var calculator = new BasicCalculator(seed);

        // Act

        var total = calculator.Multiply(right);

        // Assert

        total.Should().Be(expected).And.Be(calculator.Total);
    }
    
    [Test]
    [TestCase(0, 10.5, 0)]
    [TestCase(5.5, 2, 2.75)]
    [TestCase(5.5, -2, -2.75)]
    public void CanDivide(decimal seed, decimal right, decimal expected)
    {
        // Arrange

        var calculator = new BasicCalculator(seed);

        // Act

        var total = calculator.Divide(right);

        // Assert

        total.Should().Be(expected).And.Be(calculator.Total);
    }
}