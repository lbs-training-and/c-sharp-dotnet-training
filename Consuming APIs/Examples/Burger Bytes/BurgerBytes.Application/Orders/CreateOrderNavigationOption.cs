using BurgerBytes.App.Input;
using BurgerBytes.App.Navigation;
using BurgerBytes.App.Receipts;
using Microsoft.Extensions.Logging;

namespace BurgerBytes.App.Orders;

public class CreateOrderNavigationOption : INavigationOption
{
    private readonly IInputHandler _inputHandler;
    private readonly IOrderManager _orderManager;
    private readonly IOrderProcess _orderProcess;
    private readonly IReceiptPrinter _receiptPrinter;
    private readonly ILogger<CreateOrderNavigationOption> _logger;

    public CreateOrderNavigationOption(
        IInputHandler inputHandler,
        IOrderManager orderManager, 
        IOrderProcess orderProcess,
        IReceiptPrinter receiptPrinter,
        ILogger<CreateOrderNavigationOption> logger)
    {
        _inputHandler = inputHandler;
        _orderManager = orderManager;
        _orderProcess = orderProcess;
        _receiptPrinter = receiptPrinter;
        _logger = logger;
    }

    public string DisplayName => "Create Order";

    public async Task EnterAsync()
    {
        do
        {
            var order = await _orderProcess.TakeOrderAsync();

            _orderManager.Add(order);

            _receiptPrinter.Print(order);
            
            _logger.LogInformation("Order successfully placed. Order Id: {OrderId}", order.Id);

        } while (_inputHandler.RequestBool("Do you want to placed another order?"));
    }
}