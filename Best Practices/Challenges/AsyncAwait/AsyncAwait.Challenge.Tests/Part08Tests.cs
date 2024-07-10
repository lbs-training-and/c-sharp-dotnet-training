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
public class Part08Tests
{
    [Test]
    public void CanReturnCorrectType()
    {
        // Arrange

        var type = typeof(Part08);

        // Act
        
        var runReturnType = type.GetMethod(nameof(Part08.Run))!.ReturnType;
        
        // Assert

        runReturnType.Should().Be(typeof(Task), "The method should return a Task.");
    }
    
    [Test]
    [AutoData]
    public async Task CanExecuteTasksConcurrently(Order order)
    {
        // Arrange

        var mockRepository = new MockRepository(MockBehavior.Loose);

        var mockNotificationServices = Enumerable.Range(0, 2)
            .Select(_ => mockRepository.Create<INotificationService>())
            .ToArray();

        var notificationServices = mockNotificationServices.Select(s => s.Object).ToArray();

        var exercise = new Part08(notificationServices[0], notificationServices[1]);

        Task? previousTask = null;

        foreach (var mock in mockNotificationServices)
        {
            mock.Setup(s => s.SendAsync(order)).Returns(() =>
            {
                previousTask = previousTask is null or { Status: TaskStatus.WaitingForActivation }
                    ? Task.Delay(100)
                    : Task.FromException(new Exception("The tasks are not running concurrently."));

                return previousTask;
            });
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