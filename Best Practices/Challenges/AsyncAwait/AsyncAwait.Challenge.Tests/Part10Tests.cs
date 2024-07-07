using AsyncAwait.Challenge.Interfaces;
using FluentAssertions;
using Moq;

namespace AsyncAwait.Challenge.Tests;

[TestFixture]
public class Part10Tests
{
    [Test]
    public void CanReturnCorrectType()
    {
        // Arrange

        var type = typeof(Part10);

        // Act
        
        var runReturnType = type.GetMethod(nameof(Part10.Run))!.ReturnType;
        
        // Assert

        runReturnType.Should().Be(typeof(Task<int>), "The method should return a Task<int>.");
    }
    
    [Test]
    public async Task CanExecuteTasksConcurrently()
    {
        // Arrange

        var mockRepository = new MockRepository(MockBehavior.Loose);

        var mockRacers = Enumerable.Range(0, 10)
            .Select(_ => mockRepository.Create<IRacer>())
            .ToArray();

        var racers = mockRacers.Select(s => s.Object).ToArray();

        var exercise = new Part10(racers);
        
        Task<int>? concurrencyTask = null;
        
        for (var i = 0; i < mockRacers.Length; i++)
        {
            var mock = mockRacers[i];
            
            var racerId = i;
          
            Task<int> GetReturnTask() => concurrencyTask =
                concurrencyTask is null or { Status: TaskStatus.WaitingForActivation }
                    ? Task.Delay(1).ContinueWith(_ => racerId)
                    : Task.FromException<int>(new Exception("The tasks are not running concurrently."));

            mock.Setup(s => s.Race()).Returns(GetReturnTask);
        }

        // Act

        var result = exercise.Run();

        var resultTask = result as Task<int> ?? Task.FromResult(-1);
        await resultTask;

        // Assert

        mockRepository.VerifyAll();
        mockRepository.VerifyNoOtherCalls();
    }
    
    [Test]
    public async Task CanReturnWinner()
    {
        // Arrange

        var mockRepository = new MockRepository(MockBehavior.Loose);

        var mockRacers = Enumerable.Range(0, 10)
            .Select(_ => mockRepository.Create<IRacer>())
            .ToArray();

        var racers = mockRacers.Select(s => s.Object).ToArray();

        var exercise = new Part10(racers);

        var winnerId = Random.Shared.Next(0, 9);

        for (var i = 0; i < mockRacers.Length; i++)
        {
            var mock = mockRacers[i];
            
            var racerId = i;

            var returnTask = Task.Delay(racerId == winnerId ? 1 : 10000).ContinueWith(_ => racerId);

            mock.Setup(s => s.Race()).Returns(returnTask);
        }

        // Act

        var result = exercise.Run();

        var resultTask = result as Task<int> ?? Task.FromResult(-1);
        await resultTask;

        // Assert

        mockRepository.VerifyAll();
        mockRepository.VerifyNoOtherCalls();

        resultTask.Result.Should().Be(winnerId);
    }
}