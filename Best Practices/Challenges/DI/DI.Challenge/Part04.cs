namespace DI.Challenge;

/// <summary>
/// This part involves registering multiple implementations for a type.
/// The registration should:
///     * Register the FaxNotificationService, SmsNotificationService and EmailNotificationService services.
///     * Use the INotificationService as the abstraction.
///     * Use singleton as the lifetime.
/// </summary>
public static partial class ServiceCollectionExtensions
{
    public static void AddPart04(this IServiceCollection serviceCollection)
    {
        // Add services here.
    }
}