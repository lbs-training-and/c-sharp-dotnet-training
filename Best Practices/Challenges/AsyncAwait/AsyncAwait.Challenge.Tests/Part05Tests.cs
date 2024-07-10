using AsyncAwait.Challenge.Exceptions;
using AsyncAwait.Challenge.Interfaces;
using AsyncAwait.Challenge.Models;
using AutoFixture.NUnit3;
using FluentAssertions;
using Moq;

namespace AsyncAwait.Challenge.Tests;

[TestFixture]
public class Part05Tests
{
    [Test]
    public void CanReturnCorrectType()
    {
        // Arrange

        var type = typeof(Part05);

        // Act
        
        var runReturnType = type.GetMethod(nameof(Part05.Run))!.ReturnType;
        
        // Assert

        runReturnType.Should().Be(typeof(Task), "The method should return a Task.");
    }
    
    [Test]
    [AutoData]
    public async Task CanDeleteOrder(Order order)
    {
        // Arrange
        
        var orderRepository = new Mock<IOrderRepository>();
        var exercise = new Part05(orderRepository.Object);

        var getOrderTask = Task.FromResult<Order?>(order);
        var deleteOrderTask = Task.Delay(1);
        
        orderRepository.Setup(o => o.GetAsync(order.Id)).Returns(getOrderTask).Verifiable();
        orderRepository.Setup(o => o.DeleteAsync(order)).Returns(deleteOrderTask).Verifiable();

        // Act

        var result = exercise.Run(order.Id);

        var resultTask = result as Task ?? Task.CompletedTask;
        await resultTask;
        
        // Assert
        
        orderRepository.Verify();
        resultTask.Should().NotBe(getOrderTask, "The method should use the await keyword.");
        resultTask.Should().NotBe(deleteOrderTask, "The method should use the await keyword.");
    }
    
    [Test]
    [InlineAutoData]
    public async Task ThrowsOrderNotFoundException(int orderId)
    {
        // Arrange
        
        var orderRepository = new Mock<IOrderRepository>();
        var exercise = new Part05(orderRepository.Object);

        var getOrderTask = Task.FromResult<Order?>(null);
        
        orderRepository.Setup(o => o.GetAsync(orderId)).Returns(getOrderTask).Verifiable();

        // Act

        var result = exercise.Run(orderId);

        var resultTask = result as Task ?? Task.CompletedTask;
        var awaitResultTask = async () => await resultTask;
        
        // Assert
        
        orderRepository.Verify();

        var ex = await awaitResultTask.Should().ThrowAsync<OrderNotFoundException>();
        ex.And.Id.Should().Be(orderId);
    }
}