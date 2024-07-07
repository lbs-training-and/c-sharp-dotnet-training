using AsyncAwait.Challenge.Interfaces;
using AsyncAwait.Challenge.Models;
using AutoFixture.NUnit3;
using FluentAssertions;
using Moq;

namespace AsyncAwait.Challenge.Tests;

[TestFixture]
public class Part03Tests
{
    [Test]
    public void CanReturnCorrectType()
    {
        // Arrange

        var type = typeof(Part03);

        // Act
        
        var runReturnType = type.GetMethod(nameof(Part03.Run))!.ReturnType;
        
        // Assert

        runReturnType.Should().Be(typeof(Task<Order?>), "The method should return a Task.");
    }
    
    [Test]
    [AutoData]
    public async Task CanGetOrder(Order order)
    {
        // Arrange
        
        var orderRepository = new Mock<IOrderRepository>();
        var exercise = new Part03(orderRepository.Object);

        var getOrderTask = Task.FromResult<Order?>(order);
        orderRepository.Setup(o => o.GetAsync(order.Id)).Returns(getOrderTask).Verifiable();

        // Act

        var result = exercise.Run(order.Id);

        var resultTask = result as Task<Order?> ?? Task.FromResult<Order?>(null);
        await resultTask;
        
        // Assert
        
        orderRepository.Verify();
        resultTask.Should().NotBe(getOrderTask, "The method should use the await keyword.");
        resultTask.Result.Should().Be(order);
    }
}