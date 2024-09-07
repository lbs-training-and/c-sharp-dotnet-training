using UnitTests.Challenge.Models;

namespace UnitTests.Challenge.Interfaces
{
    public interface INotificationService
    {
        Task SendNotificationAsync(string message);
        Task SendConfirmedAsync(Order order);
        Task SendAwaitingDispatchedAsync(Order order);
        Task SendDispatchedAsync(Order order);
        Task SendInTransitAsync(Order order);
        Task SendDeliveredAsync(Order order);
        Task SendCancelledAsync(Order order);
    }
}