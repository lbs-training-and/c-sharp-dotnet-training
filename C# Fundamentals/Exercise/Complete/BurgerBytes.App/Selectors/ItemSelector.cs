using BurgerBytes.App.Input;
using BurgerBytes.App.Items;
using BurgerBytes.App.Models;
using BurgerBytes.App.Output;

namespace BurgerBytes.App.Selectors;

public class ItemSelector : IItemSelector
{
    private readonly IInputHandler _inputHandler;
    private readonly IOutputHandler _outputHandler;

    public ItemSelector(IInputHandler inputHandler, IOutputHandler outputHandler)
    {
        _inputHandler = inputHandler;
        _outputHandler = outputHandler;
    }

    public OrderItem SelectItem(IReadOnlyCollection<Item> items)
    {
        DisplayMenu(items);

        var item = GetItem(items);
        var quantity = SelectQuantity(item);

        var orderItem = new OrderItem
        {
            Name = item.Name,
            UnitPrice = item.Price,
            TotalPrice = item.Price * quantity,
            Quantity = quantity,
            ItemId = item.Id
        };

        return orderItem;
    }

    private void DisplayMenu(IReadOnlyCollection<Item> items)
    {
        for (var i = 0; i < items.Count; i++)
        {
            var item = items.ElementAt(i);

            _outputHandler.Write($"[{i + 1}] | {item.Name}");
        }
    }

    private Item GetItem(IReadOnlyCollection<Item> items)
    {
        while (true)
        {
            var optionId = _inputHandler.RequestInt("Select item.");

            if (optionId <= 0 || optionId > items.Count)
            {
                continue;
            }

            return items.ElementAt(optionId - 1);
        }
    }

    private int SelectQuantity(Item item)
    {
        while (true)
        {
            var quantity = _inputHandler.RequestInt($"Enter {item.Name} quantity.");

            if (quantity > 0)
            {
                return quantity;
            }
            
            _outputHandler.Write("Quantity must be greater than 0.");
        }
    }
}