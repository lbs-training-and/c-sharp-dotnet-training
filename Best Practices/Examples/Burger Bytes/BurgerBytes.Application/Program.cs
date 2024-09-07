using System.Text.Json;
using BurgerBytes.App.Currency;
using BurgerBytes.App.Input;
using BurgerBytes.App.Items;
using BurgerBytes.App.Navigation;
using BurgerBytes.App.Orders;
using BurgerBytes.App.Output;
using BurgerBytes.App.Receipts;
using BurgerBytes.App.Selectors;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BurgerBytes.App;

public class Program
{
    public static Task Main(string[] args)
    {
        IServiceProvider container = new ServiceCollection()
            .AddScoped<IMenu, LiveMenu>()
            .AddSingleton<ICurrencyProvider, GbpCurrencyProvider>()
            .AddSingleton<IOrderManager, OrderManager>()
            .AddSingleton<IOutputHandler, ConsoleOutputHandler>()
            .AddSingleton<IInputHandler, ConsoleInputHandler>()
            .AddSingleton<IIntSelector, IntSelector>()
            .AddSingleton<IDecimalSelector, DecimalSelector>()
            .AddSingleton<INavigationOptionSelector, NavigationOptionSelector>()
            .AddSingleton<IItemSelector, ItemSelector>()
            .AddSingleton<IReceiptPrinter, OutputReceiptPrinter>()
            .AddSingleton<IOrderItemsProcess, OrderItemsProcess>()
            .AddSingleton<IOrderProcess, OrderProcess>()
            .AddSingleton<IOrderSelector, OrderSelector>()
            .AddSingleton<INavigationOption, CreateOrderNavigationOption>()
            .AddSingleton<INavigationOption, ViewOrdersNavigationOptions>()
            .AddSingleton<INavigator, Navigator>()
            .AddSingleton(TimeProvider.System)
            .AddSingleton(Random.Shared)
            .AddLogging(c =>
            {
                c.SetMinimumLevel(LogLevel.Trace);
                
                c.AddJsonConsole(b =>
                {
                    b.IncludeScopes = true;
                });
            })
            .BuildServiceProvider();

        var logger = container.GetRequiredService<ILogger<Program>>();
        
        using var _ = logger.BeginScope("Machine Name: {MachineName}", Environment.MachineName);
        
        logger.LogInformation("Application started.");
        
        var navigator = container.GetRequiredService<INavigator>();
        
        return navigator.NavigateAsync();
    }
}