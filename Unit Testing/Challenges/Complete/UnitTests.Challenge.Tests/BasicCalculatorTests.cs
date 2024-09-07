using FluentAssertions;

namespace UnitTests.Challenge.Tests;

[TestFixture]
public class BasicCalculatorTests
{
    [Test]
    public void CanSeed()
    {
        // Arrange

        const int seed = 0;

        // Act

        var calculator = new BasicCalculator();

        // Assert

        calculator.Total.Should().Be(seed);
    }
    
    [Test]
    public void CanSeedWithValue()
    {
        // Arrange

        const int seed = 5;

        // Act

        var calculator = new BasicCalculator(seed);

        // Assert

        calculator.Total.Should().Be(seed);
    }
    
    [Test]
    public void CanAdd()
    {
        // Arrange

        var calculator = new BasicCalculator();

        // Act

        var total = calculator.Add(5);

        // Assert

        total.Should().Be(5).And.Be(calculator.Total);
    }
    
    [Test]
    public void CanSubtract()
    {
        // Arrange
        
        var calculator = new BasicCalculator();

        // Act

        var total = calculator.Subtract(5);

        // Assert

        total.Should().Be(-5).And.Be(calculator.Total);
    }
    
    [Test]
    public void CanMultiply()
    {
        // Arrange
        
        var calculator = new BasicCalculator(2);

        // Act

        var total = calculator.Multiply(5);

        // Assert

        total.Should().Be(10).And.Be(calculator.Total);
    }
    
    [Test]
    public void CanDivide()
    {
        // Arrange
        
        var calculator = new BasicCalculator(50);

        // Act

        var total = calculator.Divide(10);

        // Assert

        total.Should().Be(5).And.Be(calculator.Total);
    }
    
    [Test]
    public void CanHandleDivideByZero()
    {
        // Arrange
        
        var calculator = new BasicCalculator(50);

        // Act

        var action = () => calculator.Divide(0);

        // Assert

        action.Should().Throw<ArithmeticException>().WithMessage("Can't divide by 0.");
    }
    
    [Test]
    public void CanReset()
    {
        // Arrange
        
        var calculator = new BasicCalculator(50);

        // Act

        var total = calculator.Reset();

        // Assert

        total.Should().Be(0).And.Be(calculator.Total);
    }
    
    [Test]
    public void CanResetWithValue()
    {
        // Arrange
        
        var calculator = new BasicCalculator(50);

        // Act

        var total = calculator.Reset(5);

        // Assert

        total.Should().Be(5).And.Be(calculator.Total);
    }
}