using UnitTests.Challenge.Exceptions;
using UnitTests.Challenge.Interfaces;
using UnitTests.Challenge.Models;

namespace UnitTests.Challenge;

public class OrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly INotificationHandler _notificationHandler;

    public OrderService(IOrderRepository orderRepository, INotificationHandler notificationHandler)
    {
        _orderRepository = orderRepository;
        _notificationHandler = notificationHandler;
    }

    public Task CreateAsync(Order order) => _orderRepository.SaveAsync(order);
    
    public Task<Order?> GetAsync(int id) => _orderRepository.GetAsync(id);

    public async Task DeleteAsync(int id)
    {
        var order = await _orderRepository.GetAsync(id);

        if (order is null)
        {
            return;
        }

        await _orderRepository.DeleteAsync(order);
    }

    public async Task UpdateStatusAsync(int id, OrderStatus orderStatus)
    {
        var order = await _orderRepository.GetAsync(id);

        if (order is null)
        {
            throw new NotFoundException($"No order could be found with the id \"{id}\".");
        }

        if (order.Status == orderStatus)
        {
            return;
        }

        order.Status = orderStatus;

        await _orderRepository.SaveAsync(order);
        await _notificationHandler.SendStatusUpdateAsync(order);
    }
}
