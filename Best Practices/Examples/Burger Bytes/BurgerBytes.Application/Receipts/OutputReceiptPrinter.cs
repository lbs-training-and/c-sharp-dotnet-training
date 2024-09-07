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
    
    public async Task PrintAsync(Order order)
    {
        var currency = await _currencyProvider.GetAsync();

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
            sb.AppendLine($"{item.Name} x{item.Quantity}: {currency.Symbol}{item.TotalPrice}");
        }
        
        sb.AppendLine("---");
        
        sb.AppendLine($"Sub Total: {currency.Symbol}{order.SubTotal}");
        sb.AppendLine($"Tip: {order.Tip}% @ {currency.Symbol}{order.TipAmount}");
        sb.AppendLine($"Grand Total: {currency.Symbol}{order.GrandTotal}");
        
        sb.AppendLine("------------------------------");
        
        _outputHandler.Write(sb.ToString());
        
        _logger.LogDebug("Printed receipt for order. Order Id: {OrderId}", order.Id);
    }
}