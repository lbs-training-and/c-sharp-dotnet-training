using AsyncAwait.Challenge.Interfaces;

namespace AsyncAwait.Challenge;

/// <summary>
/// This part involves initiating, awaiting and returning the response from an async method.
/// The Run method should:
///     * Return a type of Task{Order}.
///     * Be marked as async.
///     * Await the IOrderRepository.GetAsync() method.
///     * Return the result of the IOrderRepository.GetAsync() method.
/// </summary>
public class Part03
{
    private readonly IOrderRepository _orderRepository;

    public Part03(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public object Run(int id)
    {
        throw new NotImplementedException();
    }
}