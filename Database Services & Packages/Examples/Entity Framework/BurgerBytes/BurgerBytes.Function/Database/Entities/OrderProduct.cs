namespace BurgerBytes.Function.Database.Entities;

public class OrderProduct
{
    public int Id { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    
    public required Order Order { get; set; }
    public required Product Product { get; set; }
}