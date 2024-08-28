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
    public static void Main(string[] args)
    {
        IServiceProvider container = new ServiceCollection()
            .AddScoped<IMenu, LiveMenu>()
            .AddSingleton<ICurrencyProvider, CurrencyProvider>()
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
                c.SetMinimumLevel(LogLevel.Information);
                
                c.AddJsonConsole(b =>
                {
                    b.IncludeScopes = true;
                });
            })
            .BuildServiceProvider();
        
        var navigator = container.GetRequiredService<INavigator>();
        
        navigator.Navigate();
    }
}