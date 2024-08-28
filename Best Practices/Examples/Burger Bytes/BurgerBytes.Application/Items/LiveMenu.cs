using BurgerBytes.App.Models;

namespace BurgerBytes.App.Items;

public class LiveMenu : IMenu
{
    private readonly IReadOnlyCollection<Item> _items;

    public LiveMenu(Random random)
    {
        var basePrice = random.Next(1, 10);
        
        _items = new Item[]
        {
            new() { Id = 1, Name = "ByteBurger", Price = basePrice + 5.99m },
            new() { Id = 2, Name = "BitFries", Price = basePrice + 1.99m },
            new() { Id = 3, Name = "HashBrown", Price = basePrice + 0.99m },
            new() { Id = 4, Name = "ClassCola", Price = basePrice + 1.50m },
            new() { Id = 5, Name = "StackShake", Price = basePrice + 3.50m }
        };
    }

    public IReadOnlyCollection<Item> GetItems() => _items;
}