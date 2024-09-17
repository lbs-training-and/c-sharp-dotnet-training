namespace BurgerBooks.Function.Features.Orders.Models;

public class OrderBookDto
{
    public int Id { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public int BookId { get; set; }
}