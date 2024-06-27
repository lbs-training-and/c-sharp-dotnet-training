using DI.Challenge.Services;
using DI.Challenge.Services.Interfaces;

public class Program
{
    public static void Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddSingleton<IScopedService, ScopedService>()
            .AddSingleton<ISingletonService, SingletonService>()
            .AddTransient<ITransientService, TransientService>()
            .BuildServiceProvider();

        var part1 = serviceProvider.GetService<ISingletonService>();
        Console.WriteLine(part1?.DoSingletonStuff());
        
        var part2 = serviceProvider.GetService<ISingletonService>();
        Console.WriteLine(part2?.DoSingletonStuff());
        
    }
}
