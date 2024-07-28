using FluentAssertions;
using Moq;
using UnitTesting.Examples.MoqExamples;

namespace UnitTesting.Examples.Tests.MoqExamples;

[TestFixture]
public class CalculatorTests
{
    [Test]
    public void CanAdd()
    {
        // Arrange

        var mockRepository = new MockRepository(MockBehavior.Loose);

        var printer = mockRepository.Create<IPrinter>();
        var mathHandler = mockRepository.Create<IMathHandler>();

        const decimal expected = 10;

        mathHandler
            .Setup(h => h.Add(0, It.IsAny<decimal>()))
            .Returns(expected);

        printer.Setup(p => p.Print(expected));

        var calculator = new Calculator(mathHandler.Object, printer.Object);

        // Act

        var value = calculator.Add(10);

        // Assert

        value.Should().Be(expected).And.Be(calculator.Total);
        
        mockRepository.VerifyAll();
        mockRepository.VerifyNoOtherCalls();
    }
}


// [TestFixture]
// public class CalculatorTests
// {
//     [Test]
//     public void CanAdd()
//     {
//         // Arrange
//
//         var printer = new Mock<IPrinter>();
//         var mathHandler = new Mock<IMathHandler>();
//
//         const decimal expected = 10;
//
//         mathHandler
//             .Setup(h => h.Add(0, It.IsAny<decimal>()))
//             .Returns(expected);
//
//         var calculator = new Calculator(mathHandler.Object, printer.Object);
//
//         // Act
//
//         var value = calculator.Add(10);
//
//         // Assert
//
//         value.Should().Be(expected).And.Be(calculator.Total);
//         
//         printer.Verify(p => p.Print(expected), Times.Once);
//         mathHandler.VerifyAll();
//         mathHandler.VerifyNoOtherCalls();
//     }
// }

// [TestFixture]
// public class CalculatorTests
// {
//     [Test]
//     public void CanAdd()
//     {
//         // Arrange
//
//         var printer = new Mock<IPrinter>();
//         var mathHandler = new Mock<IMathHandler>();
//
//         const decimal expected = 10;
//
//         mathHandler
//             .Setup(h => h.Add(0, It.IsAny<decimal>()))
//             .Returns(expected);
//         
//         printer.Setup(p => p.Print(expected));
//
//         var calculator = new Calculator(mathHandler.Object, printer.Object);
//
//         // Act
//
//         var value = calculator.Add(10);
//
//         // Assert
//
//         value.Should().Be(expected).And.Be(calculator.Total);
//     }
// }
