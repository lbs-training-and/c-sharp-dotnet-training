using System.Linq.Expressions;
using FluentAssertions;
using Moq;
using Refactoring.Challenge.Interfaces;
using Refactoring.Challenge.Models;

namespace Refactoring.Challenge.Tests;

[TestFixture]
public class Part04Tests
{
    [Test]
    [TestCase(OrderStatus.Pending)]
    [TestCase(OrderStatus.Confirmed)]
    [TestCase(OrderStatus.Dispatched)]
    [TestCase(OrderStatus.Delayed)]
    [TestCase(OrderStatus.Delivered)]
    [TestCase(OrderStatus.Cancelled)]
    public async Task CanSendNotification(OrderStatus orderStatus)
    {
        // Arrange

        var notificationServiceMock = new Mock<INotificationService>();
        
        var exercise = new Part04(notificationServiceMock.Object);

        var order = new Order
        {
            Id = 1,
            Status = orderStatus
        };

        var methodFuncByOrderStatus = new Dictionary<OrderStatus, Expression<Func<INotificationService, Task>>>
        {
            { OrderStatus.Pending, s => s.SendPending() },
            { OrderStatus.Confirmed, s => s.SendConfirmed() },
            { OrderStatus.Dispatched, s => s.SendDispatched() },
            { OrderStatus.Delayed, s => s.SendDelayed() },
            { OrderStatus.Delivered, s => s.SendDelivered() },
            { OrderStatus.Cancelled, s => s.SendCancelled() },
        };

        notificationServiceMock
            .Setup(methodFuncByOrderStatus[orderStatus])
            .Returns(Task.CompletedTask);
        
        // Act

        await exercise.Run(order);

        // Assert

        notificationServiceMock.VerifyAll();
        notificationServiceMock.VerifyNoOtherCalls();
    }
    
    [Test]
    [TestCase(OrderStatus.Unknown)]
    [TestCase((OrderStatus)999)]
    public async Task ThrowsNotImplementedException(OrderStatus orderStatus)
    {
        // Arrange

        var notificationServiceMock = new Mock<INotificationService>();
        
        var exercise = new Part04(notificationServiceMock.Object);

        var order = new Order
        {
            Id = 1,
            Status = orderStatus
        };
        
        // Act

        var action = () => exercise.Run(order);

        // Assert

        await action.Should().ThrowAsync<InvalidOperationException>();

        notificationServiceMock.VerifyAll();
        notificationServiceMock.VerifyNoOtherCalls();
    }
}