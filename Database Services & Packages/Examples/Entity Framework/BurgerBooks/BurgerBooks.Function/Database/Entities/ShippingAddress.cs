namespace BurgerBooks.Function.Database.Entities;

public class ShippingAddress
{
    public int Id { get; set; }
    public required string Firstname { get; set; }
    public required string Lastname { get; set; }
    public required string AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public string? AddressLine3 { get; set; }
    public required string City { get; set; }
    public required string Postcode { get; set; }
}