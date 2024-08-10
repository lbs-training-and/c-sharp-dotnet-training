using BurgerBytes.App.Currency;
using BurgerBytes.App.Models;
using BurgerBytes.App.Output;

namespace BurgerBytes.App.Receipts;

public class OutputReceiptPrinter : IReceiptPrinter
{
    private readonly IOutputHandler _outputHandler;
    private readonly ICurrencyProvider _currencyProvider;

    public OutputReceiptPrinter(IOutputHandler outputHandler, ICurrencyProvider currencyProvider)
    {
        _outputHandler = outputHandler;
        _currencyProvider = currencyProvider;
    }
    
    public void Print(Order order)
    {
        var currencySymbol = _currencyProvider.Symbol;
        
        _outputHandler.Write("------------------------------");
        _outputHandler.Write("BurgerBytes: Order Receipt");
        _outputHandler.Write("------------------------------");
        _outputHandler.Write($"Order Id: {order.Id}");
        _outputHandler.Write($"Staff Id: {order.StaffId}");
        _outputHandler.Write($"Table Number: {order.TableNumber}");
        _outputHandler.Write("---");

        foreach (var item in order.OrderItems)
        {
            _outputHandler.Write($"{item.Name} x{item.Quantity}: {currencySymbol}{item.TotalPrice}");
        }
        
        _outputHandler.Write("---");
        
        _outputHandler.Write($"Sub Total: {currencySymbol}{order.SubTotal}");
        _outputHandler.Write($"Tip: {order.Tip}% @ {currencySymbol}{order.TipAmount}");
        _outputHandler.Write($"Grand Total: {currencySymbol}{order.GrandTotal}");
        
        _outputHandler.Write("------------------------------");
    }
}