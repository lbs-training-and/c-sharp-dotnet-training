using System.Linq.Expressions;
using FluentAssertions;
using Moq;
using UnitTests.Challenge.Interfaces;
using UnitTests.Challenge.Models;

namespace UnitTests.Challenge.Tests;

public class NotificationHandlerTests
{
    [Test]
    [TestCase(OrderStatus.Confirmed)]
    [TestCase(OrderStatus.AwaitingDispatched)]
    [TestCase(OrderStatus.Dispatched)]
    [TestCase(OrderStatus.InTransit)]
    [TestCase(OrderStatus.Delivered)]
    [TestCase(OrderStatus.Cancelled)]
    public async Task CanHandleNotification(OrderStatus orderStatus)
    {
        // Arrange

        var order = new Order { Status = orderStatus };

        var mockRepository = new MockRepository(MockBehavior.Loose);

        var notificationServiceMock = mockRepository.Create<INotificationService>();

        Expression<Func<INotificationService, Task>> func = orderStatus switch
        {
            OrderStatus.Confirmed => s => s.SendConfirmedAsync(order),
            OrderStatus.AwaitingDispatched => s => s.SendAwaitingDispatchedAsync(order),
            OrderStatus.Dispatched => s => s.SendDispatchedAsync(order),
            OrderStatus.InTransit => s => s.SendInTransitAsync(order),
            OrderStatus.Delivered => s => s.SendDeliveredAsync(order),
            OrderStatus.Cancelled => s => s.SendCancelledAsync(order),
            _ => throw new ArgumentOutOfRangeException(nameof(orderStatus), orderStatus, null)
        };

        var expectedTask = Task.Delay(1);
        
        notificationServiceMock.Setup(func).Returns(expectedTask);

        var notificationHandler = new NotificationHandler(notificationServiceMock.Object);

        // Act

        var task = notificationHandler.SendStatusUpdateAsync(order);
        await task;

        // Assert

        task.Should().Be(expectedTask);
        mockRepository.VerifyAll();
        mockRepository.VerifyNoOtherCalls();
    }

    [Test]
    [TestCase(0)]
    [TestCase(999)]
    public async Task CanHandleInvalidNotification(OrderStatus orderStatus)
    {
        // Arrange

        var order = new Order { Status = orderStatus };

        var mockRepository = new MockRepository(MockBehavior.Loose);

        var notificationServiceMock = mockRepository.Create<INotificationService>();

        var notificationHandler = new NotificationHandler(notificationServiceMock.Object);

        // Act

        var task = notificationHandler.SendStatusUpdateAsync(order);
        await task;

        // Assert

        task.Should().Be(Task.CompletedTask);
        mockRepository.VerifyNoOtherCalls();
    }
}