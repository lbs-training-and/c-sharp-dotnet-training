using AsyncAwait.Challenge.Enums;
using AsyncAwait.Challenge.Exceptions;
using AsyncAwait.Challenge.Interfaces;
using AsyncAwait.Challenge.Models;
using Microsoft.Extensions.Logging;

namespace AsyncAwait.Challenge;

/// <summary>
/// This part involves concurrently running two async methods.
/// The Run method should:
///     * Send a notification from each INotificationService concurrently.
///     * Await the completion of each notification.
/// </summary>
public class Part08
{
    private readonly INotificationService _notificationService1;
    private readonly INotificationService _notificationService2;

    public Part08(INotificationService notificationService1, INotificationService notificationService2)
    {
        _notificationService1 = notificationService1;
        _notificationService2 = notificationService2;
    }

    public async Task Run(Order order)
    {
        //var task1 = _notificationService1.SendAsync(order);
        //var task2 = _notificationService2.SendAsync(order);

        //await Task.WhenAll(task1, task2);

        var tasks = new List<Task>
        {
            _notificationService1.SendAsync(order),
            _notificationService2.SendAsync(order)
        };

        await Task.WhenAll(tasks);
    }
}