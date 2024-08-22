namespace BurgerBytes.App.Models;

public class Order
{
    public int Id { get; set; }
    public int StaffId { get; set; }
    public int TableNumber { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; }
    public decimal SubTotal { get; set; }
    public decimal Tip { get; set; }
    public decimal TipAmount { get; set; }
    public decimal GrandTotal { get; set; }
}