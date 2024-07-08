using AsyncAwait.Challenge.Interfaces;

namespace AsyncAwait.Challenge;

/// <summary>
/// This part involves initiating, but not awaiting an async method that returns an object.
/// The Run method should:
///     * Return a type of Task{Order}.
///     * Return the task from IOrderRepository.GetAsync() method.
/// </summary>
public class Part04
{
    private readonly IOrderRepository _orderRepository;

    public Part04(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public object Run(int id)
    {
        throw new NotImplementedException();
    }
}