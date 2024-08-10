using BurgerBytes.App.Input;
using BurgerBytes.App.Models;
using BurgerBytes.App.Output;
using BurgerBytes.App.Receipts;

namespace BurgerBytes.App.Orders;

public class OrderViewer : IOrderViewer
{
    private readonly IOutputHandler _outputHandler;
    private readonly IInputHandler _inputHandler;
    private readonly IReceiptPrinter _receiptPrinter;

    public OrderViewer(IOutputHandler outputHandler, IInputHandler inputHandler, IReceiptPrinter receiptPrinter)
    {
        _outputHandler = outputHandler;
        _inputHandler = inputHandler;
        _receiptPrinter = receiptPrinter;
    }
    
    public void View(IReadOnlyCollection<Order> orders)
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
    }
}