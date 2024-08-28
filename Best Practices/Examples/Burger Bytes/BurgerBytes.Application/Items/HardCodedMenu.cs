using BurgerBytes.App.Models;

namespace BurgerBytes.App.Items;

public class HardCodedMenu : IMenu
{
    private readonly IReadOnlyCollection<Item> _items =
    [
        new() { Id = 1, Name = "ByteBurger", Price = 5.99m },
        new() { Id = 2, Name = "BitFries", Price = 1.99m },
        new() { Id = 3, Name = "HashBrown", Price = 0.99m },
        new() { Id = 4, Name = "ClassCola", Price = 1.50m },
        new() { Id = 5, Name = "StackShake", Price = 3.50m }
    ];

    public IReadOnlyCollection<Item> GetItems()
    {
        return _items;
    } 
}