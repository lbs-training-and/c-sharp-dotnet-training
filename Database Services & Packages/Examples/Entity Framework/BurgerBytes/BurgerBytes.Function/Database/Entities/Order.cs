namespace BurgerBytes.Function.Database.Entities;

public class Order
{
    public int Id { get; set; }
    public decimal TotalPrice { get; set; }
    
    public required BillingAddress BillingAddress { get; set; }
    public required DeliveryAddress? ShippingAddress { get; set; }
    
    public required ICollection<OrderProduct> OrderProduct { get; set; }
}