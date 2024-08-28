using BurgerBytes.App.Models;

namespace BurgerBytes.App.Items;

public interface IMenu
{
    IReadOnlyCollection<Item> GetItems();
}