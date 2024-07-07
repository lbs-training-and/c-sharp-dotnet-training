using AsyncAwait.Challenge.Interfaces;
using AsyncAwait.Challenge.Models;
using AutoFixture.NUnit3;
using FluentAssertions;
using Moq;

namespace AsyncAwait.Challenge.Tests;

[TestFixture]
public class Part01Tests
{
    [Test]
    public void CanReturnCorrectType()
    {
        // Arrange

        var type = typeof(Part01);

        // Act
        
        var runReturnType = type.GetMethod(nameof(Part01.Run))!.ReturnType;
        
        // Assert

        runReturnType.Should().Be(typeof(Task), "The method should return a Task.");
    }
    
    [Test]
    [AutoData]
    public async Task CanSaveOrder(Order order)
    {
        // Arrange
        
        var orderRepository = new Mock<IOrderRepository>();
        var exercise = new Part01(orderRepository.Object);

        var saveOrderTask = Task.Delay(1);
        orderRepository.Setup(o => o.SaveAsync(order)).Returns(saveOrderTask).Verifiable();

        // Act

        var result = exercise.Run(order);

        var resultTask = result as Task ?? Task.CompletedTask;
        await resultTask;
        
        // Assert
        
        orderRepository.Verify();
        resultTask.Should().NotBe(saveOrderTask, "The method should use the await keyword.");
    }
}