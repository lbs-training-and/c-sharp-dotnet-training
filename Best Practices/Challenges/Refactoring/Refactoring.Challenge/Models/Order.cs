namespace Refactoring.Challenge.Models;

public class Order
{
    public int Id { get; set; }
    public OrderStatus Status { get; set; }
    public DateTime Created { get; set; }
}