using UnitTests.Challenge.Interfaces;
using UnitTests.Challenge.Interfaces.NotificationServices;

namespace UnitTests.Challenge
{
    /// <summary>
    /// This part involves writing tests for part 6, follow the document for more information
    /// </summary>
    public class NotificationWorker
    {
        private const int MaxRetryAttempts = 3;
        private const int RetryDelayMilliseconds = 1;

        private readonly INotificationService _notificationService;

        public NotificationWorker(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public async Task SendNotification(string message)
        {
            int retryCount = 0;
            bool success = false;

            while (retryCount < MaxRetryAttempts && !success)
            {
                try
                {
                    switch (_notificationService)
                    {
                        case IFaxNotificationService faxService:
                            Console.WriteLine("Sending Fax");
                            await faxService.SendNotificationAsync(message);
                            break;
                        case IEmailNotificationService emailService:
                            Console.WriteLine("Sending Email");
                            await emailService.SendNotificationAsync(message);
                            break;
                        case ISMSNotificationService smsService:
                            Console.WriteLine("Sending SMS");
                            await smsService.SendNotificationAsync(message);
                            break;
                        default:
                            throw new InvalidOperationException("Unsupported notification service");
                    }
                    success = true;
                }
                catch (Exception ex)
                {
                    retryCount++;
                    Console.WriteLine($"Attempt {retryCount} failed: {ex.Message}");
                    if (retryCount < MaxRetryAttempts)
                    {
                        Thread.Sleep(RetryDelayMilliseconds);
                    }
                    else
                    {
                        Console.WriteLine("Max retry attempts reached. Notification failed.");
                    }
                }
            }
        }
    }
}
