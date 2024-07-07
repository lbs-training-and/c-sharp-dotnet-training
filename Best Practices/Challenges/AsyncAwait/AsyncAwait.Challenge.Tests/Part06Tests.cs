using AsyncAwait.Challenge.Enums;
using AsyncAwait.Challenge.Exceptions;
using AsyncAwait.Challenge.Interfaces;
using AsyncAwait.Challenge.Models;
using AutoFixture.NUnit3;
using FluentAssertions;
using Moq;

namespace AsyncAwait.Challenge.Tests;

[TestFixture]
public class Part06Tests
{
    [Test]
    public void CanReturnCorrectType()
    {
        // Arrange

        var type = typeof(Part06);

        // Act
        
        var runReturnType = type.GetMethod(nameof(Part06.Run))!.ReturnType;
        
        // Assert

        runReturnType.Should().Be(typeof(Task), "The method should return a Task.");
    }
    
    [Test]
    [AutoData]
    public async Task CanUpdateOrderStatus(Order order)
    {
        // Arrange

        var mockRepository = new MockRepository(MockBehavior.Loose);
        
        order.Status = OrderStatus.AwaitingDispatch;

        var expectedStatus = OrderStatus.Dispatched;

        var orderRepository = mockRepository.Create<IOrderRepository>();

        var mockNotificationServices = Enumerable.Range(0, 3)
            .Select(_ => mockRepository.Create<INotificationService>())
            .ToArray();

        var notificationServices = mockNotificationServices.Select(s => s.Object).ToArray();

        var exercise = new Part06(orderRepository.Object, notificationServices);

        var getOrderTask = Task.FromResult<Order?>(order);
        var saveOrderTask = Task.Delay(1);

        orderRepository.Setup(o => o.GetAsync(order.Id)).Returns(getOrderTask).Verifiable();
        orderRepository.Setup(o => o.SaveAsync(order)).Returns(saveOrderTask).Verifiable();

        foreach (var mock in mockNotificationServices)
        {
            mock.Setup(s => s.SendAsync(order)).Returns(Task.Delay(1));
        }

        // Act

        var result = exercise.Run(order.Id, expectedStatus);

        var resultTask = result as Task ?? Task.CompletedTask;
        await resultTask;

        // Assert

        mockRepository.VerifyAll();
        mockRepository.VerifyNoOtherCalls();
        
        resultTask.Should().NotBe(getOrderTask, "The method should use the await keyword.");
        resultTask.Should().NotBe(saveOrderTask, "The method should use the await keyword.");

        order.Status.Should().Be(expectedStatus);
    }
    
    [Test]
    [InlineAutoData]
    public async Task ThrowsOrderNotFoundException(int orderId)
    {
        // Arrange
        
        var orderRepository = new Mock<IOrderRepository>();
        var exercise = new Part06(orderRepository.Object, []);

        var getOrderTask = Task.FromResult<Order?>(null);
        
        orderRepository.Setup(o => o.GetAsync(orderId)).Returns(getOrderTask).Verifiable();

        // Act

        var result = exercise.Run(orderId, OrderStatus.Dispatched);

        var resultTask = result as Task ?? Task.CompletedTask;
        var awaitResultTask = () => resultTask;
        
        // Assert
        
        orderRepository.Verify();

        var ex = await awaitResultTask.Should().ThrowAsync<OrderNotFoundException>();
        ex.And.Id.Should().Be(orderId);
    }
}