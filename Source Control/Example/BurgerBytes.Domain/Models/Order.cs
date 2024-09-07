namespace BurgerBytes.Domain.Models;

public class Order
{
    public int Id { get; set; }
    public ICollection<OrderProduct> OrderProducts { get; set; }
    public decimal TotalPrice { get; set; }
}