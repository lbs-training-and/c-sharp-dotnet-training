using AsyncAwait.Challenge.Interfaces;
using AsyncAwait.Challenge.Models;
using AutoFixture.NUnit3;
using FluentAssertions;
using Moq;

namespace AsyncAwait.Challenge.Tests;

[TestFixture]
public class Part04Tests
{
    [Test]
    public void CanReturnCorrectType()
    {
        // Arrange

        var type = typeof(Part04);

        // Act
        
        var runReturnType = type.GetMethod(nameof(Part04.Run))!.ReturnType;
        
        // Assert

        runReturnType.Should().Be(typeof(Task<Order?>), "The method should return a Task<Order>.");
    }
    
    [Test]
    [AutoData]
    public async Task CanGetOrder(Order order)
    {
        // Arrange
        
        var orderRepository = new Mock<IOrderRepository>();
        var exercise = new Part04(orderRepository.Object);

        var getOrderTask = Task.FromResult<Order?>(order);
        orderRepository.Setup(o => o.GetAsync(order.Id)).Returns(getOrderTask).Verifiable();

        // Act

        var result = exercise.Run(order.Id);

        var resultTask = result as Task<Order?> ?? Task.FromResult<Order?>(null);
        await resultTask;
        
        // Assert
        
        orderRepository.Verify();
        resultTask.Should().Be(getOrderTask, "The method should not use the await keyword.");
        resultTask.Result.Should().Be(order);
    }
}