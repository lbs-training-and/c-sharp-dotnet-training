using BurgerBytes.App.Input;
using BurgerBytes.App.Navigation;
using BurgerBytes.App.Receipts;

namespace BurgerBytes.App.Orders;

public class CreateOrderNavigationOption : INavigationOption
{
    private readonly IInputHandler _inputHandler;
    private readonly IOrderManager _orderManager;
    private readonly IOrderProcess _orderProcess;
    private readonly IReceiptPrinter _receiptPrinter;

    public CreateOrderNavigationOption(
        IInputHandler inputHandler,
        IOrderManager orderManager, 
        IOrderProcess orderProcess,
        IReceiptPrinter receiptPrinter)
    {
        _inputHandler = inputHandler;
        _orderManager = orderManager;
        _orderProcess = orderProcess;
        _receiptPrinter = receiptPrinter;
    }

    public string DisplayName => "Create Order";

    public void Enter()
    {
        do
        {
            var order = _orderProcess.TakeOrder();

            _orderManager.Add(order);

            _receiptPrinter.Print(order);

        } while (_inputHandler.RequestBool("Do you want to placed another order?"));
    }
}