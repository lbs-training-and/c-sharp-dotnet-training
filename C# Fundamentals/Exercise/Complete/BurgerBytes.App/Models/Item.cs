namespace BurgerBytes.App.Models;

public class Item
{
    public int Id { get; init; }
    public required string Name { get; init; }
    public decimal Price { get; init; }
}