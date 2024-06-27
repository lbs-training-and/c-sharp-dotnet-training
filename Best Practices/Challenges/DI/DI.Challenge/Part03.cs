using DI.Challenge.Services;
using DI.Challenge.Services.Interfaces;

namespace DI.Challenge
{
    /// <summary>
    /// This part involves registering ISingletonService, IScopedService and ITransientService 
    /// with their respective lifetime.
    /// The class should:
    ///     * Register ISingletonService
    ///     * Register IScopedService
    ///     * Register ITransientService
    /// </summary>
    public class Part03
    {
        public static void NotMain(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    services.AddSingleton<ISingletonService, SingletonService>();
                    services.AddScoped<IScopedService, ScopedService>();
                    services.AddTransient<ITransientService, TransientService>();
                });
    }
}