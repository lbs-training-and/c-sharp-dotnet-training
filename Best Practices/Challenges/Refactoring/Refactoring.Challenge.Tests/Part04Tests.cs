using FluentAssertions;

namespace Refactoring.Challenge.Tests;

[TestFixture]
public class Part04Tests
{
    [Test]
    [TestCase("toast", false)]
    [TestCase("programming", false)]
    [TestCase("radar", true)]
    [TestCase("hannah", true)]
    public void CanCheckIfPalindrome(string text, bool expected)
    {
        // Arrange

        var exercise = new Part04();

        // Act

        var isPalinedrome = exercise.Run(text);

        // Assert

        isPalinedrome.Should().Be(expected);
    }
}