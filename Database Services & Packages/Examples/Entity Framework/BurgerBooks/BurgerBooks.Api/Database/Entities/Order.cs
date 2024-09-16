namespace BurgerBooks.Api.Database.Entities;

public class Order
{
    public int Id { get; set; }
    public decimal TotalPrice { get; set; }
    
    public required BillingAddress BillingAddress { get; set; }
    public required ShippingAddress? ShippingAddress { get; set; }
    
    public required ICollection<OrderBook> OrderBooks { get; set; }
}