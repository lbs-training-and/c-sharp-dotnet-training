using UnitTests.Challenge.Interfaces;
using UnitTests.Challenge.Models;

namespace UnitTests.Challenge;

public class NotificationHandler : INotificationHandler
{
    private readonly INotificationService _notificationService;

    public NotificationHandler(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    public Task SendStatusUpdateAsync(Order order) => order.Status switch
    {
        OrderStatus.Confirmed => _notificationService.SendConfirmedAsync(order),
        OrderStatus.AwaitingDispatched => _notificationService.SendAwaitingDispatchedAsync(order),
        OrderStatus.Dispatched => _notificationService.SendDispatchedAsync(order),
        OrderStatus.InTransit => _notificationService.SendInTransitAsync(order),
        OrderStatus.Delivered => _notificationService.SendDeliveredAsync(order),
        OrderStatus.Cancelled => _notificationService.SendCancelledAsync(order),
        _ => Task.CompletedTask
    };
}