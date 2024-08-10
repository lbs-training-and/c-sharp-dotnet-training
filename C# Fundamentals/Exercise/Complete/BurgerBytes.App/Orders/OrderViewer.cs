using BurgerBytes.App.Input;
using BurgerBytes.App.Models;
using BurgerBytes.App.Output;
using BurgerBytes.App.Receipts;
using BurgerBytes.App.Selectors;

namespace BurgerBytes.App.Orders;

public class OrderViewer : IOrderViewer
{
    private readonly IOutputHandler _outputHandler;
    private readonly IReceiptPrinter _receiptPrinter;
    private readonly IIntSelector _intSelector;

    public OrderViewer(IOutputHandler outputHandler, IReceiptPrinter receiptPrinter, IIntSelector intSelector)
    {
        _outputHandler = outputHandler;
        _receiptPrinter = receiptPrinter;
        _intSelector = intSelector;
    }
    
    public void View(IReadOnlyCollection<Order> orders)
    {
        for (var i = 0; i < orders.Count; i++)
        {
            var order = orders.ElementAt(i);
            
            _outputHandler.Write($"[{i + 1}] | Order Id: {order.Id} | Table Number: {order.TableNumber} | Staff Id: {order.StaffId}");
        }

        var optionId = _intSelector.Select("Select order", 1, orders.Count);

        var selectedOrder = orders.ElementAt(optionId - 1);
        
        _receiptPrinter.Print(selectedOrder);
    }
}