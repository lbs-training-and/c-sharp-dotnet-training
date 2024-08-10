using BurgerBytes.App.Input;
using BurgerBytes.App.Models;
using BurgerBytes.App.Navigation;
using BurgerBytes.App.Output;
using BurgerBytes.App.Receipts;

namespace BurgerBytes.App.Orders;

public class ViewOrdersNavigationOptions : INavigationOption
{
    private readonly IInputHandler _inputHandler;
    private readonly IOutputHandler _outputHandler;
    private readonly IOrderManager _orderManager;
    private readonly IReceiptPrinter _receiptPrinter;

    public ViewOrdersNavigationOptions(
        IInputHandler inputHandler,
        IOutputHandler outputHandler,
        IOrderManager orderManager, 
        IReceiptPrinter receiptPrinter)
    {
        _inputHandler = inputHandler;
        _outputHandler = outputHandler;
        _orderManager = orderManager;
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
            foreach (var order in orders)
            {
                _outputHandler.Write($"[{order.Id}]");
            }
            
            while (true)
            {
                var orderId = _inputHandler.RequestInt("Enter an order's id to view the receipt.");

                Order? selectedOrder = null;

                foreach (var order in orders)
                {
                    if (order.Id == orderId)
                    {
                        selectedOrder = order;
                        break;
                    }
                }

                if (selectedOrder == null)
                {
                    continue;
                }

                _receiptPrinter.Print(selectedOrder);

                break;
            }

        } while (_inputHandler.RequestBool("Do you want to view another order?"));
    }
}