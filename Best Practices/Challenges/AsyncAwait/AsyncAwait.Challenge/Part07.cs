using AsyncAwait.Challenge.Interfaces;
using AsyncAwait.Challenge.Models;
using Microsoft.Extensions.Logging;

namespace AsyncAwait.Challenge;

/// <summary>
/// This part involves awaiting multiple async methods in order and handling exceptions.
/// The Run method should:
///     * Send a notification from each INotificationService and await the completion before invoking the next.
///     * Use a try catch to ensure a faulty notification service doesn't prevent the others from sending
///     * Log an error for any exceptions that are caught. The message can be anything you like, but the log must include the exception.
/// </summary>
public class Part07
{
    private readonly IEnumerable<INotificationService> _notificationServices;
    private readonly ILogger<Part07> _logger;

    public Part07(IEnumerable<INotificationService> notificationServices, ILogger<Part07> logger)
    {
        _notificationServices = notificationServices;
        _logger = logger;
    }

    public object Run(Order order)
    {
        throw new NotImplementedException();
    }
}