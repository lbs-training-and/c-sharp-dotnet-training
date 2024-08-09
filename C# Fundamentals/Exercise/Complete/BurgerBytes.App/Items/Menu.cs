using BurgerBytes.App.Models;

namespace BurgerBytes.App.Items;

public class Menu : IMenu
{
    private readonly IReadOnlyCollection<Item> _items;
    
    public Menu()
    {
        var byteBurger = new Item { Id = 1, Name = "ByteBurger", Price = 5.99m };
        var bitFries = new Item { Id = 2, Name = "BitFries", Price = 1.99m };
        var hashBrown = new Item { Id = 2, Name = "HashBrown", Price = 0.99m };
        var classCola = new Item { Id = 2, Name = "ClassCola", Price = 1.50m };
        var stackShake = new Item { Id = 2, Name = "StackShake", Price = 3.50m };

        _items = new[]
        {
            byteBurger,
            bitFries,
            hashBrown,
            classCola,
            stackShake
        };
    }

    public IReadOnlyCollection<Item> GetItems() => _items;
}