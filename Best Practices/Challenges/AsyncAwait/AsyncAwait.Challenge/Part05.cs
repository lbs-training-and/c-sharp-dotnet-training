using AsyncAwait.Challenge.Exceptions;
using AsyncAwait.Challenge.Interfaces;
using AsyncAwait.Challenge.Models;

namespace AsyncAwait.Challenge;

/// <summary>
/// This part involves awaiting multiple async methods and throwing an exception.
/// The Run method should:
///     * Like previous parts, update the method signature to handle scenario.
///     * Call the IOrderRepository.GetAsync() method.
///     * If the order is null, throw a OrderNotFoundException.
///     * If the order is not null, call the IOrderRepository.DeleteAsync() method.
/// </summary>
public class Part05
{
    private readonly IOrderRepository _orderRepository;

    public Part05(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task Run(int id)
    {
        var orderResult = await _orderRepository.GetAsync(id);
        if (orderResult is null)
        {
            throw new OrderNotFoundException(id);
        }

        await _orderRepository.DeleteAsync(orderResult);
    }
}