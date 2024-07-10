using FluentAssertions;

namespace Refactoring.Challenge.Tests;

[TestFixture]
public class Part04Tests
{
    [Test]
    public void CanCalculateAverage()
    {
        // Arrange

        var numbers = new [] { 1, 5, 10, 11, 3, 6 };

        var exercise = new Part04();

        // Act

        var average = exercise.Run(numbers);

        // Assert

        average.Should().Be(6);
    }
}