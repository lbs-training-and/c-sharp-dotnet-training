using BurgerBytes.App.Input;
using BurgerBytes.App.Items;
using BurgerBytes.App.Models;
using BurgerBytes.App.Selectors;

namespace BurgerBytes.App.Orders;

public class OrderItemsProcess : IOrderItemsProcess
{
    
    private readonly IMenu _menu;
    private readonly IItemSelector _itemSelector;
    private readonly IInputHandler _inputHandler;

    public OrderItemsProcess(IMenu menu, IItemSelector itemSelector, IInputHandler inputHandler)
    {
        _menu = menu;
        _itemSelector = itemSelector;
        _inputHandler = inputHandler;
    }
    
    public ICollection<OrderItem> Order()
    {
        var items = _menu.GetItems();
        var orderItems = new List<OrderItem>();
        
        do
        {
            var orderItem = _itemSelector.SelectItem(items);

            var exists = false;

            foreach (var existingOrderItem in orderItems)
            {
                if (orderItem.ItemId != existingOrderItem.ItemId)
                {
                    continue;
                }
                
                existingOrderItem.Quantity += orderItem.Quantity;
                existingOrderItem.TotalPrice += orderItem.TotalPrice;

                exists = true;
                break;
            }

            if (!exists)
            {
                orderItems.Add(orderItem);
            }
            
        } while (_inputHandler.RequestBool("Add another item?"));

        return orderItems;
    }
}