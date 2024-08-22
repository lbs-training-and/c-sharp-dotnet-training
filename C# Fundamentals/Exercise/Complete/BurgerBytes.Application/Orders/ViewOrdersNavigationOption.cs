using BurgerBytes.App.Input;
using BurgerBytes.App.Navigation;
using BurgerBytes.App.Output;
using BurgerBytes.App.Receipts;
using BurgerBytes.App.Selectors;

namespace BurgerBytes.App.Orders;

public class ViewOrdersNavigationOptions : INavigationOption
{
    private readonly IInputHandler _inputHandler;
    private readonly IOutputHandler _outputHandler;
    private readonly IOrderManager _orderManager;
    private readonly IOrderSelector _orderSelector;
    private readonly IReceiptPrinter _receiptPrinter;

    public ViewOrdersNavigationOptions(
        IInputHandler inputHandler,
        IOutputHandler outputHandler,
        IOrderManager orderManager, 
        IOrderSelector orderSelector,
        IReceiptPrinter receiptPrinter)
    {
        _inputHandler = inputHandler;
        _outputHandler = outputHandler;
        _orderManager = orderManager;
        _orderSelector = orderSelector;
        _receiptPrinter = receiptPrinter;
    }

    
    public string DisplayName { get; } = "View Orders";
    
    public void Enter()
    {
        var orders = _orderManager.GetAll();

        if (orders.Count == 0)
        {
            _outputHandler.Write("There are no orders.");
            return;
        }
        
        do
        {
            var order =_orderSelector.Select(orders);
            
            _receiptPrinter.Print(order);

        } while (_inputHandler.RequestBool("Do you want to view another order?"));
    }
}