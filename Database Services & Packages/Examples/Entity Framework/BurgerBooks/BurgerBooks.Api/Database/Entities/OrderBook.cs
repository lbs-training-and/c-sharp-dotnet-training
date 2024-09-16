namespace BurgerBooks.Api.Database.Entities;

public class OrderBook
{
    public int Id { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    
    public required Order Order { get; set; }
    public required Book Book { get; set; }
}