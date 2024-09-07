using AutoFixture;
using FluentAssertions;
using Moq;
using UnitTests.Challenge.Exceptions;
using UnitTests.Challenge.Interfaces;
using UnitTests.Challenge.Models;

namespace UnitTests.Challenge.Tests;

[TestFixture]
public class OrderServiceTestsWithFixtures
{
    [TestCase]
    public async Task CanCreate()
    {
        // Arrange

        var order = new Fixture().Create<Order>();

        var orderRepositoryMock = new Mock<IOrderRepository>();

        orderRepositoryMock.Setup(r => r.SaveAsync(order)).Returns(Task.CompletedTask);

        var orderService = new OrderService(orderRepositoryMock.Object, null!);

        // Act

        await orderService.CreateAsync(order);

        // Assert

        orderRepositoryMock.VerifyAll();
        orderRepositoryMock.VerifyNoOtherCalls();
    }

    [TestCase]
    public async Task CanGet()
    {
        // Arrange

        var expectedOrder = new Fixture().Create<Order>();

        var orderRepositoryMock = new Mock<IOrderRepository>();

        orderRepositoryMock.Setup(r => r.GetAsync(expectedOrder.Id)).ReturnsAsync(expectedOrder);

        var orderService = new OrderService(orderRepositoryMock.Object, null!);

        // Act

        var order = await orderService.GetAsync(expectedOrder.Id);

        // Assert

        order.Should().Be(expectedOrder);
    }

    [TestCase]
    public async Task CanDelete()
    {
        // Arrange

        var expectedOrder = new Fixture().Create<Order>();

        var orderRepositoryMock = new Mock<IOrderRepository>();

        orderRepositoryMock.Setup(r => r.GetAsync(expectedOrder.Id)).ReturnsAsync(expectedOrder);

        var orderService = new OrderService(orderRepositoryMock.Object, null!);

        // Act

        await orderService.DeleteAsync(expectedOrder.Id);

        // Assert

        orderRepositoryMock.Verify(r => r.DeleteAsync(expectedOrder));
    }

    [Test]
    public async Task DeleteHandlesNoOrderWithId()
    {
        // Arrange

        const int id = 5;

        var orderRepositoryMock = new Mock<IOrderRepository>();

        orderRepositoryMock.Setup(r => r.GetAsync(id)).ReturnsAsync(null as Order);

        var orderService = new OrderService(orderRepositoryMock.Object, null!);

        // Act

        await orderService.DeleteAsync(id);

        // Assert

        orderRepositoryMock.VerifyAll();
        orderRepositoryMock.VerifyNoOtherCalls();
    }

    [TestCase]
    public async Task CanUpdateStatus()
    {
        // Arrange

        var fixture = new Fixture();
        fixture.Customize<Order>(c => c.With(o => o.Status, OrderStatus.Confirmed));
        
        var order = new Fixture().Create<Order>();
        const OrderStatus expectedStatus = OrderStatus.Delivered;

        var mockRepository = new MockRepository(MockBehavior.Loose);

        var orderRepositoryMock = mockRepository.Create<IOrderRepository>();
        var notificationHandlerMock = mockRepository.Create<INotificationHandler>();

        orderRepositoryMock.Setup(r => r.GetAsync(order.Id)).ReturnsAsync(order);
        orderRepositoryMock.Setup(r => r.SaveAsync(order)).Returns(Task.CompletedTask);
        notificationHandlerMock.Setup(r => r.SendStatusUpdateAsync(order)).Returns(Task.CompletedTask);

        var orderService = new OrderService(orderRepositoryMock.Object, notificationHandlerMock.Object);

        // Act

        await orderService.UpdateStatusAsync(order.Id, expectedStatus);

        // Assert

        order.Status.Should().Be(expectedStatus);

        mockRepository.VerifyAll();
        mockRepository.VerifyNoOtherCalls();
    }

    [Test]
    public async Task UpdateStatusThrowsNotFoundException()
    {
        // Arrange

        const OrderStatus expectedStatus = OrderStatus.Delivered;

        var mockRepository = new MockRepository(MockBehavior.Loose);

        var orderRepositoryMock = mockRepository.Create<IOrderRepository>();
        var notificationHandlerMock = mockRepository.Create<INotificationHandler>();

        orderRepositoryMock.Setup(r => r.GetAsync(1)).ReturnsAsync(null as Order);

        var orderService = new OrderService(orderRepositoryMock.Object, notificationHandlerMock.Object);

        // Act

        var action = () => orderService.UpdateStatusAsync(1, expectedStatus);

        // Assert

        var ex = await action.Should().ThrowAsync<NotFoundException>();
        ex.WithMessage("No order could be found with the id \"1\".");

        mockRepository.VerifyAll();
        mockRepository.VerifyNoOtherCalls();
    }

    [Test]
    public async Task UpdateStatusHandlesSameStatus()
    {
        // Arrange

        const OrderStatus expectedStatus = OrderStatus.Delivered;
        var fixture = new Fixture();
        fixture.Customize<Order>(c => c.With(o => o.Status, expectedStatus));
        
        var order = fixture.Create<Order>();

        var mockRepository = new MockRepository(MockBehavior.Loose);

        var orderRepositoryMock = mockRepository.Create<IOrderRepository>();
        var notificationHandlerMock = mockRepository.Create<INotificationHandler>();

        orderRepositoryMock.Setup(r => r.GetAsync(order.Id)).ReturnsAsync(order);

        var orderService = new OrderService(orderRepositoryMock.Object, notificationHandlerMock.Object);

        // Act

        await orderService.UpdateStatusAsync(order.Id, expectedStatus);

        // Assert

        order.Status.Should().Be(expectedStatus);

        mockRepository.VerifyAll();
        mockRepository.VerifyNoOtherCalls();
    }
}