namespace BurgerBytes.Function.Database.Entities;

public class Extra
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public decimal Price { get; set; }
    
    public required ICollection<Product> Products { get; set; }
}