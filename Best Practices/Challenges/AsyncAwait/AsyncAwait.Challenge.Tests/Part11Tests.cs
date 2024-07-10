using System.Linq.Expressions;
using AsyncAwait.Challenge.Interfaces;
using AsyncAwait.Challenge.Models;
using AutoFixture.NUnit3;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;

namespace AsyncAwait.Challenge.Tests;

[TestFixture]
public class Part11Tests
{
    [Test]
    public void CanReturnCorrectType()
    {
        // Arrange

        var type = typeof(Part11);

        // Act
        
        var runReturnType = type.GetMethod(nameof(Part11.Run))!.ReturnType;
        
        // Assert

        runReturnType.Should().Be(typeof(Task), "The method should return a Task.");
    }
    
    [Test]
    [AutoData]
    public async Task CanExecuteTasksConcurrently(Order order)
    {
        // Arrange

        var mockRepository = new MockRepository(MockBehavior.Loose);

        var loggerMock = mockRepository.Create<ILogger<Part11>>();

        var mockNotificationServices = Enumerable.Range(0, 5)
            .Select(_ => mockRepository.Create<INotificationService>())
            .ToArray();

        var notificationServices = mockNotificationServices.Select(s => s.Object).ToArray();

        var exercise = new Part11(notificationServices, loggerMock.Object);

        Task? concurrencyTask = null;

        foreach (var mock in mockNotificationServices)
        {
            Task GetReturnTask() => concurrencyTask =
                concurrencyTask is null or { Status: TaskStatus.WaitingForActivation }
                    ? Task.Delay(100)
                    : Task.FromException(new Exception("The tasks are not running concurrently."));

            mock.Setup(s => s.SendAsync(order)).Returns(GetReturnTask);
        }
        
        // Act

        var result = exercise.Run(order);

        var resultTask = result as Task ?? Task.CompletedTask;
        await resultTask;

        // Assert

        mockRepository.VerifyAll();
        mockRepository.VerifyNoOtherCalls();
    }

    [Test]
    [AutoData]
    public async Task CanHandleExceptions(Order order)
    {
        // Arrange

        var mockRepository = new MockRepository(MockBehavior.Loose);

        var loggerMock = mockRepository.Create<ILogger<Part11>>();

        var mockNotificationServices = Enumerable.Range(0, 5)
            .Select(_ => mockRepository.Create<INotificationService>())
            .ToArray();

        var notificationServices = mockNotificationServices.Select(s => s.Object).ToArray();

        var exercise = new Part11(notificationServices, loggerMock.Object);

        foreach (var mock in mockNotificationServices)
        {
            var exception = new Exception();

            Expression<Action<ILogger<Part11>>> loggerSetup = l => l.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                exception,
                It.IsAny<Func<It.IsAnyType, Exception?, string>>());

            loggerMock.Setup(loggerSetup).Verifiable();

            mock.Setup(s => s.SendAsync(order)).ThrowsAsync(exception);
        }
        
        // Act

        var result = exercise.Run(order);

        var resultTask = result as Task ?? Task.CompletedTask;
        await resultTask;

        // Assert

        mockRepository.VerifyAll();
        mockRepository.VerifyNoOtherCalls();
    }
}