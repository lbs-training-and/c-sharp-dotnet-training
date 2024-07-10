using Refactoring.Challenge.Interfaces;
using Refactoring.Challenge.Models;

namespace Refactoring.Challenge;

/// <summary>
/// This part involves refactoring a nested if statement.
/// The Run method should:
///     * Be refactored to use a simpler solution.
///     * Not break the existing test.
/// </summary>
public class Part07
{
    private readonly INotificationService _notificationService;

    public Part07(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    public async Task Run(Order order)
    {
        if (order.Status != OrderStatus.Pending)
        {
            if (order.Status != OrderStatus.Confirmed)
            {
                if (order.Status != OrderStatus.Dispatched)
                {
                    if (order.Status != OrderStatus.Delayed)
                    {
                        if (order.Status != OrderStatus.Delivered)
                        {
                            if (order.Status != OrderStatus.Cancelled)
                            {
                                throw new InvalidOperationException();
                            }
                            else
                            {
                                await _notificationService.SendCancelled();
                            }
                        }
                        else
                        {
                            await _notificationService.SendDelivered();
                        }
                    }
                    else
                    {
                        await _notificationService.SendDelayed();
                    }
                }
                else
                {
                    await _notificationService.SendDispatched();
                }
            }
            else
            {
                await _notificationService.SendConfirmed();
            }
        }
        else
        {
            await _notificationService.SendPending();
        }
    }
}