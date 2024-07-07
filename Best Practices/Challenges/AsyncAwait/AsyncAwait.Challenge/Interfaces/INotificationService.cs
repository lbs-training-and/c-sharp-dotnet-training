using AsyncAwait.Challenge.Models;

namespace AsyncAwait.Challenge.Interfaces;

public interface INotificationService
{
    Task SendAsync(Order order);
}