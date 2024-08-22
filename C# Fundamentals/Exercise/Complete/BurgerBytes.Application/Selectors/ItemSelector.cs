using BurgerBytes.App.Models;
using BurgerBytes.App.Output;

namespace BurgerBytes.App.Selectors;

public class ItemSelector : IItemSelector
{
    private readonly IOutputHandler _outputHandler;
    private readonly IIntSelector _intSelector;

    public ItemSelector(IOutputHandler outputHandler, IIntSelector intSelector)
    {
        _outputHandler = outputHandler;
        _intSelector = intSelector;
    }

    public OrderItem SelectItem(IReadOnlyCollection<Item> items)
    {
        DisplayMenu(items);
        
        var optionId = _intSelector.Select("Select item.", 1, items.Count);
        var item = items.ElementAt(optionId - 1);
        
        var quantity = _intSelector.Select($"Enter {item.Name} quantity.", 0, 100);

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
}