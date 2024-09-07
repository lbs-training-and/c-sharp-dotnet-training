using BurgerBytes.App.Api;
using BurgerBytes.App.Api.Models;
using BurgerBytes.App.Currency;
using BurgerBytes.App.Input;
using BurgerBytes.App.Items;
using BurgerBytes.App.Navigation;
using BurgerBytes.App.Orders;
using BurgerBytes.App.Output;
using BurgerBytes.App.Receipts;
using BurgerBytes.App.Selectors;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RestSharp;

namespace BurgerBytes.App;

public class Program
{
    public static Task Main(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
            .Build();

        IServiceProvider container = new ServiceCollection()
            .AddScoped<IMenu, LiveMenu>()
            .AddSingleton<ICurrencyProvider, ApiCurrencyProvider>()
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
                c.AddFilter(nameof(Microsoft), LogLevel.Warning);
                c.AddFilter(nameof(System), LogLevel.Warning);
                c.AddFilter(nameof(BurgerBytes), LogLevel.Information);

                c.AddJsonConsole(b => { b.IncludeScopes = true; });
            })
            .Configure<BurgerBytesApiSettings>(configuration.GetRequiredSection("BurgerBytesApi"))
            .AddSingleton<IBurgerBytesApiRequestFactory, BurgerBytesApiRequestFactory>()
            .AddSingleton<IBurgerBytesApi, BurgerBytesApi>()
            .AddHttpClient()
            .AddSingleton<IRestClient>(sp => new RestClient(sp.GetRequiredService<HttpClient>()))
            .BuildServiceProvider();

        var logger = container.GetRequiredService<ILogger<Program>>();

        using var _ = logger.BeginScope("Machine Name: {MachineName}", Environment.MachineName);

        logger.LogInformation("Application started.");

        var navigator = container.GetRequiredService<INavigator>();

        return navigator.NavigateAsync();
    }
}