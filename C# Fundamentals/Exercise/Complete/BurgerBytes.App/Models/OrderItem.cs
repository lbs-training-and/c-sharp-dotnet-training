namespace BurgerBytes.App.Models;

public class OrderItem
{
    public int ItemId { get; init; }
    public required string Name { get; init; }
    public decimal UnitPrice { get; init; }
    public decimal TotalPrice { get; set; }
    public int Quantity { get; set; }
}