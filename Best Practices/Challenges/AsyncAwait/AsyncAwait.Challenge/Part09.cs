using AsyncAwait.Challenge.Enums;
using AsyncAwait.Challenge.Exceptions;
using AsyncAwait.Challenge.Interfaces;
using AsyncAwait.Challenge.Models;
using Microsoft.Extensions.Logging;

namespace AsyncAwait.Challenge;

/// <summary>
/// This part involves concurrently running multiple async methods.
/// The Run method should:
///     * Send a notification from each INotificationService concurrently.
///     * Await the completion of each notification.
///     * HINT - A method already exists to await all tasks.
/// </summary>
public class Part09
{
    private readonly IEnumerable<INotificationService> _notificationServices;

    public Part09(IEnumerable<INotificationService> notificationServices)
    {
        _notificationServices = notificationServices;
    }

    public object Run(Order order)
    {
        throw new NotImplementedException();
    }
}