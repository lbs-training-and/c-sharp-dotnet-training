using FluentAssertions;

namespace Refactoring.Challenge.Tests;

[TestFixture]
public class Part01Tests
{
    [Test]
    public void CheckIfPrime_WithPrimeNumber_ReturnsTrue()
    {
        // Arrange
        var part = new Part01();

        // Act
        var result = part.Run(7);

        // Assert
        result.Should().BeTrue();
    }

    [Test]
    public void CheckIfPrime_WithNonPrimeNumber_ReturnsFalse()
    {
        // Arrange
        var part = new Part01();

        // Act
        var result = part.Run(4);

        // Assert
        result.Should().BeFalse();
    }

    [Test]
    public void CheckIfPrime_WithNumberLessThanTwo_ReturnsFalse()
    {
        // Arrange
        var part = new Part01();

        // Act
        var result = part.Run(1);

        // Assert
        result.Should().BeFalse();
    }
}