namespace BurgerBytes.UI;

public class Order
{
    public Order()
    {
        OrderId = Guid.NewGuid();
        Items = new List<OrderItem>();
    }
    
    public Guid OrderId { get; init; }
    public string StaffId { get; set; }
    public string TableNumber { get; set; }
    public List<OrderItem> Items { get; set; }
    public int Tip { get; set; }
}