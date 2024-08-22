using BurgerBytes.App.Models;

namespace BurgerBytes.App.Selectors;

public interface IItemSelector
{
    OrderItem SelectItem(IReadOnlyCollection<Item> items);
}