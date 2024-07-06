namespace DI.Challenge;

/// <summary>
/// This part involves taking a dependency.
/// The registration should:
///     * Register the OrderService using the IOrderService type as a scoped lifetime.
///     * Take a dependency on all implementations of INotificationService.
///     * Call INotificationService's SendDispatched method in the Dispatch method.
/// </summary>
public static partial class ServiceCollectionExtensions
{
    public static void AddPart07(this IServiceCollection serviceCollection)
    {
        // Add services here.
    }
}

public class OrderService : IOrderService
{
    // Take a dependency here.
    
    public void Dispatch(Order order)
    {
        // Call send here.
    }
}

public interface IOrderService
{
    void Dispatch(Order order);
}