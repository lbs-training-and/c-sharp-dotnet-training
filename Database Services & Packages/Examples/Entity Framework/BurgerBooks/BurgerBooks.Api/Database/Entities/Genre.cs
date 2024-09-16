namespace BurgerBooks.Api.Database.Entities;

public class Genre
{
    public int Id { get; set; }
    public required string Name { get; set; }
    
    public required ICollection<Book> Books { get; set; }
}