using AsyncAwait.Challenge.Interfaces;
using AsyncAwait.Challenge.Models;
using AutoFixture.NUnit3;
using FluentAssertions;
using Moq;

namespace AsyncAwait.Challenge.Tests;

[TestFixture]
public class Part02Tests
{
    [Test]
    public void CanReturnCorrectType()
    {
        // Arrange

        var type = typeof(Part02);

        // Act
        
        var runReturnType = type.GetMethod(nameof(Part02.Run))!.ReturnType;
        
        // Assert

        runReturnType.Should().Be(typeof(Task), "The method should return a Task.");
    }
    
    [Test]
    [AutoData]
    public async Task CanSaveOrder(Order order)
    {
        // Arrange
        
        var orderRepository = new Mock<IOrderRepository>();
        var exercise = new Part02(orderRepository.Object);

        var saveOrderTask = Task.Delay(1);
        orderRepository.Setup(o => o.SaveAsync(order)).Returns(saveOrderTask).Verifiable();

        // Act

        var result = exercise.Run(order);

        var resultTask = result as Task ?? Task.CompletedTask;
        await resultTask;
        
        // Assert
        
        orderRepository.Verify();
        resultTask.Should().Be(saveOrderTask, "The method should not use the await keyword.");
    }
}