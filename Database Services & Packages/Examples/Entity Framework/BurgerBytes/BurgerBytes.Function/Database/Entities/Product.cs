namespace BurgerBytes.Function.Database.Entities;

public class Product
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public decimal Price { get; set; }
    
    public required ICollection<Extra> Extras { get; set; }
    public required ICollection<OrderProduct> ProductOrders { get; set; }
}