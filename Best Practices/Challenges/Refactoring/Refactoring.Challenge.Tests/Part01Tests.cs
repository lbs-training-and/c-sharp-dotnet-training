using FluentAssertions;

namespace Refactoring.Challenge.Tests;

[TestFixture]
public class Part01Tests
{
    [Test]
    public void CanCalculateAverage()
    {
        // Arrange

        var numbers = new [] { 1, 5, 10, 11, 3, 6 };

        var exercise = new Part01();

        // Act

        var average = exercise.Run(numbers);

        // Assert

        average.Should().Be(6);
    }
}