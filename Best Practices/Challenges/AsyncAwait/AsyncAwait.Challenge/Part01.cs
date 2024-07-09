using AsyncAwait.Challenge.Interfaces;
using AsyncAwait.Challenge.Models;

namespace AsyncAwait.Challenge;

/// <summary>
/// This part involves initiating and awaiting an async method.
/// The Run method should:
///     * Return a type of Task.
///     * Be marked as async.
///     * Await the IOrderRepository.SaveAsync() method.
/// </summary>
public class Part01
{
    private readonly IOrderRepository _orderRepository;

    public Part01(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task Run(Order order)
    {
        await _orderRepository.SaveAsync(order);
    }
}