namespace UnitTesting.Examples.AutoFixtureExamples;

public class Order
{
    public int Id { get; set; }
    public OrderStatus Status { get; set; }
    public ICollection<Product> Products { get; set; }
    public decimal TotalPrice { get; set; }
}