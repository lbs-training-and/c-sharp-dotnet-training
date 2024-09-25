namespace BurgerBooks.Function.Features.Books.Models;

public class BookDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public decimal Price { get; set; }
    public DateTime Published { get; set; }
    
    public int GenreId { get; set; }
    public IReadOnlyCollection<int> AuthorIds { get; set; }
}