using FluentAssertions;
using Moq;
using UnitTests.Challenge.Interfaces;

namespace UnitTests.Challenge.Tests;

[TestFixture]
public class WorkerTests
{
    [Test]
    [TestCase(1, 1)]
    [TestCase(5, 3)]
    [TestCase(5, 10)]
    public async Task CanDoWork(int maxAttempts, int attempts)
    {
        // Arrange

        var expectedToComplete = attempts <= maxAttempts;
        
        var jobMock = new Mock<IJob>();

        foreach (var i in Enumerable.Range(1, Math.Min(attempts, maxAttempts)))
        {
            jobMock.Setup(j => j.PerformAsync(i)).ReturnsAsync(i == attempts);
        }
        
        var worker = new Worker();

        // Act

        var completed = await worker.DoWorkAsync(jobMock.Object, maxAttempts);

        // Assert

        completed.Should().Be(expectedToComplete);
        
        jobMock.VerifyAll();
        jobMock.VerifyNoOtherCalls();
    }
    
    [Test]
    [TestCase(0)]
    [TestCase(-50)]
    public async Task DoWorkHandlesInvalidMaxAttempts(int maxAttempts)
    {
        // Arrange
        
        var jobMock = new Mock<IJob>();
        
        var worker = new Worker();

        // Act

        var action = () => worker.DoWorkAsync(jobMock.Object, maxAttempts);
        
        // Assert
        
        var ex = await action.Should().ThrowAsync<ArgumentException>();
        ex.WithMessage("Max attempts must be greater than 0.*").WithParameterName("maxAttempts");
        
        jobMock.VerifyAll();
        jobMock.VerifyNoOtherCalls();
    }
}