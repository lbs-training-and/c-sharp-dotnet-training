namespace Refactoring.Challenge.Interfaces;

public interface INotificationService
{
    Task SendPending();
    Task SendConfirmed();
    Task SendDispatched();
    Task SendDelayed();
    Task SendDelivered();
    Task SendCancelled();
}