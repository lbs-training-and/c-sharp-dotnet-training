namespace BurgerBooks.Function.Database.Entities;

public class Book
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public decimal Price { get; set; }
    public DateTime Published { get; set; }
    
    public required Genre Genre { get; set; }
    public required ICollection<Author> Authors { get; set; }
    public required ICollection<OrderBook> BookOrders { get; set; }
}