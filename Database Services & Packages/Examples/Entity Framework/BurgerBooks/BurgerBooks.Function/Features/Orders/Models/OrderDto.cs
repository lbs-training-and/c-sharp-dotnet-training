namespace BurgerBooks.Function.Features.Orders.Models;

public class OrderDto
{
    public int Id { get; set; }
    public decimal TotalPrice { get; set; }
    
    public required AddressDto BillingAddress { get; set; }
    public AddressDto? ShippingAddress { get; set; }
    
    public required IReadOnlyCollection<OrderBookDto> OrderBooks { get; set; }

}