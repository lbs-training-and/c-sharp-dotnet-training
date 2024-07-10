using AsyncAwait.Challenge.Enums;

namespace AsyncAwait.Challenge.Models;

public class Order
{
    public int Id { get; set; }
    public OrderStatus Status { get; set; }
}