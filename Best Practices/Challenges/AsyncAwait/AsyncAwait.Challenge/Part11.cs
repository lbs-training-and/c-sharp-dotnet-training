using AsyncAwait.Challenge.Interfaces;
using AsyncAwait.Challenge.Models;
using Microsoft.Extensions.Logging;

namespace AsyncAwait.Challenge;

/// <summary>
/// This part involves concurrently running multiple async methods and handling exceptions.
/// The Run method should:
///     * Send a notification from each INotificationService concurrently.
///     * Await each notification task.
///     * Use a try catch to ensure a faulty notification service doesn't prevent the others from being awaited.
///     * Log an error for any exceptions that are caught. The message can be anything you like, but the log must include the exception.
/// </summary>
public class Part11
{
    private readonly IEnumerable<INotificationService> _notificationServices;
    private readonly ILogger<Part11> _logger;

    public Part11(IEnumerable<INotificationService> notificationServices, ILogger<Part11> logger)
    {
        _notificationServices = notificationServices;
        _logger = logger;
    }

    public async Task Run(Order order)
    {
        var taskList = new List<Task>();

        foreach (var notificationService in _notificationServices)
        {
            taskList.Add(Task.Run(async () =>
            {
                try
                {
                    await notificationService.SendAsync(order);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Message");
                }
            }));
        }

        await Task.WhenAll(taskList);
    }
}