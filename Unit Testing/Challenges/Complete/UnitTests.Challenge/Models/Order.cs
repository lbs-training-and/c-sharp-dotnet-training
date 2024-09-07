namespace UnitTests.Challenge.Models;

public class Order
{
    public int Id { get; set; }
    public decimal TotalPrice { get; set; }
    public OrderStatus Status { get; set; }
}