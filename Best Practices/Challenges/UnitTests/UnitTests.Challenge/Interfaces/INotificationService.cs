namespace UnitTests.Challenge.Interfaces
{
    public interface INotificationService
    {
        Task SendNotificationAsync(string message);
    }
}
