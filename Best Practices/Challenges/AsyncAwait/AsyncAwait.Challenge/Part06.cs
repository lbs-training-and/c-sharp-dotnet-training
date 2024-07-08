using AsyncAwait.Challenge.Enums;
using AsyncAwait.Challenge.Interfaces;

namespace AsyncAwait.Challenge;

/// <summary>
/// This part involves awaiting multiple async methods and throwing an exception.
/// The Run method should:
///     * Like previous parts, update the method signature to handle scenario.
///     * Get the order using the id.
///     * If the order is null, throw a OrderNotFoundException.
///     * If the order is not null:
///       * Update its status to the supplied.
///       * Send a notification from all the INotificationService objects and await the completion before invoking the next.
/// </summary>
public class Part06
{
    private readonly IOrderRepository _orderRepository;
    private readonly IEnumerable<INotificationService> _notificationServices;

    public Part06(IOrderRepository orderRepository, IEnumerable<INotificationService> notificationServices)
    {
        _orderRepository = orderRepository;
        _notificationServices = notificationServices;
    }

    public object Run(int id, OrderStatus orderStatus)
    {
        throw new NotImplementedException();
    }
}