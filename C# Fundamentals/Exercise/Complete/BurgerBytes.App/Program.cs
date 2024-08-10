using BurgerBytes.App.Currency;
using BurgerBytes.App.Input;
using BurgerBytes.App.Items;
using BurgerBytes.App.Navigation;
using BurgerBytes.App.Orders;
using BurgerBytes.App.Output;
using BurgerBytes.App.Receipts;
using BurgerBytes.App.Selectors;

namespace BurgerBytes.App;

public class Program
{
    public static void Main(string[] args)
    {
        var menu = new Menu();
        var currencyProvider = new CurrencyProvider();
        var orderManager = new OrderManager();
        
        var outputHandler = new ConsoleOutputHandler();
        var inputHandler = new ConsoleInputHandler(outputHandler);

        var intSelector = new IntSelector(inputHandler, outputHandler);
        var decimalSelector = new DecimalSelector(inputHandler, outputHandler);
        
        var navigationOptionSelector = new NavigationOptionSelector(inputHandler, outputHandler, intSelector);
        
        var itemSelector = new ItemSelector(outputHandler, intSelector);

        var receiptPrinter = new OutputReceiptPrinter(outputHandler, currencyProvider);
        
        var orderItemsProcess = new OrderItemsProcess(menu, itemSelector, inputHandler);
        var orderProcess = new OrderProcess(intSelector, decimalSelector, currencyProvider, orderItemsProcess);
        var orderViewer = new OrderViewer(outputHandler, receiptPrinter, intSelector);
            
        
        var navigationOptions = new INavigationOption[]
        {
            new CreateOrderNavigationOption(inputHandler, orderManager, orderProcess, receiptPrinter),
            new ViewOrdersNavigationOptions(inputHandler, outputHandler, orderManager, orderViewer)
        };
        
        var navigator = new Navigator(navigationOptionSelector, navigationOptions);
        
        navigator.Navigate();
    }
}