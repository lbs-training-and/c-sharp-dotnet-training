using System.Linq.Expressions;
using FluentAssertions;
using Moq;
using Refactoring.Challenge.Interfaces;
using Refactoring.Challenge.Models;

namespace Refactoring.Challenge.Tests;

[TestFixture]
public class Part08Tests
{
    [Test]
    public async Task CanSleep()
    {
        // Arrange

        var mockRepository = new MockRepository(MockBehavior.Loose);

        var workerMocks = Enumerable.Range(0, 5)
            .Select(_ => mockRepository.Create<IWorker>())
            .ToArray();

        foreach (var workerMock in workerMocks)
        {
            workerMock.Setup(w => w.Sleep()).Returns(() => Task.Delay(200));
        }

        var workers = workerMocks.Select(m => m.Object).ToArray();
        
        var exercise = new Part08(workers);
        
        // Act

        await exercise.Run();

        // Assert

        mockRepository.VerifyAll();
        mockRepository.VerifyNoOtherCalls();
    }
}