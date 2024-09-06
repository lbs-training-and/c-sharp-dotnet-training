using BurgerBytes.App.Currency;
using BurgerBytes.App.Items;
using BurgerBytes.App.Models;
using BurgerBytes.App.Selectors;
using Microsoft.Extensions.DependencyInjection;

namespace BurgerBytes.App.Orders;

public class OrderProcess : IOrderProcess
{
    private readonly IIntSelector _intSelector;
    private readonly IDecimalSelector _decimalSelector;
    private readonly ICurrencyProvider _currencyProvider;
    private readonly IOrderItemsProcess _orderItemsProcess;
    private readonly IServiceProvider _serviceProvider;

    public OrderProcess(
        IIntSelector intSelector,
        IDecimalSelector decimalSelector,
        ICurrencyProvider currencyProvider,
        IOrderItemsProcess orderItemsProcess,
        IServiceProvider serviceProvider)
    {
        _intSelector = intSelector;
        _decimalSelector = decimalSelector;
        _currencyProvider = currencyProvider;
        _orderItemsProcess = orderItemsProcess;
        _serviceProvider = serviceProvider;
    }
    
    public async Task<Order> TakeOrderAsync()
    {
        using var scope = _serviceProvider.CreateScope();

        var menu = scope.ServiceProvider.GetRequiredService<IMenu>();

        var menuItems = await menu.GetItemsAsync();
        var currency = await _currencyProvider.GetAsync();
        
        var staffId = _intSelector.Select("Enter staff id", 1, 26);
        var tableNumber = _intSelector.Select("Enter table number", 1, 50);

        var orderItems = _orderItemsProcess.TakeOrderItems(menuItems);

        var subTotal = orderItems.Sum(orderItem => orderItem.TotalPrice);

        var tip = _decimalSelector.Select("Enter a tip", 0, 100, currency.Scale);

        var tipAmount = Math.Round(tip / 100 * subTotal, currency.Scale);

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