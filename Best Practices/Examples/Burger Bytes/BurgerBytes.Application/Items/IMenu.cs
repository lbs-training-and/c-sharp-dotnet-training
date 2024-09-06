using BurgerBytes.App.Models;

namespace BurgerBytes.App.Items;

public interface IMenu
{
    Task<IReadOnlyCollection<Item>> GetItemsAsync();
}