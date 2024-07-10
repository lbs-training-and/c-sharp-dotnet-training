using FluentAssertions;
using Refactoring.Challenge.Models;

namespace Refactoring.Challenge.Tests;

[TestFixture]
public class Part10Tests
{
    [Test]
    public void CanFilter()
    {
        // Arrange

        var allOrders = new Order[]
        {
            new() { Status = OrderStatus.Dispatched },
            new() { Status = OrderStatus.Dispatched },
            new() { Status = OrderStatus.Cancelled },
            new() { Status = OrderStatus.Dispatched },
            new() { Status = OrderStatus.Dispatched },
        };

        var expectedOrders = allOrders[..2].Concat(allOrders[3..5]);

        var exercise = new Part10();

        // Act

        var orders = exercise.Run(allOrders, OrderStatus.Dispatched, 1, 5);

        // Assert

        orders.Should().BeEquivalentTo(expectedOrders);
    }

    [Test]
    [TestCase(2, 10, 10, 20)]
    [TestCase(1, 5, 0, 5)]
    [TestCase(10, 10, 0, 0)]
    [TestCase(8, 7, 49, 50)]
    public void CanPage(int page, int pageSize, int startIndex, int endIndex)
    {
        // Arrange

        var allOrders = Enumerable.Range(0, 50)
            .Select(i => new Order
            {
                Id = i,
                Created = DateTime.UtcNow.AddSeconds(i),
                Status = OrderStatus.Cancelled
            })
            .ToArray();

        var expectedOrders = allOrders[startIndex..endIndex];

        var exercise = new Part10();

        // Act

        var orders = exercise.Run(allOrders, OrderStatus.Cancelled, page, pageSize);

        // Assert

        orders.Should().BeEquivalentTo(expectedOrders);
    }

    [Test]
    [TestCase(2, 10, 30, 40)]
    [TestCase(1, 5, 45, 50)]
    [TestCase(10, 10, 0, 0)]
    public void CanOrderAscending(int page, int pageSize, int startIndex, int endIndex)
    {
        var allOrders = Enumerable.Range(0, 50)
            .Select(i => new Order
            {
                Id = i,
                Created = DateTime.UtcNow.AddSeconds(i),
                Status = OrderStatus.Cancelled
            })
            .Reverse()
            .ToArray();

        var expectedOrders = allOrders[startIndex..endIndex];

        var exercise = new Part10();

        // Act

        var orders = exercise.Run(allOrders, OrderStatus.Cancelled, page, pageSize);
        
        // Assert

        orders.Should().BeEquivalentTo(expectedOrders);
    }
}