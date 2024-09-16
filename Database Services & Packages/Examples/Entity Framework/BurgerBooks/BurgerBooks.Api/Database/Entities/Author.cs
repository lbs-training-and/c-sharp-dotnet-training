namespace BurgerBooks.Api.Database.Entities;

public class Author
{
    public int Id { get; set; }
    public required string Name { get; set; }
    
    public required ICollection<Book> Books { get; set; }
}