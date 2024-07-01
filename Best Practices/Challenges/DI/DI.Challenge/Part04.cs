using DI.Challenge.Services.Interfaces;

namespace DI.Challenge
{
    /// <summary>
    /// This part involves registering SingletonA and SingletonB as implementations of ISingletonService.
    /// The class should:
    ///     * Configure dependency injection to register SingletonA and SingletonB.
    ///     * Ensure both SingletonA and SingletonB are registered as singletons.
    /// </summary>
    public class Part04
    {
        public static void NotMain(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    // Register Services Here
                });

    }

    /// <summary>
    /// classes required specifically for this part.
    /// Modification of these components is not necessary.
    /// </summary>
    public class SingletonA : ISingletonService
    {
        public string DoSingletonStuff()
        {
            throw new NotImplementedException();
        }
    }

    public class SingletonB : ISingletonService
    {
        public string DoSingletonStuff()
        {
            throw new NotImplementedException();
        }
    }
}
