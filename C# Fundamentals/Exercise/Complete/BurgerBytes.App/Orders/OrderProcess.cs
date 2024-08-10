using BurgerBytes.App.Currency;
using BurgerBytes.App.Input;
using BurgerBytes.App.Items;
using BurgerBytes.App.Models;
using BurgerBytes.App.Selectors;

namespace BurgerBytes.App.Orders;

public class OrderProcess : IOrderProcess
{
    private readonly IIntSelector _intSelector;
    private readonly IDecimalSelector _decimalSelector;
    private readonly ICurrencyProvider _currencyProvider;
    private readonly IOrderItemsProcess _orderItemsProcess;

    public OrderProcess(IIntSelector intSelector, IDecimalSelector decimalSelector, ICurrencyProvider currencyProvider, IOrderItemsProcess orderItemsProcess)
    {
        _intSelector = intSelector;
        _decimalSelector = decimalSelector;
        _currencyProvider = currencyProvider;
        _orderItemsProcess = orderItemsProcess;
    }
    
    public Order Create()
    {
        var staffId = _intSelector.Select("Enter staff id", 1, 26);
        var tableNumber = _intSelector.Select("Enter table number", 1, 50);

        var subTotal = 0m;

        var orderItems = _orderItemsProcess.Order();

        foreach (var orderItem in orderItems)
        {
            subTotal += orderItem.TotalPrice;
        }

        var tip = _decimalSelector.Select("Enter a tip", 0, 100, _currencyProvider.Scale);

        var tipAmount = Math.Round(tip / 100 * subTotal, _currencyProvider.Scale);

        var grandTotal = subTotal + tipAmount;
        
        var order = new Order
        {
            OrderItems = orderItems,
            StaffId = staffId,
            TableNumber = tableNumber,
            SubTotal = subTotal,
            Tip = tip,
            TipAmount = tipAmount,
            GrandTotal = grandTotal
        };

        return order;
    }
}