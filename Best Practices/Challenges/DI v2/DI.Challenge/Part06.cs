namespace DI.Challenge;

/// <summary>
/// This part involves taking a dependency.
/// The registration should:
///     * Register the ConsumerService using the IConsumerService type as a transient.
///     * Take a dependency on the ISingletonService, IScopedService and ITransientService through the constructor.
///     * Call each of the service's methods in the DoWork method.
/// </summary>
public static partial class ServiceCollectionExtensions
{
    public static void AddPart06(this IServiceCollection serviceCollection)
    {
        // Add services here.
    }
}

public class ConsumerService : IConsumerService
{
    // Take a dependency here.
    
    public void DoWork(object work)
    {
        // Call do work here.
    }
}

public interface IConsumerService
{
    void DoWork(object work);
}