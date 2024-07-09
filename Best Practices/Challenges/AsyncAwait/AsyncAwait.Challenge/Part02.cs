using AsyncAwait.Challenge.Interfaces;
using AsyncAwait.Challenge.Models;

namespace AsyncAwait.Challenge;

/// <summary>
/// This part involves initiating, but not awaiting an async method.
/// The Run method should:
///     * Return a type of Task.
///     * Return the task from IOrderRepository.SaveAsync() method.
/// </summary>
public class Part02
{
    private readonly IOrderRepository _orderRepository;

    public Part02(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public Task Run(Order order)
    {
        return _orderRepository.SaveAsync(order);
    }
}