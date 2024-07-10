using System.Linq.Expressions;
using AsyncAwait.Challenge.Enums;
using AsyncAwait.Challenge.Exceptions;
using AsyncAwait.Challenge.Interfaces;
using AsyncAwait.Challenge.Models;
using AutoFixture.NUnit3;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;

namespace AsyncAwait.Challenge.Tests;

[TestFixture]
public class Part07Tests
{
    [Test]
    public void CanReturnCorrectType()
    {
        // Arrange

        var type = typeof(Part07);

        // Act

        var runReturnType = type.GetMethod(nameof(Part07.Run))!.ReturnType;

        // Assert

        runReturnType.Should().Be(typeof(Task), "The method should return a Task.");
    }

    [Test]
    [AutoData]
    public async Task CanHandleException(Order order)
    {
        // Arrange

        var mockRepository = new MockRepository(MockBehavior.Loose);

        var mockNotificationServices = Enumerable.Range(0, 5)
            .Select(_ => mockRepository.Create<INotificationService>())
            .ToArray();

        var loggerMock = mockRepository.Create<ILogger<Part07>>();

        var notificationServices = mockNotificationServices.Select(s => s.Object).ToArray();

        var exercise = new Part07(notificationServices, loggerMock.Object);

        foreach (var mock in mockNotificationServices)
        {
            var exception = new Exception();
            
            mock.Setup(s => s.SendAsync(order)).ThrowsAsync(exception);

            Expression<Action<ILogger<Part07>>> loggerSetup = l => l.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                exception,
                It.IsAny<Func<It.IsAnyType, Exception?, string>>());

            loggerMock.Setup(loggerSetup).Verifiable();
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