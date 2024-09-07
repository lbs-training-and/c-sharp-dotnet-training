using System.Text;
using BurgerBytes.App.Currency;
using BurgerBytes.App.Models;
using BurgerBytes.App.Output;
using Microsoft.Extensions.Logging;

namespace BurgerBytes.App.Receipts;

public class OutputReceiptPrinter : IReceiptPrinter
{
    private readonly IOutputHandler _outputHandler;
    private readonly ICurrencyProvider _currencyProvider;
    private readonly ILogger<OutputReceiptPrinter> _logger;

    public OutputReceiptPrinter(IOutputHandler outputHandler, ICurrencyProvider currencyProvider, ILogger<OutputReceiptPrinter> logger)
    {
        _outputHandler = outputHandler;
        _currencyProvider = currencyProvider;
        _logger = logger;
    }
    
    public void Print(Order order)
    {
        var sb = new StringBuilder();
        
        sb.AppendLine("------------------------------");
        sb.AppendLine("BurgerBytes: Order Receipt");
        sb.AppendLine("------------------------------");
        sb.AppendLine($"Order Id: {order.Id}");
        sb.AppendLine($"Staff Id: {order.StaffId}");
        sb.AppendLine($"Table Number: {order.TableNumber}");
        sb.AppendLine("---");

        foreach (var item in order.OrderItems)
        {
            sb.AppendLine($"{item.Name} x{item.Quantity}: {order.CurrencySymbol}{item.TotalPrice}");
        }
        
        sb.AppendLine("---");
        
        sb.AppendLine($"Sub Total: {order.CurrencySymbol}{order.SubTotal}");
        sb.AppendLine($"Tip: {order.Tip}% @ {order.CurrencySymbol}{order.TipAmount}");
        sb.AppendLine($"Grand Total: {order.CurrencySymbol}{order.GrandTotal}");
        
        sb.AppendLine("------------------------------");
        
        _outputHandler.Write(sb.ToString());
        
        _logger.LogDebug("Printed receipt for order. Order Id: {OrderId}", order.Id);
    }
}