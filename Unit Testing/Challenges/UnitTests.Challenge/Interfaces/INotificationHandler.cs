using UnitTests.Challenge.Models;

namespace UnitTests.Challenge.Interfaces;

public interface INotificationHandler
{
    Task SendStatusUpdateAsync(Order order);
}