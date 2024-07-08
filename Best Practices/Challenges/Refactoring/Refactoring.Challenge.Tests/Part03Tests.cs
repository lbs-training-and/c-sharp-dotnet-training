using FluentAssertions;
using Moq;
using Refactoring.Challenge.Interfaces;

namespace Refactoring.Challenge.Tests;

[TestFixture]
public class Part03Tests
{
    [Test]
    [TestCase(5, 1)]
    [TestCase(5, 3)]
    [TestCase(5, 5)]
    [TestCase(5, -1)]
    [TestCase(1, 1)]
    public async Task CanAttemptToWork(int maxAttempts, int workedOnAttempt)
    {
        // Arrange

        var workerMock = new Mock<IWorker>();

        var expectedHasWorked = workedOnAttempt != -1;
        var workAttemptsUsed = expectedHasWorked ? workedOnAttempt : maxAttempts;
        
        var exercise = new Part03(workerMock.Object);

        var attempt = 0;
        
        workerMock.Setup(w => w.DoWorkAsync()).Returns(() =>
        {
            attempt++;
            var worked = attempt == workedOnAttempt;
            return Task.FromResult(worked);
        });

        // Act

        var hasWorked = await exercise.Run(maxAttempts);

        // Assert

        hasWorked.Should().Be(expectedHasWorked);
        
        workerMock.Verify(w => w.DoWorkAsync(), Times.Exactly(workAttemptsUsed));
    }
}