using BurgerBytes.App.Input;
using BurgerBytes.App.Items;
using BurgerBytes.App.Models;
using BurgerBytes.App.Selectors;
using Microsoft.Extensions.Logging;

namespace BurgerBytes.App.Orders;

public class OrderItemsProcess : IOrderItemsProcess
{
    private readonly IItemSelector _itemSelector;
    private readonly IInputHandler _inputHandler;
    private readonly ILogger<OrderItemsProcess> _logger;

    public OrderItemsProcess(IItemSelector itemSelector, IInputHandler inputHandler, ILogger<OrderItemsProcess> logger)
    {
        _itemSelector = itemSelector;
        _inputHandler = inputHandler;
        _logger = logger;
    }
    
    public ICollection<OrderItem> TakeOrderItems(IReadOnlyCollection<Item> items)
    {
        var orderItems = new Dictionary<int, OrderItem>();
        
        do
        {
            var orderItem = _itemSelector.SelectItem(items);

            if (orderItems.TryGetValue(orderItem.ItemId, out var existingOrderItem))
            {
                existingOrderItem.Quantity += orderItem.Quantity;
                existingOrderItem.TotalPrice += orderItem.TotalPrice;
            }
            else
            {
                orderItems.Add(orderItem.ItemId, orderItem);
            }
            
            _logger.LogDebug("Item selected. Item Id: {ItemId}", orderItem.ItemId);
            
        } while (_inputHandler.RequestBool("Add another item?"));

        return orderItems.Values.ToList();
    }
}