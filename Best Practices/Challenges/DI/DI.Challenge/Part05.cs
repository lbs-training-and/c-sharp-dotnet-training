namespace DI.Challenge;

/// <summary>
/// This part involves taking a dependency.
/// The registration should:
///     * Register the SingletonConsumerService using the ISingletonConsumerService type as a singleton.
///     * Take a dependency on the ISingletonService through the constructor.
///     * Call the ISingletonService's DoSingletonStuff method in the DoWork method.
/// </summary>
public static partial class ServiceCollectionExtensions
{
    public static void AddPart05(this IServiceCollection serviceCollection)
    {
        // Add services here.
    }
}

public class SingletonConsumerService : ISingletonConsumerService
{
    // Take a dependency here.
    
    public void DoWork(object work)
    {
        // Call do work here.
    }
}

public interface ISingletonConsumerService
{
    void DoWork(object work);
}