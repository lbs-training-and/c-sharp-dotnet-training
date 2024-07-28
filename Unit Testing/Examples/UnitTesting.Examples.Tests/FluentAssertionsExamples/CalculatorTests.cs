using FluentAssertions;
using UnitTesting.Examples.FluentAssertionsExamples;

namespace UnitTesting.Examples.Tests;

[TestFixture]
public class CalculatorTests
{
    [Test]
    public void CanDivide()
    {
        // Arrange

        const int divideBy = 2;
        const int expected = 5;
        var calculator = new Calculator(10);

        // Act 

        var value = calculator.Divide(divideBy);

        // Assert

        value.Should().Be(expected).And.Be(calculator.Total);
    }

    [Test]
    public void DivideBy0ThrowsArithmeticException()
    {
        // Arrange
        
        var calculator = new Calculator(0);

        // Act 

        var action = () => calculator.Divide(0);

        // Assert

        action.Should()
            .Throw<ArithmeticException>()
            .WithMessage("Can't divide by 0.");
    }
}